using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet.Sftp;
using Renci.SshNet;
using System.Threading;
using Renci;

namespace FileSync
{



    

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            userConfig.configChanged += UserConfig_configChanged;
            userConfig.Hide();
            fileWachter.MonitorFileChanged += FileWachter_MonitorFileChanged;
            _configFileName = Environment.CurrentDirectory + "/config.ini";
            configLoad();
            clearView();
            findWSLBash();
            fileTransfer.programPath = wlsBashPath;
            if (isFindWSLBash)
            {
                fileTransfer.programPath = wlsBashPath;
            }
            else
            {
                MessageBox.Show("WSL bash.exe can not find in the PC!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void _sftpClient_ErrorOccurred(object sender, Renci.SshNet.Common.ExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("SFTP client Error: {0}",e.Exception.Message) , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try
            {
                if (!isReConnectError)
                {
                    _sftpClient.Connect();
                    isReConnectError = false;
                }
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("SFTP client re-connect error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isReConnectError = true;
            }
        }

        private void findWSLBash()
        {
            wlsBashPath = Environment.CurrentDirectory+ "\\bash.exe";
            if (File.Exists(wlsBashPath))
            {
                isFindWSLBash = true;
                wlsBashPath = "bash.exe";//"\"" + wlsBashPath + "\"";
            }
        }

        private void sshChannelCreate()
        {
            
            try
            {
	            if (_serverAddress.Length > 0 && _userName.Length > 0 && _userPassWd.Length > 0)
                {
                    _sftpClient = new SftpClient(_serverAddress, _userName, _userPassWd);
                    _sftpClient.Connect();
                    _sftpClient.ErrorOccurred += _sftpClient_ErrorOccurred;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("sftp connect is failed Error info: {0}, pelase check connect config!", ex.Message), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void configLoad()
        {

            _monitorPath = IniFileOperator.getKeyValue(ConfigChangeType.localFolder.ToString(), _configFileName);
            if (_monitorPath.Length > 0)
            {
                fileWachter.startWatchProcess(_monitorPath);
            }
            _serverAddress = IniFileOperator.getKeyValue(ConfigChangeType.serverAddress.ToString(), _configFileName);
            _userName = IniFileOperator.getKeyValue(ConfigChangeType.userName.ToString(), _configFileName);
            _userPassWd = IniFileOperator.getKeyValue(ConfigChangeType.passWord.ToString(), _configFileName);
            _remotePath = IniFileOperator.getKeyValue(ConfigChangeType.remoteFolder.ToString(), _configFileName);
            string fileFilters =  IniFileOperator.getKeyValue(ConfigChangeType.fileFilter.ToString(), _configFileName);
            string[] splitchar = new string[] { ";" };
            _fileFilter = fileFilters.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            userConfig.textBox_fileFilter.Text = fileFilters;
            userConfig.textBox_serverAddress.Text = _serverAddress;
            userConfig.textBox_localFolder.Text = _monitorPath;
            userConfig.textBox_passWord.Text = _userPassWd;
            userConfig.textBox_userName.Text = _userName;
            userConfig.textBox_remoteFolder.Text = _remotePath;

        }
        private void UserConfig_configChanged(object sender, UserConfig.ConfigChangeInfo configChangeType)
        {
            switch (configChangeType.changeType)
            {
                case ConfigChangeType.localFolder:
                    _monitorPath = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.localFolder.ToString(), _monitorPath, _configFileName);
                    fileWachter.startWatchProcess(_monitorPath);
                    break;
                case ConfigChangeType.serverAddress:
                    if (_serverAddress != configChangeType.changInfo)
                    {
                        _serverAddress = configChangeType.changInfo;
                        IniFileOperator.setKeyValue(ConfigChangeType.serverAddress.ToString(), _serverAddress, _configFileName);
                    }
                    break;
                case ConfigChangeType.userName:
                    if (_userName != configChangeType.changInfo)
                    {
                        _userName = configChangeType.changInfo;
                        connectInfoIsChanged = true;
                        IniFileOperator.setKeyValue(ConfigChangeType.userName.ToString(), _userName, _configFileName);
                    }
                    break;
                case ConfigChangeType.passWord:
                    if (_userPassWd != configChangeType.changInfo)
                    {
                        _userPassWd = configChangeType.changInfo;
                        connectInfoIsChanged = true;
                        IniFileOperator.setKeyValue(ConfigChangeType.passWord.ToString(), _userPassWd, _configFileName);
                    }
                    break;
                case ConfigChangeType.remoteFolder:
                    _remotePath = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.remoteFolder.ToString(), _remotePath, _configFileName);
                    break;
                case ConfigChangeType.fileFilter:
                    string[] splitchar = new string[] { ";" };
                    _fileFilter = configChangeType.changInfo.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                    IniFileOperator.setKeyValue(ConfigChangeType.fileFilter.ToString(), configChangeType.changInfo, _configFileName);
                    break;
                default:
                    break;
            }

        }

        private void addChangedFileRow(ref FileChangeInfo fileChangeInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell fileFullPath = new DataGridViewTextBoxCell();
            fileFullPath.Value = fileChangeInfo.fullPath;
            row.Cells.Add(fileFullPath);
            DataGridViewTextBoxCell changeTime = new DataGridViewTextBoxCell();
            changeTime.Value = fileChangeInfo.changeTime;
            row.Cells.Add(changeTime);
            DataGridViewTextBoxCell changTypeName = new DataGridViewTextBoxCell();
            changTypeName.Value = fileChangeInfo.changeType.ToString();
            row.Cells.Add(changTypeName);
            //DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
            //row.Cells.Add(comboxcell);
            Action<DataGridViewRow> addRowAction = (data) =>
            {
                FileChangeGridView.Rows.Add(data);
            };
            if (FileChangeGridView.InvokeRequired)
            {
                ActionCall<DataGridViewRow> addRow = new ActionCall<DataGridViewRow>( (DataGridViewRow rowData) => { return FileChangeGridView.Rows.Add(rowData); });
                int index =  (int)this.Invoke(addRow, row);
                _fileIndexDic.Add(fileChangeInfo.fullPath, index);
            }
            else
            {
                FileChangeGridView.Rows.Add(row);
            }

        }
        private void resizeColumn(int column)
        {
            if (FileChangeGridView.InvokeRequired)
            {
                ActionCall<int> resizeAction = new ActionCall<int>((int a) =>
                {
                    FileChangeGridView.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    return 0;
                });
                this.Invoke(resizeAction, 0);

            }
            else
            {

                FileChangeGridView.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                return;
            }
        }


        private bool isAttentionFile(ref FileChangeInfo fileChangeInfo)
        {
            string FileName = Path.GetFileName(fileChangeInfo.fullPath);
            foreach (var item in _fileFilter)
            {
                if (FileName.EndsWith(item))
                {
                    return true;
                }
            }
            return false;
        }

        private void updateFileList(ref FileChangeInfo fileChangeInfo)
        {
            if (!isAttentionFile(ref fileChangeInfo))
            {
                return;
            }
            if (!File.Exists(fileChangeInfo.fullPath))
            {
                return;
            }
            if (!_fileIndexDic.ContainsKey(fileChangeInfo.fullPath))
            {
                addChangedFileRow(ref fileChangeInfo);
            }
            else
            {
                if (isInDownload && fileChangeInfo.fullPath == downloadingFile)
                {
                    return;
                }
                FileChangeGridView.Rows[_fileIndexDic[fileChangeInfo.fullPath]].Cells[1].Value = fileChangeInfo.changeTime;
                FileChangeGridView.Rows[_fileIndexDic[fileChangeInfo.fullPath]].Cells[2].Value = fileChangeInfo.changeType.ToString();
            }
            resizeColumn(0);
            return;

        }
        private void FileWachter_MonitorFileChanged(object sender, FileChangeInfo fileChangeInfo)
        {
            updateFileList(ref fileChangeInfo);

        }
        private void clearView()
        {
            FileChangeGridView.Rows.Clear();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userConfig.Show();
        }
        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the sync program?", "Confirm",
               System.Windows.Forms.MessageBoxButtons.YesNo,
               System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void removeFileItem(DataGridViewCellEventArgs e, string specialFileName)
        {
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (e.RowIndex >= 0)
                {
                    string fileName;
                    
                    if (e.RowIndex < FileChangeGridView.RowCount)
                    {
                        fileName = (string)FileChangeGridView.Rows[e.RowIndex].Cells[0].Value;
                        if (specialFileName == fileName)
                        {
                            FileChangeGridView.Rows.RemoveAt(e.RowIndex);
                        }
                        _fileIndexDic.Remove(specialFileName);
                        return;
                    }
                    else
                    {
                        foreach (DataGridViewRow item in FileChangeGridView.Rows)
                        {
                            
                            fileName = (string)item.Cells[0].Value;
                            if (fileName == specialFileName)
                            {
                                FileChangeGridView.Rows.Remove(item);
                                _fileIndexDic.Remove(specialFileName);
                                return;
                            }
                        }
                    }
                    MessageBox.Show($"removeFileItem Error: the original file index: {e.RowIndex}  and file:  {specialFileName} remove error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            );
            lock (UILockObj)
            {
                FileChangeGridView.Invoke(mi);
            }

        }
        private bool checkLocalDirAndCreate(string localFilePath)
        {   

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(localFilePath)))
                {
                    Directory.CreateDirectory(localFilePath);
                    return true;
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        private bool checRemoteResource(string remoteFilePath, bool isPath = true)
        {
            try
            {
                lock (sftpLocker)
                {
                    if (connectInfoIsChanged || _sftpClient == null)
                    {
                        sshChannelCreate();
                        connectInfoIsChanged = false;
                    }
                }
                if (_sftpClient != null && !_sftpClient.IsConnected)
                {
                    _sftpClient.Connect();
                    isReConnectError = false;
                }
                if (_sftpClient != null && _sftpClient.IsConnected)
                {
                    string remotePath = Path.GetDirectoryName(remoteFilePath).Replace("\\", "/");
                    bool dirIsExists = _sftpClient.Exists(remotePath);
                    LogHelper.writeInfoLog(string.Format("remote path: {0} is Exists: {1}", remotePath, dirIsExists));
                    if (dirIsExists)
                    {
                        return true;
                    }
                    if (!dirIsExists && isPath)
                    {
                        try
                        {
                            _sftpClient.CreateDirectory(remotePath);
                            return true;
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show($"Remote file/path can not create : {remotePath} ,Error info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    return false;
                }
                MessageBox.Show(string.Format("Sftp Client is not build,Please check config !"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("Sftp Client occur exception: {0},Please check config !",ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void updateUploadStatusDisplay(DataGridViewCellEventArgs e,string displayStatus)
        {
            Action<string> mi = new Action<string>((status) =>
            {
                DataGridViewButtonCell uploadButton = (DataGridViewButtonCell)FileChangeGridView.Rows[e.RowIndex].Cells[3];//.Value = "Uploading";
                uploadButton.UseColumnTextForButtonValue = false;
                resizeColumn(3);
                uploadButton.Value = status;
            });
            lock (UILockObj)
            {
                LogHelper.writeInfoLog(string.Format("change upload status:{0} !", displayStatus));
                FileChangeGridView.Invoke(mi, displayStatus);
            }
        }
        private void downloadFile(DataGridViewCellEventArgs e)
        {
            //updateUploadStatusDisplay(e, "Downloading");
            isInDownload = true;
            string fullFilePath = FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            downloadingFile = fullFilePath;
            string filePath = fullFilePath.Replace(_monitorPath, "").Replace("\\", "/");
            string remoteFilePath = _remotePath + "/" + filePath;
            remoteFilePath = remoteFilePath.Replace("//", "/");
            try
            {
                if (!checkLocalDirAndCreate(fullFilePath))
                {
                    return;
                }
                if (!checRemoteResource(remoteFilePath, false))
                {
                    return;
                }
                using (var stream = File.Open(fullFilePath, FileMode.OpenOrCreate))
                {
                    _sftpClient.DownloadFile(remoteFilePath, stream);
                }
                removeFileItem(e, fullFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("File: {0} Download Faild! Error info: {1}",
                    FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isInDownload = false;

        }
        private void uploadFile(DataGridViewCellEventArgs e)
        {
            
            updateUploadStatusDisplay(e,"Uploading");
            string fullFilePath = FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string filePath = fullFilePath.Replace(_monitorPath, "").Replace("\\", "/");
            string remoteFilePath = _remotePath + "/" + filePath;
            remoteFilePath = remoteFilePath.Replace("//", "/");
            if (!checRemoteResource(remoteFilePath))
            {
                updateUploadStatusDisplay(e, "Upload");
                return;
            }
            try
            {
                using (var stream = File.Open(fullFilePath, FileMode.Open))
                {
                    _sftpClient.UploadFile(stream, remoteFilePath, true);
                }
                removeFileItem(e, fullFilePath);
            }
            catch (System.Exception ex)
            {
                updateUploadStatusDisplay(e, "Upload");
                MessageBox.Show(string.Format("File: {0} Upload Faild, Error info: {1}!",
                    FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileChangeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < FileChangeGridView.RowCount)
            {
                if (e.ColumnIndex == 3 && 
                    _monitorPath.Length > 0 
                    && _remotePath.Length > 0 
                    && _serverAddress.Length > 0
                    )
                {
                    Task.Factory.StartNew(() => uploadFile(e), TaskCreationOptions.PreferFairness);

                }
                else if (e.ColumnIndex == 4)
                {
                    Task.Factory.StartNew(() => downloadFile(e), TaskCreationOptions.PreferFairness);
                }
                else if (e.ColumnIndex == 5)
                {
                    removeFileItem(e,null);
                }
            }
        }
        private volatile static string downloadingFile = "";
        private volatile static bool isInDownload = false;
        private readonly static object UILockObj = new object();
        private readonly static object sftpLocker = new object();
        private SftpClient _sftpClient ;
        private FileTransfer fileTransfer = new FileTransfer(4);
        private delegate int ActionCall<in T>(T t);
        private string _configFileName = "";
        private string _monitorPath = "";
        private string _serverAddress = "";
        private string _userName = "";
        private string _userPassWd = "";
        private string _remotePath = "";
        private string[] _fileFilter = { };
        private FileWachter fileWachter = new FileWachter();
        private UserConfig userConfig = new UserConfig();
        private List<Tuple<string, string, string>> changedFileList = new List<Tuple<string, string, string>>();
        private Dictionary<string, int> _fileIndexDic = new Dictionary<string, int>();
        private string wlsBashPath;
        private bool isFindWSLBash;
        private bool isPause = false;
        private bool connectInfoIsChanged = false;
        private bool isReConnectError;
        private bool realTimeSyncFlag;
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileIndexDic.Clear();
            clearView();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isPause)
            {
                fileWachter.pauseWatcher();
                toolStripStatusLabel_status.Text = "Monitor is pausing!";
                statusStrip_infoBar.ForeColor = Color.OrangeRed;
                pauseToolStripMenuItem.Text = "Resume Monitor";
                isPause = true;
            }
            else
            {
                fileWachter.resumeWatcher();
                toolStripStatusLabel_status.Text = "";
                pauseToolStripMenuItem.Text = "Pause Monitor";
                isPause = false;
            }

        }

        private void notifyIcon_background_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon_background.Visible = true;
            }
        }

        private void realTimeSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!realTimeSyncFlag)
            {
                realTimeSyncFlag = true;
            }
            else
            {
                realTimeSyncFlag = false;
            }
            
        }
    }
}
