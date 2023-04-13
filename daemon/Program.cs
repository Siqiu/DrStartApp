using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace daemon
{
    internal class Program
    {
        private static bool findTask(string processName)
        {
            foreach (Process process in Process.GetProcessesByName(processName))
                // exist
                return false;
            return true;
        }

        private static void Main(string[] args)
        {
            string applicationName = "BmsApplication";
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            var backEndSitePath = di.FullName + @"\source\Release\BmsApplication.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo(backEndSitePath);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;


            while (true)
            {
                // 查找执行程序在task list中
                if (findTask(applicationName))
                {
                    // 如果不在则重新启动后台
                    Process.Start(startInfo);
                    Console.WriteLine(DateTime.Now.ToString() + "Start Backend");
                }

                Thread.Sleep(1000);
            }
        }
    }
}