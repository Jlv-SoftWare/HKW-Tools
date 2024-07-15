namespace HKW_Tools
{
    partial class Frm_FileSystem
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
            this.ShowChilds_ListBox = new System.Windows.Forms.ListBox();
            this.Input_MaxPath_TextBox = new System.Windows.Forms.TextBox();
            this.ClickTo_ReShow_Button = new System.Windows.Forms.Button();
            this.ClickTo_GoTo_ParentPath_Button = new System.Windows.Forms.Button();
            this.Funs_GroupBox = new System.Windows.Forms.GroupBox();
            this.Get_NewDirName_TextBox = new System.Windows.Forms.TextBox();
            this.Get_Name_TextBox = new System.Windows.Forms.TextBox();
            this.Clipboard_TextBox = new System.Windows.Forms.TextBox();
            this.ClickTo_ReNameChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_StickupChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_MoveChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_CopyChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_CreateNewDirChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_RemoveChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_DownloadChild_Button = new System.Windows.Forms.Button();
            this.ClickTo_UploadChild_Button = new System.Windows.Forms.Button();
            this.SelectFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.SaveChildDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.ClickTo_GotoInputPath_Button = new System.Windows.Forms.Button();
            this.ShowLoading_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Show_PercentageProgess = new System.Windows.Forms.TextBox();
            this.PercentageChar = new System.Windows.Forms.Label();
            this.Funs_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowChilds_ListBox
            // 
            this.ShowChilds_ListBox.FormattingEnabled = true;
            this.ShowChilds_ListBox.HorizontalScrollbar = true;
            this.ShowChilds_ListBox.ItemHeight = 17;
            this.ShowChilds_ListBox.Location = new System.Drawing.Point(12, 44);
            this.ShowChilds_ListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowChilds_ListBox.Name = "ShowChilds_ListBox";
            this.ShowChilds_ListBox.Size = new System.Drawing.Size(206, 344);
            this.ShowChilds_ListBox.TabIndex = 0;
            this.ShowChilds_ListBox.SelectedIndexChanged += new System.EventHandler(this.ShowChilds_ListBox_SelectedIndexChanged);
            this.ShowChilds_ListBox.DoubleClick += new System.EventHandler(this.ShowChilds_ListBox_DoubleClick);
            // 
            // Input_MaxPath_TextBox
            // 
            this.Input_MaxPath_TextBox.Location = new System.Drawing.Point(12, 13);
            this.Input_MaxPath_TextBox.Name = "Input_MaxPath_TextBox";
            this.Input_MaxPath_TextBox.Size = new System.Drawing.Size(148, 23);
            this.Input_MaxPath_TextBox.TabIndex = 1;
            this.Input_MaxPath_TextBox.Text = "/storage/emulated/0";
            this.Input_MaxPath_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_MaxPath_TextBox_KeyDown);
            // 
            // ClickTo_ReShow_Button
            // 
            this.ClickTo_ReShow_Button.Location = new System.Drawing.Point(225, 353);
            this.ClickTo_ReShow_Button.Name = "ClickTo_ReShow_Button";
            this.ClickTo_ReShow_Button.Size = new System.Drawing.Size(201, 35);
            this.ClickTo_ReShow_Button.TabIndex = 2;
            this.ClickTo_ReShow_Button.Text = "刷新";
            this.ClickTo_ReShow_Button.UseVisualStyleBackColor = true;
            this.ClickTo_ReShow_Button.Click += new System.EventHandler(this.ClickTo_ReShow_Button_Click);
            // 
            // ClickTo_GoTo_ParentPath_Button
            // 
            this.ClickTo_GoTo_ParentPath_Button.Location = new System.Drawing.Point(234, 12);
            this.ClickTo_GoTo_ParentPath_Button.Name = "ClickTo_GoTo_ParentPath_Button";
            this.ClickTo_GoTo_ParentPath_Button.Size = new System.Drawing.Size(184, 25);
            this.ClickTo_GoTo_ParentPath_Button.TabIndex = 3;
            this.ClickTo_GoTo_ParentPath_Button.Text = "返回上一级";
            this.ClickTo_GoTo_ParentPath_Button.UseVisualStyleBackColor = true;
            this.ClickTo_GoTo_ParentPath_Button.Click += new System.EventHandler(this.ClickTo_GoTo_ParentPath_Button_Click);
            // 
            // Funs_GroupBox
            // 
            this.Funs_GroupBox.Controls.Add(this.Get_NewDirName_TextBox);
            this.Funs_GroupBox.Controls.Add(this.Get_Name_TextBox);
            this.Funs_GroupBox.Controls.Add(this.Clipboard_TextBox);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_ReNameChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_StickupChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_MoveChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_CopyChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_CreateNewDirChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_RemoveChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_DownloadChild_Button);
            this.Funs_GroupBox.Controls.Add(this.ClickTo_UploadChild_Button);
            this.Funs_GroupBox.Location = new System.Drawing.Point(227, 44);
            this.Funs_GroupBox.Name = "Funs_GroupBox";
            this.Funs_GroupBox.Size = new System.Drawing.Size(199, 303);
            this.Funs_GroupBox.TabIndex = 4;
            this.Funs_GroupBox.TabStop = false;
            this.Funs_GroupBox.Text = "功能区";
            // 
            // Get_NewDirName_TextBox
            // 
            this.Get_NewDirName_TextBox.Location = new System.Drawing.Point(82, 232);
            this.Get_NewDirName_TextBox.Name = "Get_NewDirName_TextBox";
            this.Get_NewDirName_TextBox.Size = new System.Drawing.Size(102, 23);
            this.Get_NewDirName_TextBox.TabIndex = 10;
            // 
            // Get_Name_TextBox
            // 
            this.Get_Name_TextBox.Location = new System.Drawing.Point(70, 262);
            this.Get_Name_TextBox.Name = "Get_Name_TextBox";
            this.Get_Name_TextBox.Size = new System.Drawing.Size(114, 23);
            this.Get_Name_TextBox.TabIndex = 9;
            // 
            // Clipboard_TextBox
            // 
            this.Clipboard_TextBox.Location = new System.Drawing.Point(59, 204);
            this.Clipboard_TextBox.Name = "Clipboard_TextBox";
            this.Clipboard_TextBox.ReadOnly = true;
            this.Clipboard_TextBox.Size = new System.Drawing.Size(125, 23);
            this.Clipboard_TextBox.TabIndex = 8;
            // 
            // ClickTo_ReNameChild_Button
            // 
            this.ClickTo_ReNameChild_Button.Location = new System.Drawing.Point(7, 259);
            this.ClickTo_ReNameChild_Button.Name = "ClickTo_ReNameChild_Button";
            this.ClickTo_ReNameChild_Button.Size = new System.Drawing.Size(57, 26);
            this.ClickTo_ReNameChild_Button.TabIndex = 7;
            this.ClickTo_ReNameChild_Button.Text = "重命名:";
            this.ClickTo_ReNameChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_ReNameChild_Button.Click += new System.EventHandler(this.ClickTo_ReNameChild_Button_Click);
            // 
            // ClickTo_StickupChild_Button
            // 
            this.ClickTo_StickupChild_Button.Location = new System.Drawing.Point(7, 201);
            this.ClickTo_StickupChild_Button.Name = "ClickTo_StickupChild_Button";
            this.ClickTo_StickupChild_Button.Size = new System.Drawing.Size(46, 26);
            this.ClickTo_StickupChild_Button.TabIndex = 6;
            this.ClickTo_StickupChild_Button.Text = "粘贴";
            this.ClickTo_StickupChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_StickupChild_Button.Click += new System.EventHandler(this.ClickTo_StickupChild_Button_Click);
            // 
            // ClickTo_MoveChild_Button
            // 
            this.ClickTo_MoveChild_Button.Location = new System.Drawing.Point(108, 118);
            this.ClickTo_MoveChild_Button.Name = "ClickTo_MoveChild_Button";
            this.ClickTo_MoveChild_Button.Size = new System.Drawing.Size(85, 40);
            this.ClickTo_MoveChild_Button.TabIndex = 5;
            this.ClickTo_MoveChild_Button.Text = "剪切";
            this.ClickTo_MoveChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_MoveChild_Button.Click += new System.EventHandler(this.ClickTo_MoveChild_Button_Click);
            // 
            // ClickTo_CopyChild_Button
            // 
            this.ClickTo_CopyChild_Button.Location = new System.Drawing.Point(7, 118);
            this.ClickTo_CopyChild_Button.Name = "ClickTo_CopyChild_Button";
            this.ClickTo_CopyChild_Button.Size = new System.Drawing.Size(85, 40);
            this.ClickTo_CopyChild_Button.TabIndex = 4;
            this.ClickTo_CopyChild_Button.Text = "复制";
            this.ClickTo_CopyChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_CopyChild_Button.Click += new System.EventHandler(this.ClickTo_CopyChild_Button_Click);
            // 
            // ClickTo_CreateNewDirChild_Button
            // 
            this.ClickTo_CreateNewDirChild_Button.Location = new System.Drawing.Point(7, 230);
            this.ClickTo_CreateNewDirChild_Button.Name = "ClickTo_CreateNewDirChild_Button";
            this.ClickTo_CreateNewDirChild_Button.Size = new System.Drawing.Size(69, 26);
            this.ClickTo_CreateNewDirChild_Button.TabIndex = 3;
            this.ClickTo_CreateNewDirChild_Button.Text = "新建目录:";
            this.ClickTo_CreateNewDirChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_CreateNewDirChild_Button.Click += new System.EventHandler(this.ClickTo_CreateNewDirChild_Button_Click);
            // 
            // ClickTo_RemoveChild_Button
            // 
            this.ClickTo_RemoveChild_Button.Location = new System.Drawing.Point(7, 160);
            this.ClickTo_RemoveChild_Button.Name = "ClickTo_RemoveChild_Button";
            this.ClickTo_RemoveChild_Button.Size = new System.Drawing.Size(186, 35);
            this.ClickTo_RemoveChild_Button.TabIndex = 2;
            this.ClickTo_RemoveChild_Button.Text = "删除";
            this.ClickTo_RemoveChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_RemoveChild_Button.Click += new System.EventHandler(this.ClickTo_RemoveChild_Button_Click);
            // 
            // ClickTo_DownloadChild_Button
            // 
            this.ClickTo_DownloadChild_Button.Location = new System.Drawing.Point(7, 70);
            this.ClickTo_DownloadChild_Button.Name = "ClickTo_DownloadChild_Button";
            this.ClickTo_DownloadChild_Button.Size = new System.Drawing.Size(186, 42);
            this.ClickTo_DownloadChild_Button.TabIndex = 1;
            this.ClickTo_DownloadChild_Button.Text = "下载";
            this.ClickTo_DownloadChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_DownloadChild_Button.Click += new System.EventHandler(this.ClickTo_DownloadChild_Button_Click);
            // 
            // ClickTo_UploadChild_Button
            // 
            this.ClickTo_UploadChild_Button.Location = new System.Drawing.Point(7, 22);
            this.ClickTo_UploadChild_Button.Name = "ClickTo_UploadChild_Button";
            this.ClickTo_UploadChild_Button.Size = new System.Drawing.Size(186, 42);
            this.ClickTo_UploadChild_Button.TabIndex = 0;
            this.ClickTo_UploadChild_Button.Text = "上传";
            this.ClickTo_UploadChild_Button.UseVisualStyleBackColor = true;
            this.ClickTo_UploadChild_Button.Click += new System.EventHandler(this.ClickTo_UploadChild_Button_Click);
            // 
            // SelectFileDlg
            // 
            this.SelectFileDlg.Filter = "所有文件|*.*";
            // 
            // ClickTo_GotoInputPath_Button
            // 
            this.ClickTo_GotoInputPath_Button.Location = new System.Drawing.Point(166, 12);
            this.ClickTo_GotoInputPath_Button.Name = "ClickTo_GotoInputPath_Button";
            this.ClickTo_GotoInputPath_Button.Size = new System.Drawing.Size(52, 25);
            this.ClickTo_GotoInputPath_Button.TabIndex = 5;
            this.ClickTo_GotoInputPath_Button.Text = "跳转";
            this.ClickTo_GotoInputPath_Button.UseVisualStyleBackColor = true;
            this.ClickTo_GotoInputPath_Button.Click += new System.EventHandler(this.ClickTo_GotoInputPath_Button_Click);
            // 
            // ShowLoading_ProgressBar
            // 
            this.ShowLoading_ProgressBar.Location = new System.Drawing.Point(12, 394);
            this.ShowLoading_ProgressBar.Name = "ShowLoading_ProgressBar";
            this.ShowLoading_ProgressBar.Size = new System.Drawing.Size(371, 21);
            this.ShowLoading_ProgressBar.TabIndex = 6;
            // 
            // Show_PercentageProgess
            // 
            this.Show_PercentageProgess.BackColor = System.Drawing.SystemColors.Info;
            this.Show_PercentageProgess.Enabled = false;
            this.Show_PercentageProgess.Location = new System.Drawing.Point(389, 392);
            this.Show_PercentageProgess.Name = "Show_PercentageProgess";
            this.Show_PercentageProgess.ReadOnly = true;
            this.Show_PercentageProgess.Size = new System.Drawing.Size(29, 23);
            this.Show_PercentageProgess.TabIndex = 7;
            // 
            // PercentageChar
            // 
            this.PercentageChar.AutoSize = true;
            this.PercentageChar.Location = new System.Drawing.Point(424, 396);
            this.PercentageChar.Name = "PercentageChar";
            this.PercentageChar.Size = new System.Drawing.Size(19, 17);
            this.PercentageChar.TabIndex = 8;
            this.PercentageChar.Text = "%";
            // 
            // Frm_FileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(444, 422);
            this.Controls.Add(this.PercentageChar);
            this.Controls.Add(this.Show_PercentageProgess);
            this.Controls.Add(this.ShowLoading_ProgressBar);
            this.Controls.Add(this.ClickTo_GotoInputPath_Button);
            this.Controls.Add(this.Funs_GroupBox);
            this.Controls.Add(this.ClickTo_GoTo_ParentPath_Button);
            this.Controls.Add(this.ClickTo_ReShow_Button);
            this.Controls.Add(this.Input_MaxPath_TextBox);
            this.Controls.Add(this.ShowChilds_ListBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FileSystem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理 <?> 的文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FileSystem_FormClosing);
            this.Load += new System.EventHandler(this.Frm_FileSystem_Load);
            this.Funs_GroupBox.ResumeLayout(false);
            this.Funs_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ShowChilds_ListBox;
        private System.Windows.Forms.Button ClickTo_ReShow_Button;
        private System.Windows.Forms.Button ClickTo_GoTo_ParentPath_Button;
        private System.Windows.Forms.GroupBox Funs_GroupBox;
        public System.Windows.Forms.TextBox Input_MaxPath_TextBox;
        private System.Windows.Forms.Button ClickTo_DownloadChild_Button;
        private System.Windows.Forms.Button ClickTo_UploadChild_Button;
        private System.Windows.Forms.Button ClickTo_RemoveChild_Button;
        private System.Windows.Forms.Button ClickTo_CreateNewDirChild_Button;
        private System.Windows.Forms.Button ClickTo_ReNameChild_Button;
        private System.Windows.Forms.Button ClickTo_StickupChild_Button;
        private System.Windows.Forms.Button ClickTo_MoveChild_Button;
        private System.Windows.Forms.Button ClickTo_CopyChild_Button;
        private System.Windows.Forms.TextBox Get_Name_TextBox;
        private System.Windows.Forms.TextBox Clipboard_TextBox;
        public System.Windows.Forms.OpenFileDialog SelectFileDlg;
        private System.Windows.Forms.TextBox Get_NewDirName_TextBox;
        private System.Windows.Forms.FolderBrowserDialog SaveChildDlg;
        private System.Windows.Forms.Button ClickTo_GotoInputPath_Button;
        private System.Windows.Forms.ProgressBar ShowLoading_ProgressBar;
        private System.Windows.Forms.TextBox Show_PercentageProgess;
        private System.Windows.Forms.Label PercentageChar;
    }
}