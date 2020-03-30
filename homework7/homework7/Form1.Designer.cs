namespace homework7
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.draw = new System.Windows.Forms.Button();
            this.ntext = new System.Windows.Forms.TextBox();
            this.n = new System.Windows.Forms.Label();
            this.lengtext = new System.Windows.Forms.TextBox();
            this.per1text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.per2text = new System.Windows.Forms.TextBox();
            this.th1text = new System.Windows.Forms.TextBox();
            this.th2text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pentext = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(739, 12);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(50, 23);
            this.draw.TabIndex = 0;
            this.draw.Text = "draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // ntext
            // 
            this.ntext.Location = new System.Drawing.Point(686, 61);
            this.ntext.Name = "ntext";
            this.ntext.Size = new System.Drawing.Size(100, 25);
            this.ntext.TabIndex = 1;
            this.ntext.Text = "10";
            // 
            // n
            // 
            this.n.AutoSize = true;
            this.n.Location = new System.Drawing.Point(689, 43);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(75, 15);
            this.n.TabIndex = 2;
            this.n.Text = "递归深度n";
            // 
            // lengtext
            // 
            this.lengtext.Location = new System.Drawing.Point(686, 118);
            this.lengtext.Name = "lengtext";
            this.lengtext.Size = new System.Drawing.Size(100, 25);
            this.lengtext.TabIndex = 3;
            this.lengtext.Text = "100";
            // 
            // per1text
            // 
            this.per1text.Location = new System.Drawing.Point(686, 180);
            this.per1text.Name = "per1text";
            this.per1text.Size = new System.Drawing.Size(100, 25);
            this.per1text.TabIndex = 4;
            this.per1text.Text = "0.6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "主干长度leng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "右分支长度比per1";
            // 
            // per2text
            // 
            this.per2text.Location = new System.Drawing.Point(686, 239);
            this.per2text.Name = "per2text";
            this.per2text.Size = new System.Drawing.Size(100, 25);
            this.per2text.TabIndex = 7;
            this.per2text.Text = "0.7";
            // 
            // th1text
            // 
            this.th1text.Location = new System.Drawing.Point(686, 303);
            this.th1text.Name = "th1text";
            this.th1text.Size = new System.Drawing.Size(100, 25);
            this.th1text.TabIndex = 8;
            this.th1text.Text = "0.5236";
            // 
            // th2text
            // 
            this.th2text.Location = new System.Drawing.Point(686, 368);
            this.th2text.Name = "th2text";
            this.th2text.Size = new System.Drawing.Size(100, 25);
            this.th2text.TabIndex = 9;
            this.th2text.Text = "0.349";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "左分支长度比per2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(682, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "右分支角度th1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "左分支角度th2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(689, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "画笔颜色pen";
            // 
            // pentext
            // 
            this.pentext.FormattingEnabled = true;
            this.pentext.Items.AddRange(new object[] {
            "blue",
            "black",
            "red"});
            this.pentext.Location = new System.Drawing.Point(685, 424);
            this.pentext.Name = "pentext";
            this.pentext.Size = new System.Drawing.Size(104, 23);
            this.pentext.TabIndex = 15;
            this.pentext.Text = "blue";
            this.pentext.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "cls";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(12, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(621, 393);
            this.panel.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pentext);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.th2text);
            this.Controls.Add(this.th1text);
            this.Controls.Add(this.per2text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.per1text);
            this.Controls.Add(this.lengtext);
            this.Controls.Add(this.n);
            this.Controls.Add(this.ntext);
            this.Controls.Add(this.draw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.TextBox ntext;
        private System.Windows.Forms.Label n;
        private System.Windows.Forms.TextBox lengtext;
        private System.Windows.Forms.TextBox per1text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox per2text;
        private System.Windows.Forms.TextBox th1text;
        private System.Windows.Forms.TextBox th2text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox pentext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel;
    }
}

