﻿using Homework11;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework11Form {
    public partial class FormEdit : Form {
        public Order CurrentOrder { get; set; }

        public FormEdit() {
            orderBindingSource.DataSource = CurrentOrder;
            txtOrderId.Enabled = true;
            InitializeComponent();
        }

        public FormEdit(Order order, bool editMode = false) : this() {
            CurrentOrder = order;
            orderBindingSource.DataSource = CurrentOrder;
            txtOrderId.Enabled = !editMode;
        }

        private void AddItem(object sender, EventArgs e) {
            FormItemEdit formItemEdit = new FormItemEdit(new OrderItem());
            try {
                if (formItemEdit.ShowDialog() == DialogResult.OK) {
                    int index = 0;
                    if (CurrentOrder.Items.Count != 0) {
                        index = CurrentOrder.Items.Max(i => i.Index) + 1;
                    }
                    formItemEdit.OrderItem.Index = index;
                    CurrentOrder.AddItem(formItemEdit.OrderItem);
                    itemsBindingSource.ResetBindings(false);
                }
            }catch (Exception e2) {
                MessageBox.Show(e2.Message);
            }
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            OrderItem orderItem = itemsBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单");
                return;
            }
            CurrentOrder.RemoveItem(orderItem);
            itemsBindingSource.ResetBindings(false);
        }
        private void btnSave_Click(object sender, EventArgs e) {
            CurrentOrder.Items.ForEach(item => {
                item.Item = null;
                item.OrderId = CurrentOrder.OrderId;
            });

            this.Close();
        }

        private void Edit()
        {
            OrderItem orderItem = itemsBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项");
                return;
            }
            FormItemEdit formItemEdit = new FormItemEdit(orderItem);
            if (formItemEdit.ShowDialog() == DialogResult.OK)
            {
                itemsBindingSource.ResetBindings(false);
            }
        }
        private void btnEditItem_Click(object sender, EventArgs e) {
            Edit();
        }

        private void dgvItems_DoubleClick(object sender, EventArgs e) {
            Edit();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}