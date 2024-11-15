using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
using POOFinal.Models;

namespace POOFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Hide(); // Esconde o label de erro inicialmente
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = username_input.Text.Trim();
            string password = password_input.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                label3.Text = "Por favor, insira seu e-mail e senha.";
                label3.Show();
                return;
            }

            try
            {
                // Abre a conex�o usando o bloco `using` para garantir o fechamento adequado
                using (var connection = BdConnection.Connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Define o comando SQL para busca do usu�rio
                    string query = @"SELECT Id, Nome, Email, Telemovel, Tecnico 
                                     FROM Utilizadores 
                                     WHERE Email = @Email AND Password = @Password";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        // Adiciona par�metros para prevenir SQL Injection
                        cmd.Parameters.AddWithValue("@Email", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Executa o comando
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Se o usu�rio for encontrado
                            {
                                // L� os dados do usu�rio
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string nome = reader.GetString(reader.GetOrdinal("Nome"));
                                string email = reader.GetString(reader.GetOrdinal("Email"));
                                string telemovel = reader.IsDBNull(reader.GetOrdinal("Telemovel")) ? "" : reader.GetString(reader.GetOrdinal("Telemovel"));
                                bool tecnico = reader.GetBoolean(reader.GetOrdinal("Tecnico"));

                                // Inicializa a sess�o do usu�rio logado
                                SessionManager.Instance.Login(id, nome, email, telemovel, tecnico);

                                // Exibe uma mensagem de sucesso e abre o pr�ximo formul�rio
                                MessageBox.Show("Login realizado com sucesso!");
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide(); // Esconde o Form1
                            }
                            else
                            {
                                // Exibe uma mensagem de erro caso o login falhe
                                label3.Text = "Utilizador ou password inv�lidos.";
                                label3.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro e log detalhado
                MessageBox.Show("Erro ao realizar login: " + ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        // M�todos de eventos que n�o fazem nada podem ser removidos se n�o forem necess�rios
        private void label1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
