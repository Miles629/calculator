using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Homework9._1
{
    public partial class Form1 : Form
    {
        SimpleCrawler myCrawler;
        string startUrl;
        //if (args.Length >= 1) startUrl = args[0];
        public Form1()
        {
            InitializeComponent();
            myCrawler = new SimpleCrawler(textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                startUrl = textBox2.Text;
                myCrawler.urls.Add(startUrl, false);//加入初始页面
                myCrawler.Crawl();
                //new Thread(myCrawler.Crawl).Start();
            }
            catch
            {
                MessageBox.Show("there is something wrong！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
