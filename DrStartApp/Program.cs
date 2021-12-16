using System;
using System.Diagnostics;
using System.IO;

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
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            //
            var webSitePath = di.FullName + @"\source\dist\index.html";
            var backEndSitePath = di.FullName + @"\source\Release\DR_Application.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo(backEndSitePath);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            KillProcess("DR_Application");
            Process.Start(startInfo);

            Process.Start(webSitePath);
        }
    }
}