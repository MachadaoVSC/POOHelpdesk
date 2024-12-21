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
            label3.Hide();
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
                var connection = BdConnection.Connection();

                string query = @"SELECT *
                         FROM Utilizador
                         WHERE Email = @Email AND Password = @Password";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                            if (!ativo)
                            {
                                label3.Text = "Sua conta está inativa.";
                                label3.Show();
                                return;
                            }

                            Utilizador utilizador = new Utilizador(
                                id: reader.GetInt32(reader.GetOrdinal("IdUtilizador")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                email: reader.GetString(reader.GetOrdinal("Email")),
                                telemovel: reader.IsDBNull(reader.GetOrdinal("Telemovel")) ? "" : reader.GetString(reader.GetOrdinal("Telemovel")),
                                password: reader.GetString(reader.GetOrdinal("Password")),
                                tecnico: reader.GetBoolean(reader.GetOrdinal("Tecnico")),
                                ativo: ativo, 
                                dataRegistro: reader.GetDateTime(reader.GetOrdinal("DataRegistro")) 
                            );

                            LoginManager.Instance.AdicionarUtilizador(utilizador);

                            MessageBox.Show("Login realizado com sucesso!");
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            label3.Text = "Utilizador ou senha inválidos.";
                            label3.Show();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar login: " + ex.Message);
            }
        }

    }
}