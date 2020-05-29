using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework11;

namespace Homework11Form {
    public partial class FormItemEdit : Form {
        public OrderItem OrderItem { get; set; }

        public FormItemEdit() {
            InitializeComponent();
        }

        public FormItemEdit(OrderItem orderItem):this() {
            this.OrderItem = orderItem;
            this.ItemBindingSource.DataSource = orderItem;
            List<Item> goods = GoodsService.GetAll();
            if (goods.Count == 0) {
                GoodsService.Add(new Item("apple", 100.0));
                GoodsService.Add(new Item("egg", 200.0));
                GoodsService.Add(new Item("banana", 300.0));
                GoodsService.Add(new Item("pen", 799));
                GoodsService.Add(new Item("ipad", 7000));
                GoodsService.Add(new Item("bag", 1));
                goods = GoodsService.GetAll();
            }
            goodsBindingSource.DataSource = goods;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ItemBindingSource.ResetBindings(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}