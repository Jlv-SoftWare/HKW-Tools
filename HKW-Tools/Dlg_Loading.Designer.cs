namespace HKW_Tools
{
    partial class Dlg_Loading
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
            this.Load_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TipsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Load_ProgressBar
            // 
            this.Load_ProgressBar.Location = new System.Drawing.Point(10, 26);
            this.Load_ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.Load_ProgressBar.Name = "Load_ProgressBar";
            this.Load_ProgressBar.Size = new System.Drawing.Size(212, 18);
            this.Load_ProgressBar.TabIndex = 0;
            // 
            // TipsLabel
            // 
            this.TipsLabel.AutoSize = true;
            this.TipsLabel.Location = new System.Drawing.Point(10, 7);
            this.TipsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TipsLabel.Name = "TipsLabel";
            this.TipsLabel.Size = new System.Drawing.Size(32, 17);
            this.TipsLabel.TabIndex = 1;
            this.TipsLabel.Text = "Tips";
            // 
            // Dlg_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(231, 53);
            this.Controls.Add(this.TipsLabel);
            this.Controls.Add(this.Load_ProgressBar);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_Loading_FormClosing);
            this.Load += new System.EventHandler(this.Dlg_Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label TipsLabel;
        public System.Windows.Forms.ProgressBar Load_ProgressBar;
    }
}