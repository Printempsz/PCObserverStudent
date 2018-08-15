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
using System.Net.Sockets;
using System.Threading;

namespace PCObserverStudent
{
    public delegate void CallBack(string message);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            try
            {
                CallBack callBack = new CallBack(ShowMessage);
                //创建后台线程定时向服务端发送信息
                Thread thread = new Thread(timedTrans);
                thread.IsBackground = true;
                thread.Start(callBack);
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //处理从线程异步传输的信息
        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        //定时发送函数
        private void timedTrans(object obj)
        {
            Config config;
            int mode;
            CallBack callback = (CallBack)obj;
            string guid = Guid.NewGuid().ToString();
            string hostName = Dns.GetHostName();
            string ip = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            string ans = "";
            string postData;
            Encoding encoding = new UTF8Encoding();
            string url = "http://localhost:8000/test.php";
            ArrayList processList = new ArrayList();
            while (true)
            {
                try
                {
                    config = new Config();
                    mode = config.check(); //blacklist:0  whitelist:1
                    foreach (Process p in Process.GetProcesses())
                    {
                        if (!processList.Contains(p.ProcessName))
                            processList.Add(p.ProcessName);
                    }
                    if (mode == 0)
                    {
                        BlackList checker = new BlackList();
                        ans = checker.Check(processList);
                    }
                    else
                    {
                        foreach (Process ps in Process.GetProcesses())
                        {
                            WhiteList checker = new WhiteList();
                            ans = checker.check(processList);
                        }
                    }
                    postData = string.Format("s={0}&guid={1}&hostname={2}&ip={3}&mode={4}",
                                    ans, guid, hostName, ip, mode);
                    byte[] postBytes = encoding.GetBytes(postData);

                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                    webRequest.UserAgent = ".NET Framework Example Client";
                    webRequest.Method = "POST";
                    webRequest.ContentLength = postBytes.Length;
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    Stream requestStream = webRequest.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    byte[] buffer = new byte[1024];
                    int len = response.GetResponseStream().Read(buffer, 0, 1024);
                    Console.WriteLine(encoding.GetString(buffer, 0, len));
                    requestStream.Close();
                }
                catch (Exception e)
                {
                    callback(e.Message);
                }

                Thread.Sleep(5000);
            }

        }
    }
}
