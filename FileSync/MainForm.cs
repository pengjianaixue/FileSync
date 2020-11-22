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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


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
            _configFileName = Environment.CurrentDirectory + "/config.json";
            configLoad(_configFileName);
            clearView();
            Task.Factory.StartNew(()=>sshChannelCreate());
            // not use 
            fileTransfer.programPath = "";
            

        }

        private void _sftpClient_ErrorOccurred(object sender, Renci.SshNet.Common.ExceptionEventArgs e)
        {
            try
            {
                if (isNeedAutoReconnect)
                {
                    MessageBox.Show(string.Format($"SFTP client Error: {e.Exception.Message}  Do the reconnect action."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sftpClient.Connect();
                    isNeedAutoReconnect = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("SFTP client re-connect error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isNeedAutoReconnect = false;
            }
        }
        private bool sshChannelCreate()
        {
            
            try
            {
	            if (_serverAddress.Length > 0 && _userName.Length > 0 && _userPassWd.Length > 0)
                {
                    _sftpClient = new SftpClient(_serverAddress, _userName, _userPassWd);
                    _sftpClient.Connect();
                    _sftpClient.KeepAliveInterval = new System.TimeSpan(TimeSpan.TicksPerSecond*30);
                    _sftpClient.ErrorOccurred += _sftpClient_ErrorOccurred;
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("sftp connect is failed Error info: {0}, pelase check connect config!", ex.Message), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        private void setCurrentUserConfirationVar(UserConfig.ConfigInfo item)
        {
            string[] splitchar = new string[] { ";" };
            _fileFilter = item.fileFilter.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            _serverAddress = item.serverAddress;
            _userName = item.userName;
            _userPassWd = Base64Helper.Base64Dncode(item.passWord);
            _monitorPath = item.localFolder;
            StartMonitor(_monitorPath);
            _remotePath = item.remoteFolder;
        }

        private void configLoad(string filePath)
        {
            _userconfigList = JsonHelper.JsonConverToList<UserConfig.ConfigInfo>(File.ReadAllText(filePath));
            userConfig.userConfigList = _userconfigList;
            foreach (UserConfig.ConfigInfo item in _userconfigList)
            {
                userConfig.comboBox_Configuration.Items.Add(item.configrationName);
                if (item.isUsed)
                {
                    setCurrentUserConfirationVar(item);
                    userConfig.textBox_fileFilter.Text = item.fileFilter;
                    userConfig.textBox_serverAddress.Text = _serverAddress;
                    userConfig.textBox_localFolder.Text = _monitorPath;
                    userConfig.textBox_passWord.Text = _userPassWd;
                    userConfig.textBox_userName.Text = _userName;
                    userConfig.textBox_remoteFolder.Text = _remotePath;
                    userConfig.comboBox_Configuration.Text = item.configrationName;
                }
                
            }
            
            

        }
        private void recordUserConfigration(string filePath)
        {
            lock (configSaveLocker)
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, _userconfigList);
                }
            }
            

        }

        private void StartMonitor(string path)
        {
            if (path.Length > 0 && Directory.Exists(path))
            {
                fileWachter.startWatchProcess(path);
            }
        }
        private void UserConfig_configChanged(object sender, UserConfig.ConfigChangeInfo configChangeType)
        {
            _userconfigList[_currentConfigUsed].isUsed = false;
            _currentConfigUsed = configChangeType.configrationGroupIndex;
            _userconfigList[_currentConfigUsed].isUsed = true;
            switch (configChangeType.changeType)
            {
                case ConfigChangeType.localFolder:
                    _monitorPath = configChangeType.changInfo;
                    _userconfigList[_currentConfigUsed].localFolder = configChangeType.changInfo;
                    StartMonitor(_monitorPath);
                    break;
                case ConfigChangeType.serverAddress:
                    if (_serverAddress != configChangeType.changInfo)
                    {
                        _serverAddress = configChangeType.changInfo;
                        _userconfigList[_currentConfigUsed].serverAddress = configChangeType.changInfo;
                        connectInfoIsChanged = true;
                    }
                    break;
                case ConfigChangeType.userName:
                    if (_userName != configChangeType.changInfo)
                    {
                        _userName = configChangeType.changInfo;
                        _userconfigList[_currentConfigUsed].userName = configChangeType.changInfo;
                        connectInfoIsChanged = true;
                    }
                    break;
                case ConfigChangeType.passWord:
                    if (_userPassWd != configChangeType.changInfo)
                    {
                        _userPassWd = configChangeType.changInfo;
                        _userconfigList[_currentConfigUsed].passWord = Base64Helper.Base64Encode(configChangeType.changInfo);
                        connectInfoIsChanged = true;
                    }
                    break;
                case ConfigChangeType.remoteFolder:
                    _remotePath = configChangeType.changInfo;
                    _userconfigList[_currentConfigUsed].remoteFolder = configChangeType.changInfo;
                    break;
                case ConfigChangeType.fileFilter:
                    _userconfigList[_currentConfigUsed].remoteFolder = configChangeType.changInfo;
                    string[] splitchar = new string[] { ";" };
                    _fileFilter = configChangeType.changInfo.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case ConfigChangeType.isUsed:
                    setCurrentUserConfirationVar(_userconfigList[_currentConfigUsed]);
                    break;
                default:
                    break;
            }
            Task.Factory.StartNew(()=>recordUserConfigration(_configFileName));
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

        private void removeFileItem(int rowIndex, string specialFileName)
        {
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (rowIndex >= 0)
                {
                    string fileName;
                    
                    if (rowIndex < FileChangeGridView.RowCount)
                    {
                        //Console.WriteLine($"rowIndex: {rowIndex} < FileChangeGridView.RowCount {FileChangeGridView.RowCount}");
                        fileName = FileChangeGridView.Rows[rowIndex].Cells[0].Value.ToString();
                        if (specialFileName == fileName)
                        {
                            FileChangeGridView.Rows.RemoveAt(rowIndex);
                            //Console.WriteLine($"specialFileName: {specialFileName} == fileName {fileName}");
                            _fileIndexDic.Remove(specialFileName);
                            return;
                        }
                    }
                    foreach (DataGridViewRow item in FileChangeGridView.Rows)
                    {

                        fileName = item.Cells[0].Value.ToString();
                        if (fileName == specialFileName)
                        {
                            FileChangeGridView.Rows.Remove(item);
                            _fileIndexDic.Remove(specialFileName);
                            return;
                        }
                    }
                    MessageBox.Show($"removeFileItem Error: the original file index: {rowIndex}  and file:  {specialFileName} remove error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (!sshChannelCreate())
                        {
                            return false;
                        }
                        connectInfoIsChanged = false;

                    }
                }
                if (_sftpClient != null && !_sftpClient.IsConnected)
                {
                    _sftpClient.Connect();
                    isNeedAutoReconnect = true;
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


        private void updateUploadStatusDisplay(int rowIndex, string displayStatus,string fileName="")
        {
            Action<string> mi = new Action<string>((status) =>
            {
                int vaildRowIndex = rowIndex;
                if (fileName.Length > 0)
                {
                    if (FileChangeGridView.Rows[rowIndex].Cells[0].ToString() != fileName)
                    {
                        string currentRowFileName = "";
                        foreach (DataGridViewRow item in FileChangeGridView.Rows)
                        {
                            currentRowFileName = item.Cells[0].Value.ToString();
                            if (fileName == currentRowFileName)
                            {
                                vaildRowIndex = item.Index;
                            }
                        }
                    }
                }
                DataGridViewButtonCell uploadButton = (DataGridViewButtonCell)FileChangeGridView.Rows[vaildRowIndex].Cells[3];
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
                removeFileItem(e.RowIndex, fullFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("File: {0} Download Faild! Error info: {1}",
                    FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isInDownload = false;

        }

        private bool uploadFile(string fullFilePath)
        {
            string filePath = fullFilePath.Replace(_monitorPath, "").Replace("\\", "/");
            string remoteFilePath = _remotePath + "/" + filePath;
            remoteFilePath = remoteFilePath.Replace("//", "/");
            if (!checRemoteResource(remoteFilePath))
            {
                return false;
            }
            try
            {
                using (var stream = File.Open(fullFilePath, FileMode.Open))
                {
                    _sftpClient.UploadFile(stream, remoteFilePath, true);
                }
                return true;
                
            }
            catch (System.Exception ex)
            {
                
                MessageBox.Show(string.Format("File: {0} Upload Faild, Error info: {1}!",
                    fullFilePath, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void uploadFile(DataGridViewCellEventArgs e)
        {
            string fullFilePath = FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateUploadStatusDisplay(e.RowIndex, "Uploading");
            if (!uploadFile(fullFilePath))
            {
                updateUploadStatusDisplay(e.RowIndex, "Upload");
                return;
            }
            removeFileItem(e.RowIndex, fullFilePath);
            return;
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
                    removeFileItem(e.RowIndex, FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }
        private volatile static string downloadingFile = "";
        private volatile static bool isInDownload = false;
        private readonly static object UILockObj = new object();
        private readonly static object sftpLocker = new object();
        private readonly static object  configSaveLocker = new object();
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
        private bool isPause = false;
        private bool connectInfoIsChanged = false;
        private bool isNeedAutoReconnect;
        private List<UserConfig.ConfigInfo> _userconfigList = new List<UserConfig.ConfigInfo>();
        private int _currentConfigUsed;

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

        private void UplaodAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<string> uploadFileList = new List<string>();
            foreach (DataGridViewRow item in FileChangeGridView.Rows)
            {
                if (item.Cells[0].Value.ToString().Length > 0)
                {
                    uploadFileList.Add(item.Cells[0].Value.ToString());
                }
            }
            foreach (string item in uploadFileList)
            {
                Task.Factory.StartNew(() =>
                {
                    updateUploadStatusDisplay(0, "Uploading", item);
                    Console.WriteLine($"Done the Uploading: {item}");
                    if (!uploadFile(item))
                    {
                        updateUploadStatusDisplay(0, "Upload", item);
                        Console.WriteLine($"uploadFile failed: {item}");
                        return;
                    }
                    removeFileItem(0, item);
                    Console.WriteLine($"remove File: {item}");
                    return;
                });
            }
            

        }
    }
}
