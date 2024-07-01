namespace HKW_Tools
{
    partial class Frm_ShowDeviceInfo
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
            this.Show_DeviceInfo_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Show_DeviceInfo_TextBox
            // 
            this.Show_DeviceInfo_TextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Show_DeviceInfo_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Show_DeviceInfo_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Show_DeviceInfo_TextBox.Location = new System.Drawing.Point(18, 12);
            this.Show_DeviceInfo_TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Show_DeviceInfo_TextBox.Multiline = true;
            this.Show_DeviceInfo_TextBox.Name = "Show_DeviceInfo_TextBox";
            this.Show_DeviceInfo_TextBox.ReadOnly = true;
            this.Show_DeviceInfo_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Show_DeviceInfo_TextBox.Size = new System.Drawing.Size(462, 237);
            this.Show_DeviceInfo_TextBox.TabIndex = 0;
            this.Show_DeviceInfo_TextBox.WordWrap = false;
            // 
            // Frm_ShowDeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(491, 260);
            this.Controls.Add(this.Show_DeviceInfo_TextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ShowDeviceInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备 <?> 的信息";
            this.Load += new System.EventHandler(this.Frm_ShowDeviceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Show_DeviceInfo_TextBox;
    }
}