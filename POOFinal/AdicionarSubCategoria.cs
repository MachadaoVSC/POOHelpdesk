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
    public partial class AdicionarSubCategoria : Form
    {
        public AdicionarSubCategoria()
        {
            InitializeComponent();
            carregarSubCategorias();
            carregarCategorias();
        }

        private void carregarCategorias()
        {
            try
            {
                comboBox1.DataSource = Enum.GetValues(typeof(Categoria));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarSubCategorias()
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
                listView1.Columns.Add("Ativo", 100);

                List<SubCategoria> subCategorias = SubCategoriaManager.ObterTodasSubCategorias();

                foreach (var subCategoria in subCategorias)
                {
                    var item = new ListViewItem(subCategoria.IdSubCategoria.ToString());
                    item.SubItems.Add(subCategoria.Nome);

                    item.SubItems.Add(subCategoria.Categoria.ToString());

                    item.SubItems.Add(subCategoria.Ativa ? "Sim" : "Não");
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
            string nome = textBox1.Text;

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria categoriaProduto;
            if (Enum.TryParse(comboBox1.SelectedItem.ToString(), out categoriaProduto))
            {
                SubCategoria novaSubCategoria = new SubCategoria(0, nome, categoriaProduto, true, DateTime.Now);

                bool sucesso = SubCategoriaManager.AdicionarSubCategoria(novaSubCategoria);

                if (sucesso)
                {
                    MessageBox.Show("Sub-Categoria adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarSubCategorias();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar a sub-categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Categoria selecionada inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                checkBox1.Checked = selectedItem.SubItems[3].Text == "Sim";
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                textBox1.Text = "";
                comboBox1.SelectedIndex = -1;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];

                int id = int.Parse(selectedItem.SubItems[0].Text);
                string nome = textBox1.Text;
                Categoria categoriaSelecionada = (Categoria)comboBox1.SelectedItem;
                bool ativa = checkBox1.Checked;

                SubCategoria subCategoriaEditada = new SubCategoria(id, nome, categoriaSelecionada, ativa, DateTime.Now);

                bool sucesso = SubCategoriaManager.AtualizarSubCategoria(subCategoriaEditada);

                if (sucesso)
                {
                    MessageBox.Show("Sub-Categoria atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarSubCategorias();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar Sub-Categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma sub-categoria para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
