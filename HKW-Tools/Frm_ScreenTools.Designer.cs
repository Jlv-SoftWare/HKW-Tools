using System;

namespace HKW_Tools
{
    partial class Frm_ScreenTools
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
            this.ChangesScreenArgsFuns_GroupBox = new System.Windows.Forms.GroupBox();
            this.ClickTo_ResetScreenDPISize_Button = new System.Windows.Forms.Button();
            this.ClickToResetScreenSize_Button = new System.Windows.Forms.Button();
            this.SetDpiFuns_GroupBox = new System.Windows.Forms.GroupBox();
            this.ClickTo_SetScreenDPISize_Button = new System.Windows.Forms.Button();
            this.HelpLabel3 = new System.Windows.Forms.Label();
            this.Get_DPINum_Box = new System.Windows.Forms.TextBox();
            this.Set_ScreenSizeFunsGroupBox = new System.Windows.Forms.GroupBox();
            this.HelpLabel2 = new System.Windows.Forms.Label();
            this.HelpLabel1 = new System.Windows.Forms.Label();
            this.Get_HightNum_Box = new System.Windows.Forms.TextBox();
            this.ClickTo_SetScreenSize_Button = new System.Windows.Forms.Button();
            this.Get_WightNum_Box = new System.Windows.Forms.TextBox();
            this.ScreenCastingFuns_GroupBox = new System.Windows.Forms.GroupBox();
            this.CheckTo_Record_CheckBox = new System.Windows.Forms.CheckBox();
            this.Get_SaveVideoPathBox = new System.Windows.Forms.TextBox();
            this.ClickTo_CastScreen_Button = new System.Windows.Forms.Button();
            this.SaveVideoDlg = new System.Windows.Forms.SaveFileDialog();
            this.HelpLabel4 = new System.Windows.Forms.Label();
            this.ClickTo_Get_aScreenShot_Button = new System.Windows.Forms.Button();
            this.SaveScreenShotDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.ChangesScreenArgsFuns_GroupBox.SuspendLayout();
            this.SetDpiFuns_GroupBox.SuspendLayout();
            this.Set_ScreenSizeFunsGroupBox.SuspendLayout();
            this.ScreenCastingFuns_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangesScreenArgsFuns_GroupBox
            // 
            this.ChangesScreenArgsFuns_GroupBox.Controls.Add(this.ClickTo_Get_aScreenShot_Button);
            this.ChangesScreenArgsFuns_GroupBox.Controls.Add(this.ClickTo_ResetScreenDPISize_Button);
            this.ChangesScreenArgsFuns_GroupBox.Controls.Add(this.ClickToResetScreenSize_Button);
            this.ChangesScreenArgsFuns_GroupBox.Controls.Add(this.SetDpiFuns_GroupBox);
            this.ChangesScreenArgsFuns_GroupBox.Controls.Add(this.Set_ScreenSizeFunsGroupBox);
            this.ChangesScreenArgsFuns_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.ChangesScreenArgsFuns_GroupBox.Name = "ChangesScreenArgsFuns_GroupBox";
            this.ChangesScreenArgsFuns_GroupBox.Size = new System.Drawing.Size(348, 139);
            this.ChangesScreenArgsFuns_GroupBox.TabIndex = 0;
            this.ChangesScreenArgsFuns_GroupBox.TabStop = false;
            this.ChangesScreenArgsFuns_GroupBox.Text = "屏幕管理";
            // 
            // ClickTo_ResetScreenDPISize_Button
            // 
            this.ClickTo_ResetScreenDPISize_Button.Location = new System.Drawing.Point(213, 66);
            this.ClickTo_ResetScreenDPISize_Button.Name = "ClickTo_ResetScreenDPISize_Button";
            this.ClickTo_ResetScreenDPISize_Button.Size = new System.Drawing.Size(120, 30);
            this.ClickTo_ResetScreenDPISize_Button.TabIndex = 10;
            this.ClickTo_ResetScreenDPISize_Button.Text = "重置DPI";
            this.ClickTo_ResetScreenDPISize_Button.UseVisualStyleBackColor = true;
            this.ClickTo_ResetScreenDPISize_Button.Click += new System.EventHandler(this.ClickTo_ResetScreenDPISize_Button_Click);
            // 
            // ClickToResetScreenSize_Button
            // 
            this.ClickToResetScreenSize_Button.Location = new System.Drawing.Point(213, 27);
            this.ClickToResetScreenSize_Button.Name = "ClickToResetScreenSize_Button";
            this.ClickToResetScreenSize_Button.Size = new System.Drawing.Size(120, 30);
            this.ClickToResetScreenSize_Button.TabIndex = 9;
            this.ClickToResetScreenSize_Button.Text = "重置分辨率";
            this.ClickToResetScreenSize_Button.UseVisualStyleBackColor = true;
            this.ClickToResetScreenSize_Button.Click += new System.EventHandler(this.ClickToResetScreenSize_Button_Click);
            // 
            // SetDpiFuns_GroupBox
            // 
            this.SetDpiFuns_GroupBox.Controls.Add(this.ClickTo_SetScreenDPISize_Button);
            this.SetDpiFuns_GroupBox.Controls.Add(this.HelpLabel3);
            this.SetDpiFuns_GroupBox.Controls.Add(this.Get_DPINum_Box);
            this.SetDpiFuns_GroupBox.Location = new System.Drawing.Point(104, 22);
            this.SetDpiFuns_GroupBox.Name = "SetDpiFuns_GroupBox";
            this.SetDpiFuns_GroupBox.Size = new System.Drawing.Size(106, 110);
            this.SetDpiFuns_GroupBox.TabIndex = 8;
            this.SetDpiFuns_GroupBox.TabStop = false;
            this.SetDpiFuns_GroupBox.Text = "调整DPI";
            // 
            // ClickTo_SetScreenDPISize_Button
            // 
            this.ClickTo_SetScreenDPISize_Button.Location = new System.Drawing.Point(9, 79);
            this.ClickTo_SetScreenDPISize_Button.Name = "ClickTo_SetScreenDPISize_Button";
            this.ClickTo_SetScreenDPISize_Button.Size = new System.Drawing.Size(86, 23);
            this.ClickTo_SetScreenDPISize_Button.TabIndex = 8;
            this.ClickTo_SetScreenDPISize_Button.Text = "设置";
            this.ClickTo_SetScreenDPISize_Button.UseVisualStyleBackColor = true;
            this.ClickTo_SetScreenDPISize_Button.Click += new System.EventHandler(this.ClickTo_SetScreenDPISize_Button_Click);
            // 
            // HelpLabel3
            // 
            this.HelpLabel3.AutoSize = true;
            this.HelpLabel3.Location = new System.Drawing.Point(6, 39);
            this.HelpLabel3.Name = "HelpLabel3";
            this.HelpLabel3.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel3.TabIndex = 7;
            this.HelpLabel3.Text = "数值:";
            // 
            // Get_DPINum_Box
            // 
            this.Get_DPINum_Box.Location = new System.Drawing.Point(47, 36);
            this.Get_DPINum_Box.Name = "Get_DPINum_Box";
            this.Get_DPINum_Box.Size = new System.Drawing.Size(48, 23);
            this.Get_DPINum_Box.TabIndex = 6;
            this.Get_DPINum_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Get_DPINum_Box_KeyDown);
            this.Get_DPINum_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Get_DPINum_Box_KeyPress);
            // 
            // Set_ScreenSizeFunsGroupBox
            // 
            this.Set_ScreenSizeFunsGroupBox.Controls.Add(this.HelpLabel2);
            this.Set_ScreenSizeFunsGroupBox.Controls.Add(this.HelpLabel1);
            this.Set_ScreenSizeFunsGroupBox.Controls.Add(this.Get_HightNum_Box);
            this.Set_ScreenSizeFunsGroupBox.Controls.Add(this.ClickTo_SetScreenSize_Button);
            this.Set_ScreenSizeFunsGroupBox.Controls.Add(this.Get_WightNum_Box);
            this.Set_ScreenSizeFunsGroupBox.Location = new System.Drawing.Point(6, 22);
            this.Set_ScreenSizeFunsGroupBox.Name = "Set_ScreenSizeFunsGroupBox";
            this.Set_ScreenSizeFunsGroupBox.Size = new System.Drawing.Size(92, 110);
            this.Set_ScreenSizeFunsGroupBox.TabIndex = 7;
            this.Set_ScreenSizeFunsGroupBox.TabStop = false;
            this.Set_ScreenSizeFunsGroupBox.Text = "调整分辨率";
            // 
            // HelpLabel2
            // 
            this.HelpLabel2.AutoSize = true;
            this.HelpLabel2.Location = new System.Drawing.Point(6, 22);
            this.HelpLabel2.Name = "HelpLabel2";
            this.HelpLabel2.Size = new System.Drawing.Size(23, 17);
            this.HelpLabel2.TabIndex = 4;
            this.HelpLabel2.Text = "宽:";
            // 
            // HelpLabel1
            // 
            this.HelpLabel1.AutoSize = true;
            this.HelpLabel1.Location = new System.Drawing.Point(6, 51);
            this.HelpLabel1.Name = "HelpLabel1";
            this.HelpLabel1.Size = new System.Drawing.Size(23, 17);
            this.HelpLabel1.TabIndex = 3;
            this.HelpLabel1.Text = "高:";
            // 
            // Get_HightNum_Box
            // 
            this.Get_HightNum_Box.Location = new System.Drawing.Point(35, 48);
            this.Get_HightNum_Box.Name = "Get_HightNum_Box";
            this.Get_HightNum_Box.Size = new System.Drawing.Size(45, 23);
            this.Get_HightNum_Box.TabIndex = 1;
            this.Get_HightNum_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Get_HightNum_Box_KeyPress);
            // 
            // ClickTo_SetScreenSize_Button
            // 
            this.ClickTo_SetScreenSize_Button.Location = new System.Drawing.Point(10, 79);
            this.ClickTo_SetScreenSize_Button.Name = "ClickTo_SetScreenSize_Button";
            this.ClickTo_SetScreenSize_Button.Size = new System.Drawing.Size(70, 23);
            this.ClickTo_SetScreenSize_Button.TabIndex = 4;
            this.ClickTo_SetScreenSize_Button.Text = "设置";
            this.ClickTo_SetScreenSize_Button.UseVisualStyleBackColor = true;
            this.ClickTo_SetScreenSize_Button.Click += new System.EventHandler(this.ClickTo_SetScreenSize_Button_Click);
            // 
            // Get_WightNum_Box
            // 
            this.Get_WightNum_Box.Location = new System.Drawing.Point(35, 19);
            this.Get_WightNum_Box.Name = "Get_WightNum_Box";
            this.Get_WightNum_Box.Size = new System.Drawing.Size(45, 23);
            this.Get_WightNum_Box.TabIndex = 2;
            this.Get_WightNum_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Get_WightNum_Box_KeyDown);
            this.Get_WightNum_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Get_WightNum_Box_KeyPress);
            // 
            // ScreenCastingFuns_GroupBox
            // 
            this.ScreenCastingFuns_GroupBox.Controls.Add(this.HelpLabel4);
            this.ScreenCastingFuns_GroupBox.Controls.Add(this.CheckTo_Record_CheckBox);
            this.ScreenCastingFuns_GroupBox.Controls.Add(this.Get_SaveVideoPathBox);
            this.ScreenCastingFuns_GroupBox.Controls.Add(this.ClickTo_CastScreen_Button);
            this.ScreenCastingFuns_GroupBox.Location = new System.Drawing.Point(12, 157);
            this.ScreenCastingFuns_GroupBox.Name = "ScreenCastingFuns_GroupBox";
            this.ScreenCastingFuns_GroupBox.Size = new System.Drawing.Size(348, 83);
            this.ScreenCastingFuns_GroupBox.TabIndex = 1;
            this.ScreenCastingFuns_GroupBox.TabStop = false;
            this.ScreenCastingFuns_GroupBox.Text = "投屏选项";
            // 
            // CheckTo_Record_CheckBox
            // 
            this.CheckTo_Record_CheckBox.AutoSize = true;
            this.CheckTo_Record_CheckBox.Location = new System.Drawing.Point(6, 52);
            this.CheckTo_Record_CheckBox.Name = "CheckTo_Record_CheckBox";
            this.CheckTo_Record_CheckBox.Size = new System.Drawing.Size(87, 21);
            this.CheckTo_Record_CheckBox.TabIndex = 2;
            this.CheckTo_Record_CheckBox.Text = "投屏时录制";
            this.CheckTo_Record_CheckBox.UseVisualStyleBackColor = true;
            this.CheckTo_Record_CheckBox.Click += new System.EventHandler(this.CheckTo_Record_CheckBox_Click);
            // 
            // Get_SaveVideoPathBox
            // 
            this.Get_SaveVideoPathBox.Enabled = false;
            this.Get_SaveVideoPathBox.Location = new System.Drawing.Point(68, 23);
            this.Get_SaveVideoPathBox.Name = "Get_SaveVideoPathBox";
            this.Get_SaveVideoPathBox.ReadOnly = true;
            this.Get_SaveVideoPathBox.Size = new System.Drawing.Size(186, 23);
            this.Get_SaveVideoPathBox.TabIndex = 1;
            // 
            // ClickTo_CastScreen_Button
            // 
            this.ClickTo_CastScreen_Button.Location = new System.Drawing.Point(260, 22);
            this.ClickTo_CastScreen_Button.Name = "ClickTo_CastScreen_Button";
            this.ClickTo_CastScreen_Button.Size = new System.Drawing.Size(82, 43);
            this.ClickTo_CastScreen_Button.TabIndex = 0;
            this.ClickTo_CastScreen_Button.Text = "投屏";
            this.ClickTo_CastScreen_Button.UseVisualStyleBackColor = true;
            this.ClickTo_CastScreen_Button.Click += new System.EventHandler(this.ClickTo_CastScreen_Button_Click);
            // 
            // SaveVideoDlg
            // 
            this.SaveVideoDlg.DefaultExt = "mp4";
            this.SaveVideoDlg.Filter = "MP4文件|*.mp4;*.mp4";
            this.SaveVideoDlg.Title = "选择录屏保存路径";
            // 
            // HelpLabel4
            // 
            this.HelpLabel4.AutoSize = true;
            this.HelpLabel4.Enabled = false;
            this.HelpLabel4.Location = new System.Drawing.Point(6, 26);
            this.HelpLabel4.Name = "HelpLabel4";
            this.HelpLabel4.Size = new System.Drawing.Size(59, 17);
            this.HelpLabel4.TabIndex = 3;
            this.HelpLabel4.Text = "保存位置:";
            // 
            // ClickTo_Get_aScreenShot_Button
            // 
            this.ClickTo_Get_aScreenShot_Button.Location = new System.Drawing.Point(213, 102);
            this.ClickTo_Get_aScreenShot_Button.Name = "ClickTo_Get_aScreenShot_Button";
            this.ClickTo_Get_aScreenShot_Button.Size = new System.Drawing.Size(120, 30);
            this.ClickTo_Get_aScreenShot_Button.TabIndex = 11;
            this.ClickTo_Get_aScreenShot_Button.Text = "截屏";
            this.ClickTo_Get_aScreenShot_Button.UseVisualStyleBackColor = true;
            this.ClickTo_Get_aScreenShot_Button.Click += new System.EventHandler(this.ClickTo_Get_aScreenShot_Button_Click);
            // 
            // Frm_ScreenTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(372, 254);
            this.Controls.Add(this.ScreenCastingFuns_GroupBox);
            this.Controls.Add(this.ChangesScreenArgsFuns_GroupBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ScreenTools";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕工具(<?>)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ScreenTools_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ScreenTools_Load);
            this.ChangesScreenArgsFuns_GroupBox.ResumeLayout(false);
            this.SetDpiFuns_GroupBox.ResumeLayout(false);
            this.SetDpiFuns_GroupBox.PerformLayout();
            this.Set_ScreenSizeFunsGroupBox.ResumeLayout(false);
            this.Set_ScreenSizeFunsGroupBox.PerformLayout();
            this.ScreenCastingFuns_GroupBox.ResumeLayout(false);
            this.ScreenCastingFuns_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChangesScreenArgsFuns_GroupBox;
        private System.Windows.Forms.GroupBox ScreenCastingFuns_GroupBox;
        private System.Windows.Forms.Button ClickTo_CastScreen_Button;
        private System.Windows.Forms.TextBox Get_WightNum_Box;
        private System.Windows.Forms.TextBox Get_HightNum_Box;
        private System.Windows.Forms.TextBox Get_DPINum_Box;
        private System.Windows.Forms.Button ClickTo_SetScreenSize_Button;
        private System.Windows.Forms.GroupBox Set_ScreenSizeFunsGroupBox;
        private System.Windows.Forms.Label HelpLabel2;
        private System.Windows.Forms.Label HelpLabel1;
        private System.Windows.Forms.GroupBox SetDpiFuns_GroupBox;
        private System.Windows.Forms.Label HelpLabel3;
        private System.Windows.Forms.Button ClickTo_ResetScreenDPISize_Button;
        private System.Windows.Forms.Button ClickToResetScreenSize_Button;
        private System.Windows.Forms.Button ClickTo_SetScreenDPISize_Button;
        private System.Windows.Forms.CheckBox CheckTo_Record_CheckBox;
        private System.Windows.Forms.TextBox Get_SaveVideoPathBox;
        private System.Windows.Forms.SaveFileDialog SaveVideoDlg;
        private System.Windows.Forms.Label HelpLabel4;
        private System.Windows.Forms.Button ClickTo_Get_aScreenShot_Button;
        private System.Windows.Forms.FolderBrowserDialog SaveScreenShotDlg;
    }
}