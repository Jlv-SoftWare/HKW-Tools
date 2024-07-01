using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using ToolsNT_API;

namespace HKW_Tools
{
    public partial class Frm_InstallAPP : Form
    {
        readonly MainFrm mainFrm;
        readonly string selectedDevice;

        public Frm_InstallAPP(MainFrm mainFrm, string selectDevice)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
            selectedDevice = selectDevice;
            Text = Text.Replace("<?>", selectedDevice);
        }

        private void SelectAPK_Button_Click(object sender, EventArgs e)
        {
            DialogResult SelectResult = SelectAPKDialog.ShowDialog();
            if (SelectResult == DialogResult.OK)
            {
                APKPath_TextBox.Text = SelectAPKDialog.FileName;
            }
        }

        private void ClickToInstallAPK_Button_Click(object sender, EventArgs e)
        {
            if (APKPath_TextBox.Text.Trim() == "")
            {
                MessageBox.Show("APK路径输入为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(APKPath_TextBox.Text))
            {
                MessageBox.Show("输入的APK路径无效", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckedToSignInstall_CheckBox.Checked)
            {
                
                ADB.APP.SignInstall(selectedDevice, APKPath_TextBox.Text);
            }
            else
            {
                ADB.APP.Install(selectedDevice, APKPath_TextBox.Text);
            }
            
            return;
        }

        private void APKPath_TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (filePath.ToLower().EndsWith("apk"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void APKPath_TextBox_DragDrop(object sender, DragEventArgs e)
        {
            APKPath_TextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void ClickTo_Open_Frm_AppStore_Button_Click(object sender, EventArgs e)
        {
            Frm_AppStore frm_AppStore = new Frm_AppStore(selectedDevice);
            frm_AppStore.ShowDialog();
        }

        private void Frm_InstallAPP_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }
    }
}
