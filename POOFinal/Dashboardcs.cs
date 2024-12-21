using POOFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOFinal
{
    public partial class Dashboardcs : Form
    {
        public Dashboardcs()
        {
            InitializeComponent();
        }
       
        private void Dashboardcs_Load(object sender, EventArgs e)
        {

            var result = PedidoManager.GetPedidosCount();
            int total = result.pedidosAbertos + result.pedidosEmResolucao;
            label1.Text = result.totalPedidos.ToString();
            label2.Text = total.ToString() ;
            label3.Text = result.pedidosConcluidos.ToString();

            var utilizadorLogado = LoginManager.Instance.getUserLogado();
            if (utilizadorLogado == null)
            {
                MessageBox.Show("Nenhum utilizador logado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                listView1.Items.Clear();    
                listView1.Columns.Clear();

                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Utilizador", 150);
                listView1.Columns.Add("Assunto", 150);
                listView1.Columns.Add("Categoria", 150);
                listView1.Columns.Add("Sub-Categoria", 150);
                listView1.Columns.Add("Produto", 150);
                listView1.Columns.Add("Prioridade", 150);
                listView1.Columns.Add("Estado", 150);
                listView1.Columns.Add("Tecnico", 150);
                listView1.Columns.Add("Data Criação", 150);

                List<Pedido> pedidos = PedidoManager.GetByUtilizadorId(utilizadorLogado.Id);

                foreach (var pedido in pedidos)
                {
                    var item = new ListViewItem(pedido.ID.ToString());
                    item.SubItems.Add(pedido.Utilizador.Nome);
                    item.SubItems.Add(pedido.Assunto);
                    item.SubItems.Add(pedido.Categoria.ToString());
                    item.SubItems.Add(pedido.SubCategoria.Nome.ToString());
                    item.SubItems.Add(pedido.Produto.Nome.ToString());
                    item.SubItems.Add(pedido.Prioridade.ToString());
                    item.SubItems.Add(pedido.Estado.ToString());
                    if (pedido.Tecnico == null)
                    {
                        item.SubItems.Add("Sem Tecnico");

                    }
                    else
                    {
                        item.SubItems.Add(pedido.Tecnico.Nome.ToString());
                    }
                    item.SubItems.Add(pedido.DataCriacao.ToString());

                    item.Tag = pedido;

                    switch (pedido.Prioridade)
                    {
                        case Prioridade.Baixa:
                            item.BackColor = Color.LightGreen;
                            break;
                        case Prioridade.Normal:
                            item.BackColor = Color.LightYellow;
                            break;
                        case Prioridade.Alta:
                            item.BackColor = Color.Orange;
                            break;
                        case Prioridade.Urgente:
                            item.BackColor = Color.Red;
                            break;
                    }

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar utilizadores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
