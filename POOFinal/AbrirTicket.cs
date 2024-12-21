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
    public partial class AbrirTicket : Form
    {
        public AbrirTicket()
        {
            InitializeComponent();
            PreencherCategoria();
            PreencherPrioridade();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string titulo = textBox5.Text;
            string desc = richTextBox1.Text;

            var selectedCategory = comboBox5.SelectedItem as dynamic;
            if (selectedCategory == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var categoria = CategoriaManager.GetById(selectedCategory.ID);

            var subcategoriaSelecionada = comboBox3.SelectedItem as dynamic;
            if (subcategoriaSelecionada == null)
            {
                MessageBox.Show("Por favor, selecione uma subcategoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subcategoriaSelecionada.ID);

            var prodSelecionada = comboBox2.SelectedItem as dynamic;
            if (prodSelecionada == null)
            {
                MessageBox.Show("Por favor, selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var produto = ProdutoManager.GetById(prodSelecionada.ID);
            

            var prioridadeSelecionada = comboBox1.SelectedItem as dynamic;
            if (prioridadeSelecionada == null)
            {
                MessageBox.Show("Por favor, selecione uma prioridade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prioridade = (Prioridade)prioridadeSelecionada.ID;

            try
            {
                var utilizadorLogado = LoginManager.Instance.getUserLogado();
                if (utilizadorLogado == null)
                {
                    MessageBox.Show("Nenhum utilizador logado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var pedido = new Pedido(
                    id: 0,
                    assunto: titulo,
                    descAssunto: desc,
                    categoria: categoria,
                    subCategoria: subCategoria,
                    produto: produto,
                    utilizador: utilizadorLogado,
                    tecnico: null, 
                    estado: EstadoPedido.Aberto,
                    prioridade: prioridade,
                    solucao: null, 
                    dataCriacao: DateTime.Now,
                    dataConclusao: null 
                );

                bool sucesso = PedidoManager.InsertPedido(pedido);

                if (sucesso)
                {
                    MessageBox.Show("Pedido criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao criar o pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox5.Text = "";
            richTextBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }



        private void PreencherCategoria()
        {
            var tipos = Enum.GetValues(typeof(Categoria));

            if (tipos != null && tipos.Length > 0)
            {
                comboBox5.Items.Clear();

                foreach (Categoria tipo in tipos)
                {
                    comboBox5.Items.Add(new { ID = (int)tipo, Nome = tipo.ToString() });
                }

                comboBox5.DisplayMember = "Nome";
                comboBox5.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show("Nenhum Tipo de Pedido encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherPrioridade()
        {
            var prioridades = Enum.GetValues(typeof(Prioridade));

            if (prioridades != null && prioridades.Length > 0)
            {
                comboBox1.Items.Clear();

                foreach (Prioridade prioridade in prioridades)
                {
                    comboBox1.Items.Add(new { ID = (int)prioridade, Nome = prioridade.ToString() });
                }

                comboBox1.DisplayMember = "Nome"; 
                comboBox1.ValueMember = "ID"; 
            }
            else
            {
                MessageBox.Show("Nenhum tipo de prioridade encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AbrirTicket_Load(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem is not null)
            {
                var selectedCategory = comboBox5.SelectedItem as dynamic;
                int categoriaId = selectedCategory.ID;

                CarregarSubCategorias(categoriaId);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma categoria válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarregarSubCategorias(int categoriaId)
        {
            try
            {
                var subCategorias = SubCategoriaManager.ObterSubCategoriasPorCategoriaId(categoriaId);

                if (subCategorias.Any())
                {
                    comboBox3.Items.Clear();

                    foreach (var subCategoria in subCategorias)
                    {
                        comboBox3.Items.Add(new { ID = subCategoria.IdSubCategoria, Nome = subCategoria.Nome });
                    }

                    comboBox3.DisplayMember = "Nome";
                    comboBox3.ValueMember = "ID";
                }
                else
                {
                    MessageBox.Show("Nenhuma subcategoria encontrada para esta categoria.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar subcategorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem is not null)
            {
                var selectedProduto = comboBox3.SelectedItem as dynamic;
                int produtoId = selectedProduto.ID;

                CarregarProdutos(produtoId);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma categoria válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarregarProdutos(int produtoId)
        {
            try
            {
                var produtos = ProdutoManager.ObterProdutosPorSubCategoriaId(produtoId);

                if (produtos.Any())
                {
                    comboBox2.Items.Clear();

                    foreach (var produto in produtos)
                    {
                        comboBox2.Items.Add(new { ID = produto.IdProduto, Nome = produto.Nome });
                    }

                    comboBox2.DisplayMember = "Nome";
                    comboBox2.ValueMember = "ID";
                }
                else
                {
                    MessageBox.Show("Nenhuma subcategoria encontrada para esta categoria.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar subcategorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
