using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using POOFinal.Models;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics.Eventing.Reader;
using System.Data.SQLite;
using System.Data;

namespace POOFinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var utilizadorlogado = LoginManager.Instance.getUserLogado();

            if (utilizadorlogado != null && !utilizadorlogado.Tecnico)
            {
                AtualizarMenu();
            }

            loadform(new Dashboardcs());
        }
        private void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }
        private void AtualizarMenu()
        {
            menuStrip1.Items["utilizadoresToolStripMenuItem"].Enabled = false;
            menuStrip1.Items["produtosToolStripMenuItem"].Enabled = false;
            adicionarSoluçãoToolStripMenuItem.Enabled = false;


        }


        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new AdicionarUtilizadorescs());
        }

        private void adicionarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new AbrirTicket());
        }

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adicionarConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Produtos());

        }

        private void adicionarConsultarSubcategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new AdicionarSubCategoria());
        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                loadform(new ConsultarPedidos());
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Dashboardcs());

        }
    }
}
    


