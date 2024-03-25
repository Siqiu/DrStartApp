using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace StartApp
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

        static void normal(int port)
        {
            string backEndNameOld = "DR_Application";
            string backEndName = "BmsApplication";
            string daemonName = "daemon";
            
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            
            var webSitePath = di.FullName + @"\source\dist\index.html";
            var backEndSitePath = di.FullName + @"\source\Release\BmsApplication.exe";
            var daemonSitePath = di.FullName + @"\source\daemon.exe";

            ProcessStartInfo backEnd = new ProcessStartInfo(backEndSitePath);
            backEnd.WindowStyle = ProcessWindowStyle.Hidden;
            backEnd.Arguments = port.ToString() + " " + webSitePath;
            
            ProcessStartInfo daemon = new ProcessStartInfo(daemonSitePath);
            daemon.WindowStyle = ProcessWindowStyle.Hidden;

            KillProcess(backEndNameOld);
            KillProcess(backEndName);
            KillProcess(daemonName);
            
            Process.Start(backEnd);

            Process.Start(webSitePath);
            
            Process.Start(daemon);
        }

        static void Main(string[] args)
        {
            const string password = "666666";

            Console.WriteLine("请输入密码：(Please enter the password:)");
            Console.WriteLine("");
            string inputPassword = Console.ReadLine();

            if (inputPassword == password)
            {
                Console.WriteLine("密码正确，正在启动程序...(Password correct, starting the program...)");
                normal(8888);
            }
            else
            { 
                Console.WriteLine("密码错误，程序无法启动。(Incorrect password, program cannot be started.)");
            }

            Console.WriteLine("按任意键退出... (Press any key to exit...)");
            Console.ReadKey();
        }
    }
}