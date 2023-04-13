using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DrStartApp
{
    static class Program
    {
        private static void KillProcess(string processName)
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    // 不显示命令窗口
                    process.StartInfo.CreateNoWindow = true;
                    process.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }

        static void Main(string[] args)
        {
            string backEndName = "BmsApplication";
            string daemonName = "daemon";
            
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            
            var webSitePath = di.FullName + @"\source\dist\index.html";
            var backEndSitePath = di.FullName + @"\source\Release\BmsApplication.exe";
            var daemonSitePath = di.FullName + @"\source\daemon.exe";

            ProcessStartInfo backEnd = new ProcessStartInfo(backEndSitePath);
            backEnd.WindowStyle = ProcessWindowStyle.Hidden;
            
            ProcessStartInfo daemon = new ProcessStartInfo(daemonSitePath);
            daemon.WindowStyle = ProcessWindowStyle.Hidden;

            KillProcess(backEndName);
            KillProcess(daemonName);
            
            Process.Start(backEnd);

            Process.Start(webSitePath);
            
            Process.Start(daemon);
        }
    }
}