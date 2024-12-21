using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    internal class SubCategoriaManager
    {
        public static bool AdicionarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = @"INSERT INTO Sub_Categoria (Nome, Categoria, Ativa, DataCriacao)
                                 VALUES (@Nome, @Categoria, @Ativa, @DataCriacao)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", subCategoria.Nome);
                    cmd.Parameters.AddWithValue("@Categoria", subCategoria.Categoria);
                    cmd.Parameters.AddWithValue("@Ativa", subCategoria.Ativa);
                    cmd.Parameters.AddWithValue("@DataCriacao", subCategoria.DataCriacao);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar Sub_Categoria: {ex.Message}");
                return false;
            }
        }

        public static List<SubCategoria> ObterTodasSubCategorias()
        {
            List<SubCategoria> subCategorias = new List<SubCategoria>();

            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Sub_Categoria";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SubCategoria subCategoria = new SubCategoria(
                            id: reader.GetInt32(reader.GetOrdinal("IdSubCategoria")),
                            nome: reader.GetString(reader.GetOrdinal("Nome")),
                            categoria: (Categoria)reader.GetInt32(reader.GetOrdinal("Categoria")),
                            ativa: reader.GetBoolean(reader.GetOrdinal("Ativa")),
                            dataCriacao: reader.GetDateTime(reader.GetOrdinal("DataCriacao"))
                        );

                        subCategorias.Add(subCategoria);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Sub_Categorias: {ex.Message}");
            }

            return subCategorias;
        }

        public static SubCategoria ObterSubCategoriaPorId(int id)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Sub_Categoria WHERE IdSubCategoria = @Id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SubCategoria(
                                id: reader.GetInt32(reader.GetOrdinal("IdSubCategoria")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                categoria: (Categoria)reader.GetInt32(reader.GetOrdinal("Categoria")),
                                ativa: reader.GetBoolean(reader.GetOrdinal("Ativa")),
                                dataCriacao: reader.GetDateTime(reader.GetOrdinal("DataCriacao"))
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter SubCategoria por ID: {ex.Message}");
            }

            return null;
        }


        public static List<SubCategoria> ObterSubCategoriasPorCategoriaId(int categoriaId)
        {
            List<SubCategoria> subCategorias = new List<SubCategoria>();

            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Sub_Categoria WHERE Categoria = @CategoriaId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubCategoria subCategoria = new SubCategoria(
                                id: reader.GetInt32(reader.GetOrdinal("IdSubCategoria")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                categoria: (Categoria)reader.GetInt32(reader.GetOrdinal("Categoria")),
                                ativa: reader.GetBoolean(reader.GetOrdinal("Ativa")),
                                dataCriacao: reader.GetDateTime(reader.GetOrdinal("DataCriacao"))
                            );

                            subCategorias.Add(subCategoria);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Sub_Categorias: {ex.Message}");
            }

            return subCategorias;
        }


        public static bool AtualizarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = @"UPDATE Sub_Categoria
                         SET Nome = @Nome,
                             Categoria = @Categoria,
                             Ativa = @Ativa
                         WHERE IdSubCategoria = @IdSubCategoria";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", subCategoria.Nome);
                    cmd.Parameters.AddWithValue("@Categoria", subCategoria.Categoria);
                    cmd.Parameters.AddWithValue("@Ativa", subCategoria.Ativa);
                    cmd.Parameters.AddWithValue("@IdSubCategoria", subCategoria.IdSubCategoria);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar Sub_Categoria: {ex.Message}");
                return false;
            }
        }

    }
}
