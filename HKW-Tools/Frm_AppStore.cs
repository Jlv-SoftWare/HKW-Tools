using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ToolsNT_API;
using static ToolsNT_API.ToolsItems;
using ToolsNT_API.WebTools;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace HKW_Tools
{
    public partial class Frm_AppStore : Form
    {
        readonly string selectedDevice;

        APPStore.AppList appList;
        readonly Bitmap errorImage = new Bitmap(64, 64);
        readonly Bitmap noneBitmap = DrawA_NonePicture();

        public Frm_AppStore(string deviceID)
        {
            InitializeComponent();
            selectedDevice = deviceID;
            appList = APPStore.AppList.Get_APPInFos(Link.GetUrlJsonData("https://gitee.com/j-donkey/HKW-AppStore/raw/master/app-list.json"));
        }

        string LegalSaveName(string name)
        {
            return name.Replace("\\", "_")
                .Replace("/", "_")
                .Replace(":", "_")
                .Replace("*", "_")
                .Replace("?", "_")
                .Replace("\"", "_")
                .Replace("<", "_")
                .Replace(">", "_")
                .Replace("|", "_");
        }

        static Bitmap DrawA_NonePicture()
        {
            Bitmap bmp = new Bitmap(64, 64);

            // 使用 Graphics 从位图中获取画布
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                // 设置画布背景色为白色
                graphics.Clear(Color.Transparent);

                // 设置绘制文本的字体和颜色
                Font font = new Font("Microsoft YaHei UI", 24, FontStyle.Regular, GraphicsUnit.Pixel);
                SolidBrush brush = new SolidBrush(Color.Black);

                // 设置文本居中绘制
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                // 绘制文本（汉字 "无"）
                graphics.DrawString("无", font, brush, new RectangleF(0, 0, bmp.Width, bmp.Height), format);
            }
            return bmp;
        }
        Image GetUrlPicture(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(url);
                webClient.Dispose();

                // 将字节数组转换成图片
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            catch
            {
                return null;
            }
        }

        Bitmap ImageTo64x64BitMap(System.Drawing.Image image)
        {
            if (image != null)
            {
                Bitmap bitmap = new Bitmap(image, new Size(64, 64));
                return bitmap;
            }
            return null;
        }

        void ShowIconOn_IconBox(Image icon)
        {
            if (icon != null)
            {
                ShowIconBox.Image = icon;
            }

            else
            {
                ShowIconBox.Image = null;
                MessageBox.Show("图标加载失败!", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowInfoOn_GroupBoxItems()
        {
            if (Show_AppList_ListBox.SelectedItem != null)
            {
                ClearTextBoxes();
                int seletedAppNum = Show_AppList_ListBox.SelectedIndex;
                string appName = Show_AppList_ListBox.SelectedItem.ToString();
                string appVer = appList.Applist[seletedAppNum].Version;
                string appDescription = appList.Applist[seletedAppNum].Description;
                string appIconUrl = appList.Applist[seletedAppNum].Icon.ToLower() == "none" ? null : appList.Applist[seletedAppNum].Icon;
                ShowOnTextBoxes(appName, appVer, appDescription, appIconUrl);

            }
        }

        void ClearTextBoxes()
        {
            Show_AppName_TextBox.Text = "";
            Show_AppVer_TextBox.Text = "";
            Show_AppDescription_TextBox.Text = "";
            ShowIconBox.Image = errorImage;
        }

        void ShowOnTextBoxes(string name, string ver, string description, string iconUrl)
        {
            Show_AppName_TextBox.Text = name;
            Show_AppVer_TextBox.Text = ver;
            Show_AppDescription_TextBox.Text = description;
            if (iconUrl != null)
            {
                Image icon = GetUrlPicture(iconUrl);
                ShowIconOn_IconBox(ImageTo64x64BitMap(icon));
            }
            else
            {
                ShowIconBox.Image = noneBitmap;
            }
        }

        private void Frm_AppStore_Load(object sender, EventArgs e)
        {
            if (selectedDevice == null)
            {
                ClickTo_InstallSelectedApp_Button.Enabled = false;
                CheckedToSignApp_CheckBox.Enabled = false;
            }
            Show_AppList_ListBox.Items.Clear();
            foreach (var app in appList.Applist)
            {
                Show_AppList_ListBox.Items.Add(app.Name);
            }
        }

        private void Show_AppList_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowInfoOn_GroupBoxItems();
        }

        private void WebAppStoreLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread openStoreLink = new Thread(new ThreadStart(() =>
            {
                CommandHelper.Exec("start https://chiyang001.github.io/APP/", true);
                return;
            }));
            openStoreLink.Start();
        }

        private void ClickTo_SaveApk_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Show_AppList_ListBox.SelectedItem != null)
                {
                    DialogResult selectResult = SelectSaveDirDlg.ShowDialog();
                    if (selectResult == DialogResult.OK)
                    {
                        int selectedAppNum = Show_AppList_ListBox.SelectedIndex;
                        string downloadLink = appList.Applist[selectedAppNum].Url;
                        string downlaodFilename = $"{LegalSaveName(appList.Applist[selectedAppNum].Name)}.apk";
                        string aPKPath = Link.DownLoadFile(downloadLink, SelectSaveDirDlg.SelectedPath, downlaodFilename);
                        if (aPKPath != null)
                        {
                            MessageBox.Show($"下载完成!\n已经将文件保存到\"{aPKPath}\"", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"未知错误: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClickTo_InstallSelectedApp_Button_Click(object sender, EventArgs e)
        {
            string selectedAppName = Show_AppList_ListBox.SelectedItem.ToString();
            if (selectedAppName != null)
            {
                if (ADB.Devices.Exists(selectedDevice))
                {
                    int selectedAppIndex = Show_AppList_ListBox.SelectedIndex;
                    string savePath = Link.DownLoadFile(appList.Applist[selectedAppIndex].Url, Path.GetDirectoryName(Download_apk), Path.GetFileName(Download_apk));
                    if (savePath != null)
                    {
                        if (CheckedToSignApp_CheckBox.Checked)
                        {
                            ADB.APP.SignInstall(selectedDevice, savePath);
                        }
                        else
                        {
                            ADB.APP.Install(selectedDevice, savePath);
                        }

                        if (File.Exists(Download_apk))
                        {
                            File.Delete(Download_apk);
                        }
                    }
                }
            }
            
        }
    }
}
