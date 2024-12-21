namespace POOFinal
{
    partial class Dashboardcs
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label3 = new Label();
            listView1 = new ListView();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(357, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(139, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(99, 98);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(17, 22);
            label4.Name = "label4";
            label4.Size = new Size(116, 23);
            label4.TabIndex = 1;
            label4.Text = "Total Pedidos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(17, 54);
            label1.Name = "label1";
            label1.Size = new Size(33, 40);
            label1.TabIndex = 0;
            label1.Text = "0";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(809, 189);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 125);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(16, 22);
            label5.Name = "label5";
            label5.Size = new Size(140, 23);
            label5.TabIndex = 2;
            label5.Text = "Pedidos Abertos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(16, 54);
            label2.Name = "label2";
            label2.Size = new Size(33, 40);
            label2.TabIndex = 1;
            label2.Text = "0";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(1261, 189);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 125);
            panel3.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(17, 22);
            label6.Name = "label6";
            label6.Size = new Size(150, 23);
            label6.TabIndex = 3;
            label6.Text = "Pedidos Fechados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(17, 54);
            label3.Name = "label3";
            label3.Size = new Size(33, 40);
            label3.TabIndex = 1;
            label3.Text = "0";
            // 
            // listView1
            // 
            listView1.Location = new Point(234, 413);
            listView1.Name = "listView1";
            listView1.Size = new Size(1432, 409);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(234, 371);
            label7.Name = "label7";
            label7.Size = new Size(111, 32);
            label7.TabIndex = 4;
            label7.Text = "Pedidos:";
            // 
            // Dashboardcs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 1102);
            Controls.Add(label7);
            Controls.Add(listView1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboardcs";
            Text = "Dashboardcs";
            Load += Dashboardcs_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListView listView1;
        private Label label7;
        private PictureBox pictureBox1;
    }
}