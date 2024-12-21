using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace POOFinal.Models
{
    public static class ProdutoManager
    {
        public static List<Produto> GetAllProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Produto";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int categoriaDbValue = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("Categoria"));
                        Categoria categoria = (Categoria)Enum.ToObject(typeof(Categoria), categoriaDbValue);

                        int subCategoriaId = reader.IsDBNull(reader.GetOrdinal("SubCategoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("SubCategoria"));
                        SubCategoria subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subCategoriaId);

                        Produto produto = new Produto(
                            idProduto: reader.GetInt32(reader.GetOrdinal("IdProduto")),
                            nome: reader.GetString(reader.GetOrdinal("Nome")),
                            categoria: categoria,
                            subCategoria: subCategoria,
                            referencia: reader.GetString(reader.GetOrdinal("Ref")),
                            ativo: reader.GetBoolean(reader.GetOrdinal("Ativo"))
                        );

                        produtos.Add(produto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return produtos;
        }

        public static Produto GetById(int idProduto)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Produto WHERE IdProduto = @IdProduto";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdProduto", idProduto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int categoriaDbValue = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("Categoria"));
                            Categoria categoria = (Categoria)Enum.ToObject(typeof(Categoria), categoriaDbValue);

                            int subCategoriaId = reader.IsDBNull(reader.GetOrdinal("SubCategoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("SubCategoria"));
                            SubCategoria subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subCategoriaId);

                            return new Produto(
                                idProduto: reader.GetInt32(reader.GetOrdinal("IdProduto")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                categoria: categoria,
                                subCategoria: subCategoria,
                                referencia: reader.GetString(reader.GetOrdinal("Ref")),
                                ativo: reader.GetBoolean(reader.GetOrdinal("Ativo"))
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Produto por ID: {ex.Message}");
            }

            return null;
        }



        public static List<Produto> ObterProdutosPorSubCategoriaId(int subcategoriaId)
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                var connection = BdConnection.Connection();

                string query = "SELECT * FROM Produto WHERE SubCategoria = @SubCategoriaId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SubCategoriaId", subcategoriaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int categoriaDbValue = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("Categoria"));
                            Categoria categoria = (Categoria)Enum.ToObject(typeof(Categoria), categoriaDbValue);

                            int subCategoriaId = reader.IsDBNull(reader.GetOrdinal("SubCategoria")) ? 0 : reader.GetInt32(reader.GetOrdinal("SubCategoria"));
                            SubCategoria subCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subCategoriaId);

                            Produto produto = new Produto(
                                idProduto: reader.GetInt32(reader.GetOrdinal("IdProduto")),
                                nome: reader.GetString(reader.GetOrdinal("Nome")),
                                categoria: categoria,
                                subCategoria: subCategoria,
                                referencia: reader.GetString(reader.GetOrdinal("Ref")),
                                ativo: reader.GetBoolean(reader.GetOrdinal("Ativo"))
                            );

                            produtos.Add(produto);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Produtos: {ex.Message}");
            }

            return produtos;
        }


        public static bool InsertProduto(Produto produto)
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
                INSERT INTO Produto (Nome, Categoria, SubCategoria, Ref, Ativo) 
                VALUES (@Nome, @Categoria, @SubCategoria, @Ref, @Ativo)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", produto.Nome);

                        cmd.Parameters.AddWithValue("@Categoria", (int)produto.CategoriaTipo);
                        cmd.Parameters.AddWithValue("@SubCategoria", produto.SubCategoriaTipo.IdSubCategoria);

                        cmd.Parameters.AddWithValue("@Ref", produto.Ref);
                        cmd.Parameters.AddWithValue("@Ativo", produto.Ativo ? 1 : 0);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool AtualizarPoduto(Produto produto)
        {
            try
            {
                var connection = BdConnection.Connection();

                string query = @"UPDATE Produto
                         SET Nome = @Nome,
                             Categoria = @Categoria,
                            SubCategoria= @SubCategoria,
                            Ref=@Ref,
                            Ativo = @Ativo
                         WHERE IdProduto = @IdProduto";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@Categoria", produto.CategoriaTipo);
                    cmd.Parameters.AddWithValue("@SubCategoria", produto.SubCategoriaTipo.IdSubCategoria);
                    cmd.Parameters.AddWithValue("@Ref", produto.Ref);
                    cmd.Parameters.AddWithValue("@Ativo", produto.Ativo);
                    cmd.Parameters.AddWithValue("@IdProduto", produto.IdProduto);


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
                Console.WriteLine($"Erro ao atualizar Produto: {ex.Message}");
                return false;
            }

        }
    }
}

