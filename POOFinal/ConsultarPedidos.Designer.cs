namespace POOFinal
{
    partial class ConsultarPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            checkedListBox1 = new CheckedListBox();
            checkBox1 = new CheckBox();
            richTextBox2 = new RichTextBox();
            comboBox4 = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label12 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(197, 173);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(1254, 459);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            label1.Location = new Point(681, 106);
            label1.Name = "label1";
            label1.Size = new Size(233, 36);
            label1.TabIndex = 1;
            label1.Text = "Consultar Pedidos";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBox4);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(198, 48);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1253, 700);
            panel1.TabIndex = 2;
            panel1.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(checkedListBox1);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(richTextBox2);
            panel2.Location = new Point(159, 454);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(946, 221);
            panel2.TabIndex = 15;
            panel2.Visible = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(421, 179);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(154, 39);
            button1.TabIndex = 26;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(119, 38);
            checkedListBox1.Margin = new Padding(3, 2, 3, 2);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(172, 94);
            checkedListBox1.TabIndex = 24;
            checkedListBox1.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(119, 148);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(98, 19);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "Solução Geral";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(119, 38);
            richTextBox2.Margin = new Padding(3, 2, 3, 2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(604, 106);
            richTextBox2.TabIndex = 22;
            richTextBox2.Text = "";
            richTextBox2.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Font = new Font("Segoe UI", 13F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(363, 418);
            comboBox4.Margin = new Padding(3, 2, 3, 2);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(133, 31);
            comboBox4.TabIndex = 25;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Cursor = Cursors.Hand;
            label11.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label11.ForeColor = Color.ForestGreen;
            label11.Location = new Point(851, 65);
            label11.Name = "label11";
            label11.Size = new Size(113, 20);
            label11.TabIndex = 14;
            label11.Text = "Assumir Ticket";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F);
            label10.Location = new Point(851, 43);
            label10.Name = "label10";
            label10.Size = new Size(81, 25);
            label10.TabIndex = 13;
            label10.Text = "Assunto:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F);
            label9.Location = new Point(508, 44);
            label9.Name = "label9";
            label9.Size = new Size(81, 25);
            label9.TabIndex = 12;
            label9.Text = "Assunto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F);
            label8.Location = new Point(159, 43);
            label8.Name = "label8";
            label8.Size = new Size(81, 25);
            label8.TabIndex = 11;
            label8.Text = "Assunto:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13F);
            label12.Location = new Point(257, 420);
            label12.Name = "label12";
            label12.Size = new Size(96, 25);
            label12.TabIndex = 21;
            label12.Text = "Resolucão:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(257, 111);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(334, 31);
            textBox1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(257, 177);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(604, 91);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // comboBox3
            // 
            comboBox3.Enabled = false;
            comboBox3.Font = new Font("Segoe UI", 13F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(827, 362);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(133, 31);
            comboBox3.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.Font = new Font("Segoe UI", 13F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(537, 362);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 31);
            comboBox2.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.Font = new Font("Segoe UI", 13F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(257, 362);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 31);
            comboBox1.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F);
            label7.Location = new Point(827, 322);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 5;
            label7.Text = "Produto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(537, 322);
            label6.Name = "label6";
            label6.Size = new Size(119, 25);
            label6.TabIndex = 4;
            label6.Text = "SubCategoria";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(257, 322);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 3;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(159, 173);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 2;
            label4.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(159, 107);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 1;
            label3.Text = "Assunto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(1177, 39);
            label2.Name = "label2";
            label2.Size = new Size(25, 28);
            label2.TabIndex = 0;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // ConsultarPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 791);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ConsultarPedidos";
            Text = "ConsultarPedidos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private Panel panel1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label11;
        private Panel panel2;
        private Button button1;
        private ComboBox comboBox4;
        private CheckedListBox checkedListBox1;
        private CheckBox checkBox1;
        private RichTextBox richTextBox2;
        private Label label12;
    }
}