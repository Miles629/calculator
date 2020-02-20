using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace WindowsFormsApp1
{
    public partial class Form1 : Skin_Mac
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int haveop=0;
        private int havere=0;
        private int haven1 = 0,haven2 = 0;
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string n1 = label1.Text;
            string n2 = label2.Text;
            string op = label5.Text;
            //label4.Text = "=";
            double a1, a2;
            if (double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
            {
                label3.Text = calculate(a1, a2, op).ToString();
                textBox1.Text = textBox1.Text + label3.Text + "\r\n";
            }
            else
                label3.Text = "NaN";
            haveop = 0;
            haven1 = 0;
            havere = 1;
            haven2 = 0;
        }
        private double calculate(double a1,double a2,string op)
        {

                if (op[0] == '-')
                {
                    return (a1 - a2);
                }
                if (op[0] == '+')
                {
                    return (a1 + a2);
                }
                if (op[0] == '/')
                {
                    return (a1 / a2);
                }
                if (op[0] == '*')
                {
                    return (a1 * a2);
                }
                else return 9999999;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(haven1==1&&haveop==1&&haven2==1)//连续运算
            {
                string n1 = label1.Text;
                string n2 = label2.Text;
                string op = label5.Text;
                double a1, a2;
                if (double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
                {
                    label1.Text = calculate(a1, a2, op).ToString();
                    label2.Text = "";
                    label3.Text = label1.Text;
                    textBox1.Text = textBox1.Text + label1.Text + "\r\n";
                }
                else
                    label3.Text = "NaN";
            }
            if(haven1==0&&havere==1)//一则运算过后立刻运算
            {
                label1.Text = label3.Text;
                label2.Text = "";
                haven1 = 1;
            }
            else
            {
            }
            label5.Text = "/";
            haveop = 1;
            label2.Text = "";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (haven1 == 1 && haveop == 1 && haven2 == 1)//连续运算
            {
                string n1 = label1.Text;
                string n2 = label2.Text;
                string op = label5.Text;
                double a1, a2;
                if (double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
                {
                    label1.Text = calculate(a1, a2, op).ToString();
                    label2.Text = "";
                    label3.Text = label1.Text;
                    textBox1.Text = textBox1.Text + label1.Text + "\r\n";
                }
                else
                    label3.Text = "NaN";
            }
            if (haven1 == 0 && havere == 1)//一则运算过后立刻运算
            {
                label1.Text = label3.Text;
                label2.Text = "";
                haven1 = 1;
            }
            else
            {
            }
            label5.Text = "*";
            haveop = 1;
            label2.Text = "";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (haven1 == 1 && haveop == 1 && haven2 == 1)//连续运算
            {
                string n1 = label1.Text;
                string n2 = label2.Text;
                string op = label5.Text;
                double a1, a2;
                if(double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
                {
                    label1.Text = calculate(a1, a2, op).ToString();
                    label2.Text = "";
                    label3.Text = label1.Text;
                    textBox1.Text = textBox1.Text + label1.Text + "\r\n";
                }
                else
                    label3.Text = "NaN";
            }
            if (haven1 == 0 && havere == 1)//一则运算过后立刻运算
            {
                label1.Text = label3.Text;
                label2.Text = "";
                haven1 = 1;
            }
            else
            {
                //label5.Text = "-";
                //haveop = 1;
            }
            label5.Text = "-";
            haveop = 1;
            label2.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (haven1 == 1 && haveop == 1 && haven2 == 1)//连续运算
            {
                string n1 = label1.Text;
                string n2 = label2.Text;
                string op = label5.Text;
                double a1, a2;
                if (double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
                {
                    label1.Text = calculate(a1, a2, op).ToString();
                    label2.Text = "";
                    label3.Text = label1.Text;
                    textBox1.Text = textBox1.Text + label1.Text + "\r\n";
                }
                else
                    label3.Text = "NaN";
            }
            if (haven1 == 0 && havere == 1)//一则运算过后立刻运算
            {
                label1.Text = label3.Text;
                label2.Text = "";
                haven1 = 1;
            }
            else
            {
                //label5.Text = "+";
                //haveop = 1;
            }
            label5.Text = "+";
            haveop = 1;
            label2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            { 
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "2";
            else
            {
                label2.Text = label2.Text + "2";
                haven2 = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "3";
            else
            {
                label2.Text = label2.Text + "3";
                haven2 = 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "4";
            else
            { 
                label2.Text = label2.Text + "4";
                haven2 = 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "5";
            else
            { 
                label2.Text = label2.Text + "5"; 
                haven2 = 1; 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "6";
            else
            {
                label2.Text = label2.Text + "6";
                haven2 = 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "7";
            else
            {
                label2.Text = label2.Text + "7";
                haven2 = 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "8";
            else
            {
                label2.Text = label2.Text + "8";
                haven2 = 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "9";
            else
            {
                label2.Text = label2.Text + "9";
                haven2 = 1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "0";
            else
            {
                label2.Text = label2.Text + "0";
                haven2 = 1;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + ".";
            else
            {
                label2.Text = label2.Text + ".";
                haven2 = 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "怎么用都可以")
                label6.Text = "就是功能不多";
            else if (label6.Text == "就是功能不多")
                label6.Text = "的高仿手机计算器";
            else if (label6.Text == "的高仿手机计算器")
                label6.Text = "支持用上次结果作为第一操作数";
            else if (label6.Text == "支持用上次结果作为第一操作数")
                label6.Text = "支持连续使用运算符--over";
            else if (label6.Text == "支持连续使用运算符--over")
                label6.Text = "怎么用都可以";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.LinkVisited == true)
                linkLabel1.Text = "QMail:1067874054@qq.com";
            try
            {
                linkLabel1.LinkVisited = true;
                linkLabel1.Text = "你的star是对我最大的鼓励！";
                System.Diagnostics.Process.Start("https://github.com/Miles629/calculator");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
                linkLabel1.Text = "啊嘞，出错了？再次点击向作者反馈";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Form1.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            {
                label1.Text = "";
                haven1 = 1;
            }
            if (haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "1";
            else
            {
                label2.Text = label2.Text + "1";
                haven2 = 1;
            }
        }
    }
}
