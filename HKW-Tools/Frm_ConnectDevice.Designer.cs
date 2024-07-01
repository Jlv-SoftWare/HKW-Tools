namespace HKW_Tools
{
    partial class Frm_ConnectDevice
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
            this.HelpLabel1 = new System.Windows.Forms.Label();
            this.HelpLabel2 = new System.Windows.Forms.Label();
            this.GetDeviceIP_TextBox = new System.Windows.Forms.TextBox();
            this.GetDeviceTCPIP_TextBox = new System.Windows.Forms.TextBox();
            this.HelpLabel3 = new System.Windows.Forms.Label();
            this.GetPairCode_TextBox = new System.Windows.Forms.TextBox();
            this.ClickToConnect_Button = new System.Windows.Forms.Button();
            this.IpInfos_GroupBox = new System.Windows.Forms.GroupBox();
            this.IpInfos_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpLabel1
            // 
            this.HelpLabel1.AutoSize = true;
            this.HelpLabel1.Location = new System.Drawing.Point(6, 29);
            this.HelpLabel1.Name = "HelpLabel1";
            this.HelpLabel1.Size = new System.Drawing.Size(22, 17);
            this.HelpLabel1.TabIndex = 0;
            this.HelpLabel1.Text = "IP:";
            // 
            // HelpLabel2
            // 
            this.HelpLabel2.AutoSize = true;
            this.HelpLabel2.Location = new System.Drawing.Point(175, 29);
            this.HelpLabel2.Name = "HelpLabel2";
            this.HelpLabel2.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel2.TabIndex = 1;
            this.HelpLabel2.Text = "端口:";
            // 
            // GetDeviceIP_TextBox
            // 
            this.GetDeviceIP_TextBox.Location = new System.Drawing.Point(29, 26);
            this.GetDeviceIP_TextBox.Name = "GetDeviceIP_TextBox";
            this.GetDeviceIP_TextBox.Size = new System.Drawing.Size(140, 23);
            this.GetDeviceIP_TextBox.TabIndex = 2;
            this.GetDeviceIP_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GetDeviceIP_TextBox_KeyPress);
            // 
            // GetDeviceTCPIP_TextBox
            // 
            this.GetDeviceTCPIP_TextBox.Location = new System.Drawing.Point(216, 26);
            this.GetDeviceTCPIP_TextBox.Name = "GetDeviceTCPIP_TextBox";
            this.GetDeviceTCPIP_TextBox.Size = new System.Drawing.Size(63, 23);
            this.GetDeviceTCPIP_TextBox.TabIndex = 3;
            this.GetDeviceTCPIP_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GetDeviceTCPIP_TextBox_KeyPress);
            // 
            // HelpLabel3
            // 
            this.HelpLabel3.AutoSize = true;
            this.HelpLabel3.Location = new System.Drawing.Point(4, 60);
            this.HelpLabel3.Name = "HelpLabel3";
            this.HelpLabel3.Size = new System.Drawing.Size(124, 34);
            this.HelpLabel3.TabIndex = 4;
            this.HelpLabel3.Text = "六位配对码:\n(仅对需配对设备使用)";
            // 
            // GetPairCode_TextBox
            // 
            this.GetPairCode_TextBox.Location = new System.Drawing.Point(71, 55);
            this.GetPairCode_TextBox.Name = "GetPairCode_TextBox";
            this.GetPairCode_TextBox.Size = new System.Drawing.Size(57, 23);
            this.GetPairCode_TextBox.TabIndex = 5;
            this.GetPairCode_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GetPairCode_TextBox_KeyPress);
            // 
            // ClickToConnect_Button
            // 
            this.ClickToConnect_Button.Location = new System.Drawing.Point(155, 55);
            this.ClickToConnect_Button.Name = "ClickToConnect_Button";
            this.ClickToConnect_Button.Size = new System.Drawing.Size(133, 39);
            this.ClickToConnect_Button.TabIndex = 6;
            this.ClickToConnect_Button.Text = "连接";
            this.ClickToConnect_Button.UseVisualStyleBackColor = true;
            this.ClickToConnect_Button.Click += new System.EventHandler(this.ClickToConnect_Button_Click);
            // 
            // IpInfos_GroupBox
            // 
            this.IpInfos_GroupBox.Controls.Add(this.GetDeviceTCPIP_TextBox);
            this.IpInfos_GroupBox.Controls.Add(this.ClickToConnect_Button);
            this.IpInfos_GroupBox.Controls.Add(this.GetPairCode_TextBox);
            this.IpInfos_GroupBox.Controls.Add(this.HelpLabel1);
            this.IpInfos_GroupBox.Controls.Add(this.HelpLabel3);
            this.IpInfos_GroupBox.Controls.Add(this.HelpLabel2);
            this.IpInfos_GroupBox.Controls.Add(this.GetDeviceIP_TextBox);
            this.IpInfos_GroupBox.Location = new System.Drawing.Point(2, 5);
            this.IpInfos_GroupBox.Name = "IpInfos_GroupBox";
            this.IpInfos_GroupBox.Size = new System.Drawing.Size(288, 108);
            this.IpInfos_GroupBox.TabIndex = 7;
            this.IpInfos_GroupBox.TabStop = false;
            this.IpInfos_GroupBox.Text = "IP设置";
            // 
            // Frm_ConnectDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 115);
            this.Controls.Add(this.IpInfos_GroupBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConnectDevice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接设备";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConnectDevice_FormClosing);
            this.IpInfos_GroupBox.ResumeLayout(false);
            this.IpInfos_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label HelpLabel1;
        private System.Windows.Forms.Label HelpLabel2;
        private System.Windows.Forms.TextBox GetDeviceIP_TextBox;
        private System.Windows.Forms.TextBox GetDeviceTCPIP_TextBox;
        private System.Windows.Forms.Label HelpLabel3;
        private System.Windows.Forms.TextBox GetPairCode_TextBox;
        private System.Windows.Forms.Button ClickToConnect_Button;
        private System.Windows.Forms.GroupBox IpInfos_GroupBox;
    }
}