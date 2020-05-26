using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
    public partial class FormMain : Form {
        BindingSource fieldsBS = new BindingSource();
        public String Keyword { get; set; }

        public FormMain() {
            InitializeComponent();
            orderBindingSource.DataSource = OrderService.GetAllOrdersList();
            txtValue.DataBindings.Add("Text", this, "Keyword");
        }

        private void btnAdd_Click_1(object sender, EventArgs e) {
            FormEdit form2 = new FormEdit(new Order());
            if (form2.ShowDialog() == DialogResult.OK) {
                OrderService.AddOrder(form2.CurrentOrder);
                QueryAll();
            }
        }

        private void QueryAll() {
            orderBindingSource.DataSource = OrderService.GetAllOrdersList();
            orderBindingSource.ResetBindings(false);
        }

        private void btnModify_Click(object sender, EventArgs e) {
            EditOrder();
        }
        private void dbvOrders_DoubleClick_1(object sender, EventArgs e) {
            EditOrder();
        }
        private void EditOrder() {
            Order order = orderBindingSource.Current as Order;
            if (order == null) {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            order = OrderService.GetOrder(order.OrderId); //查询出最新的订单信息
            FormEdit form2 = new FormEdit(order, true);
            if (form2.ShowDialog() == DialogResult.OK) {
                OrderService.UpdateOrder(form2.CurrentOrder);
                QueryAll();
            }
        }


        private void dbvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dbvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            OrderService.RemoveOrder(order.OrderId);
            QueryAll();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                OrderService.Import(fileName);
                QueryAll();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                OrderService.Export(fileName);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Order order = OrderService.GetOrder(Keyword);
            List<Order> result = new List<Order>();
            if (order != null)
                result.Add(order);
            else result = OrderService.SearchByGoodsName(Keyword);
            if (result == null)
                result = OrderService.SearchByCustomerName(Keyword);
            orderBindingSource.DataSource = result;
            orderBindingSource.ResetBindings(true);
        }
    }
}