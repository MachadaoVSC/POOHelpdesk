using POOFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POOFinal
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            carregarProdutos();
            carregarCategorias();
        }

        private void carregarCategorias()
        {
            try
            {
                comboBox1.DataSource = Enum.GetValues(typeof(Categoria));
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void carregarProdutos()
        {
            try
            {
                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.View = View.Details;
                listView1.FullRowSelect = true;


                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Nome", 150);
                listView1.Columns.Add("Categoria", 200);
                listView1.Columns.Add("Sub-Categoria", 200);
                listView1.Columns.Add("Referencia", 200);
                listView1.Columns.Add("Ativo", 100);



                List<Produto> produtos = ProdutoManager.GetAllProdutos();

                foreach (var produto in produtos)
                {
                    var item = new ListViewItem(produto.IdProduto.ToString());
                    item.SubItems.Add(produto.Nome);
                    item.SubItems.Add(produto.CategoriaTipo.ToString());
                    item.SubItems.Add(produto.SubCategoriaTipo.Nome.ToString());
                    item.SubItems.Add(produto.Ref);

                    if (produto.Ativo == true)
                    {
                        item.SubItems.Add("Sim");
                    }
                    else
                    {
                        item.SubItems.Add("Não");
                    }

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar utilizadores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeProduto = textBox1.Text;
                string RefProduto = textBox2.Text;

                Categoria categoriaProduto = (Categoria)comboBox1.SelectedItem;
                var subcategoriaSelecionada = comboBox2.SelectedItem as dynamic;
                int subcategoriaId;
                if (subcategoriaSelecionada != null)
                {
                    subcategoriaId = subcategoriaSelecionada.ID;
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma subcategoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(nomeProduto))
                {
                    MessageBox.Show("Por favor, insira o nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SubCategoria subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subcategoriaId);

                Produto novoProduto = new Produto(0, nomeProduto, categoriaProduto, subCategoria, RefProduto, true);

                bool sucesso = ProdutoManager.InsertProduto(novoProduto);

                if (sucesso)
                {
                    MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarProdutos();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[1].Text;

                string categoriaTexto = selectedItem.SubItems[2].Text.Trim();

                try
                  {
                     Categoria categoriaSelecionada = (Categoria)Enum.Parse(typeof(Categoria), categoriaTexto, ignoreCase: true);
                     comboBox1.SelectedItem = categoriaSelecionada;
                   }
                 catch (Exception)
                   {
                      MessageBox.Show($"Categoria inválida: {categoriaTexto}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
                string subCategoriaTexto = selectedItem.SubItems[3].Text.Trim();

                if (!string.IsNullOrEmpty(subCategoriaTexto))
                {
                    // Percorre os itens do ComboBox e encontra a subcategoria correspondente
                    foreach (var item in comboBox2.Items)
                    {
                        dynamic subCategoria = item; // Supõe que você adicionou itens dinâmicos com ID e Nome
                        if (subCategoria.Nome == subCategoriaTexto)
                        {
                            comboBox2.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    comboBox2.SelectedIndex = -1; // Nenhuma subcategoria encontrada ou inválida
                }
                textBox2.Text = selectedItem.SubItems[4].Text;
                bool ativa = checkBox1.Checked;

                checkBox1.Checked = selectedItem.SubItems[5].Text == "Sim";
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem is Categoria categoriaSelecionada)
                {
                    int categoriaId = (int)categoriaSelecionada;
                    CarregarSubCategorias(categoriaId);
                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    // Nenhuma seleção feita
                    return;
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma categoria válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar a seleção de categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CarregarSubCategorias(int categoriaId)
        {
            try
            {
                var subCategorias = SubCategoriaManager.ObterSubCategoriasPorCategoriaId(categoriaId);

                if (subCategorias.Any())
                {
                    comboBox2.Items.Clear();

                    foreach (var subCategoria in subCategorias)
                    {
                        comboBox2.Items.Add(new { ID = subCategoria.IdSubCategoria, Nome = subCategoria.Nome });
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];

             int id = int.Parse(selectedItem.SubItems[0].Text);
             string nome = textBox1.Text;
             string RefProduto = textBox2.Text;
             Categoria categoriaSelecionada = (Categoria)comboBox1.SelectedItem;
             var subcategoriaSelecionada = comboBox2.SelectedItem as dynamic;
             bool ativo = checkBox1.Checked;
             int subcategoriaId;
                if (subcategoriaSelecionada != null)
                {
                    subcategoriaId = subcategoriaSelecionada.ID;
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma subcategoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("Por favor, insira o nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SubCategoria subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subcategoriaId);
                Produto produtoEditado = new Produto(id, nome, categoriaSelecionada, subCategoria, RefProduto,ativo);
             bool sucesso = ProdutoManager.AtualizarPoduto(produtoEditado);

              if (sucesso)
              {
                 MessageBox.Show("Produto atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarProdutos();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar Produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Produto para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
