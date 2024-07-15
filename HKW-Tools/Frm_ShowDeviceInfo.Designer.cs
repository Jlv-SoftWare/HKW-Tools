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
            this.HelpLabel1 = new System.Windows.Forms.Label();
            this.HelpLabel2 = new System.Windows.Forms.Label();
            this.HelpLabel3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelpLabel1
            // 
            this.HelpLabel1.AutoSize = true;
            this.HelpLabel1.Location = new System.Drawing.Point(33, 34);
            this.HelpLabel1.Name = "HelpLabel1";
            this.HelpLabel1.Size = new System.Drawing.Size(35, 17);
            this.HelpLabel1.TabIndex = 0;
            this.HelpLabel1.Text = "名称:";
            // 
            // HelpLabel2
            // 
            this.HelpLabel2.AutoSize = true;
            this.HelpLabel2.Location = new System.Drawing.Point(33, 63);
            this.HelpLabel2.Name = "HelpLabel2";
            this.HelpLabel2.Size = new System.Drawing.Size(82, 17);
            this.HelpLabel2.TabIndex = 1;
            this.HelpLabel2.Text = "Android版本:";
            // 
            // HelpLabel3
            // 
            this.HelpLabel3.AutoSize = true;
            this.HelpLabel3.Location = new System.Drawing.Point(33, 80);
            this.HelpLabel3.Name = "HelpLabel3";
            this.HelpLabel3.Size = new System.Drawing.Size(43, 17);
            this.HelpLabel3.TabIndex = 2;
            this.HelpLabel3.Text = "label1";
            // 
            // Frm_ShowDeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(491, 260);
            this.Controls.Add(this.HelpLabel3);
            this.Controls.Add(this.HelpLabel2);
            this.Controls.Add(this.HelpLabel1);
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

        private System.Windows.Forms.Label HelpLabel1;
        private System.Windows.Forms.Label HelpLabel2;
        private System.Windows.Forms.Label HelpLabel3;
    }
}