using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FactoryApp : Form
    {
        public FactoryApp()
        {
            InitializeComponent();
        }
        static string backEndNameOld = "DR_Application";
        static string backEndName = "BmsApplication";
        static string daemonName = "daemon";
        
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
            DirectoryInfo di = new DirectoryInfo($@"{System.Environment.CurrentDirectory}");
            // file:///C:/Users/donn1e/source/RiderProjects/StartApp/FactoryApp/bin/Debug/source/dist/index.html#/?p=8889
            var webSitePath = di.FullName + @"\source\dist\index.html";
            // var webSitePath = di.FullName + @"\source\dist\index.html";
            var backEndSitePath = di.FullName + @"\source\Release\BmsApplication.exe";
            var daemonSitePath = di.FullName + @"\source\daemon.exe";

            ProcessStartInfo backEnd = new ProcessStartInfo(backEndSitePath);
            backEnd.WindowStyle = ProcessWindowStyle.Hidden;
            backEnd.Arguments = port.ToString() + " " + webSitePath;
            
            // ProcessStartInfo daemon = new ProcessStartInfo(daemonSitePath);
            // daemon.WindowStyle = ProcessWindowStyle.Hidden;


            
            Process.Start(backEnd);

            // Process.Start(webSitePath);
            
            string queryString = @"#/?p=";
            var portStr = port.ToString();

            Uri uri = new Uri(webSitePath);
            string newUrl = $"{uri.AbsoluteUri}{queryString}{portStr}";


            try
            {
                Process.Start("msedge.exe", newUrl);
            }
            catch (Exception e)
            {
              
                Console.WriteLine(e);
                MessageBox.Show("https://www.microsoft.com/en-us/edge/download?form=MA13FJ", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            // Process.Start(newUrl);

            // Process.Start(@"file:///C:/Users/donn1e/source/RiderProjects/StartApp/FactoryApp/bin/Debug/source/dist/index.html?p=8889");
  
            // Process.Start(daemon);
        }

        private static int[] portNum = new int[20];
        private void button1_Click(object sender, EventArgs e)
        {
            int totalPortNum = 0;
            int i = 0;
            for (; i < 20; i++)
            {
                totalPortNum++;
                if (portNum[i] == 0)
                {
                    portNum[i] = 8888 + i;
                   break;
                }
            }

            if (i >= 20)
            {
                MessageBox.Show("MAX 20", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            totalPortNum += 8888;
            tbBackendNum.Text = "port " + totalPortNum.ToString();
            normal(totalPortNum);
            // throw new System.NotImplementedException();
            // MessageBox.Show("start new one?", "Success",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // MessageBox.Show("start new one?", "Fail",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void btn_close_all_Click(object sender, EventArgs e)
        {
            KillProcess(backEndNameOld);
            KillProcess(backEndName);
            KillProcess(daemonName);
            // throw new System.NotImplementedException();
            Array.Clear(portNum, 0, portNum.Length);
            tbBackendNum.Text = "port 0";
            // MessageBox.Show("Close all backend", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}