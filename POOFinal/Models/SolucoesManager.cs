using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    class SolucoesManager
    {
        public static int InsertSolucoes(Solucoes solucao)
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
            INSERT INTO Solucoes (DescAssunto, Categoria, SubCategoria, Produto, Geral, IdTecnico) 
            VALUES (@DescAssunto, @Categoria, @SubCategoria, @Produto, @Geral, @IdTecnico);
            SELECT last_insert_rowid();";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DescAssunto", solucao.DescAssunto);
                        cmd.Parameters.AddWithValue("@Categoria", (int)solucao.CategoriaTipo);
                        cmd.Parameters.AddWithValue("@SubCategoria", (int)solucao.SubCategoriaTipo.IdSubCategoria);
                        cmd.Parameters.AddWithValue("@Produto", (int)solucao.ProdutoTipo.IdProduto);
                        cmd.Parameters.AddWithValue("@Geral", solucao.Geral ? 1 : 0);
                        cmd.Parameters.AddWithValue("@IdTecnico", solucao.Tecnico.Id);

                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Erro ao inserir a solução no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }

        public static Solucoes GetById(int idSolucao)
        {
            Solucoes solucao = null;

            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
            SELECT IdResolucao, DescAssunto, Categoria, SubCategoria, Produto, Geral, IdTecnico 
            FROM Solucoes 
            WHERE IdResolucao = @IdSolucao";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdSolucao", idSolucao);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                solucao = new Solucoes(
                                    id: Convert.ToInt32(reader["IdResolucao"]),
                                    descassunto: reader["DescAssunto"].ToString(),
                                    categoria: (Categoria)Convert.ToInt32(reader["Categoria"]),
                                    subCategoria: SubCategoriaManager.ObterSubCategoriaPorId(Convert.ToInt32(reader["SubCategoria"])),
                                    produto: ProdutoManager.GetById(Convert.ToInt32(reader["Produto"])),
                                    geral: Convert.ToBoolean(reader["Geral"]),
                                    tecnico: UtilizadorManager.GetUserById(Convert.ToInt32(reader["IdTecnico"]))
                                );
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }

            return solucao;
        }


    }
}
