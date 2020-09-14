﻿using System;
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
        private void findWSLBash()
        {
            wlsBashPath = Environment.CurrentDirectory+ "\\bash.exe";
            if (File.Exists(wlsBashPath))
            {
                isFindWSLBash = true;
                wlsBashPath = "bash.exe";//"\"" + wlsBashPath + "\"";
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
                    _serverAddress = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.serverAddress.ToString(), _serverAddress, _configFileName);
                    break;
                case ConfigChangeType.userName:
                    _userName = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.userName.ToString(), _userName, _configFileName);
                    break;
                case ConfigChangeType.passWord:
                    _userPassWd = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.passWord.ToString(), _userPassWd, _configFileName);
                    break;
                case ConfigChangeType.remoteFolder:
                    _remotePath = configChangeType.changInfo;
                    IniFileOperator.setKeyValue(ConfigChangeType.remoteFolder.ToString(), _remotePath, _configFileName);
                    break;
                case ConfigChangeType.fileFilter:
                    string[] splitchar = new string[] { ";" };
                    _fileFilter = configChangeType.changInfo.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                    IniFileOperator.setKeyValue(ConfigChangeType.fileFilter.ToString(), configChangeType.changInfo, _configFileName);
                    //for (int i = 0; i< _fileFilter.Length;++i)
                    //{
                    //    IniFileOperator.setKeyValue(ConfigChangeType.fileFilter.ToString()+i.ToString(), _fileFilter[i], 
                    //        _configFileName,"FileFilter");
                    //}
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
        private void resizeColumn()
        {
            if (FileChangeGridView.InvokeRequired)
            {
                ActionCall<int> resizeAction = new ActionCall<int>((int a) =>
                {
                    foreach (DataGridViewColumn column in FileChangeGridView.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        break;
                    }
                    return 0;
                });
                this.Invoke(resizeAction, 0);

            }
            else
            {
                
                foreach (DataGridViewColumn column in FileChangeGridView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    break;
                }
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
                FileChangeGridView.Rows[_fileIndexDic[fileChangeInfo.fullPath]].Cells[1].Value = fileChangeInfo.changeTime;
                FileChangeGridView.Rows[_fileIndexDic[fileChangeInfo.fullPath]].Cells[2].Value = fileChangeInfo.changeType.ToString();
            }
            resizeColumn();
            return;

        }
        private void notifyIcon_background_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon_background.Visible = true;
        }
        private void FileWachter_MonitorFileChanged(object sender, FileChangeInfo fileChangeInfo)
        {
            updateFileList(ref fileChangeInfo);

        }
        private void clearView()
        {
            for (int i = 0; i < FileChangeGridView.RowCount; ++i)
            {

                FileChangeGridView.Rows.RemoveAt(i);
            }
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

        private void removeFileItem(DataGridViewCellEventArgs e)
        {
            MethodInvoker mi = new MethodInvoker(() =>
            {
                string fileName = (string)FileChangeGridView.Rows[e.RowIndex].Cells[0].Value;
                _fileIndexDic.Remove(fileName);
                FileChangeGridView.Rows.RemoveAt(e.RowIndex);
            }
            );
            this.BeginInvoke(mi);

        }

        private bool checkDirAndCreate(string remoteFilePath)
        {
            SftpClient sftpClient = new SftpClient(_serverAddress, _userName,_userPassWd);
            sftpClient.Connect();
            if (sftpClient!=null && sftpClient.IsConnected)
            {
                string remotePath  = Path.GetDirectoryName(remoteFilePath).Replace("\\","/");
                if (!sftpClient.Exists(remotePath))
                {
                    string commandInfo = "";
                    try
                    {
                        string mkdirCommand =  string.Format("mkdir -p {0}", remotePath);
                        fileTransfer.executeWSLBashCommand(string.Format( "\"ssh {0}@{1} {2}\"", _userName, _serverAddress, mkdirCommand));
                        if (fileTransfer.processIsFinishedWithSucess(out commandInfo))
                        {
                            return true;
                        }
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(string.Format("Remote path can not create : {0} ,Error info: {1}",
                    remotePath, commandInfo), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                   
                }
                return true;
            }
            return false;
            
        }

        private void uploadFile(DataGridViewCellEventArgs e)
        {
            MethodInvoker mi = new MethodInvoker(() =>
            {
                DataGridViewButtonCell uploadButton =  (DataGridViewButtonCell)FileChangeGridView.Rows[e.RowIndex].Cells[3];//.Value = "Uploading";
                uploadButton.Value = "Uploading";
            });
            BeginInvoke(mi);
            string fullFilePath = FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string[] splitchar = new string[] { ":" };
            string diskPrefix = "";
            string purepath = "";
            string[] pathSplit = fullFilePath.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            if (pathSplit.Length > 1)
            {
                diskPrefix = pathSplit[0].ToLower();
                purepath = pathSplit[1];
            }
            else
            {
                return;
            }
            string pcFilePathToWSLAddress = "/mnt/" + diskPrefix + purepath.Replace("\\", "/");
            string filePath = fullFilePath.Replace(_monitorPath, "").Replace("\\", "/");
            string remoteFilePath = _remotePath + "/" + filePath;
            remoteFilePath = remoteFilePath.Replace("//", "/");
            if (!checkDirAndCreate(remoteFilePath))
            {
                return;
            }
            string rsyncCommand = string.Format("rsync -avzr {0} {1}@{2}:{3}", pcFilePathToWSLAddress, _userName,_serverAddress, remoteFilePath);
            string executeCommand = "\"" + rsyncCommand + "\"";
            fileTransfer.executeWSLBashCommand(executeCommand);
            string runInfo = "";
            if (fileTransfer.processIsFinishedWithSucess(out runInfo))
            {
                removeFileItem(e);
                LogHelper.writeInfoLog(string.Format("Upload File: {0} to {1}, Full Command: {2}", fullFilePath , remoteFilePath, rsyncCommand));
            }
            else
            {
                MessageBox.Show(string.Format("File: {0} Upload Faild! Error info: {1}",
                    FileChangeGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), runInfo), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //"rsync -avL  ./sshd_config   jianpeng@192.168.248.137:/home/jianpeng/workspace";
                    //uploadFile(e);
                    Task.Run(() => uploadFile(e));

                }
                else if (e.ColumnIndex == 4)
                {
                    removeFileItem(e);
                }
            }
        }
        private FileTransfer fileTransfer = new FileTransfer();
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
    }
}
