using Microsoft.Win32;
using metalAssistor.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
 
using System.Windows.Forms;

namespace metalAssistor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            //util.WordUtil.ReadSclerometer(@"C:\Users\Administrator\Desktop\金属\硬度计 - 副本.doc");
            Process cur = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id == cur.Id) continue;
                if (p.ProcessName == cur.ProcessName)
                {
                    //if (args != null && args.Length > 0 && args[0] == "-s")
                    //    MessageBox.Show("请勿重复打开！");
                    return;
                }
            }
            ChangeDllPath("lib;");
            //cbx_startup();
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;


            //LoginFormNew from = new LoginFormNew();
            //if (from.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }

        private static void ChangeDllPath(string path)
        {
            AppDomain.CurrentDomain.SetData("PRIVATE_BINPATH", path);
            AppDomain.CurrentDomain.SetData("BINPATH_PROBE_ONLY", path);
            var method = typeof(AppDomainSetup).GetMethod("UpdateContextProperty", BindingFlags.NonPublic | BindingFlags.Static);
            var funsion = typeof(AppDomain).GetMethod("GetFusionContext", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(null, new object[] { funsion.Invoke(AppDomain.CurrentDomain, null), "PRIVATE_BINPATH", path });
        }

        private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs e)
        {
            //项目的命名空间为winform1, 嵌入dll资源在libs文件夹下，所以这里用的命名空间为： winform1.libs.
            string dllName = "metalAssistor.lib." + new AssemblyName(e.Name).Name + ".dll";
            using (var dllStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dllName))
            {
                byte[] dllData = new byte[dllStream.Length];
                dllStream.Read(dllData, 0, dllData.Length);
                return Assembly.Load(dllData);
            }
        }

        private static bool start = true;
        private static void cbx_startup()
        {
            // 要设置软件名称，有唯一性要求，最好起特别一些
            string SoftWare = "metalAssistor";

            // 注意this.uiCheckBox1.Checked时针对Winfom程序的，如果是命令行程序要另外设置一个触发值
            if (start)
            {
                Console.WriteLine("设置开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath + " -s";
                RegistryKey rk = Registry.CurrentUser; // 添加到 当前登陆用户的 注册表启动项     
                try
                {
                    //SetValue:存储值的名称   
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    // 检测是否之前有设置自启动了，如果设置了，就看值是否一样
                    string old_path = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", old_path);
                    if (old_path == null || !path.Equals(old_path))
                    {
                        rk2.SetValue(SoftWare, path);
                        Console.WriteLine("添加开启启动成功");
                    }
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("开机自启动设置失败");
                }
            }
            else
            {
                // 取消开机自启动
                Console.WriteLine("取消开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.CurrentUser;
                try
                {
                    // SetValue: 存储值的名称
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    string old_path = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", old_path);
                    rk2.DeleteValue(SoftWare, false);
                    Console.WriteLine("取消开启启动成功");
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception ee)
                {
                    //MessageBox.Show(ee.Message.ToString(), "提 示", MessageBoxButtons.OK, MessageBoxIcon.Error);  // 提示
                    Console.WriteLine("取消开机自启动失败");
                }
            }
        }

    }

}

