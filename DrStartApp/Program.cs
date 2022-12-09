﻿using System;
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
                    process.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }

        private static bool findTask(string processName)
        {
            foreach (Process process in Process.GetProcessesByName(processName))
            {
                // exist
                return false;
            }
            return true;
        }
        
        static void Main(string[] args)
        {
            string applicationName = "DR_Application";
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            
            var webSitePath = di.FullName + @"\source\dist\index.html";
            var backEndSitePath = di.FullName + @"\source\Release\DR_Application.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo(backEndSitePath);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            KillProcess(applicationName);
            Process.Start(startInfo);

            Process.Start(webSitePath);

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