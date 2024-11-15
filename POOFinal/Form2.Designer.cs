
namespace POOFinal
{
    partial class Form2
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
            menuStrip1 = new MenuStrip();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            adicionarPedidosToolStripMenuItem = new ToolStripMenuItem();
            consultarPedidoToolStripMenuItem = new ToolStripMenuItem();
            soluçõesToolStripMenuItem = new ToolStripMenuItem();
            adicionarSoluçãoToolStripMenuItem = new ToolStripMenuItem();
            consultarSoluçõesToolStripMenuItem = new ToolStripMenuItem();
            utilizadoresToolStripMenuItem = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox5 = new TextBox();
            label12 = new Label();
            button3 = new Button();
            comboBox3 = new ComboBox();
            comboBox1 = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            richTextBox1 = new RichTextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            Column3 = new DataGridViewButtonColumn();
            label6 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem, pedidosToolStripMenuItem, soluçõesToolStripMenuItem, utilizadoresToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1160, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(116, 29);
            dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adicionarPedidosToolStripMenuItem, consultarPedidoToolStripMenuItem });
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(91, 29);
            pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // adicionarPedidosToolStripMenuItem
            // 
            adicionarPedidosToolStripMenuItem.Name = "adicionarPedidosToolStripMenuItem";
            adicionarPedidosToolStripMenuItem.Size = new Size(189, 34);
            adicionarPedidosToolStripMenuItem.Text = "Adicionar";
            adicionarPedidosToolStripMenuItem.Click += adicionarPedidosToolStripMenuItem_Click;
            // 
            // consultarPedidoToolStripMenuItem
            // 
            consultarPedidoToolStripMenuItem.Name = "consultarPedidoToolStripMenuItem";
            consultarPedidoToolStripMenuItem.Size = new Size(189, 34);
            consultarPedidoToolStripMenuItem.Text = "Consultar";
            // 
            // soluçõesToolStripMenuItem
            // 
            soluçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adicionarSoluçãoToolStripMenuItem, consultarSoluçõesToolStripMenuItem });
            soluçõesToolStripMenuItem.Name = "soluçõesToolStripMenuItem";
            soluçõesToolStripMenuItem.Size = new Size(99, 29);
            soluçõesToolStripMenuItem.Text = "Soluções";
            // 
            // adicionarSoluçãoToolStripMenuItem
            // 
            adicionarSoluçãoToolStripMenuItem.Name = "adicionarSoluçãoToolStripMenuItem";
            adicionarSoluçãoToolStripMenuItem.Size = new Size(189, 34);
            adicionarSoluçãoToolStripMenuItem.Text = "Adicionar";
            // 
            // consultarSoluçõesToolStripMenuItem
            // 
            consultarSoluçõesToolStripMenuItem.Name = "consultarSoluçõesToolStripMenuItem";
            consultarSoluçõesToolStripMenuItem.Size = new Size(189, 34);
            consultarSoluçõesToolStripMenuItem.Text = "Consultar";
            // 
            // utilizadoresToolStripMenuItem
            // 
            utilizadoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultarToolStripMenuItem });
            utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            utilizadoresToolStripMenuItem.Size = new Size(120, 29);
            utilizadoresToolStripMenuItem.Text = "Utilizadores";
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(271, 34);
            consultarToolStripMenuItem.Text = "Adicionar/Consultar";
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1160, 712);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(comboBox3);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(3, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(1157, 709);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(165, 120);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(550, 31);
            textBox5.TabIndex = 26;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(54, 120);
            label12.Name = "label12";
            label12.Size = new Size(56, 25);
            label12.TabIndex = 25;
            label12.Text = "Titulo";
            // 
            // button3
            // 
            button3.Location = new Point(476, 576);
            button3.Name = "button3";
            button3.Size = new Size(177, 56);
            button3.TabIndex = 24;
            button3.Text = "Adicionar Pedido";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(165, 381);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(182, 33);
            comboBox3.TabIndex = 23;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Baixa", "Alta", "Normal", "Urgente" });
            comboBox1.Location = new Point(165, 461);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(54, 464);
            label11.Name = "label11";
            label11.Size = new Size(93, 25);
            label11.TabIndex = 19;
            label11.Text = "Prioridade";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(26, 384);
            label10.Name = "label10";
            label10.Size = new Size(133, 25);
            label10.TabIndex = 18;
            label10.Text = "Tecnico Atribuir";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(165, 176);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(943, 165);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(54, 251);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 17;
            label9.Text = "Assunto";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(476, 60);
            label8.Name = "label8";
            label8.Size = new Size(166, 25);
            label8.TabIndex = 16;
            label8.Text = "Abertura de Pedido";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(479, 415);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 15;
            label7.Text = "label7";
            label7.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(535, 647);
            button2.Name = "button2";
            button2.Size = new Size(293, 39);
            button2.TabIndex = 14;
            button2.Text = "Atualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column3 });
            dataGridView1.Location = new Point(57, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1054, 369);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column3
            // 
            Column3.HeaderText = "Delete";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Text = "Delete";
            Column3.UseColumnTextForButtonValue = true;
            Column3.Width = 70;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(395, 610);
            label6.Name = "label6";
            label6.Size = new Size(0, 25);
            label6.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(479, 473);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 11;
            label5.Text = "Telemovel";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(572, 470);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(237, 31);
            textBox4.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(830, 510);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 9;
            label4.Text = "Tecnico?";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(923, 526);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(70, 29);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Não";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(923, 491);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(67, 29);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Sim";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(572, 545);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(237, 31);
            textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(236, 551);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(237, 31);
            textBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(479, 551);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 551);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // button1
            // 
            button1.Location = new Point(236, 647);
            button1.Name = "button1";
            button1.Size = new Size(293, 39);
            button1.TabIndex = 2;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(236, 467);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 31);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 470);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 748);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form2";
            Text = "Sistema de Ticket - Helpdesk";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem adicionarPedidosToolStripMenuItem;
        private ToolStripMenuItem consultarPedidoToolStripMenuItem;
        private ToolStripMenuItem soluçõesToolStripMenuItem;
        private ToolStripMenuItem adicionarSoluçãoToolStripMenuItem;
        private ToolStripMenuItem consultarSoluçõesToolStripMenuItem;
        private ToolStripMenuItem utilizadoresToolStripMenuItem;
        private ToolStripMenuItem consultarToolStripMenuItem;
        private Panel panel1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private DataGridView dataGridView1;
        private DataGridViewButtonColumn Column3;
        private Button button2;
        private Label label7;
        private Panel panel2;
        private RichTextBox richTextBox1;
        private Label label9;
        private Label label8;
        private Label label11;
        private Label label10;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Button button3;
        private Label label12;
        private TextBox textBox5;
    }
}