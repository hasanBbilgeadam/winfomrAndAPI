namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listBox1 = new ListBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            txtUpdatePrice = new TextBox();
            textUpdateName = new TextBox();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(47, 12);
            button1.Name = "button1";
            button1.Size = new Size(279, 64);
            button1.TabIndex = 0;
            button1.Text = "Tüm Ürünleri Listele";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 93);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(339, 334);
            listBox1.TabIndex = 1;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(367, 286);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "name";
            txtName.Size = new Size(180, 23);
            txtName.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(367, 330);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "price";
            txtPrice.Size = new Size(180, 23);
            txtPrice.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(377, 368);
            button2.Name = "button2";
            button2.Size = new Size(170, 49);
            button2.TabIndex = 4;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(589, 329);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Item ıd  to delete";
            textBox1.Size = new Size(159, 23);
            textBox1.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(589, 358);
            button3.Name = "button3";
            button3.Size = new Size(141, 59);
            button3.TabIndex = 6;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtUpdatePrice
            // 
            txtUpdatePrice.Location = new Point(506, 97);
            txtUpdatePrice.Name = "txtUpdatePrice";
            txtUpdatePrice.PlaceholderText = "price";
            txtUpdatePrice.Size = new Size(180, 23);
            txtUpdatePrice.TabIndex = 8;
            // 
            // textUpdateName
            // 
            textUpdateName.Location = new Point(506, 53);
            textUpdateName.Name = "textUpdateName";
            textUpdateName.PlaceholderText = "name";
            textUpdateName.Size = new Size(180, 23);
            textUpdateName.TabIndex = 7;
            // 
            // button4
            // 
            button4.Location = new Point(548, 141);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(txtUpdatePrice);
            Controls.Add(textUpdateName);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private TextBox txtName;
        private TextBox txtPrice;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private TextBox txtUpdatePrice;
        private TextBox textUpdateName;
        private Button button4;
    }
}
