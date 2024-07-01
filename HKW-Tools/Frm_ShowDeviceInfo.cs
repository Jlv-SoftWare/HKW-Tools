using System;
using System.Windows.Forms;
using ToolsNT_API;

namespace HKW_Tools
{
    public partial class Frm_ShowDeviceInfo : Form
    {
        readonly string selectedDevice;

        public Frm_ShowDeviceInfo(string deviceID)
        {
            InitializeComponent();
            selectedDevice = deviceID;
            Text = $"设备 {selectedDevice} 的信息";
        }

        private void Frm_ShowDeviceInfo_Load(object sender, EventArgs e)
        {
            Show_DeviceInfo_TextBox.Text = ADB.Devices.Info(selectedDevice);
        }

    }
}
