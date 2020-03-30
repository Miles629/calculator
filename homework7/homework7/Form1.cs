using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int n1 = 10;
        double leng = 100;
        public Form1()
        {
            InitializeComponent();
            graphics = panel.CreateGraphics();
            graphics.Clear(Color.White);
            this.BackColor = Color.Gray;

        }

        private void draw_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ntext.Text.Equals("")) n1 = Convert.ToInt32(ntext.Text);
                if (!lengtext.Text.Equals("")) leng = Convert.ToDouble(lengtext.Text);
                if (!per1text.Text.Equals("")) per1 = Convert.ToDouble(per1text.Text);
                if (!per2text.Text.Equals("")) per2 = Convert.ToDouble(per2text.Text);
                if (!th1text.Text.Equals("")) th1 = Convert.ToDouble(th1text.Text);
                if (!th2text.Text.Equals("")) th2 = Convert.ToDouble(th2text.Text);

            }catch
            {
                MessageBox.Show("请检查输入数据格式是否正确！");
            }

       
            drawCayleyTree(n1, 200, 310, leng, -Math.PI / 2);
        }

        void drawCayleyTree(int n,double x0,double y0,double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen pen=Pens.Blue;
            switch(pentext.Text)
            {
                case "blue": pen = Pens.Blue; break;
                case "black": pen = Pens.Black; break;
                case "red": pen = Pens.Red; break;
            }
            graphics.DrawLine(
                    pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }
    }
}
