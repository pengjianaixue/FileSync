namespace FileSync
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.globalFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FileChangeGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpLoad = new System.Windows.Forms.DataGridViewButtonColumn();
            this.igroneThisTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_background = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_backgroud = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileChangeGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip_backgroud.SuspendLayout();
            this.SuspendLayout();
            // 
            // globalFlowLayoutPanel
            // 
            this.globalFlowLayoutPanel.AutoScroll = true;
            this.globalFlowLayoutPanel.AutoSize = true;
            this.globalFlowLayoutPanel.Controls.Add(this.FileChangeGridView);
            this.globalFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.globalFlowLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.globalFlowLayoutPanel.Name = "globalFlowLayoutPanel";
            this.globalFlowLayoutPanel.Size = new System.Drawing.Size(1074, 390);
            this.globalFlowLayoutPanel.TabIndex = 1;
            // 
            // FileChangeGridView
            // 
            this.FileChangeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FileChangeGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FileChangeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileChangeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.ChangeTime,
            this.ChangeType,
            this.UpLoad,
            this.igroneThisTime});
            this.FileChangeGridView.Location = new System.Drawing.Point(3, 3);
            this.FileChangeGridView.Name = "FileChangeGridView";
            this.FileChangeGridView.RowHeadersWidth = 50;
            this.FileChangeGridView.RowTemplate.Height = 35;
            this.FileChangeGridView.Size = new System.Drawing.Size(1059, 375);
            this.FileChangeGridView.TabIndex = 0;
            this.FileChangeGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileChangeGridView_CellContentClick);
            // 
            // FileName
            // 
            this.FileName.FillWeight = 21.16487F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // ChangeTime
            // 
            this.ChangeTime.FillWeight = 21.16487F;
            this.ChangeTime.HeaderText = "Change Time";
            this.ChangeTime.Name = "ChangeTime";
            this.ChangeTime.ReadOnly = true;
            // 
            // ChangeType
            // 
            this.ChangeType.FillWeight = 21.16487F;
            this.ChangeType.HeaderText = "Change Type";
            this.ChangeType.Name = "ChangeType";
            this.ChangeType.ReadOnly = true;
            // 
            // UpLoad
            // 
            this.UpLoad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UpLoad.HeaderText = "Up Load";
            this.UpLoad.Name = "UpLoad";
            this.UpLoad.Text = "UpLoad";
            this.UpLoad.ToolTipText = "UpLoad this file to server";
            this.UpLoad.UseColumnTextForButtonValue = true;
            this.UpLoad.Width = 53;
            // 
            // igroneThisTime
            // 
            this.igroneThisTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.igroneThisTime.HeaderText = "Ignore";
            this.igroneThisTime.Name = "igroneThisTime";
            this.igroneThisTime.Text = "Ignore";
            this.igroneThisTime.ToolTipText = "Ignore this file change";
            this.igroneThisTime.UseColumnTextForButtonValue = true;
            this.igroneThisTime.Width = 47;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.syncFolderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // syncFolderToolStripMenuItem
            // 
            this.syncFolderToolStripMenuItem.Name = "syncFolderToolStripMenuItem";
            this.syncFolderToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.syncFolderToolStripMenuItem.Text = "Sync folder";
            // 
            // notifyIcon_background
            // 
            this.notifyIcon_background.ContextMenuStrip = this.contextMenuStrip_backgroud;
            this.notifyIcon_background.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_background.Icon")));
            this.notifyIcon_background.Text = "notifyIcon_backgroud";
            this.notifyIcon_background.Visible = true;
            this.notifyIcon_background.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_background_MouseDoubleClick);
            // 
            // contextMenuStrip_backgroud
            // 
            this.contextMenuStrip_backgroud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip_backgroud.Name = "contextMenuStrip_backgroud";
            this.contextMenuStrip_backgroud.Size = new System.Drawing.Size(97, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1074, 415);
            this.Controls.Add(this.globalFlowLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FileSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.globalFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileChangeGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip_backgroud.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel globalFlowLayoutPanel;
        private System.Windows.Forms.DataGridView FileChangeGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeType;
        private System.Windows.Forms.DataGridViewButtonColumn UpLoad;
        private System.Windows.Forms.DataGridViewButtonColumn igroneThisTime;
        private System.Windows.Forms.NotifyIcon notifyIcon_background;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_backgroud;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

