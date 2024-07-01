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

namespace HKW_Tools
{
    public partial class Frm_ConnectDevice : Form
    {
        private MainFrm mainFrm;

        public Frm_ConnectDevice(MainFrm mainFrm)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
        }

        private void ClickToConnect_Button_Click(object sender, EventArgs e)
        {
            if (GetPairCode_TextBox.Text.Trim() == "")
            {
                if (ADB.Devices.Connect(GetDeviceIP_TextBox.Text, GetDeviceTCPIP_TextBox.Text))
                {
                    MessageBox.Show($"成功连接到{GetDeviceIP_TextBox.Text}:{GetDeviceTCPIP_TextBox.Text}", "连接成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("连接失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ADB.Devices.Pair(GetDeviceIP_TextBox.Text, GetDeviceTCPIP_TextBox.Text, GetPairCode_TextBox.Text))
            {
                if (ADB.Devices.Connect(GetDeviceIP_TextBox.Text, GetDeviceTCPIP_TextBox.Text))
                {
                    MessageBox.Show($"成功配对到{GetDeviceIP_TextBox.Text}:{GetDeviceTCPIP_TextBox.Text}", "配对成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("配对失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Frm_ConnectDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }

        private void GetDeviceIP_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GetDeviceTCPIP_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GetPairCode_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (GetPairCode_TextBox.Text.Length == 6)
            {
                if (!char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }
    }
}
