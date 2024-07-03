namespace HKW_Tools
{
    partial class Frm_AppManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AppManage));
            this.APPList_ListBox = new System.Windows.Forms.ListBox();
            this.PullAPP_Button = new System.Windows.Forms.Button();
            this.UninstallAPP_Button = new System.Windows.Forms.Button();
            this.EnableAPP_Button = new System.Windows.Forms.Button();
            this.DisableAPP_Button = new System.Windows.Forms.Button();
            this.RadioButton_GroupBox = new System.Windows.Forms.GroupBox();
            this.ClickToShowTHIRDS_APPS_RaidoButton = new System.Windows.Forms.RadioButton();
            this.ClickToShowENABLE_APPS_RaidoButton = new System.Windows.Forms.RadioButton();
            this.ClickToShowSYSTEM_APPS_RaidoButton = new System.Windows.Forms.RadioButton();
            this.ClickToShowDISABLE_APPS_RaidoButton = new System.Windows.Forms.RadioButton();
            this.ClickToShowALL_APPS_RaidoButton = new System.Windows.Forms.RadioButton();
            this.SelectDirDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.RadioButton_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // APPList_ListBox
            // 
            this.APPList_ListBox.FormattingEnabled = true;
            this.APPList_ListBox.ItemHeight = 17;
            this.APPList_ListBox.Location = new System.Drawing.Point(12, 12);
            this.APPList_ListBox.Name = "APPList_ListBox";
            this.APPList_ListBox.Size = new System.Drawing.Size(248, 378);
            this.APPList_ListBox.TabIndex = 0;
            // 
            // PullAPP_Button
            // 
            this.PullAPP_Button.Location = new System.Drawing.Point(266, 167);
            this.PullAPP_Button.Name = "PullAPP_Button";
            this.PullAPP_Button.Size = new System.Drawing.Size(121, 41);
            this.PullAPP_Button.TabIndex = 1;
            this.PullAPP_Button.Text = "提取";
            this.PullAPP_Button.UseVisualStyleBackColor = true;
            this.PullAPP_Button.Click += new System.EventHandler(this.PullAPP_Button_Click);
            // 
            // UninstallAPP_Button
            // 
            this.UninstallAPP_Button.Location = new System.Drawing.Point(266, 12);
            this.UninstallAPP_Button.Name = "UninstallAPP_Button";
            this.UninstallAPP_Button.Size = new System.Drawing.Size(121, 41);
            this.UninstallAPP_Button.TabIndex = 2;
            this.UninstallAPP_Button.Text = "卸载";
            this.UninstallAPP_Button.UseVisualStyleBackColor = true;
            this.UninstallAPP_Button.Click += new System.EventHandler(this.UninstallAPP_Button_Click);
            // 
            // EnableAPP_Button
            // 
            this.EnableAPP_Button.Location = new System.Drawing.Point(266, 73);
            this.EnableAPP_Button.Name = "EnableAPP_Button";
            this.EnableAPP_Button.Size = new System.Drawing.Size(121, 41);
            this.EnableAPP_Button.TabIndex = 3;
            this.EnableAPP_Button.Text = "启用";
            this.EnableAPP_Button.UseVisualStyleBackColor = true;
            // 
            // DisableAPP_Button
            // 
            this.DisableAPP_Button.Location = new System.Drawing.Point(266, 120);
            this.DisableAPP_Button.Name = "DisableAPP_Button";
            this.DisableAPP_Button.Size = new System.Drawing.Size(121, 41);
            this.DisableAPP_Button.TabIndex = 4;
            this.DisableAPP_Button.Text = "禁用";
            this.DisableAPP_Button.UseVisualStyleBackColor = true;
            // 
            // RadioButton_GroupBox
            // 
            this.RadioButton_GroupBox.Controls.Add(this.ClickToShowTHIRDS_APPS_RaidoButton);
            this.RadioButton_GroupBox.Controls.Add(this.ClickToShowENABLE_APPS_RaidoButton);
            this.RadioButton_GroupBox.Controls.Add(this.ClickToShowSYSTEM_APPS_RaidoButton);
            this.RadioButton_GroupBox.Controls.Add(this.ClickToShowDISABLE_APPS_RaidoButton);
            this.RadioButton_GroupBox.Controls.Add(this.ClickToShowALL_APPS_RaidoButton);
            this.RadioButton_GroupBox.Location = new System.Drawing.Point(266, 214);
            this.RadioButton_GroupBox.Name = "RadioButton_GroupBox";
            this.RadioButton_GroupBox.Size = new System.Drawing.Size(121, 176);
            this.RadioButton_GroupBox.TabIndex = 5;
            this.RadioButton_GroupBox.TabStop = false;
            this.RadioButton_GroupBox.Text = "展示选项";
            // 
            // ClickToShowTHIRDS_APPS_RaidoButton
            // 
            this.ClickToShowTHIRDS_APPS_RaidoButton.AutoSize = true;
            this.ClickToShowTHIRDS_APPS_RaidoButton.Location = new System.Drawing.Point(6, 142);
            this.ClickToShowTHIRDS_APPS_RaidoButton.Name = "ClickToShowTHIRDS_APPS_RaidoButton";
            this.ClickToShowTHIRDS_APPS_RaidoButton.Size = new System.Drawing.Size(86, 21);
            this.ClickToShowTHIRDS_APPS_RaidoButton.TabIndex = 4;
            this.ClickToShowTHIRDS_APPS_RaidoButton.TabStop = true;
            this.ClickToShowTHIRDS_APPS_RaidoButton.Text = "第三方应用";
            this.ClickToShowTHIRDS_APPS_RaidoButton.UseVisualStyleBackColor = true;
            this.ClickToShowTHIRDS_APPS_RaidoButton.Click += new System.EventHandler(this.ClickToShowTHIRDS_APPS_RaidoButton_Click);
            // 
            // ClickToShowENABLE_APPS_RaidoButton
            // 
            this.ClickToShowENABLE_APPS_RaidoButton.AutoSize = true;
            this.ClickToShowENABLE_APPS_RaidoButton.Location = new System.Drawing.Point(6, 82);
            this.ClickToShowENABLE_APPS_RaidoButton.Name = "ClickToShowENABLE_APPS_RaidoButton";
            this.ClickToShowENABLE_APPS_RaidoButton.Size = new System.Drawing.Size(86, 21);
            this.ClickToShowENABLE_APPS_RaidoButton.TabIndex = 3;
            this.ClickToShowENABLE_APPS_RaidoButton.TabStop = true;
            this.ClickToShowENABLE_APPS_RaidoButton.Text = "启用的应用";
            this.ClickToShowENABLE_APPS_RaidoButton.UseVisualStyleBackColor = true;
            this.ClickToShowENABLE_APPS_RaidoButton.Click += new System.EventHandler(this.ClickToShowENABLE_APPS_RaidoButton_Click);
            // 
            // ClickToShowSYSTEM_APPS_RaidoButton
            // 
            this.ClickToShowSYSTEM_APPS_RaidoButton.AutoSize = true;
            this.ClickToShowSYSTEM_APPS_RaidoButton.Location = new System.Drawing.Point(6, 112);
            this.ClickToShowSYSTEM_APPS_RaidoButton.Name = "ClickToShowSYSTEM_APPS_RaidoButton";
            this.ClickToShowSYSTEM_APPS_RaidoButton.Size = new System.Drawing.Size(86, 21);
            this.ClickToShowSYSTEM_APPS_RaidoButton.TabIndex = 2;
            this.ClickToShowSYSTEM_APPS_RaidoButton.TabStop = true;
            this.ClickToShowSYSTEM_APPS_RaidoButton.Text = "系统的应用";
            this.ClickToShowSYSTEM_APPS_RaidoButton.UseVisualStyleBackColor = true;
            this.ClickToShowSYSTEM_APPS_RaidoButton.Click += new System.EventHandler(this.ClickToShowSYSTEM_APPS_RaidoButton_Click);
            // 
            // ClickToShowDISABLE_APPS_RaidoButton
            // 
            this.ClickToShowDISABLE_APPS_RaidoButton.AutoSize = true;
            this.ClickToShowDISABLE_APPS_RaidoButton.Location = new System.Drawing.Point(6, 52);
            this.ClickToShowDISABLE_APPS_RaidoButton.Name = "ClickToShowDISABLE_APPS_RaidoButton";
            this.ClickToShowDISABLE_APPS_RaidoButton.Size = new System.Drawing.Size(86, 21);
            this.ClickToShowDISABLE_APPS_RaidoButton.TabIndex = 1;
            this.ClickToShowDISABLE_APPS_RaidoButton.TabStop = true;
            this.ClickToShowDISABLE_APPS_RaidoButton.Text = "禁用的应用";
            this.ClickToShowDISABLE_APPS_RaidoButton.UseVisualStyleBackColor = true;
            this.ClickToShowDISABLE_APPS_RaidoButton.Click += new System.EventHandler(this.ClickToShowDISABLE_APPS_RaidoButton_Click);
            // 
            // ClickToShowALL_APPS_RaidoButton
            // 
            this.ClickToShowALL_APPS_RaidoButton.AutoSize = true;
            this.ClickToShowALL_APPS_RaidoButton.Checked = true;
            this.ClickToShowALL_APPS_RaidoButton.Location = new System.Drawing.Point(6, 22);
            this.ClickToShowALL_APPS_RaidoButton.Name = "ClickToShowALL_APPS_RaidoButton";
            this.ClickToShowALL_APPS_RaidoButton.Size = new System.Drawing.Size(86, 21);
            this.ClickToShowALL_APPS_RaidoButton.TabIndex = 0;
            this.ClickToShowALL_APPS_RaidoButton.TabStop = true;
            this.ClickToShowALL_APPS_RaidoButton.Text = "所有的应用";
            this.ClickToShowALL_APPS_RaidoButton.UseVisualStyleBackColor = true;
            this.ClickToShowALL_APPS_RaidoButton.CheckedChanged += new System.EventHandler(this.ClickToShowALL_APPS_RaidoButton_CheckedChanged);
            this.ClickToShowALL_APPS_RaidoButton.Click += new System.EventHandler(this.ClickToShowALL_APPS_RaidoButton_Click);
            // 
            // Frm_AppManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 400);
            this.Controls.Add(this.RadioButton_GroupBox);
            this.Controls.Add(this.DisableAPP_Button);
            this.Controls.Add(this.EnableAPP_Button);
            this.Controls.Add(this.UninstallAPP_Button);
            this.Controls.Add(this.PullAPP_Button);
            this.Controls.Add(this.APPList_ListBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AppManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理 <?> 的APP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_APPManage_FormClosing);
            this.Load += new System.EventHandler(this.Frm_APPManage_Load);
            this.RadioButton_GroupBox.ResumeLayout(false);
            this.RadioButton_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox APPList_ListBox;
        private System.Windows.Forms.Button PullAPP_Button;
        private System.Windows.Forms.Button UninstallAPP_Button;
        private System.Windows.Forms.Button EnableAPP_Button;
        private System.Windows.Forms.Button DisableAPP_Button;
        private System.Windows.Forms.GroupBox RadioButton_GroupBox;
        private System.Windows.Forms.RadioButton ClickToShowALL_APPS_RaidoButton;
        private System.Windows.Forms.RadioButton ClickToShowDISABLE_APPS_RaidoButton;
        private System.Windows.Forms.RadioButton ClickToShowSYSTEM_APPS_RaidoButton;
        private System.Windows.Forms.RadioButton ClickToShowTHIRDS_APPS_RaidoButton;
        private System.Windows.Forms.RadioButton ClickToShowENABLE_APPS_RaidoButton;
        private System.Windows.Forms.FolderBrowserDialog SelectDirDlg;
    }
}