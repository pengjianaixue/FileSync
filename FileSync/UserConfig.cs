using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSync
{
    public enum ConfigChangeType
    {
        localFolder,
        serverAddress,
        userName,
        passWord,
        remoteFolder

    }
    public partial class UserConfig : Form
    {
        
        public struct ConfigChangeInfo
        {
            public string changInfo;
            public ConfigChangeType changeType;

        }
        public UserConfig()
        {
            InitializeComponent();
        }
        public delegate void ConfigChanged(object sender, ConfigChangeInfo configChangeType);

        public event ConfigChanged configChanged;
        private void button_openFolder_Click(object sender, EventArgs e)
        {
            DialogResult res = localFolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox_localFolder.Text = localFolderBrowserDialog.SelectedPath;
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox_serverAddress_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_serverAddress.Text;
            configChangeInfo.changeType = ConfigChangeType.serverAddress;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_userName.Text;
            configChangeInfo.changeType = ConfigChangeType.userName;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_passWord_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_passWord.Text;
            configChangeInfo.changeType = ConfigChangeType.passWord;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_localFolder_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_localFolder.Text;
            configChangeInfo.changeType = ConfigChangeType.localFolder;
            configChanged?.Invoke(sender,configChangeInfo);
        }

        private void textBox_remoteFolder_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_remoteFolder.Text;
            configChangeInfo.changeType = ConfigChangeType.remoteFolder;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void checkBox_hostNameMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hostNameMode.Checked)
            {
                textBox_userName.Enabled = false;
                textBox_passWord.Enabled = false;
            }
            else
            {
                textBox_userName.Enabled = true;
                textBox_passWord.Enabled = true;
            }
        }
    }
}
