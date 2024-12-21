using POOFinal.Models;

namespace POOFinal
{
    public partial class AdicionarUtilizadorescs : Form
    {
        public AdicionarUtilizadorescs()
        {
            InitializeComponent();
            carregarUtilizadores();
        }

        private void carregarUtilizadores()
        {
            try
            {
                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.View = View.Details;
                listView1.FullRowSelect = true;


                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Nome", 150);
                listView1.Columns.Add("Email", 200);
                listView1.Columns.Add("Telemovel", 100);
                listView1.Columns.Add("Técnico", 70);
                listView1.Columns.Add("Ativo", 70);
                listView1.Columns.Add("Data Registo", 170);


                List<Utilizador> utilizadores = UtilizadorManager.GetAllUsers();

                foreach (var utilizador in utilizadores)
                {
                    var item = new ListViewItem(utilizador.Id.ToString());
                    item.SubItems.Add(utilizador.Nome);
                    item.SubItems.Add(utilizador.Email);
                    item.SubItems.Add(utilizador.Telemovel);
                    item.SubItems.Add(utilizador.Tecnico ? "Sim" : "Não");
                    item.SubItems.Add(utilizador.Ativo ? "Sim" : "Não");
                    item.SubItems.Add(utilizador.DataRegistro.ToString());

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
                bool tecnico = false;
                if (radioButton1.Checked)
                {
                    tecnico = true;
                }
                string nome = textBox1.Text.Trim();
                string email = textBox2.Text.Trim();
                string password = textBox3.Text.Trim();
                string telemovel = textBox4.Text.Trim();

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios (Nome, Email, Password).");
                    return;
                }

                var novoUtilizador = new Utilizador(
                    0,
                    nome,
                    email,
                    telemovel,
                    password,
                    tecnico,
                    true,
                    DateTime.Now
                );

                if (UtilizadorManager.AdicionarUser(novoUtilizador))
                {
                    carregarUtilizadores();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    MessageBox.Show("Utilizador adicionado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao inserir utilizador!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var itemSelecionado = listView1.SelectedItems[0];

                textBox1.Text = itemSelecionado.SubItems[1].Text;
                textBox2.Text = itemSelecionado.SubItems[2].Text;
                textBox4.Text = itemSelecionado.SubItems[3].Text;

                if (itemSelecionado.SubItems[4].Text == "Sim")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Por favor, selecione um utilizador para atualizar.");
                    return;
                }

                var itemSelecionado = listView1.SelectedItems[0];
                int id = int.Parse(itemSelecionado.SubItems[0].Text);

                string nome = textBox1.Text.Trim();
                string email = textBox2.Text.Trim();
                string telemovel = textBox4.Text.Trim();
                bool tecnico = radioButton1.Checked;

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Por favor, preencha os campos obrigatórios (Nome e Email).");
                    return;
                }

                var utilizadorAtualizado = new Utilizador(
                    id,
                    nome,
                    email,
                    telemovel,
                    null,
                    tecnico,
                    true, 
                    DateTime.Now 
                );

                if (UtilizadorManager.AtualizarUser(utilizadorAtualizado))
                {
                    MessageBox.Show("Utilizador atualizado com sucesso!");

                    carregarUtilizadores();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar utilizador!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

    }
}
