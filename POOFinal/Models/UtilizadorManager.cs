using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POOFinal.Models
{
    internal class UtilizadorManager
    {
        public static List<Utilizador> GetAllUsers()
        {
            List<Utilizador> utilizadores = new List<Utilizador>();

            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Utilizador";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Utilizador utilizador = new Utilizador(
                            id: reader.GetInt32(reader.GetOrdinal("IdUtilizador")),
                            nome: reader.GetString(reader.GetOrdinal("Nome")),
                            email: reader.GetString(reader.GetOrdinal("Email")),
                            telemovel: reader.IsDBNull(reader.GetOrdinal("Telemovel")) ? "" : reader.GetString(reader.GetOrdinal("Telemovel")),
                            password: reader.GetString(reader.GetOrdinal("Password")),
                            tecnico: reader.GetBoolean(reader.GetOrdinal("Tecnico")),
                            ativo: reader.GetBoolean(reader.GetOrdinal("Ativo")), 
                            dataRegistro: reader.GetDateTime(reader.GetOrdinal("DataRegistro"))  
                        );

                        utilizadores.Add(utilizador);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar utilizadores: {ex.Message}\n{ex.StackTrace}");
                throw;  
            }

            return utilizadores;
        }

        public static Utilizador GetUserById(int id)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Utilizador WHERE IdUtilizador = @IdUtilizador";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdUtilizador", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Utilizador(
                                id: reader.GetInt32(reader.GetOrdinal("IdUtilizador")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                email: reader.GetString(reader.GetOrdinal("Email")),
                                telemovel: reader.IsDBNull(reader.GetOrdinal("Telemovel")) ? "" : reader.GetString(reader.GetOrdinal("Telemovel")),
                                password: reader.GetString(reader.GetOrdinal("Password")),
                                tecnico: reader.GetBoolean(reader.GetOrdinal("Tecnico")),
                                ativo: reader.GetBoolean(reader.GetOrdinal("Ativo")),
                                dataRegistro: reader.GetDateTime(reader.GetOrdinal("DataRegistro"))
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao pesquisar utilizador por ID: {ex.Message}\n{ex.StackTrace}");
                throw; 
            }

            return null; 
        }


        public static bool AdicionarUser(Utilizador utilizador)
        {
            try
            {
                var connection = BdConnection.Connection();
                string query = @"
            INSERT INTO Utilizador (Nome, Email, Telemovel, Password, Tecnico, Ativo, DataRegistro) 
            VALUES (@Nome, @Email, @Telemovel, @Password, @Tecnico, @Ativo, @DataRegistro)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", utilizador.Nome);
                    cmd.Parameters.AddWithValue("@Email", utilizador.Email);
                    cmd.Parameters.AddWithValue("@Telemovel", string.IsNullOrEmpty(utilizador.Telemovel) ? DBNull.Value : (object)utilizador.Telemovel);
                    cmd.Parameters.AddWithValue("@Password", utilizador.Password);
                    cmd.Parameters.AddWithValue("@Tecnico", utilizador.Tecnico);
                    cmd.Parameters.AddWithValue("@Ativo", utilizador.Ativo);
                    cmd.Parameters.AddWithValue("@DataRegistro", utilizador.DataRegistro);
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Erro no banco de dados: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return false;
            }
        }


        public static bool AtualizarUser(Utilizador utilizador)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = "UPDATE Utilizador SET Nome = @Nome, Email = @Email, Telemovel = @Telemovel, Tecnico = @Tecnico WHERE IdUtilizador = @IdUtilizador";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", utilizador.Nome);
                    cmd.Parameters.AddWithValue("@Email", utilizador.Email);
                    cmd.Parameters.AddWithValue("@Telemovel", string.IsNullOrEmpty(utilizador.Telemovel) ? DBNull.Value : (object)utilizador.Telemovel);
                    cmd.Parameters.AddWithValue("@Tecnico", utilizador.Tecnico);
                    cmd.Parameters.AddWithValue("@IdUtilizador", utilizador.Id);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar utilizador no banco de dados: {ex.Message}");
                return false;
            }
        }


    }
}
