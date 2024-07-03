using HKW_Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static ToolsNT_API.ToolsItems;

namespace ToolsNT_API
{
    static class ToolsItems
    {
        public static string
        InstallPath = AppDomain.CurrentDomain.BaseDirectory,
        adb_exe_path = Path.Combine(InstallPath, "ADB", "adb.exe"),
        adb_exe = $"\"{adb_exe_path}\"",
        AdbWinApi_dll = Path.Combine(InstallPath, "ADB", "AdbWinApi.dll"),
        AdbWinUsbApi_dll = Path.Combine(InstallPath, "ADB", "AdbWinUsbApi.dll"),
        ToolsNT_exe_path = Path.Combine(InstallPath, "ToolsNT.exe"),
        ToolsNT_exe = $"\"{ToolsNT_exe_path}\"",
        aapt_arm_pie = Path.Combine(InstallPath, "Tools", "aapt-arm-pie"),
        aapt_arm_pie_on_device = "/data/local/tmp/aapt-arm-pie",
        testkey_pk8_path = Path.Combine(InstallPath, "Tools", "testkey.pk8"),
        testkey_pk8 = $"\"{testkey_pk8_path}\"",
        testkey_x509_pem_path = Path.Combine(InstallPath, "Tools", "testkey.x509.pem"),
        testkey_x509_pem = $"\"{testkey_x509_pem_path}\"",
        apksigner_jar_path = Path.Combine(InstallPath, "Tools", "apksigner.jar"),
        apksigner_jar = $"\"{apksigner_jar_path}\"",
        zipalign_exe_path = Path.Combine(InstallPath, "Tools", "zipalign.exe"),
        zipalign_exe = $"\"{zipalign_exe_path}\"",
        align_Dir = Path.Combine(InstallPath, "Align"),
        sign_Dir = Path.Combine(InstallPath, "Dist"),
        aligned_Apk = Path.Combine(align_Dir, "Align.apk"),
        signed_Apk = Path.Combine(sign_Dir, "Signed.apk"),
        scrcpy_exe_path = Path.Combine(InstallPath, "ADB", "scrcpy.exe"),
        scrcpy_exe = $"\"{scrcpy_exe_path}\"",
        Download_apk = Path.Combine(InstallPath, "Downloads", "Download.apk");
        public const string AppVersion = "1.2.0";
    }

    static class CommandHelper
    {
        public static string Exec(string command, bool createNoWindow)
        {
            command = (command.Trim().TrimEnd('&') + "&exit").Trim('\r', '\n');
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = createNoWindow;          //不显示程序窗口
                p.Start();//启动程序
                          //向cmd窗口写入命令
                p.StandardInput.WriteLine(command);
                p.StandardInput.AutoFlush = true;
                //获取cmd窗口的输出信息
                StreamReader reader = p.StandardOutput;//截取输出流
                StreamReader error = p.StandardError;//截取错误信息
                string Returnedstr = reader.ReadToEnd() + error.ReadToEnd();
                Returnedstr = Returnedstr.Substring(Returnedstr.IndexOf("&exit")).Substring(7);
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
                return Returnedstr.TrimEnd('\r', '\n');
            }
        }

