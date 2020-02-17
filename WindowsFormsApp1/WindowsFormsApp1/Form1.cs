using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int haveop=0;
        private int havere=0;
        private int haven1 = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string n1 = label1.Text;
            string n2 = label2.Text;
            string op = label5.Text;
            double a1, a2;
            if (double.TryParse(n1, out a1) && double.TryParse(n2, out a2))
                label3.Text = calculate(a1, a2, op).ToString();
            else
                label3.Text = "NaN";
            haveop = 0;
            haven1 = 0;
            havere = 1;
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
            if(haven1==0&&havere==1)
            {
                label1.Text = label3.Text;
                label5.Text = "/";
                haveop = 1;
            }
            else
            {
                label5.Text = "/";
                haveop = 1;
            }
            label2.Text = "";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (haven1 == 0 && havere == 1)
            {
                label1.Text = label3.Text;
                label5.Text = "*";
                haveop = 1;
                label2.Text = "";
            }
            else
            {
                label5.Text = "*";
                haveop = 1;
            }
            label2.Text = "";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (haven1 == 0 && havere == 1)
            {
                label1.Text = label3.Text;
                label5.Text = "-";
                haveop = 1;
            }
            else
            {
                label5.Text = "-";
                haveop = 1;
            }
            label2.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (haven1 == 0 && havere == 1)
            {
                label1.Text = label3.Text;
                label5.Text = "+";
                haveop = 1;
                
            }
            else
            {
                label5.Text = "+";
                haveop = 1;
            }
            label2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (haveop == 0 && haven1 == 0)
            { 
                label1.Text = "";
                haven1 = 1;
            }
            if(haveop == 0 && haven1 == 1)
                label1.Text = label1.Text + "2";
            else label2.Text = label2.Text + "2";
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
            else label2.Text = label2.Text + "3";
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
            else label2.Text = label2.Text + "4";
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
            else label2.Text = label2.Text + "5";
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
            else label2.Text = label2.Text + "6";
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
            else label2.Text = label2.Text + "7";
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
            else label2.Text = label2.Text + "8";
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
            else label2.Text = label2.Text + "9";
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
            else label2.Text = label2.Text + "0";
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
            else label2.Text = label2.Text + ".";
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
            else label2.Text=label2.Text+"1";
        }
    }
}
