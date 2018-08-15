using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCObserverStudent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"\\Mac\Home\Downloads\晴空暑假\PCObserverStudent\server_PHP\1.txt", string.Empty);
            Config config = new Config();
            int mode = config.check(); //blacklist:0  whitelist:1
            Console.WriteLine(mode);
            Stopwatch watch = Stopwatch.StartNew();
            ArrayList process = new ArrayList();
            foreach (Process ps in Process.GetProcesses())
            {
                if (!process.Contains(ps.ProcessName)) process.Add(ps.ProcessName);
            }
            string ans = "";
            if (mode == 0)
            {
                textBox1.Text = "黑名单模式";
                BlackList checker = new BlackList();
                ans = checker.Check(process);
            }
            else
            {
                textBox1.Text = "白名单模式";
                foreach (Process ps in Process.GetProcesses())
                {
                    WhiteList checker = new WhiteList();
                    ans = checker.check(process);
                }
            }
            Guid Guid = Guid.NewGuid();
            string guid = Guid.ToString();
            string hostname = System.Net.Dns.GetHostName();
            IPAddress ddr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            string ip = ddr.ToString();
            string postData = string.Format("s={0}&guid={1}&hostname={2}&ip={3}&mode={4}", ans, guid, hostname, ip, mode);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytepostData = encoding.GetBytes(postData);
            string URL = "http://192.168.1.131:2333/test.php";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Method = "POST";
            request.ContentLength = bytepostData.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytepostData, 0, bytepostData.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //Stream data = response.GetResponseStream();
            //response.Close();

            string[] txtStrs = File.ReadAllLines(@"\\Mac\Home\Downloads\晴空暑假\PCObserverStudent\server_PHP\1.txt", System.Text.Encoding.UTF8);
            string txtShow = string.Empty;
            for (int i = 0; i < txtStrs.Length; i++)
            {
                txtShow += txtStrs[i] + "\n";
            }
            richTextBox1.Text = txtShow;
        }
    }
}
