using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PCObserverStudent
{
    class Config
    {
        private string ans;
        public Config()
        {
            string url = "http://localhost:8000/admin.php";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(stream, Encoding.UTF8);
            ans = myStreamReader.ReadToEnd();
            //Console.WriteLine(ans.CompareTo("blacklist_mode"));
        }

        public int check()
        {
            return ans.CompareTo("blacklist_mode");
        }
    }
}
