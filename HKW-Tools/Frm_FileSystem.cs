using System;
using System.Threading;
using System.Windows.Forms;
using ToolsNT_API;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HKW_Tools
{
    public partial class Frm_FileSystem : Form
    {
        readonly string selectedDevice;
        MainFrm mainFrm;

        public Frm_FileSystem(MainFrm mainFrm, string deviceID)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
            CheckForIllegalCrossThreadCalls = false;
            LastOpened_Path = Input_MaxPath_TextBox.Text;
            selectedDevice = deviceID;
            Text = Text.Replace("<?>", selectedDevice);
        }

        const string IsFile = "文件", IsDir = "目录";

        bool MoveMode { get; set; }
        bool CopyMode { get; set; }
        string LastOpened_Path  { get; set; }

        private string Get_SelectChild()
        {
            if (ShowChilds_ListBox.SelectedItem == null)
            {
                return null;
            }
            string SelectItem = ShowChilds_ListBox.SelectedItem.ToString();
            return SelectItem.Substring(SelectItem.IndexOf("]") + 1).Trim('\r').Trim('\n');
        }

        private void DisableALLControls()
        {
            Text += " (请等待所有项加载完成)";
            Enabled = false;
        }

        private void EnableALLControls()
        {
            Text = Text.Replace(" (请等待所有项加载完成)", "");
            Enabled = true;
        }

        private void ReShow()
        {
            Thread reShowThread = new Thread(new ThreadStart(() =>
            {
                DisableALLControls();
                ShowChilds_ListBox.Items.Clear();
                if (!ADB.FM.Path_CanOpen(selectedDevice, Input_MaxPath_TextBox.Text))
                {
                    MessageBox.Show(Input_MaxPath_TextBox.Text);
                    MessageBox.Show("无法打开这个路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Input_MaxPath_TextBox.Text = LastOpened_Path;
                }

                string[] Childs = ADB.FM.GetChilds(selectedDevice, Input_MaxPath_TextBox.Text);
                ShowLoading_ProgressBar.Minimum = 0;
                ShowLoading_ProgressBar.Maximum = Childs.Length - 1;

                if (Childs[0] == "")
                {
                    Get_Name_TextBox.Text = "";
                    ShowLoading_ProgressBar.Maximum = 1;
                    ShowLoading_ProgressBar.Value = 1;
                    EnableALLControls();
                    return;
                }

                Get_Name_TextBox.Text = "";
                string Type;
                int Loadi = 0;

                foreach (string Child in Childs)
                {
                    Type = ADB.FM.Is_Dictionary(selectedDevice, ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Child))
                           ? IsDir : IsFile;
                    ShowChilds_ListBox.Items.Add($"[{Type}]{Child}");
                    ShowLoading_ProgressBar.Value = Loadi;
                    Show_PercentageProgess.Text = Math.Round((float)(Loadi + 1) / Childs.Length * 100).ToString();
                    Loadi++;
                }

                LastOpened_Path = Input_MaxPath_TextBox.Text;

                EnableALLControls();

            }));
            reShowThread.Start();
        }

        private void Frm_FileSystem_Load(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ClickTo_ReShow_Button_Click(object sender, EventArgs e)
        {
            ReShow();
        }

        private void ShowChilds_ListBox_DoubleClick(object sender, EventArgs e)
        {
            if (Get_SelectChild() == null)
            {
                return;
            }
            string OldPath = Input_MaxPath_TextBox.Text, Child = Get_SelectChild();
            string NewPath = ADB.FM.CombinePaths(OldPath, Child);
            if (ADB.FM.Is_Dictionary(selectedDevice, NewPath))
            {
                Input_MaxPath_TextBox.Text = NewPath;
                ReShow();
            }
        }

        private void ClickTo_GoTo_ParentPath_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Input_MaxPath_TextBox.Text.StartsWith("/"))
                {
                    Input_MaxPath_TextBox.Text = "/" + Input_MaxPath_TextBox.Text;
                }
                string ParentPath = ADB.FM.GetParentDir(Input_MaxPath_TextBox.Text);
                
                if (ParentPath == "")
                {
                    ParentPath =  "/";
                }
                Input_MaxPath_TextBox.Text = ParentPath;
                ReShow();
            }
            catch
            { 
                
            }
        }

        private void Input_MaxPath_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!ADB.FM.Exists(selectedDevice, Input_MaxPath_TextBox.Text))
                {
                    MessageBox.Show("找不到指定的路径","错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ReShow();
                e.SuppressKeyPress = true;
            }
        }

        private void ClickTo_UploadChild_Button_Click(object sender, EventArgs e)
        {
            if (!ADB.FM.Exists(selectedDevice, Input_MaxPath_TextBox.Text))
            {
                MessageBox.Show("找不到指定的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (SelectFileDlg.ShowDialog() == DialogResult.OK)
            {
                string FileToUpLoad = SelectFileDlg.FileName;
                if (MessageBox.Show($"确定上传\'{FileToUpLoad}\'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ADB.FM.UpLoad(selectedDevice, FileToUpLoad, Input_MaxPath_TextBox.Text))
                    {
                        MessageBox.Show("上传成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReShow();
                        return;
                    }
                }
            }
        }

        private void ClickTo_DownloadChild_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectChild() != null)
            {
                if (!ADB.FM.Exists(selectedDevice, Input_MaxPath_TextBox.Text))
                {
                    MessageBox.Show("找不到指定的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Child = Get_SelectChild();
                string ChildToDownLoad = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Child);
                if (SaveChildDlg.ShowDialog() == DialogResult.OK)
                {
                    string SaveDir = SaveChildDlg.SelectedPath;
                    if (MessageBox.Show($"确定下载\n{CommandHelper.RealSTR(ChildToDownLoad)}\n到\n{CommandHelper.RealSTR(SaveDir)}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ADB.FM.DownLoad(selectedDevice, ChildToDownLoad, SaveDir))
                        {
                            MessageBox.Show("下载成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void ClickTo_RemoveChild_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectChild() == null)
            {
                return;
            }
            string ChildToRemove = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_SelectChild());
            if (MessageBox.Show($"确定删除\'{ChildToRemove}\'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (ADB.FM.Delete(selectedDevice, ChildToRemove))
                {
                    MessageBox.Show("删除成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReShow();
                }
            }
        }

        private void ClickTo_CreateNewDirChild_Button_Click(object sender, EventArgs e)
        {
            if (!ADB.FM.Exists(selectedDevice, Input_MaxPath_TextBox.Text))
            {
                MessageBox.Show("找不到指定的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Input_MaxPath_TextBox.Text = "/storage/emulated/0";
                return;
            }
            if (Get_NewDirName_TextBox.Text.Trim() == "")
            {
                MessageBox.Show("文件夹名称为空", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ADB.FM.ContainsInvalidChars(Get_NewDirName_TextBox.Text))
            {
                MessageBox.Show("输入的名称含有非法字符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string DirToCreate = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_NewDirName_TextBox.Text);
            if (ADB.FM.CreateDir(selectedDevice, DirToCreate))
            {
                MessageBox.Show("创建成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Get_NewDirName_TextBox.Text = "";
                ReShow();
            }
            else
            {
                MessageBox.Show("创建失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClickTo_ReNameChild_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectChild() == null)
            {
                return;
            }
            if (ADB.FM.ContainsInvalidChars(Get_Name_TextBox.Text))
            {
                MessageBox.Show("输入的名称含有非法字符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Get_SelectChild() == Get_Name_TextBox.Text)
            {
                return;
            }
            if (MessageBox.Show($"确定重命名为\"{Get_Name_TextBox.Text}\"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string OldNamePath = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_SelectChild());
                string NewNamePath = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_Name_TextBox.Text);
                if (ADB.FM.ReName(selectedDevice, OldNamePath, NewNamePath))
                {
                    MessageBox.Show("重命名成功!", "" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReShow();
                }
                else
                {
                    MessageBox.Show("重命名失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClickTo_GotoInputPath_Button_Click(object sender, EventArgs e)
        {
            if (!ADB.FM.Exists(selectedDevice, Input_MaxPath_TextBox.Text))
            {
                MessageBox.Show("找不到指定的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Input_MaxPath_TextBox.Text = "/storage/emulated/0";
            }
            ReShow();
        }

        private void ClickTo_MoveChild_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectChild() == null)
            {
                return;
            }
            CopyMode = false;
            MoveMode = true;
            Clipboard_TextBox.Text = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_SelectChild());
        }

        private void ClickTo_CopyChild_Button_Click(object sender, EventArgs e)
        {
            if (Get_SelectChild() == null)
            {
                return;
            }
            CopyMode = true;
            MoveMode = false;
            Clipboard_TextBox.Text = ADB.FM.CombinePaths(Input_MaxPath_TextBox.Text, Get_SelectChild());
        }

        private void ClickTo_StickupChild_Button_Click(object sender, EventArgs e)
        {
            if (Clipboard_TextBox.Text.Trim() == "") 
            {
                return;
            }

            string ChildToCopy_Or_Move = Clipboard_TextBox.Text, ChildDir = ADB.FM.GetParentDir(ChildToCopy_Or_Move);
            string ChildSaveDir = Input_MaxPath_TextBox.Text;

            if (ChildDir == Input_MaxPath_TextBox.Text || ChildDir + '/' == Input_MaxPath_TextBox.Text)
            {
                return;
            }
            if (CopyMode)
            {
                DialogResult dialogResult = MessageBox.Show($"确定复制{ChildToCopy_Or_Move}到当前目录?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ADB.FM.Copy(selectedDevice, ChildToCopy_Or_Move, ChildSaveDir))
                    {
                        MessageBox.Show("复制成功!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clipboard_TextBox.Text = "";
                        ReShow();
                    }
                    else
                    {
                        MessageBox.Show("复制失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            if (MoveMode)
            {
                DialogResult dialogResult = MessageBox.Show($"确定移动{ChildToCopy_Or_Move}到当前目录?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ADB.FM.Move(selectedDevice, ChildToCopy_Or_Move, ChildSaveDir))
                    {
                        MessageBox.Show("移动成功!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clipboard_TextBox.Text = "";
                        ReShow();
                    }
                    else
                    {
                        MessageBox.Show("移动失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Frm_FileSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.ShowMainFrm();
        }

        private void ShowChilds_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Name_TextBox.Text = Get_SelectChild();
            Get_Name_TextBox.Text = Get_Name_TextBox.Text.Trim('\r').Trim('\n');
        }
    }
}
