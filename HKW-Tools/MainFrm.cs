using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToolsNT_API;
using static ToolsNT_API.ToolsItems;

namespace HKW_Tools
{
    public partial class MainFrm : Form
    {
        static string SelectedDeviceID { get; set; }

        Frm_ConnectDevice frm_ConnectDevice;
        Frm_InstallAPP frm_InstallAPP;
        Frm_FileSystem frm_FileSystem;
        Frm_AppManage frm_APPManage;
        Frm_ScreenTools frm_ScreenTools;

        public MainFrm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void ShowMainFrm()
        {
            Visible = true;
        }

        public static string GetSelectedDeviceID()
        {
            return SelectedDeviceID;
        }

        private string Get_SelectedDeviceID()
        {
            string showed = "";
            while (showed == "")
            {
                showed = ShowDevices_ComboBox.SelectedItem.ToString();
            }
            return showed;
        }

        private static bool HaveDevices()
        {
            if (!ADB.Devices.Have())
            {
                MessageBox.Show($"当前无设备连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void Sync_Devices()
        {
            string[] devices = ADB.Devices.List();
            string[] showedDevices = ShowDevices_ComboBox.Items.Cast<string>().ToArray();
            foreach (var newdevice in devices)
            {
                foreach (var showeddevice in showedDevices)
                {

                    if (!ShowDevices_ComboBox.Items.Contains(newdevice))
                    {
                        ShowDevices_ComboBox.Items.Add(newdevice);
                    }
                    if (!devices.Contains(showeddevice))
                    {
                        ShowDevices_ComboBox.Items.Remove(showeddevice);
                    }

                    if (ShowDevices_ComboBox.SelectedItem == null)
                    {
                        ShowDevices_ComboBox.SelectedIndex = 0;
                    }

                    if (showedDevices[0] == "无")
                    {
                        ShowNumOfDevices_Label.Text = $"当前无设备连接";
                    }
                    else
                    {
                        ShowNumOfDevices_Label.Text = $"当前连接了 {devices.Length} 个设备";
                    }
                }
            }
        }

        public void MainFrm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.GetDirectoryName(Download_apk)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Download_apk));
            }
            
            if (ShowDevices_ComboBox.Items.Count == 0)
            {
                ShowDevices_ComboBox.Items.Clear();
                foreach (string item in ADB.Devices.List())
                {
                    ShowDevices_ComboBox.Items.Add(item);
                }
                ShowDevices_ComboBox.SelectedIndex = 0;
            }
            Thread sync_DevicesThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Sync_Devices();
                    Thread.Sleep(950);
                }
            }));
            sync_DevicesThread.Start();
        }

        private void Open_Frm_ConnectDevice_Button_Click(object sender, EventArgs e)
        {
            if (frm_ConnectDevice == null || frm_ConnectDevice.IsDisposed)
            {
                frm_ConnectDevice = new Frm_ConnectDevice(this);
                
            }
            frm_ConnectDevice.Show();
            Visible = false;
        }

        private void Open_Frm_InstallAPP_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {
                if (frm_InstallAPP == null || frm_InstallAPP.IsDisposed)
                {
                    frm_InstallAPP = new Frm_InstallAPP(this, Get_SelectedDeviceID());
                }
                frm_InstallAPP.Show();
                Visible = false;
            }
            
        }



        private void Open_Frm_SpecialFuns_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {

            }
        }

        private void Open_Frm_FileSystem_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {
                if (frm_FileSystem == null || frm_FileSystem.IsDisposed)
                {
                    frm_FileSystem = new Frm_FileSystem(this, Get_SelectedDeviceID());
                    
                }
                frm_FileSystem.Show();
                Visible = false;
            }
            
        }

        private void Open_Frm_APPManage_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {
                if (frm_APPManage == null || frm_APPManage.IsDisposed)
                {
                    frm_APPManage = new Frm_AppManage(this, Get_SelectedDeviceID());
                }
                frm_APPManage.Show();
                Visible = false;
            }
            
        }

        private void Open_Frm_ShowDeviceInfo_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {
                Frm_ShowDeviceInfo frm_ShowDeviceInfo = new Frm_ShowDeviceInfo(Get_SelectedDeviceID());
                frm_ShowDeviceInfo.Show();
            }
        }

        private void LinkDeviceShell_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (HaveDevices())
            {
                ADB.Devices.LinkShell(Get_SelectedDeviceID());
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitResult = MessageBox.Show("确定退出HKW工具箱?", "确定退出?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exitResult == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            ADB.Server.Stop();
            Hide();
            Environment.Exit(0);
        }

        private void Open_Frm_ScreenTools_Button_Click(object sender, EventArgs e)
        {
            if (HaveDevices())
            {
                if (frm_ScreenTools == null || frm_ScreenTools.IsDisposed)
                {
                    frm_ScreenTools = new Frm_ScreenTools(this, Get_SelectedDeviceID());
                }
                frm_ScreenTools.Show();
                Visible = false;
            }
        }

        private void Open_Frm_AppStore_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deviceID = Get_SelectedDeviceID();
            Frm_AppStore frm_AppStore = new Frm_AppStore(deviceID == "无" ? null : deviceID);
            frm_AppStore.ShowDialog();
        }
    }
}
