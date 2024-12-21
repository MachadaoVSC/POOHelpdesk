using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    internal class PedidoManager
    {
        public static List<Pedido> GetAllPedidos()
        {
            var pedidos = new List<Pedido>();

            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = "SELECT * FROM Pedido";

                    using (var cmd = new SQLiteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pedido = new Pedido(
                                 id: Convert.ToInt32(reader["IdPedido"]),
                                 assunto: reader["Assunto"].ToString(),
                                 descAssunto: reader["DescAssunto"].ToString(),
                                 categoria: (Categoria)Convert.ToInt32(reader["Categoria"]),
                                 subCategoria: SubCategoriaManager.ObterSubCategoriaPorId(Convert.ToInt32(reader["SubCategoria"])),
                                 produto: ProdutoManager.GetById(Convert.ToInt32(reader["Produto"])),
                                 utilizador: UtilizadorManager.GetUserById(Convert.ToInt32(reader["IdUtilizador"])),
                                 tecnico: reader["IdTecnico"] != DBNull.Value ? UtilizadorManager.GetUserById(Convert.ToInt32(reader["IdTecnico"])) : null,
                                 estado: (EstadoPedido)Convert.ToInt32(reader["Estado"]),
                                 prioridade: (Prioridade)Convert.ToInt32(reader["Prioridade"]),
                                 solucao: reader["IdSolucao"] != DBNull.Value ?  SolucoesManager.GetById(Convert.ToInt32(reader["IdSolucao"])) : null,
                                 dataCriacao: Convert.ToDateTime(reader["DataCriacao"]),
                                 dataConclusao: reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : (DateTime?)null
                            );
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
            return pedidos;
        }

        public static Pedido GetById(int idPedido)
        {
            Pedido pedido = null;

            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = "SELECT * FROM Pedido WHERE IdPedido = @IdPedido";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int subCategoriaId = Convert.ToInt32(reader["SubCategoria"]);
                                int produtoId = Convert.ToInt32(reader["Produto"]);
                                int utilizadorId = Convert.ToInt32(reader["IdUtilizador"]);
                                int? tecnicoId = reader["IdTecnico"] != DBNull.Value ? (int?)Convert.ToInt32(reader["IdTecnico"]) : null;
                                int? idSolucao = reader["IdSolucao"] != DBNull.Value ? (int?)Convert.ToInt32(reader["IdSolucao"]) : null;

                                pedido = new Pedido(
                                    id: Convert.ToInt32(reader["IdPedido"]),
                                    assunto: reader["Assunto"].ToString(),
                                    descAssunto: reader["DescAssunto"].ToString(),
                                    categoria: (Categoria)Convert.ToInt32(reader["Categoria"]),
                                    subCategoria: null,
                                    produto: null, 
                                    utilizador: null,
                                    tecnico: null, 
                                    estado: (EstadoPedido)Convert.ToInt32(reader["Estado"]),
                                    prioridade: (Prioridade)Convert.ToInt32(reader["Prioridade"]),
                                    solucao: idSolucao.HasValue ? SolucoesManager.GetById(idSolucao.Value) : null, 
                                    dataCriacao: Convert.ToDateTime(reader["DataCriacao"]),
                                    dataConclusao: reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : (DateTime?)null
                                );

                                reader.Close();

                                pedido.SubCategoria = SubCategoriaManager.ObterSubCategoriaPorId(subCategoriaId);
                                pedido.Produto = ProdutoManager.GetById(produtoId);
                                pedido.Utilizador = UtilizadorManager.GetUserById(utilizadorId);
                                pedido.Tecnico = tecnicoId.HasValue ? UtilizadorManager.GetUserById(tecnicoId.Value) : null;
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

            return pedido;
        }

        public static List<Pedido> GetByUtilizadorId(int idUtilizador)
        {
            var pedidos = new List<Pedido>();

            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = "SELECT * FROM Pedido WHERE IdUtilizador = @IdUtilizador";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizador);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pedido = new Pedido(
                                    id: Convert.ToInt32(reader["IdPedido"]),
                                    assunto: reader["Assunto"].ToString(),
                                    descAssunto: reader["DescAssunto"].ToString(),
                                    categoria: (Categoria)Convert.ToInt32(reader["Categoria"]),
                                    subCategoria: SubCategoriaManager.ObterSubCategoriaPorId(Convert.ToInt32(reader["SubCategoria"])),
                                    produto: ProdutoManager.GetById(Convert.ToInt32(reader["Produto"])),
                                    utilizador: UtilizadorManager.GetUserById(Convert.ToInt32(reader["IdUtilizador"])),
                                    tecnico: reader["IdTecnico"] != DBNull.Value ? UtilizadorManager.GetUserById(Convert.ToInt32(reader["IdTecnico"])) : null,
                                    estado: (EstadoPedido)Convert.ToInt32(reader["Estado"]),
                                    prioridade: (Prioridade)Convert.ToInt32(reader["Prioridade"]),
                                    solucao: reader["IdSolucao"] != DBNull.Value ? SolucoesManager.GetById(Convert.ToInt32(reader["IdSolucao"])) : null,
                                    dataCriacao: Convert.ToDateTime(reader["DataCriacao"]),
                                    dataConclusao: reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : (DateTime?)null
                                );
                                pedidos.Add(pedido);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }

            return pedidos;
        }


        public static bool InsertPedido(Pedido pedido)
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
                INSERT INTO Pedido 
                (Assunto, DescAssunto, Categoria, SubCategoria, Produto, IdUtilizador, IdTecnico, Estado, Prioridade, IdSolucao, DataCriacao, DataConclusao) 
                VALUES 
                (@Assunto, @DescAssunto, @Categoria, @SubCategoria, @Produto, @IdUtilizador, @IdTecnico, @Estado, @Prioridade, @IdSolucao, @DataCriacao, @DataConclusao)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Assunto", pedido.Assunto);
                        cmd.Parameters.AddWithValue("@DescAssunto", pedido.DescAssunto);
                        cmd.Parameters.AddWithValue("@Categoria", pedido.Categoria); 
                        cmd.Parameters.AddWithValue("@SubCategoria", pedido.SubCategoria.IdSubCategoria); 
                        cmd.Parameters.AddWithValue("@Produto", pedido.Produto.IdProduto);
                        cmd.Parameters.AddWithValue("@IdUtilizador", pedido.Utilizador.Id);
                        cmd.Parameters.AddWithValue("@IdTecnico", pedido.Tecnico?.Id ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Estado", (int)pedido.Estado); 
                        cmd.Parameters.AddWithValue("@Prioridade", pedido.Prioridade); 
                        cmd.Parameters.AddWithValue("@IdSolucao", pedido.Solucao ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DataCriacao", pedido.DataCriacao);
                        cmd.Parameters.AddWithValue("@DataConclusao", pedido.DataConclusao ?? (object)DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Erro ao inserir pedido no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }

        public static bool UpdateTecnico(int idPedido, int? idTecnico)
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = "UPDATE Pedido SET IdTecnico = @IdTecnico , Estado = @Estado  WHERE IdPedido = @IdPedido";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@IdTecnico", idTecnico.HasValue ? (object)idTecnico.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Estado", EstadoPedido.EmResolucao);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Erro ao atualizar o técnico no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }

        public static bool UpdatePedidoComSolucao(int idPedido, int idSolucao, EstadoPedido novoEstado)
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
                UPDATE Pedido 
                SET IdSolucao = @IdSolucao, 
                    Estado = @Estado,
                    DataConclusao = @DataConclusao 
                WHERE IdPedido = @IdPedido";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@IdSolucao", idSolucao);
                        cmd.Parameters.AddWithValue("@Estado", (int)novoEstado);
                        cmd.Parameters.AddWithValue("@DataConclusao", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Erro ao atualizar o pedido com a solução no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }

        public static (int pedidosAbertos, int pedidosEmResolucao, int pedidosConcluidos, int totalPedidos) GetPedidosCount()
        {
            try
            {
                using (var connection = BdConnection.Connection())
                {
                    string query = @"
                    SELECT 
                        COUNT(CASE WHEN Estado = @EstadoAberto OR Estado = @EstadoEmResolucao THEN 1 END) AS PedidosAbertos,
                        COUNT(CASE WHEN Estado = @EstadoEmResolucao THEN 1 END) AS PedidosEmResolucao,
                        COUNT(CASE WHEN Estado = @EstadoConcluido THEN 1 END) AS PedidosConcluidos,
                        COUNT(*) AS TotalPedidos
                    FROM Pedido";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EstadoAberto", (int)EstadoPedido.Aberto);
                        cmd.Parameters.AddWithValue("@EstadoEmResolucao", (int)EstadoPedido.EmResolucao);
                        cmd.Parameters.AddWithValue("@EstadoConcluido", (int)EstadoPedido.Concluido);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int pedidosAbertos = reader.GetInt32(reader.GetOrdinal("PedidosAbertos"));
                                int pedidosEmResolucao = reader.GetInt32(reader.GetOrdinal("PedidosEmResolucao"));
                                int pedidosConcluidos = reader.GetInt32(reader.GetOrdinal("PedidosConcluidos"));
                                int totalPedidos = reader.GetInt32(reader.GetOrdinal("TotalPedidos"));

                                return (pedidosAbertos, pedidosEmResolucao, pedidosConcluidos, totalPedidos);
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

            return (0, 0, 0, 0);
        }
    }
}


