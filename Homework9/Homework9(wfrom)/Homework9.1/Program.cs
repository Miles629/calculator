using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Homework9._1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class SimpleCrawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        TextBox t1;
        public SimpleCrawler(TextBox t)
        {
            t1 = t;
        }

        //static void Main(string[] args)
        //{
        //    //SimpleCrawler myCrawler = new SimpleCrawler();
        //    //string startUrl = "http://www.cnblogs.com/dstang2000/";
        //    //if (args.Length >= 1) startUrl = args[0];
        //    //myCrawler.urls.Add(startUrl, false);//加入初始页面
        //    //new Thread(myCrawler.Crawl()).Start();
        //}

        public void Crawl()
        {
            //Console.WriteLine("开始爬行了.... ");
            t1.Text = "开始爬行了....";
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                //Console.WriteLine("爬行" + current + "页面!");
                t1.Text = t1.Text + "爬行" + current + "页面!";
                string html = DownLoad(current); // 下载
                //Console.WriteLine(html);
                Regex ishtml = new Regex(@"^<!DOCTYPE html>");
                urls[current] = true;
                count++;
                if (ishtml.IsMatch(html))
                {
                    t1.Text = t1.Text + "是html，爬行成功！\r\n";
                    Parse(html);//解析,并加入新的链接
                    //Console.WriteLine("是html，爬行成功");
                    //t1.Text = t1.Text + html;
                }

            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            if (Regex.IsMatch(strRef, @"^/"))
                strRef = "http://www.cnblogs.com/dstang2000/" + strRef;
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
