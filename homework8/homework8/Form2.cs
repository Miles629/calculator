using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8
{
    public partial class Form2 : Form
    {
        Order order;
        List<OrderItem> orderItems=new List<OrderItem>();
        OrderService orderService;
        string onum;
        string cus;
        int tnum;
        double tp=0;
        List<OrderItem> list;
        int i;
        public Form2(OrderService orderService)
        {
            this.orderService = orderService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onum = ddhtext.Text;
            cus = yhmtext.Text;
            tnum = Convert.ToInt32(spstext.Text);
            tx.Text = "需添加" + tnum + "种商品";
            i = tnum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // string coname, int idd, double pprice, int num
           try
            {
                OrderItem oi1 = new OrderItem(spmtext.Text, Convert.ToInt32(idhtext.Text),
                    Convert.ToDouble(djtext.Text), Convert.ToInt32(sltext.Text));
                orderItems.Add(oi1);
                i = i - 1;
                tx.Text = "需添加" + i + "种商品";
                dataGridView1.DataSource = orderItems;
                if(i==0)
                {
                    foreach(OrderItem oi in orderItems)
                    {
                        tp = tp + oi.per_price * oi.number;
                    }
                    //string onum, string cus, int tnum, double tp, List<OrderItem> list
                    orderService.AddOrder(onum, cus, tnum, tp, orderItems);
                    Close();
                   
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
                Close();
            }
        }

    }
}