        public static string Exec_UTF8(string command, bool createNoWindow)
        {
            command = (command.Trim().TrimEnd('&') + "&exit").Trim('\r', '\n');

            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;        // 是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  // 由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   // 重定向标准错误输出
                p.StartInfo.CreateNoWindow = createNoWindow; // 不显示程序窗口

                // Set the output encoding to UTF-8
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.StartInfo.StandardErrorEncoding = Encoding.UTF8;

                p.Start(); // 启动程序

                // 向cmd窗口写入命令，设置 chcp 65001 (UTF-8)
                p.StandardInput.WriteLine("chcp 65001");
                p.StandardInput.WriteLine(command);
                p.StandardInput.AutoFlush = true;

                // 获取cmd窗口的输出信息
                StreamReader outputReader = p.StandardOutput; // 截取输出流
                StreamReader errorReader = p.StandardError; // 截取错误信息

                // 读取输出和错误信息
                string output = outputReader.ReadToEnd();
                string error = errorReader.ReadToEnd();

                // 等待程序执行完退出进程
                p.WaitForExit();
                p.Close();

                // 处理输出信息
                string returnedStr = output + error;
                int exitIndex = returnedStr.IndexOf("&exit");
                if (exitIndex >= 0)
                {
                    returnedStr = returnedStr.Substring(exitIndex + 5).Trim(); // 去掉 &exit 及之前的信息
                }

                return returnedStr.TrimEnd('\r', '\n');
            }
        }

        public static string RealSTR(string str)
        {
            return str.Replace("\n", "\\n").Replace("\r", "\\r").Replace(" ","<空格>");
        }
    }

    static class ADB
    {
        public static class Server
        {
            public static void Start()
            {
                Dlg_Loading startserver_Progress = new Dlg_Loading("初始化", "正在启动ADB服务");
                Thread startserver_Thread = new Thread(new ThreadStart(() =>
                {
                    CommandHelper.Exec_UTF8($"{adb_exe} start-server", true);
                    startserver_Progress.Hide();
                    startserver_Progress.Close();
                    return;
                }));
                startserver_Thread.Start();
                startserver_Progress.ShowDialog();
                return;
            }

            public static void ReStart()
            {
                Dlg_Loading restartserver_Progress = new Dlg_Loading("操作", "正在重启ADB服务");
                Thread restartserver_Thread = new Thread(new ThreadStart(() =>
                {
                    CommandHelper.Exec_UTF8($"{adb_exe} kill-server &{adb_exe} start-server", true);
                    restartserver_Progress.Hide();
                    restartserver_Progress.Close();
                    return;
                }));
                restartserver_Thread.Start();
                restartserver_Progress.ShowDialog();
                return;
            }

            public static void Stop()
            {
                Dlg_Loading stopserver_Progress = new Dlg_Loading("操作", "正在停止ADB服务");
                Thread stopserver_Thread = new Thread(new ThreadStart(() =>
                {
                    CommandHelper.Exec_UTF8($"{adb_exe} kill-server", true);
                    stopserver_Progress.Hide();
                    stopserver_Progress.Close();
                    return;
                }));
                stopserver_Thread.Start();
                stopserver_Progress.ShowDialog();
            }
        }
        
        public static class Devices
        {

            public static string[] List()
            {
                string result = CommandHelper.Exec($"{adb_exe} devices", true);

                // 处理命令输出，提取设备列表
                string[] lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> devices = new List<string>();
                foreach (string line in lines)
                {
                    if (line.EndsWith("\toffline") || line.StartsWith("List of "))
                    {
                        continue;
                    }
                    string deviceName = line.Substring(0, line.LastIndexOf("\tdevice"));
                    devices.Add(deviceName.Trim());
                }
                if (devices.Count == 0)
                {
                    return new string[] { "无" };
                }
                return devices.ToArray();
            }

            public static bool Connect(string ip, string tcp_ip)
            {
                if (Exists($"{ip}:{tcp_ip}"))
                {
                    return true;
                }
                Dlg_Loading Connecting_Progress = new Dlg_Loading("连接中", $"正在连接到{ip}:{tcp_ip}");
                string ConnectResult = ""; bool JobResult = false;
                Thread Connecting_Thread = new Thread(new ThreadStart(() =>
                {
                    ConnectResult = CommandHelper.Exec_UTF8($"{adb_exe} connect {ip}:{tcp_ip}", true);
                    if (ConnectResult.StartsWith("connected to"))
                    {
                        JobResult = true;
                    }
                    Connecting_Progress.Hide();
                    Connecting_Progress.Close();
                    return;
                }));
                Connecting_Thread.Start();
                Connecting_Progress.ShowDialog();
                return JobResult;
            }

            public static bool Pair(string ip, string tcp_ip, string pairCode)
            {
                Dlg_Loading Connecting_Progress = new Dlg_Loading("配对中", $"正在配对到{ip}:{tcp_ip}");
                string ConnectResult = ""; bool JobResult = false;
                Thread Connecting_Thread = new Thread(new ThreadStart(() =>
                {
                    ConnectResult = CommandHelper.Exec_UTF8($"{adb_exe} pair {ip}:{tcp_ip} {pairCode}",true);
                    if (ConnectResult.StartsWith("Successfully paired"))
                    {
                        JobResult = true;
                    }
                    Connecting_Progress.Hide();
                    Connecting_Progress.Close();
                    return;
                }));
                Connecting_Thread.Start();
                Connecting_Progress.ShowDialog();
                return JobResult;
            }

            public static bool Have()
            {
                if (List().Contains("无"))
                {
                    return false;
                }
                return true;
            }
           
            public static bool Exists(string deviceID)
            {
                bool Result;
                if (!List().Contains(deviceID))
                {
                    Result = false;
                }
                else
                {
                    Result = true;
                }
                return Result;
            }

            public static string Info(string deviceID)
            {
                return CommandHelper.Exec($"ToolsNT deviceinfo {deviceID}", true);
            }

            public static void LinkShell(string deviceID)
            {
                Thread linkThread = new Thread(new ThreadStart(() =>
                {
                    CommandHelper.Exec_UTF8($"start ToolsNT linkshell {deviceID}", true);
                }));
                linkThread.Start();
            }
        }

        public static class APP
        {
            public static string GetAppApkPath(string deviceID, string app_Package)
            {
                return CommandHelper.Exec($"{adb_exe} -s {deviceID} shell pm path {app_Package}", true).Replace("package:", "");
            }

            public static bool PullApp(string deviceID, string app_Package, string saveDir)
            {
                string appApkPath = GetAppApkPath(deviceID, app_Package);
                return FM.DownLoad(deviceID, appApkPath, saveDir, $"{app_Package}.apk");
            }

            public static class GetList
            {
                public static string[] All(string deviceID)
                {
                    string command = $"{adb_exe} -s {deviceID} shell pm list packages";
                    string[] noapps = { "无" }, appList = CommandHelper.Exec_UTF8(command, true).Trim().Replace("package:", "").Split('\n');

                    if (appList[0] == "")
                    {
                        return noapps;
                    }
                    return appList;
                }

                public static string[] Thirds(string deviceID)
                {
                    string command = $"{adb_exe} -s {deviceID} shell pm list packages -3";
                    string[] noapps = { "无" }, appList = CommandHelper.Exec_UTF8(command, true).Trim().Replace("package:", "").Split('\n');

                    if (appList[0] == "")
                    {
                        return noapps;
                    }
                    return appList;
                }

                public static string[] Systems(string deviceID)
                {
                    string command = $"{adb_exe} -s {deviceID} shell pm list packages -s";
                    string[] noapps = { "无" }, appList = CommandHelper.Exec_UTF8(command, true).Trim().Replace("package:", "").Split('\n');

                    if (appList[0] == "")
                    {
                        return noapps;
                    }
                    return appList;
                }

                public static string[] Disables(string deviceID)
                {
                    string command = $"{adb_exe} -s {deviceID} shell pm list packages -d";
                    string[] noapps = { "无" }, appList = CommandHelper.Exec_UTF8(command, true).Trim().Replace("package:", "").Split('\n');

                    if (appList[0] == "")
                    {
                        return noapps;
                    }
                    return appList;
                }

                public static string[] Enables(string deviceID)
                {
                    string command = $"{adb_exe} -s {deviceID} shell pm list packages -e";
                    string[] noapps = { "无" }, appList = CommandHelper.Exec_UTF8(command, true).Trim().Replace("package:", "").Split('\n');

                    if (appList[0] == "")
                    {
                        return noapps;
                    }
                    return appList;
                }
            }

            public static class Infos
            {
                public static class AAPTSettings
                {
                    public static bool ExistsAAPT(string DeviceID)
                    {
                        if (FM.Exists(DeviceID, "/data/local/tmp/aapt-arm-pie"))
                        {
                            return true;
                        }
                        return false;
                    }

                    public static bool InstallAAPT(string deviceID)
                    {
                        if (FM.UpLoad(deviceID, aapt_arm_pie, "/data/local/tmp/"))
                        {
                            CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell chmod 0755 /data/local/tmp/aapt-arm-pie", true);
                            return true;
                        }
                        return false;
                    }
                }

                static string GetInfos(string deviceID, string app_Package)
                {
                    return CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell {aapt_arm_pie_on_device} d badging {GetAppApkPath(deviceID, app_Package)}", true);;
                }

                public static string Get_Label(string deviceID, string app_Package)
                {
                    string appInfo = GetInfos(deviceID, app_Package);
                    appInfo = appInfo.Substring(appInfo.IndexOf("application-label:'") + 19);
                    string appName = appInfo.Substring(0, appInfo.IndexOf("\'"));
                    return appName;
                }
            }

            public static bool Exists(string deviceID, string app_Package)
            {
                if (!GetList.All(deviceID).Contains(app_Package))
                {
                    return false;
                }
                return true;
            }

            public static void Install(string deviceID, string aPK_Path)
            {
                if (!Devices.Exists(deviceID))
                {
                    MessageBox.Show($"找不到设备\"{deviceID}\"", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!File.Exists(aPK_Path))
                {
                    MessageBox.Show($"找不到文件\"{aPK_Path}\"", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string installResult;
                Dlg_Loading install_Progress = new Dlg_Loading("安装中",$"正在安装APK到\"{deviceID}\"");
                Thread install_Thread = new Thread(new ThreadStart(() =>
                {
                    installResult = CommandHelper.Exec($"{adb_exe} -s {deviceID} install -r -t -d \"{aPK_Path}\"", true);
                    install_Progress.Hide();
                    if (installResult.EndsWith("Success"))
                    {
                        MessageBox.Show($"安装成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"安装失败,ADB返回信息:\n{installResult}", "失败");
                    }
                    install_Progress.Close();
                    return;
                }));
                install_Thread.Start();
                install_Progress.ShowDialog();
                return;
            }

            public static void SignInstall(string deviceID, string aPK_Path)
            {
                string signedAPK_Path = "";
                Dlg_Loading sign_Progress = new Dlg_Loading("签名中", $"正在签名APK");
                Thread sign_Thread = new Thread(new ThreadStart(() =>
                {
                    signedAPK_Path = Sign(aPK_Path);
                    sign_Progress.Hide();
                    if (signedAPK_Path == null)
                    {
                        MessageBox.Show($"签名失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sign_Progress.Close();
                    return;
                }));
                sign_Thread.Start();
                sign_Progress.ShowDialog();

                Install(deviceID, signedAPK_Path);

                File.Delete(aligned_Apk);
                File.Delete(signedAPK_Path);
            }
            
            private static string Sign(string aPK_Path)
            {
                if (!File.Exists(aPK_Path))
                {
                    return null;
                }

                if (!Directory.Exists(align_Dir))
                {
                    Directory.CreateDirectory(align_Dir);
                }

                if (!Directory.Exists(sign_Dir))
                {
                    Directory.CreateDirectory(sign_Dir);
                }

                string command_Align = $"{zipalign_exe} -v 4 {aPK_Path} {aligned_Apk}",
                       command_Sign = $"java -jar {apksigner_jar} sign " +
                                      $"--key {testkey_pk8} " +
                                      $"--cert {testkey_x509_pem} " +
                                      $"--out \"{signed_Apk}\" \"{aligned_Apk}\"";
                CommandHelper.Exec(command_Align, true);
                if (!File.Exists(aligned_Apk))
                {
                    return null;
                }
                CommandHelper.Exec(command_Sign, true);
                if (!File.Exists(signed_Apk))
                {
                    return null;
                }
                return signed_Apk;

            }
            
            public static void Uninstall(string deviceID, string app_Package, bool keepData)
            {
                if (!Devices.Exists(deviceID))
                {
                    MessageBox.Show($"找不到设备\"{deviceID}\"", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*
                if (!GetList.All(deviceID).Contains(app_Package))
                {
                    MessageBox.Show($"找不到APP\"{app_Package}\"", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */
                string Command = !keepData ? $"{adb_exe} -s {deviceID} uninstall {app_Package}" : $"{adb_exe} -s {deviceID} shell cmd package uninstall -k {app_Package}";
                string installResult;
                Dlg_Loading uninstall_Progress = new Dlg_Loading("卸载中",$"卸载APP:\"{app_Package}\"");
                Thread uninstall_Thread = new Thread(new ThreadStart(() =>
                {
                    installResult = CommandHelper.Exec_UTF8(Command, true);
                    uninstall_Progress.Hide();
                    if (installResult.EndsWith("Success"))
                    {
                        MessageBox.Show($"卸载成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"卸载失败,ADB返回信息:\n{installResult}", "失败");
                    }
                    uninstall_Progress.Close();
                    return;
                }));
                uninstall_Thread.Start();
                uninstall_Progress.ShowDialog();
                return;
            }

            public static void EnableApp(string devicesID, string app_Package)
            {
                CommandHelper.Exec($"{adb_exe} -s {devicesID} shell pm enable {app_Package}", true);
            }

            public static void DisableApp(string devicesID, string app_Package)
            {
                CommandHelper.Exec($"{adb_exe} -s {devicesID} shell pm disable-user {app_Package}", true);
            }
        }

        public static class Screen
        {
            public static class Size
            {
                public static void Set(string deviceID, int wight, int hight)
                {
                    CommandHelper.Exec($"{adb_exe} -s {deviceID} shell wm size {wight}x{hight}", true);
                }

                public static void Reset(string deviceID)
                {
                    CommandHelper.Exec($"{adb_exe} -s {deviceID} shell wm size reset", true);
                }
            }

            public static class Density
            {
                public static void Set(string deviceID, int dpiSize)
                {
                    CommandHelper.Exec($"{adb_exe} -s {deviceID} shell wm density {dpiSize}", true);
                }

                public static void Reset(string deviceID)
                {
                    CommandHelper.Exec($"{adb_exe} -s {deviceID} shell wm density reset", true);
                }
            }

            public static void Record(string deviceID)
            {
                CommandHelper.Exec($"{scrcpy_exe} -s {deviceID}",true);
            }

            public static void Record(string deviceID, string saveVideoPath)
            {
                CommandHelper.Exec_UTF8($"{scrcpy_exe} -s {deviceID} -r {saveVideoPath}", true);
            }

            public static string Get_a_ScreenShot(string deviceID, string screenShotSaveDir)
            {
                string screenShotSavePath = Path.Combine(screenShotSaveDir, "ScreenShot.png");
                int screenShotNum = 1;
                while (File.Exists(screenShotSavePath))
                {
                    screenShotSavePath = Path.Combine(screenShotSaveDir, $"ScreenShot({screenShotNum}).png");
                    screenShotNum++;
                }
                CommandHelper.Exec($"{adb_exe} -s {deviceID} shell screencap /sdcard/screenshit.png&" +
                                   $"{adb_exe} -s {deviceID} pull /sdcard/screenshit.png {screenShotSavePath}&" +
                                   $"{adb_exe} -s {deviceID} shell rm -f /sdcard/screenshit.png", true);
                if (File.Exists(screenShotSavePath))
                {
                    return screenShotSavePath;
                }
                return null;
            }

        }

        public static class FM
        {
            public static bool Exists(string deviceID, string maxPath)
            {
                string Command = $"{adb_exe} -s {deviceID} shell [ -e \"{maxPath}\" ] && echo \"True\" || echo \"False\"";
                bool BOOL;
                switch (CommandHelper.Exec(Command, true).Trim())
                {
                    case "\"True\"":
                        BOOL = true;
                        break;

                    case "\"False\"":
                        BOOL = false;
                        break;

                    default:
                        BOOL = false;
                        break;
                }
                return BOOL;
            }

            public static bool Path_CanOpen(string deviceID, string maxPath)
            {
                if (!Exists(deviceID, maxPath))
                {
                    return false;
                }
                if (CommandHelper.Exec($"{adb_exe} -s {deviceID} shell ls {maxPath}", true).StartsWith("ls: "))
                {
                    return false;
                }
                return true;
            }

            public static bool Is_Dictionary(string deviceID, string maxPath)
            {
                string Command = $"{adb_exe} -s {deviceID} shell [ -d \"{maxPath}\" ] && echo \"True\" || echo \"False\"";
                bool BOOL;
                switch (CommandHelper.Exec_UTF8(Command, true).Trim())
                {
                    case "\"False\"": 
                        BOOL = false;
                        break;

                    default:
                        BOOL = true; 
                        break;
                }
                return BOOL;

            }

            public static string GetParentDir(string maxPath)
            {
                string ParentDir = maxPath;
                if (ParentDir.EndsWith("/"))
                {
                    ParentDir = ParentDir.Substring(0, ParentDir.LastIndexOf('/'));
                }
                return ParentDir.Substring(0, ParentDir.LastIndexOf('/')).Trim('\r').Trim('\n');
            }

            public static string GetFileName(string maxPath)
            {
                if (maxPath.EndsWith("/"))
                {
                    maxPath.TrimEnd('/');
                }
                return maxPath.Substring(maxPath.LastIndexOf("/") + 1);
            }

            public static string CombinePaths(string path1, string path2)
            {
                if (path1.EndsWith("/") || path1.EndsWith("\\"))
                {
                    return (path1 + path2).Trim('\r').Trim('\n');
                }
                else
                {
                    return (path1 + "/" + path2).Trim('\r').Trim('\n');
                }
            }

            public static string[] GetChilds(string deviceID, string maxPath)
            {
                return CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell ls {maxPath}", true).Split('\n');
            }

            public static bool DownLoad(string deviceID, string devicePath, string saveDir)
            {
                
                string SavePath = Path.Combine(saveDir, GetFileName(devicePath));
                if (!Directory.Exists(saveDir))
                {
                    return false;
                }

                string Command = $"{adb_exe} -s {deviceID} pull \"{devicePath}\" \"{saveDir}\"";
                CommandHelper.Exec(Command, true);
                if (Directory.Exists(SavePath) || File.Exists(SavePath))
                {
                    return true;
                }
                return false;
            }

            public static bool DownLoad(string deviceID, string devicePath, string saveDir, string saveFileName)
            {

                string savePath = Path.Combine(saveDir, saveFileName);
                if (!Directory.Exists(saveDir))
                {
                    return false;
                }

                string Command = $"{adb_exe} -s {deviceID} pull \"{devicePath}\" \"{Path.Combine(savePath)}\"";
                CommandHelper.Exec(Command, true);
                if (Directory.Exists(savePath) || File.Exists(savePath))
                {
                    return true;
                }
                return false;
            }

            public static bool UpLoad(string deviceID, string maxPath, string device_SaveDir)
            {
                string Command = $"{adb_exe} -s {deviceID} push \"{maxPath}\" \"{device_SaveDir}\"";
                string DevicePath = CombinePaths(device_SaveDir, Path.GetFileName(maxPath));
                CommandHelper.Exec(Command, true);
                if (Exists(deviceID, DevicePath))
                {
                    return true;
                }
                return false;
            }

            public static bool Delete(string deviceID, string devicePath)
            {
                string Command = $"{adb_exe} -s {deviceID} shell rm -rf \"{devicePath}\"";
                CommandHelper.Exec_UTF8(Command, true);

                if (!Exists(deviceID, devicePath))
                {
                    return true;
                }
                return false;
            }

            public static bool CreateDir(string deviceID, string dirPathToCreate)
            {
                CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell mkdir -p {dirPathToCreate}", true);
                
                if (Exists(deviceID, dirPathToCreate))
                {
                    return true;
                }
                return false;
            }

            public static bool Copy(string deviceID, string devicePathToCopy, string deviceSaveDir)
            {
                if (!Exists(deviceID, devicePathToCopy) && !Exists(deviceID, deviceSaveDir))
                {
                    return false;
                }
                string SavePath = CombinePaths(deviceSaveDir, GetFileName(devicePathToCopy));
                CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell cp -f \"{devicePathToCopy}\" \"{deviceSaveDir}\"", true);
                if (Exists(deviceID, SavePath))
                {
                    return true;
                }
                return false;
            }

            public static bool Move(string deviceID, string devicePathToMove, string deviceSaveDir)
            {
                if (!Exists(deviceID, devicePathToMove) && !Exists(deviceID, deviceSaveDir))
                {
                    return false;
                }
                string SavePath = CombinePaths(deviceSaveDir, GetFileName(devicePathToMove));
                CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell mv -f \"{devicePathToMove}\" \"{deviceSaveDir}\"", true);
                if (Exists(deviceID, SavePath))
                {
                    return true;
                }
                return false;
            }

            public static bool ReName(string deviceID, string deviceOldNamePath, string deviceNewNamePath)
            {
                if (!Exists(deviceID, deviceOldNamePath))
                {
                    return false;
                }
                CommandHelper.Exec_UTF8($"{adb_exe} -s {deviceID} shell mv -f \"{deviceOldNamePath}\" \"{deviceNewNamePath}\"", true);
                if (Exists(deviceID, deviceNewNamePath))
                {
                    return true;
                }
                return false;
            }

            public static bool ContainsInvalidChars(string path)
            {
                char[] invalidPathChars = { '/', '\\', '?', '*', ':', '"', '<', '>', '|' };

                return path.Any(c => invalidPathChars.Contains(c));
            }
        }

        public static bool ExistsADBItems()
        {
            if (!File.Exists(adb_exe_path) || !File.Exists(AdbWinApi_dll) || !File.Exists(AdbWinUsbApi_dll))
            {
                return false;
            }
            return true;
        }

        public static bool ExistsToolsNT()
        {
            if (!File.Exists(ToolsNT_exe_path))
            {
                return false;
            }
            return true;
        }
    }

    namespace WebTools
    {
        public static class Link
        {
            static async Task<string> DownloadFileAsync(string fileUrl, string saveDir, string saveFileName)
            {
                string savePath = Path.Combine(saveDir, saveFileName);
                string saveFileExtension = Path.GetExtension(savePath);

                int fileNameNum = 1;

                while (File.Exists(savePath))
                {
                    savePath = Path.Combine(saveDir, $"{saveFileName}({fileNameNum}){saveFileExtension}");
                    fileNameNum++;
                }

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        using (HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                        {
                            response.EnsureSuccessStatusCode(); // 确保成功响应

                            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                         fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                            {

                                long totalBytes = response.Content.Headers.ContentLength ?? -1;
                                long totalRead = 0;
                                byte[] buffer = new byte[8192];
                                int bytesRead, progress;

                                Dlg_Loading downloadDlg = new Dlg_Loading("请等待", 0, 100);

                                Thread downloadThread = new Thread(async () =>
                                {
                                    try
                                    {
                                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                        {
                                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                                            totalRead += bytesRead;

                                            // 计算进度百分比
                                            progress = (int)Math.Round((double)totalRead / totalBytes * 100);

                                            downloadDlg.UpdateProgressBar(progress);
                                        }
                                    }
                                    catch { MessageBox.Show("下载的文件可能不完整", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    downloadDlg.Hide();
                                    downloadDlg.Close();
                                });
                                downloadThread.Start();
                                downloadDlg.ShowDialog();
                                
                            }
                        }

                        return savePath; // 下载成功
                    }
                    catch (HttpRequestException e)
                    {
                        MessageBox.Show($"Http请求错误: {e.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null; // 下载失败
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show($"IO错误: {e.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null; // 下载失败
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"未知错误: {e.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            public static string DownLoadFile(string fileUrl, string saveDir, string saveFileName)
            {
                string result = null;
                Task.Run(async () =>
                {
                    result = await DownloadFileAsync(fileUrl, saveDir, saveFileName);
                }).Wait();
                return result;
            } 
            static async Task<string> GetJsonDataAsync(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            public static string GetUrlJsonData(string url)
            {
                string result = null;
                Task.Run(async () =>
                {
                    result = await GetJsonDataAsync(url);
                }).Wait();
                return result;
            }

            static public string GetFileNameFromUrl(string url)
            {
                return Path.GetFileName(url);
            }
        }

        public static class APPStore
        {
            public class AppInfo
            {
                public string Name { get; set; }
                public string Url { get; set; }
                public string Icon { get; set; }
                public string Version { get; set; }
                public string Author { get; set; }
                public string Description { get; set; }
                public string CutPhoto { get; set; }
                public int Category { get; set; }
                public string XinSpecTag { get; set; }
            }

            public class AppList
            {
                public List<AppInfo> Applist { get; set; }

                public static AppList Get_APPInFos(string jsonData)
                {
                    AppList appList = JsonConvert.DeserializeObject<AppList>(jsonData);
                    return appList;
                }
            }

        }
    }
}
