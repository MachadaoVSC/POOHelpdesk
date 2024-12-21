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
    public partial class ConsultarPedidos : Form
    {
        public ConsultarPedidos()
        {
            InitializeComponent();
            carregarPedidos();
        }

        private void carregarPedidos()
        {
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

                List<Pedido> pedidos;
                var utilizadorlogado = LoginManager.Instance.getUserLogado();

                pedidos = PedidoManager.GetAllPedidos(); // Retorna uma lista de pedidos

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

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                var selectedItem = listView1.SelectedItems[0];
                var pedido = selectedItem.Tag as Pedido;

                if (pedido != null)
                {
                    panel1.Visible = true;
                    textBox1.Text = pedido.Assunto;
                    richTextBox1.Text = pedido.DescAssunto;
                    comboBox1.Text = pedido.Categoria.ToString();
                    comboBox2.Text = pedido.SubCategoria.Nome.ToString();
                    comboBox3.Text = pedido.Produto.Nome.ToString();
                    label9.Text = "Cliente: " + pedido.Utilizador.Nome.ToString();

                    if (pedido.Tecnico == null)
                    {
                        label10.Text = "Tecnico: Por definir";
                        label11.Visible = true;
                        panel2.Visible = false;
                        comboBox4.Items.Clear();
                        richTextBox2.Text = "";
                        checkBox1.Enabled = false;

                    }
                    else
                    {
                        label10.Text = "Tecnico: " + pedido.Tecnico.Nome.ToString();
                        label11.Visible = false;
                        panel2.Visible = true;
                        comboBox4.Items.Clear();
                        comboBox4.Items.Add("Nova");
                        comboBox4.Items.Add("Existente");


                        if (pedido.Solucao != null)
                        {
                            if (pedido.Solucao.Geral == false)
                            {
                                comboBox4.Enabled = false;
                                comboBox4.SelectedIndex = 0;
                                richTextBox2.Visible = true;
                                checkBox1.Visible = true;
                                richTextBox2.Text = pedido.Solucao.DescAssunto;
                                richTextBox2.Enabled = false;
                                checkBox1.Enabled = false;
                                if (pedido.Solucao.Geral == true)
                                {
                                    checkBox1.Checked = true;
                                }
                                else
                                {
                                    checkBox1.Checked = false;
                                }
                                button1.Enabled = false;
                            }
                            else
                            {

                            }
                        }
                    }
                    label8.Text = "Data: " + pedido.DataCriacao.ToString();
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];

                var pedido = selectedItem.Tag as Pedido;

                MessageBox.Show(pedido.ID.ToString());
                var pedidobd = PedidoManager.GetById(pedido.ID);

                if (pedidobd != null)
                {
                    MessageBox.Show($"Pedido ID: {pedidobd.ID}\nAssunto: {pedidobd.Assunto}");
                }
                else
                {
                    MessageBox.Show("Pedido não encontrado.");
                }

                var utilizadorLogado = LoginManager.Instance.getUserLogado();
                if (utilizadorLogado == null)
                {
                    MessageBox.Show("Nenhum Tecnico logado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    bool atualizado = PedidoManager.UpdateTecnico(pedido.ID, utilizadorLogado.Id);

                    if (atualizado)
                    {
                        MessageBox.Show($"Técnico atualizado para o pedido ID: {pedido.ID}");
                    }
                    else
                    {
                        MessageBox.Show($"Falha ao atualizar o técnico para o pedido ID: {pedido.ID}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar o técnico: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado.");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Nova")
            {
                checkedListBox1.Visible = false;
                richTextBox2.Visible = true;
                checkBox1.Visible = true;
            }
            else if (comboBox4.SelectedItem.ToString() == "Existente")
            {
                richTextBox2.Visible = false;
                checkBox1.Visible = false;
                checkedListBox1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                var pedido = selectedItem.Tag as Pedido;


                var utilizadorLogado = LoginManager.Instance.getUserLogado();
                if (utilizadorLogado == null)
                {
                    MessageBox.Show("Nenhum utilizador logado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox4.SelectedItem.ToString() == "Nova")
                {
                    string resolucao = richTextBox2.Text;
                    bool geral = false;
                    if (checkBox1.Checked)
                    {
                        geral = true;
                    }
                    else
                    {
                        geral = false;
                    }

                    Solucoes solucao = new Solucoes(
                        id: 0,
                        descassunto: resolucao,
                        categoria: pedido.Categoria,
                        subCategoria: pedido.SubCategoria,
                        produto: pedido.Produto,
                        geral: geral,
                        tecnico: utilizadorLogado
                    );
                    int idSolucao = SolucoesManager.InsertSolucoes(solucao);

                    if (idSolucao > 0)
                    {
                        bool atualizado = PedidoManager.UpdatePedidoComSolucao(pedido.ID, idSolucao, EstadoPedido.Concluido);

                        if (atualizado)
                        {
                            MessageBox.Show("Pedido atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar o pedido com a solução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao inserir a solução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (comboBox4.SelectedItem.ToString() == "Existente")
                {

                }
            }
        }
    }
}
