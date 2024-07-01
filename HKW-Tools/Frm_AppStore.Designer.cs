namespace HKW_Tools
{
    partial class Frm_AppStore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AppStore));
            this.Show_AppList_ListBox = new System.Windows.Forms.ListBox();
            this.AppInfos_FunsGroupBox = new System.Windows.Forms.GroupBox();
            this.HelpLabel5 = new System.Windows.Forms.Label();
            this.ShowIconBox = new System.Windows.Forms.PictureBox();
            this.Show_AppDescription_TextBox = new System.Windows.Forms.TextBox();
            this.ClickTo_SaveApk_Button = new System.Windows.Forms.Button();
            this.HelpLabel3 = new System.Windows.Forms.Label();
            this.Show_AppVer_TextBox = new System.Windows.Forms.TextBox();
            this.HelpLabel2 = new System.Windows.Forms.Label();
            this.Show_AppName_TextBox = new System.Windows.Forms.TextBox();
            this.HelpLabel1 = new System.Windows.Forms.Label();
            this.ClickTo_InstallSelectedApp_Button = new System.Windows.Forms.Button();
            this.CheckedToSignApp_CheckBox = new System.Windows.Forms.CheckBox();
            this.WebAppStoreLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SelectSaveDirDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.AppInfos_FunsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Show_AppList_ListBox
            // 
            this.Show_AppList_ListBox.FormattingEnabled = true;
            this.Show_AppList_ListBox.ItemHeight = 17;
            this.Show_AppList_ListBox.Location = new System.Drawing.Point(12, 12);
            this.Show_AppList_ListBox.Name = "Show_AppList_ListBox";
            this.Show_AppList_ListBox.Size = new System.Drawing.Size(160, 310);
            this.Show_AppList_ListBox.TabIndex = 0;
            this.Show_AppList_ListBox.SelectedIndexChanged += new System.EventHandler(this.Show_AppList_ListBox_SelectedIndexChanged);
            // 
            // AppInfos_FunsGroupBox
            // 
            this.AppInfos_FunsGroupBox.Controls.Add(this.HelpLabel5);
            this.AppInfos_FunsGroupBox.Controls.Add(this.ShowIconBox);
            this.AppInfos_FunsGroupBox.Controls.Add(this.Show_AppDescription_TextBox);
            this.AppInfos_FunsGroupBox.Controls.Add(this.ClickTo_SaveApk_Button);
            this.AppInfos_FunsGroupBox.Controls.Add(this.HelpLabel3);
            this.AppInfos_FunsGroupBox.Controls.Add(this.Show_AppVer_TextBox);
            this.AppInfos_FunsGroupBox.Controls.Add(this.HelpLabel2);
            this.AppInfos_FunsGroupBox.Controls.Add(this.Show_AppName_TextBox);
            this.AppInfos_FunsGroupBox.Controls.Add(this.HelpLabel1);
            this.AppInfos_FunsGroupBox.Location = new System.Drawing.Point(178, 13);
            this.AppInfos_FunsGroupBox.Name = "AppInfos_FunsGroupBox";
            this.AppInfos_FunsGroupBox.Size = new System.Drawing.Size(209, 293);
            this.AppInfos_FunsGroupBox.TabIndex = 1;
            this.AppInfos_FunsGroupBox.TabStop = false;
            this.AppInfos_FunsGroupBox.Text = "APP信息";
            // 
            // HelpLabel5
            // 
            this.HelpLabel5.AutoSize = true;
            this.HelpLabel5.Location = new System.Drawing.Point(13, 48);
            this.HelpLabel5.Name = "HelpLabel5";
            this.HelpLabel5.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel5.TabIndex = 7;
            this.HelpLabel5.Text = "图标:";
            // 
            // ShowIconBox
            // 
            this.ShowIconBox.Location = new System.Drawing.Point(54, 24);
            this.ShowIconBox.Name = "ShowIconBox";
            this.ShowIconBox.Size = new System.Drawing.Size(64, 64);
            this.ShowIconBox.TabIndex = 6;
            this.ShowIconBox.TabStop = false;
            // 
            // Show_AppDescription_TextBox
            // 
            this.Show_AppDescription_TextBox.Location = new System.Drawing.Point(16, 175);
            this.Show_AppDescription_TextBox.Multiline = true;
            this.Show_AppDescription_TextBox.Name = "Show_AppDescription_TextBox";
            this.Show_AppDescription_TextBox.ReadOnly = true;
            this.Show_AppDescription_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Show_AppDescription_TextBox.Size = new System.Drawing.Size(173, 83);
            this.Show_AppDescription_TextBox.TabIndex = 5;
            // 
            // ClickTo_SaveApk_Button
            // 
            this.ClickTo_SaveApk_Button.Location = new System.Drawing.Point(16, 264);
            this.ClickTo_SaveApk_Button.Name = "ClickTo_SaveApk_Button";
            this.ClickTo_SaveApk_Button.Size = new System.Drawing.Size(173, 23);
            this.ClickTo_SaveApk_Button.TabIndex = 3;
            this.ClickTo_SaveApk_Button.Text = "下载";
            this.ClickTo_SaveApk_Button.UseVisualStyleBackColor = true;
            this.ClickTo_SaveApk_Button.Click += new System.EventHandler(this.ClickTo_SaveApk_Button_Click);
            // 
            // HelpLabel3
            // 
            this.HelpLabel3.AutoSize = true;
            this.HelpLabel3.Location = new System.Drawing.Point(13, 155);
            this.HelpLabel3.Name = "HelpLabel3";
            this.HelpLabel3.Size = new System.Drawing.Size(38, 17);
            this.HelpLabel3.TabIndex = 4;
            this.HelpLabel3.Text = "描述↓";
            // 
            // Show_AppVer_TextBox
            // 
            this.Show_AppVer_TextBox.Location = new System.Drawing.Point(54, 129);
            this.Show_AppVer_TextBox.Name = "Show_AppVer_TextBox";
            this.Show_AppVer_TextBox.ReadOnly = true;
            this.Show_AppVer_TextBox.Size = new System.Drawing.Size(54, 23);
            this.Show_AppVer_TextBox.TabIndex = 3;
            // 
            // HelpLabel2
            // 
            this.HelpLabel2.AutoSize = true;
            this.HelpLabel2.Location = new System.Drawing.Point(13, 132);
            this.HelpLabel2.Name = "HelpLabel2";
            this.HelpLabel2.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel2.TabIndex = 2;
            this.HelpLabel2.Text = "版本:";
            // 
            // Show_AppName_TextBox
            // 
            this.Show_AppName_TextBox.Location = new System.Drawing.Point(54, 103);
            this.Show_AppName_TextBox.Name = "Show_AppName_TextBox";
            this.Show_AppName_TextBox.ReadOnly = true;
            this.Show_AppName_TextBox.Size = new System.Drawing.Size(135, 23);
            this.Show_AppName_TextBox.TabIndex = 1;
            // 
            // HelpLabel1
            // 
            this.HelpLabel1.AutoSize = true;
            this.HelpLabel1.Location = new System.Drawing.Point(13, 106);
            this.HelpLabel1.Name = "HelpLabel1";
            this.HelpLabel1.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel1.TabIndex = 0;
            this.HelpLabel1.Text = "名称:";
            // 
            // ClickTo_InstallSelectedApp_Button
            // 
            this.ClickTo_InstallSelectedApp_Button.Location = new System.Drawing.Point(178, 321);
            this.ClickTo_InstallSelectedApp_Button.Name = "ClickTo_InstallSelectedApp_Button";
            this.ClickTo_InstallSelectedApp_Button.Size = new System.Drawing.Size(90, 23);
            this.ClickTo_InstallSelectedApp_Button.TabIndex = 2;
            this.ClickTo_InstallSelectedApp_Button.Text = "安装";
            this.ClickTo_InstallSelectedApp_Button.UseVisualStyleBackColor = true;
            this.ClickTo_InstallSelectedApp_Button.Click += new System.EventHandler(this.ClickTo_InstallSelectedApp_Button_Click);
            // 
            // CheckedToSignApp_CheckBox
            // 
            this.CheckedToSignApp_CheckBox.AutoSize = true;
            this.CheckedToSignApp_CheckBox.Location = new System.Drawing.Point(283, 323);
            this.CheckedToSignApp_CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckedToSignApp_CheckBox.Name = "CheckedToSignApp_CheckBox";
            this.CheckedToSignApp_CheckBox.Size = new System.Drawing.Size(96, 21);
            this.CheckedToSignApp_CheckBox.TabIndex = 6;
            this.CheckedToSignApp_CheckBox.Text = "签上TestKey";
            this.CheckedToSignApp_CheckBox.UseVisualStyleBackColor = true;
            // 
            // WebAppStoreLinkLabel
            // 
            this.WebAppStoreLinkLabel.AutoSize = true;
            this.WebAppStoreLinkLabel.Location = new System.Drawing.Point(12, 329);
            this.WebAppStoreLinkLabel.Name = "WebAppStoreLinkLabel";
            this.WebAppStoreLinkLabel.Size = new System.Drawing.Size(136, 17);
            this.WebAppStoreLinkLabel.TabIndex = 7;
            this.WebAppStoreLinkLabel.TabStop = true;
            this.WebAppStoreLinkLabel.Text = "网页端应用商店(@奕奕)";
            this.WebAppStoreLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebAppStoreLinkLabel_LinkClicked);
            // 
            // Frm_AppStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(394, 356);
            this.Controls.Add(this.WebAppStoreLinkLabel);
            this.Controls.Add(this.CheckedToSignApp_CheckBox);
            this.Controls.Add(this.AppInfos_FunsGroupBox);
            this.Controls.Add(this.Show_AppList_ListBox);
            this.Controls.Add(this.ClickTo_InstallSelectedApp_Button);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AppStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用商店";
            this.Load += new System.EventHandler(this.Frm_AppStore_Load);
            this.AppInfos_FunsGroupBox.ResumeLayout(false);
            this.AppInfos_FunsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowIconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Show_AppList_ListBox;
        private System.Windows.Forms.GroupBox AppInfos_FunsGroupBox;
        private System.Windows.Forms.Label HelpLabel1;
        private System.Windows.Forms.TextBox Show_AppName_TextBox;
        private System.Windows.Forms.TextBox Show_AppVer_TextBox;
        private System.Windows.Forms.Label HelpLabel2;
        private System.Windows.Forms.Label HelpLabel3;
        private System.Windows.Forms.TextBox Show_AppDescription_TextBox;
        private System.Windows.Forms.Button ClickTo_InstallSelectedApp_Button;
        private System.Windows.Forms.Button ClickTo_SaveApk_Button;
        private System.Windows.Forms.CheckBox CheckedToSignApp_CheckBox;
        private System.Windows.Forms.PictureBox ShowIconBox;
        private System.Windows.Forms.Label HelpLabel5;
        private System.Windows.Forms.LinkLabel WebAppStoreLinkLabel;
        private System.Windows.Forms.FolderBrowserDialog SelectSaveDirDlg;
    }
}