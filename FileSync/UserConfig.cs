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
        remoteFolder,
        fileFilter,
        isUsed

}
    
    public partial class UserConfig : Form
    {
        
        public struct ConfigChangeInfo
        {
            public string changInfo;
            public ConfigChangeType changeType;
            public int configrationGroupIndex;

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
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_userName.Text;
            configChangeInfo.changeType = ConfigChangeType.userName;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_passWord_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_passWord.Text;
            configChangeInfo.changeType = ConfigChangeType.passWord;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void textBox_localFolder_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_localFolder.Text;
            configChangeInfo.changeType = ConfigChangeType.localFolder;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender,configChangeInfo);
        }

        private void textBox_remoteFolder_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changInfo = textBox_remoteFolder.Text;
            configChangeInfo.changeType = ConfigChangeType.remoteFolder;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
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

        private void textBox_fileFilter_TextChanged(object sender, EventArgs e)
        {
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            // use the is to cast the sender
            if (sender is TextBox textBox)
            {
                configChangeInfo.changInfo = textBox.Text;
            }
            configChangeInfo.changeType = ConfigChangeType.fileFilter;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender, configChangeInfo);
        }

        private void comboBox_Configuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Configuration.SelectedIndex >= 0 && _currentUsedConfigurationIndex != comboBox_Configuration.SelectedIndex)
            {
                _currentUsedConfigurationIndex = comboBox_Configuration.SelectedIndex;
                updateConfiguration(sender,userConfigList[_currentUsedConfigurationIndex]);
            }

        }
        private void updateConfiguration(object sender,ConfigInfo configInfo)
        {
            textBox_serverAddress.Text = configInfo.serverAddress;
            textBox_userName.Text = configInfo.userName;
            textBox_passWord.Text = Base64Helper.Base64Dncode(configInfo.passWord);
            textBox_localFolder.Text = configInfo.localFolder;
            textBox_remoteFolder.Text = configInfo.remoteFolder;
            textBox_fileFilter.Text = configInfo.fileFilter;
            ConfigChangeInfo configChangeInfo = new ConfigChangeInfo();
            configChangeInfo.changeType = ConfigChangeType.isUsed;
            configChangeInfo.configrationGroupIndex = _currentUsedConfigurationIndex;
            configChanged?.Invoke(sender, configChangeInfo);

        }
        public List<ConfigInfo> userConfigList { get; set; }
        private int _currentUsedConfigurationIndex { get; set; }
        public class ConfigInfo
        {
            public string configrationName { get; set; }
            public string serverAddress { get; set; } 
            public string userName { get; set; }
            public string passWord { get; set; }
            public string localFolder { get; set; }
            public string fileFilter { get; set; }
            public string remoteFolder { get; set; }
            public bool isUsed { get; set; }
            
        }
    }
}
