using System;
using System.IO;
using System.Net;
using System.Text;

namespace el3venDll
{
    public class NetEasyUse
    {
        public static string GetIP()
        {
            try
            {
                string strUrl = "http://www.ip138.com/ip2city.asp";     //获得IP的网址
                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);
                Stream s = webreq.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd();         //读取网站返回的数据  格式：您的IP地址是：[x.x.x.x]
                int i = all.IndexOf("[") + 1;
                string tempip = all.Substring(i, 15);
                string ip = tempip.Replace("]", "").Replace(" ", "").Replace("<", "");     //去除杂项找出ip
                return ip;
            }
            catch
            {
                return "false";
            }
        }
    }
}
