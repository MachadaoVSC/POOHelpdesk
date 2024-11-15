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
            CarregarUtilizadores();
            CarregarTecnicos();
            BdConnection.CloseConnection();
        }

        private void CarregarUtilizadores()
        {
            List<Utilizador> utilizadores = new List<Utilizador>();

            try
            {
                if (BdConnection.Connection.State != ConnectionState.Open)
                {
                    BdConnection.Connection.Open();
                }

                using (var cmd = new SQLiteCommand("SELECT id, Nome, Email, Telemovel, Password, Tecnico FROM Utilizadores", BdConnection.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Nenhum utilizador encontrado na base de dados.");
                        return;
                    }

                    while (reader.Read())
                    {
                        try
                        {
                            Utilizador utilizador = new Utilizador(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3), // Safe nullable handling
                                reader.GetString(4),
                                reader.GetInt32(5) == 1 // Safe boolean handling for "Tecnico"
                            );
                            utilizadores.Add(utilizador);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao ler um registro: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar utilizadores: {ex.Message}");
            }
            finally
            {
                if (BdConnection.Connection.State == ConnectionState.Open)
                {
                    BdConnection.Connection.Close();
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = utilizadores;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string telemovel = textBox4.Text;

            try
            {
                if (BdConnection.Connection.State != ConnectionState.Open)
                {
                    BdConnection.Connection.Open();
                }

                using (var cmd = new SQLiteCommand(@"INSERT INTO Utilizadores (Nome, Email, Telemovel, Password, Tecnico) 
                                                    VALUES (@Nome, @Email, @Telemovel, @Password, @Tecnico)", BdConnection.Connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telemovel", telemovel);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Tecnico", 0);

                    cmd.ExecuteNonQuery();
                    CarregarUtilizadores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir utilizador: " + ex.Message);
            }
        }

        // Método para o RadioButton técnico
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Método para o RadioButton não técnico
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Adicionar customização de painel, se necessário
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int valorCelula = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                MessageBox.Show(valorCelula.ToString());

                try
                {
                    // Abrir a conexão explicitamente
                    if (BdConnection.Connection.State != ConnectionState.Open)
                    {
                        BdConnection.Connection.Open();
                    }

                    // Criar o comando SQL
                    using (var cmd = BdConnection.Connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, Nome, Email, Telemovel, Password, Tecnico FROM Utilizadores WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", valorCelula); // Usar parâmetros para evitar SQL Injection

                        label7.Text = valorCelula.ToString();

                        // Executar o comando e ler os resultados
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Nenhum utilizador encontrado na base de dados.");
                                return;
                            }

                            while (reader.Read())
                            {
                                try
                                {
                                    textBox1.Text = reader.GetString(1);
                                    textBox2.Text = reader.GetString(2);
                                    textBox3.Text = reader.GetString(4);
                                    textBox4.Text = reader.GetString(3);
                                    if (reader.GetBoolean(5) == true)
                                    {
                                        radioButton1.Checked = true;
                                    }
                                    else
                                    {
                                        radioButton2.Checked = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Erro ao ler um registro: {ex.Message}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar utilizadores: {ex.Message}");
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int valorCelula = int.Parse(label7.Text);
            bool tecnico = radioButton1.Checked;
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string telemovel = textBox4.Text;

            try
            {
                if (BdConnection.Connection.State != ConnectionState.Open)
                {
                    BdConnection.Connection.Open();
                }

                using (var cmd = new SQLiteCommand(@"UPDATE Utilizadores 
                                                    SET Nome = @Nome, 
                                                        Email = @Email, 
                                                        Telemovel = @Telemovel, 
                                                        Password = @Password, 
                                                        Tecnico = @Tecnico 
                                                    WHERE Id = @Id", BdConnection.Connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telemovel", telemovel);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Tecnico", tecnico ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Id", valorCelula);

                    cmd.ExecuteNonQuery();
                    CarregarUtilizadores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar utilizador: " + ex.Message);
            }
        }

        private void adicionarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lógica de quando o item de menu "Adicionar Pedidos" é clicado
            MessageBox.Show("Adicionar Pedidos Clicado");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica de quando a seleção no ComboBox de técnicos muda
            MessageBox.Show($"Técnico Selecionado: {comboBox3.SelectedItem}");
        }

        private void CarregarTecnicos()
        {
            comboBox3.Items.Clear();

            try
            {
                if (BdConnection.Connection.State != ConnectionState.Open)
               {
                    BdConnection.Connection.Open();
               }

                using (var cmd = new SQLiteCommand("SELECT id, Nome FROM Utilizadores WHERE Tecnico=1", BdConnection.Connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar técnicos: " + ex.Message);
            }


            comboBox3.SelectedIndex = -1; // Define o índice padrão como vazio
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Adicionar customização do painel 2, se necessário
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int prioridade;
            int tecnico;
            string titulo = textBox5.Text;
            string assunto = richTextBox1.Text;
            string prioridade_aux = comboBox1.Text;
            int utilizador = SessionManager.Instance.Id; // Acessando a ID do utilizador da sessão

            // Determinando a prioridade com base no valor selecionado no comboBox
            if (prioridade_aux == "Baixa") prioridade = (int)Prioridade.Baixa;
            else if (prioridade_aux == "Normal") prioridade = (int)Prioridade.Normal;
            else if (prioridade_aux == "Alta") prioridade = (int)Prioridade.Alta;
            else prioridade = (int)Prioridade.Urgente;

             //Verificando se o técnico foi selecionado no comboBox3
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um técnico.");
                return;
            }

             //Verifica se o item selecionado é do tipo esperado (KeyValuePair<int, string>)
            if (comboBox3.SelectedItem is KeyValuePair<int, string> selectedItem)
            {
                tecnico = selectedItem.Key;
            }
            else
            {
                MessageBox.Show("Seleção inválida do técnico.");
                return;
            }

            tecnico = 1;
            // Bloco try-catch para garantir o manejo correto da conexão com o banco
            try
            {
                // Verificando se a conexão está aberta, caso contrário, abre-a
                if (BdConnection.Connection.State != ConnectionState.Open)
                {
                    BdConnection.Connection.Open();
                }

                // Inserindo o novo pedido na tabela 'Pedido'
                using (var cmd = new SQLiteCommand("INSERT INTO Pedido (Titulo, Assunto, UtilizadorId, TecnicoId, Estado, Prioridade, IdResolucao) " +
                                                  "VALUES (@Titulo, @Assunto, @Utilizador, @Tecnico, 0, @Prioridade, NULL)", BdConnection.Connection))
                {
                    // Adicionando os parâmetros corretamente
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@Assunto", assunto);
                    cmd.Parameters.AddWithValue("@Prioridade", prioridade);
                    cmd.Parameters.AddWithValue("@Utilizador", utilizador);
                    cmd.Parameters.AddWithValue("@Tecnico", tecnico);

                    // Executando o comando SQL para inserir o pedido
                    cmd.ExecuteNonQuery();
                }

                // Limpar a RichTextBox após inserção bem-sucedida
                richTextBox1.Clear();
                MessageBox.Show("Pedido registrado com sucesso.");
            }
            catch (SQLiteException sqlEx)
            {
                // Captura exceções específicas do SQLite
                MessageBox.Show("Erro ao adicionar pedido (SQLite): " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Captura exceções genéricas
                MessageBox.Show("Erro ao adicionar pedido: " + ex.Message);
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


