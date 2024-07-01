namespace HKW_Tools
{
    partial class Frm_InstallAPP
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
            this.APKPath_TextBox = new System.Windows.Forms.TextBox();
            this.SelectAPK_Button = new System.Windows.Forms.Button();
            this.CheckedToSignInstall_CheckBox = new System.Windows.Forms.CheckBox();
            this.ClickToInstallAPK_Button = new System.Windows.Forms.Button();
            this.SelectAPKDialog = new System.Windows.Forms.OpenFileDialog();
            this.ClickTo_Open_Frm_AppStore_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // APKPath_TextBox
            // 
            this.APKPath_TextBox.AllowDrop = true;
            this.APKPath_TextBox.Location = new System.Drawing.Point(92, 12);
            this.APKPath_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.APKPath_TextBox.Name = "APKPath_TextBox";
            this.APKPath_TextBox.Size = new System.Drawing.Size(231, 23);
            this.APKPath_TextBox.TabIndex = 0;
            this.APKPath_TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.APKPath_TextBox_DragDrop);
            this.APKPath_TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.APKPath_TextBox_DragEnter);
            // 
            // SelectAPK_Button
            // 
            this.SelectAPK_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.SelectAPK_Button.Location = new System.Drawing.Point(11, 11);
            this.SelectAPK_Button.Margin = new System.Windows.Forms.Padding(2);
            this.SelectAPK_Button.Name = "SelectAPK_Button";
            this.SelectAPK_Button.Size = new System.Drawing.Size(77, 27);
            this.SelectAPK_Button.TabIndex = 1;
            this.SelectAPK_Button.Text = "选择APK:";
            this.SelectAPK_Button.UseVisualStyleBackColor = true;
            this.SelectAPK_Button.Click += new System.EventHandler(this.SelectAPK_Button_Click);
            // 
            // CheckedToSignInstall_CheckBox
            // 
            this.CheckedToSignInstall_CheckBox.AutoSize = true;
            this.CheckedToSignInstall_CheckBox.Location = new System.Drawing.Point(236, 39);
            this.CheckedToSignInstall_CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckedToSignInstall_CheckBox.Name = "CheckedToSignInstall_CheckBox";
            this.CheckedToSignInstall_CheckBox.Size = new System.Drawing.Size(96, 21);
            this.CheckedToSignInstall_CheckBox.TabIndex = 2;
            this.CheckedToSignInstall_CheckBox.Text = "签上TestKey";
            this.CheckedToSignInstall_CheckBox.UseVisualStyleBackColor = true;
            // 
            // ClickToInstallAPK_Button
            // 
            this.ClickToInstallAPK_Button.Location = new System.Drawing.Point(166, 62);
            this.ClickToInstallAPK_Button.Margin = new System.Windows.Forms.Padding(2);
            this.ClickToInstallAPK_Button.Name = "ClickToInstallAPK_Button";
            this.ClickToInstallAPK_Button.Size = new System.Drawing.Size(166, 31);
            this.ClickToInstallAPK_Button.TabIndex = 3;
            this.ClickToInstallAPK_Button.Text = "安装";
            this.ClickToInstallAPK_Button.UseVisualStyleBackColor = true;
            this.ClickToInstallAPK_Button.Click += new System.EventHandler(this.ClickToInstallAPK_Button_Click);
            // 
            // SelectAPKDialog
            // 
            this.SelectAPKDialog.Filter = "APK安装包(*.apk;*.apk.1)|*.APK;*.apk;*.Apk;*.aPk;*.apK;*.ApK;*.APk;*.aPK;";
            // 
            // ClickTo_Open_Frm_AppStore_Button
            // 
            this.ClickTo_Open_Frm_AppStore_Button.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClickTo_Open_Frm_AppStore_Button.ForeColor = System.Drawing.Color.MediumPurple;
            this.ClickTo_Open_Frm_AppStore_Button.Location = new System.Drawing.Point(11, 56);
            this.ClickTo_Open_Frm_AppStore_Button.Name = "ClickTo_Open_Frm_AppStore_Button";
            this.ClickTo_Open_Frm_AppStore_Button.Size = new System.Drawing.Size(121, 31);
            this.ClickTo_Open_Frm_AppStore_Button.TabIndex = 4;
            this.ClickTo_Open_Frm_AppStore_Button.Text = "应用商店";
            this.ClickTo_Open_Frm_AppStore_Button.UseVisualStyleBackColor = false;
            this.ClickTo_Open_Frm_AppStore_Button.Click += new System.EventHandler(this.ClickTo_Open_Frm_AppStore_Button_Click);
            // 
            // Frm_InstallAPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(334, 99);
            this.Controls.Add(this.ClickTo_Open_Frm_AppStore_Button);
            this.Controls.Add(this.ClickToInstallAPK_Button);
            this.Controls.Add(this.CheckedToSignInstall_CheckBox);
            this.Controls.Add(this.SelectAPK_Button);
            this.Controls.Add(this.APKPath_TextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InstallAPP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "向 <?> 安装APK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_InstallAPP_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox APKPath_TextBox;
        private System.Windows.Forms.Button SelectAPK_Button;
        private System.Windows.Forms.CheckBox CheckedToSignInstall_CheckBox;
        private System.Windows.Forms.Button ClickToInstallAPK_Button;
        public System.Windows.Forms.OpenFileDialog SelectAPKDialog;
        private System.Windows.Forms.Button ClickTo_Open_Frm_AppStore_Button;
    }
}