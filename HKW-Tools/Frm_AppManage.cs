using System;
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
            
            APPList_ListBox.HorizontalScrollbar = true;
        }

        public void Show_ALL_APPS()
        {
            APPList_ListBox.Items.Clear();
            foreach (string APP_Package in ADB.APP.GetList.All(selectedDevice))
            {
                APPList_ListBox.Items.Add(APP_Package);
            }
        }

        public void Show_System_APPS()
        {
            APPList_ListBox.Items.Clear();
            foreach (string APP_Package in ADB.APP.GetList.Systems(selectedDevice))
            {
                APPList_ListBox.Items.Add(APP_Package);
            }
        }

        public void Show_Thirds_APPS()
        {
            APPList_ListBox.Items.Clear();
            foreach (string APP_Package in ADB.APP.GetList.Thirds(selectedDevice))
            {
                APPList_ListBox.Items.Add(APP_Package);
            }
        }

        public void Show_DISABLE_APPS()
        {
            APPList_ListBox.Items.Clear();
            foreach (string APP_Package in ADB.APP.GetList.Disables(selectedDevice))
            {
                APPList_ListBox.Items.Add(APP_Package);
            }
        }

        public void Show_ENABLE_APPS()
        {
            APPList_ListBox.Items.Clear();
            foreach (string APP_Package in ADB.APP.GetList.Enables(selectedDevice))
            {
                APPList_ListBox.Items.Add(APP_Package);
            }
        }

        private void Frm_APPManage_Load(object sender, EventArgs e)
        {
            Show_ALL_APPS();
        }

        private void ClickToShowALL_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            Show_ALL_APPS();
        }

        private void ClickToShowDISABLE_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            Show_DISABLE_APPS();
        }

        private void ClickToShowENABLE_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            Show_ENABLE_APPS();
        }

        private void ClickToShowSYSTEM_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            Show_System_APPS();
        }

        private void ClickToShowTHIRDS_APPS_RaidoButton_Click(object sender, EventArgs e)
        {
            Show_Thirds_APPS();
        }

        private void ReShow()
        {
            if (ClickToShowALL_APPS_RaidoButton.Checked)
            {
                Show_ALL_APPS();
            }
            if (ClickToShowDISABLE_APPS_RaidoButton.Checked)
            {
                Show_DISABLE_APPS();
            }
            if (ClickToShowENABLE_APPS_RaidoButton.Checked)
            {
                Show_ENABLE_APPS();
            }
            if (ClickToShowSYSTEM_APPS_RaidoButton.Checked)
            {
                Show_System_APPS();
            }
            if (ClickToShowTHIRDS_APPS_RaidoButton.Checked)
            {
                Show_Thirds_APPS();
            }
        }

        private string Get_SelectedApp()
        {
            if (APPList_ListBox.SelectedItem == null || APPList_ListBox.SelectedItem.ToString() == "无")
            {
                return null;
            }
            return APPList_ListBox.SelectedItem.ToString().Trim('\r', '\n');
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

        private void ClickToShowALL_APPS_RaidoButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Frm_APPManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }
    }
}
