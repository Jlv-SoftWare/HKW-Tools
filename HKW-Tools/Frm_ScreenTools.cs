using System;
using System.IO;
using System.Windows.Forms;
using ToolsNT_API;
using static ToolsNT_API.ToolsItems;

namespace HKW_Tools
{
    public partial class Frm_ScreenTools : Form
    {
        readonly MainFrm mainFrm;

        readonly string selectedDevice;

        public Frm_ScreenTools(MainFrm mainFrm, string deviceID)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
            selectedDevice = deviceID;
            Text = Text.Replace("<?>", selectedDevice);
        }

        void SetScreenSize()
        {
            if (Get_HightNum_Box.Text.Trim() != "" && Get_WightNum_Box.Text.Trim() != "")
            {
                int wight = int.Parse(Get_WightNum_Box.Text), hight = int.Parse(Get_HightNum_Box.Text);

                if (wight <= 73 && hight <= 73)
                {
                    MessageBox.Show("输入的数值必须大于等于73!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool doJob = MessageBox.Show($"确定分辨率设置为\n" +
                                            $"宽: {wight}\n" +
                                            $"高: {hight}"
                                            , ""
                                            , MessageBoxButtons.YesNo
                                            , MessageBoxIcon.Question) == DialogResult.Yes;
                
                if (doJob)
                {
                    ADB.Screen.Size.Set(selectedDevice, wight, hight);
                    MessageBox.Show("操作完成", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void SetScreenDPI()
        {
            if (Get_DPINum_Box.Text.Trim() != "")
            {
                int dpiNum = int.Parse(Get_DPINum_Box.Text);
                if (dpiNum <= 73)
                {
                    MessageBox.Show("输入的数值必须大于等于73!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool doJob = MessageBox.Show($"确定将DPI设置为{dpiNum}?"
                            , ""
                            , MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == DialogResult.Yes;
                if (doJob)
                {
                    ADB.Screen.Density.Set(selectedDevice, dpiNum);
                    MessageBox.Show("操作完成", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        void ResetScreenSize()
        {
            bool doJob = MessageBox.Show("确定重置分辨率?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (doJob)
            {
                ADB.Screen.Size.Reset(selectedDevice);
                MessageBox.Show("操作完成", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void ResetScreenDPI()
        {
            bool doJob = MessageBox.Show("确定重置DPI?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (doJob)
            {
                ADB.Screen.Density.Reset(selectedDevice);
                MessageBox.Show("操作完成", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void EnableHelpToSaveControls()
        {
            HelpLabel4.Enabled = true;
            Get_SaveVideoPathBox.Enabled = true;
        }

        void DisableHelpToSaveControls()
        {
            Get_SaveVideoPathBox.Text = "";
            HelpLabel4.Enabled = false;
            Get_SaveVideoPathBox.Enabled = false;
        }

        private void Get_HightNum_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // 取消非数字和控制键的输入
            }
        }

        private void Get_WightNum_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Get_DPINum_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Frm_ScreenTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }

        private void Get_WightNum_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetScreenSize();
            }
        }

        private void Get_DPINum_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetScreenDPI();
            }
        }

        private void ClickTo_SetScreenSize_Button_Click(object sender, EventArgs e)
        {
            SetScreenSize();
        }

        private void ClickTo_SetScreenDPISize_Button_Click(object sender, EventArgs e)
        {
            SetScreenDPI();
        }

        private void ClickToResetScreenSize_Button_Click(object sender, EventArgs e)
        {
            ResetScreenSize();
        }

        private void ClickTo_ResetScreenDPISize_Button_Click(object sender, EventArgs e)
        {
            ResetScreenDPI();
        }

        private void CheckTo_Record_CheckBox_Click(object sender, EventArgs e)
        {
            if (CheckTo_Record_CheckBox.Checked)
            {
                EnableHelpToSaveControls();
                if (SaveVideoDlg.ShowDialog() == DialogResult.OK)
                {
                    Get_SaveVideoPathBox.Text = SaveVideoDlg.FileName;
                }
                else
                {
                    
                    CheckTo_Record_CheckBox.Checked = false;
                    DisableHelpToSaveControls();
                }
            }
            else
            {
                DisableHelpToSaveControls();
            }
        }

        private void ClickTo_CastScreen_Button_Click(object sender, EventArgs e)
        {
            if (!File.Exists(scrcpy_exe))
            {
                MessageBox.Show("找不到投屏组件(Scrcpy)", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Visible = false;
            if (!CheckTo_Record_CheckBox.Checked)
            {
                ADB.Screen.Record(selectedDevice);
            }
            else
            {
                MessageBox.Show($"将会把录屏保存到\"{Path.GetDirectoryName(Get_SaveVideoPathBox.Text)}\"里"
                                ,""
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                ADB.Screen.Record(selectedDevice, Get_SaveVideoPathBox.Text);
            }
            Visible = true;
        }

        private void Frm_ScreenTools_Load(object sender, EventArgs e)
        {
            SaveVideoDlg.FileName = $"ScreenRecord_{DateTime.Now.Year}" +
                                    $"_{DateTime.Now.Month}" +
                                    $"_{DateTime.Now.Day}" +
                                    $"_{DateTime.Now.Hour}" +
                                    $"-{DateTime.Now.Minute}" +
                                    $"-{DateTime.Now.Second}.mp4";
        }

        private void ClickTo_Get_aScreenShot_Button_Click(object sender, EventArgs e)
        {
            if (SaveScreenShotDlg.ShowDialog() == DialogResult.OK)
            {
                string screenShotSavePath = ADB.Screen.Get_a_ScreenShot(selectedDevice, SaveScreenShotDlg.SelectedPath);
                if (screenShotSavePath != null)
                {
                    MessageBox.Show($"已经保存到了\"{Path.GetDirectoryName(screenShotSavePath)}\".", ""
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
