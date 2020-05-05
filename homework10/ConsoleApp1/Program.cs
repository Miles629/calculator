//本代码是基于老师所给出的示范代码进行修改得到的控制台版，删除了原代码中不必要的事件和简化了start（）函数,
//因为这一次的作业是并行，所以并行之外的部分基本沿用了先前的代码。
//为并行池创建新增了run_parallel（）函数，将complatedCount作为私有变量，将start（）作为进程开始的初始化函数
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Crawler
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            Thread thread= null;
            crawler.StartURL = "http://www.cnblogs.com/dstang2000/";
            Match match = Regex.Match(crawler.StartURL, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = ".html?$";

            if (thread != null)
            {
                thread.Abort();
                Console.WriteLine("终止");
            }
            thread = new Thread(crawler.Start);
            thread.Start();
            Console.WriteLine("爬虫启动");

        }
      
        public event Action<Crawler, int, string, string> Downloaded;
        //所有已下载和待下载URL，key是URL，value表示是否下载成功
        private ConcurrentDictionary<string, bool> urls_statues = new ConcurrentDictionary<string, bool>();
        //待下载队列
        private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();
        //URL检测表达式，用于在HTML文本中查找URL
        private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则
        public int MaxPage { get; set; } //最大下载数量
        public string StartURL { get; set; } //起始网址
        public Encoding HtmlEncoding { get; set; } //网页编码
        private int complatedCount = 0;//已完成的任务数
        public Crawler()
        {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }

        public void Start()
        {
            //爬虫开始的初始化工作
            urls_statues.Clear();
            pending = new ConcurrentQueue<string>();
            pending.Enqueue(StartURL);
            complatedCount = 0;
            Downloaded += (crawler, index, url, info) => { complatedCount++; };
            run_parallel();
        }
        //并行任务池创建函数
        private void run_parallel()
        {
            List<Task> tasks = new List<Task>();
            while (tasks.Count < MaxPage)
            {
                if (!pending.TryDequeue(out string url))
                {
                    int index = tasks.Count;
                    Console.WriteLine($"task.count{tasks.Count} is {tasks[index].Status}");
                    Task task = Task.Run(() => DownloadAndParse(url, index));
                    tasks.Add(task);
                    if (complatedCount == tasks.Count)
                    {
                        break;
                    }
                }
            }

            Task.WaitAll(tasks.ToArray()); //等待剩余任务全部执行完毕
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"task[{i}]:result:{tasks[i].Status}");
            }
        }

        //url: 待处理的网址，index：任务序号
        private void DownloadAndParse(string url, int index)
        {
            try
            {
                string html = DownLoad(url, index);
                urls_statues[url] = true;
                Parse(html, url);//解析,并加入新的链接
                Downloaded(this, index, url, "success");
            }
            catch (Exception ex)
            {
                Downloaded(this, index, url, "Error:" + ex.Message);
            }
        }

        //url: 待处理的网址，index：任务序号
        private string DownLoad(string url, int index)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = HtmlEncoding;
            string html = webClient.DownloadString(url);
            File.WriteAllText(index + ".html", html, Encoding.UTF8);
            return html;
        }

        private void Parse(string html, string pageUrl)
        {
            var matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl = FixUrl(linkUrl, pageUrl);//转绝对路径

                //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";

                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !urls_statues.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                    urls_statues.TryAdd(linkUrl, false);
                }
            }
        }

        //这个函数是从老师的示范里拿的，自己写的考虑太不周全了
        //将相对路径转为绝对路径，url：待转地址， baseUrl：当前页面地址
        static private string FixUrl(string url, string baseUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(baseUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = baseUrl.LastIndexOf('/');
                return FixUrl(url, baseUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), baseUrl);
            }

            int end = baseUrl.LastIndexOf("/");
            return baseUrl.Substring(0, end) + "/" + url;
        }
    }
}
