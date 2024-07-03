using System;
using System.Threading;
using System.Windows.Forms;
using ToolsNT_API;

namespace HKW_Tools
{
    public partial class Frm_AppManage : Form
    {
        readonly string selectedDevice;
        readonly MainFrm mainFrm;

        public Frm_AppManage(MainFrm mainFrm, string deviceID)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
            selectedDevice = deviceID;
            Text = Text.Replace("<?>", selectedDevice);
            CheckForIllegalCrossThreadCalls = false;
            APPList_ListBox.HorizontalScrollbar = true;
        }

        private void Frm_APPManage_Load(object sender, EventArgs e)
        {
            if (!ADB.APP.Infos.AAPTSettings.ExistsAAPT(selectedDevice))
            {
                ADB.APP.Infos.AAPTSettings.InstallAAPT(selectedDevice);
            }
            ReShow();
        }

        private void ClickToShowALL_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ClickToShowDISABLE_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ClickToShowENABLE_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ClickToShowSYSTEM_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ClickToShowTHIRDS_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ReShow()
        {
            Thread loadThread = new Thread(new ThreadStart(() =>
            {
                UninstallAPP_Button.Enabled = false;
                EnableAPP_Button.Enabled = false;
                DisableAPP_Button.Enabled = false;
                RadioButton_GroupBox.Enabled = false;
                if (ClickToShowALL_APPS_RaidoButton.Checked)
                {
                    APPList_ListBox.Items.Clear();
                    foreach (string app_Package in ADB.APP.GetList.All(selectedDevice))
                    {
                        APPList_ListBox.Items.Add($"[{ADB.APP.Infos.Get_Label(selectedDevice, app_Package)}] {app_Package}");
                    }
                }
                if (ClickToShowDISABLE_APPS_RaidoButton.Checked)
                {
                    APPList_ListBox.Items.Clear();
                    foreach (string app_Package in ADB.APP.GetList.Disables(selectedDevice))
                    {
                        APPList_ListBox.Items.Add($"[{ADB.APP.Infos.Get_Label(selectedDevice, app_Package)}] {app_Package}");
                    }
                }
                if (ClickToShowENABLE_APPS_RaidoButton.Checked)
                {
                    APPList_ListBox.Items.Clear();
                    foreach (string app_Package in ADB.APP.GetList.Enables(selectedDevice))
                    {
                        APPList_ListBox.Items.Add($"[{ADB.APP.Infos.Get_Label(selectedDevice, app_Package)}] {app_Package}");
                    }
                }
                if (ClickToShowSYSTEM_APPS_RaidoButton.Checked)
                {
                    APPList_ListBox.Items.Clear();
                    foreach (string app_Package in ADB.APP.GetList.Systems(selectedDevice))
                    {
                        APPList_ListBox.Items.Add($"[{ADB.APP.Infos.Get_Label(selectedDevice, app_Package)}] {app_Package}");
                    }
                }
                if (ClickToShowTHIRDS_APPS_RaidoButton.Checked)
                {
                    APPList_ListBox.Items.Clear();
                    foreach (string app_Package in ADB.APP.GetList.Thirds(selectedDevice))
                    {
                        APPList_ListBox.Items.Add($"[{ADB.APP.Infos.Get_Label(selectedDevice, app_Package)}] {app_Package}");
                    }
                }
                UninstallAPP_Button.Enabled = true;
                EnableAPP_Button.Enabled = true;
                DisableAPP_Button.Enabled = true;
                RadioButton_GroupBox.Enabled = true;
            }));
            loadThread.Start();
        }

        private string Get_SelectedApp()
        {
            if (APPList_ListBox.SelectedItem != null)
            {
                string app_Package = APPList_ListBox.SelectedItem.ToString();
                return app_Package.Substring(app_Package.LastIndexOf("] ") + 1).Trim('\r', '\n');
            }
            return null;
        }


        private void UninstallAPP_Button_Click(object sender, EventArgs e)
        {
            string selectedApp = Get_SelectedApp();
            if (selectedApp == null)
            {
                return;
            }
            DialogResult MessageResult = MessageBox.Show(
                $"确定卸载{selectedApp}?\n\'是\': 直接卸载\n" +
                $"\'否\': 保留数据卸载(你要有一个相同签名的安装包才可重新安装)", "警告",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation);
            if (MessageResult == DialogResult.Cancel)
            {
                return;
            }
            bool KeepData;
            if (MessageResult == DialogResult.Yes)
            {
                KeepData = false;
            }
            else
            {
                KeepData = true;
            }
            ADB.APP.Uninstall(selectedDevice, Get_SelectedApp(), KeepData);
            ReShow();
            return;
        }

        private void Frm_APPManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }

        private void PullAPP_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectedApp() != null)
            {
                string selectedApp = Get_SelectedApp();
                DialogResult selectResult = SelectDirDlg.ShowDialog();
                if (selectResult == DialogResult.OK)
                {
                    string saveDir = SelectDirDlg.SelectedPath;
                    bool saveOK = false;
                    Dlg_Loading saveApkProgressDlg = new Dlg_Loading("请等待", "正在保存Apk......");
                    Thread saveApkThread = new Thread(new ThreadStart(() =>
                    {
                        saveOK = ADB.APP.PullApp(selectedDevice, selectedApp, saveDir);
                        saveApkProgressDlg.Hide();
                        if (saveOK)
                        {
                            MessageBox.Show("提取成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("提取失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        saveApkProgressDlg.Close();
                    }));
                    saveApkThread.Start();
                    saveApkProgressDlg.ShowDialog();
                }
            }
        }

        private void DisableAPP_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectedApp() != null)
            {
                string selectedApp = Get_SelectedApp();
                ADB.APP.DisableApp(selectedDevice, selectedApp);
                MessageBox.Show("操作完成!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ReShow();
        }

        private void EnableAPP_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectedApp() != null)
            {
                string selectedApp = Get_SelectedApp();
                ADB.APP.EnableApp(selectedDevice, selectedApp);
                
                MessageBox.Show("操作完成!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ReShow();
        }
    }
}
