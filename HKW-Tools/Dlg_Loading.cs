using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsNT_API;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HKW_Tools
{
    public partial class Dlg_Loading : Form
    {
        public Dlg_Loading(string dlgTitle, string tipsText)
        {
            InitializeComponent();
            Text = dlgTitle;
            TipsLabel.Text = tipsText;
            CheckForIllegalCrossThreadCalls = false;
            Load_ProgressBar.Style = ProgressBarStyle.Marquee;
            Load_ProgressBar.MarqueeAnimationSpeed = 1;
        }

        public Dlg_Loading(string dlgTitle, int barMinNum, int barMaxNum)
        {
            InitializeComponent();
            Text = dlgTitle;
            TipsLabel.Text = $"下载中[{0}%]";
            CheckForIllegalCrossThreadCalls = false;
            Load_ProgressBar.Minimum = barMinNum;
            Load_ProgressBar.Maximum = barMaxNum;

        }

        private void Dlg_Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public void UpdateProgressBar(int progressNum)
        {
            Load_ProgressBar.Value = progressNum;
            TipsLabel.Text = $"下载中[{progressNum}%]";
        }

        private void Dlg_Loading_Load(object sender, EventArgs e)
        {

        }
    }
}
