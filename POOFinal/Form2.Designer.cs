
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
            produtosToolStripMenuItem = new ToolStripMenuItem();
            adicionarConsultarSubcategoriaToolStripMenuItem = new ToolStripMenuItem();
            adicionarConsultarToolStripMenuItem = new ToolStripMenuItem();
            utilizadoresToolStripMenuItem = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem, pedidosToolStripMenuItem, soluçõesToolStripMenuItem, produtosToolStripMenuItem, utilizadoresToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1539, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(96, 24);
            dashboardToolStripMenuItem.Text = "Dashboard";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adicionarPedidosToolStripMenuItem, consultarPedidoToolStripMenuItem });
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(75, 24);
            pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // adicionarPedidosToolStripMenuItem
            // 
            adicionarPedidosToolStripMenuItem.Name = "adicionarPedidosToolStripMenuItem";
            adicionarPedidosToolStripMenuItem.Size = new Size(156, 26);
            adicionarPedidosToolStripMenuItem.Text = "Adicionar";
            adicionarPedidosToolStripMenuItem.Click += adicionarPedidosToolStripMenuItem_Click;
            // 
            // consultarPedidoToolStripMenuItem
            // 
            consultarPedidoToolStripMenuItem.Name = "consultarPedidoToolStripMenuItem";
            consultarPedidoToolStripMenuItem.Size = new Size(156, 26);
            consultarPedidoToolStripMenuItem.Text = "Consultar";
            consultarPedidoToolStripMenuItem.Click += consultarPedidoToolStripMenuItem_Click;
            // 
            // soluçõesToolStripMenuItem
            // 
            soluçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adicionarSoluçãoToolStripMenuItem, consultarSoluçõesToolStripMenuItem });
            soluçõesToolStripMenuItem.Name = "soluçõesToolStripMenuItem";
            soluçõesToolStripMenuItem.Size = new Size(82, 24);
            soluçõesToolStripMenuItem.Text = "Soluções";
            // 
            // adicionarSoluçãoToolStripMenuItem
            // 
            adicionarSoluçãoToolStripMenuItem.Name = "adicionarSoluçãoToolStripMenuItem";
            adicionarSoluçãoToolStripMenuItem.Size = new Size(156, 26);
            adicionarSoluçãoToolStripMenuItem.Text = "Adicionar";
            // 
            // consultarSoluçõesToolStripMenuItem
            // 
            consultarSoluçõesToolStripMenuItem.Name = "consultarSoluçõesToolStripMenuItem";
            consultarSoluçõesToolStripMenuItem.Size = new Size(156, 26);
            consultarSoluçõesToolStripMenuItem.Text = "Consultar";
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adicionarConsultarSubcategoriaToolStripMenuItem, adicionarConsultarToolStripMenuItem });
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(82, 24);
            produtosToolStripMenuItem.Text = "Produtos";
            produtosToolStripMenuItem.Click += produtosToolStripMenuItem_Click;
            // 
            // adicionarConsultarSubcategoriaToolStripMenuItem
            // 
            adicionarConsultarSubcategoriaToolStripMenuItem.Name = "adicionarConsultarSubcategoriaToolStripMenuItem";
            adicionarConsultarSubcategoriaToolStripMenuItem.Size = new Size(322, 26);
            adicionarConsultarSubcategoriaToolStripMenuItem.Text = "Adicionar/Consultar Sub-categoria";
            adicionarConsultarSubcategoriaToolStripMenuItem.Click += adicionarConsultarSubcategoriaToolStripMenuItem_Click;
            // 
            // adicionarConsultarToolStripMenuItem
            // 
            adicionarConsultarToolStripMenuItem.Name = "adicionarConsultarToolStripMenuItem";
            adicionarConsultarToolStripMenuItem.Size = new Size(322, 26);
            adicionarConsultarToolStripMenuItem.Text = "Adicionar/Consultar Produto";
            adicionarConsultarToolStripMenuItem.Click += adicionarConsultarToolStripMenuItem_Click;
            // 
            // utilizadoresToolStripMenuItem
            // 
            utilizadoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultarToolStripMenuItem });
            utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            utilizadoresToolStripMenuItem.Size = new Size(102, 24);
            utilizadoresToolStripMenuItem.Text = "Utilizadores";
            utilizadoresToolStripMenuItem.Click += utilizadoresToolStripMenuItem_Click;
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(224, 26);
            consultarToolStripMenuItem.Text = "Adicionar/Consultar";
            consultarToolStripMenuItem.Click += consultarToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1539, 625);
            panel1.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1539, 653);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Ticket - Helpdesk";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem adicionarConsultarToolStripMenuItem;
        private ToolStripMenuItem adicionarConsultarSubcategoriaToolStripMenuItem;
    }
}