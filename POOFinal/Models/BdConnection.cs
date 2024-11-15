using System;
using System.Data.SQLite;
using System.IO;

namespace POOFinal.Models
{
    public class BdConnection
    {
        private static SQLiteConnection _sqliteConnection;

        // Caminho do banco de dados
        private static readonly string DatabasePath = "c:\\Users\\leandro.machado\\source\\repos\\POOFinal\\POOFinal\\helpdesk.sqlite";

        // Propriedade para obter a conexão
        public static SQLiteConnection Connection
        {
            get
            {
                if (_sqliteConnection == null)
                {
                    // Verifica se o arquivo da base de dados já existe
                    if (!File.Exists(DatabasePath))
                    {
                        // Cria o arquivo do banco de dados se ele não existir
                        SQLiteConnection.CreateFile(DatabasePath);
                        Console.WriteLine("Base de dados criada com sucesso.");
                    }

                    // Inicializa e abre a conexão
                    _sqliteConnection = new SQLiteConnection($"Data Source={DatabasePath}; Version=3;");
                    _sqliteConnection.Open();

                    // Cria as tabelas se não existirem
                    CreateTablesIfNotExists();
                }

                return _sqliteConnection;
            }
        }

        // Método para fechar a conexão
        public static void CloseConnection()
        {
            if (_sqliteConnection != null)
            {
                _sqliteConnection.Close();
                _sqliteConnection = null;
            }
        }

        // Método para criar as tabelas caso elas não existam
        private static void CreateTablesIfNotExists()
        {
            CreateUtilizadorTable();
            CreateEstadoPedidoTable();
            CreatePrioridadeTable();
            CreatePedidoTable();
            CreateSolucoesTable(); // Nova tabela para soluções
        }

        // Método para criar a tabela Utilizadores
        private static void CreateUtilizadorTable()
        {
            string createUtilizadorTableQuery = @"
                CREATE TABLE IF NOT EXISTS Utilizadores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    Telemovel TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Tecnico BOOLEAN DEFAULT 0 CHECK(Tecnico IN (0, 1))
                );
            ";
            using (var command = new SQLiteCommand(createUtilizadorTableQuery, _sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            InsertDefaultAdminUser();
        }

        // Método para criar a tabela EstadoPedido
        private static void CreateEstadoPedidoTable()
        {
            string createEstadoPedidoTableQuery = @"
                CREATE TABLE IF NOT EXISTS EstadoPedido (
                    Id INTEGER PRIMARY KEY,
                    Descricao TEXT NOT NULL UNIQUE
                );
            ";
            using (var command = new SQLiteCommand(createEstadoPedidoTableQuery, _sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            InsertDefaultEstados();
        }

        // Método para inserir valores padrão na tabela EstadoPedido
        private static void InsertDefaultEstados()
        {
            string[] estados = { "Aberto", "EmResolucao", "Concluido" };
            for (int i = 0; i < estados.Length; i++)
            {
                string insertEstadoQuery = @"
                    INSERT OR IGNORE INTO EstadoPedido (Id, Descricao) VALUES (@Id, @Descricao);
                ";
                using (var command = new SQLiteCommand(insertEstadoQuery, _sqliteConnection))
                {
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@Descricao", estados[i]);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para criar a tabela Prioridade
        private static void CreatePrioridadeTable()
        {
            string createPrioridadeTableQuery = @"
                CREATE TABLE IF NOT EXISTS Prioridade (
                    Id INTEGER PRIMARY KEY,
                    Descricao TEXT NOT NULL UNIQUE
                );
            ";
            using (var command = new SQLiteCommand(createPrioridadeTableQuery, _sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            InsertDefaultPrioridades();
        }

        // Método para inserir valores padrão na tabela Prioridade
        private static void InsertDefaultPrioridades()
        {
            string[] prioridades = { "Baixa", "Normal", "Alta", "Urgente" };
            for (int i = 0; i < prioridades.Length; i++)
            {
                string insertPrioridadeQuery = @"
                    INSERT OR IGNORE INTO Prioridade (Id, Descricao) VALUES (@Id, @Descricao);
                ";
                using (var command = new SQLiteCommand(insertPrioridadeQuery, _sqliteConnection))
                {
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@Descricao", prioridades[i]);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para criar a tabela Pedido
        private static void CreatePedidoTable()
        {
            string createPedidoTableQuery = @"
                CREATE TABLE IF NOT EXISTS Pedido (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL, -- Novo campo Titulo adicionado
                    Assunto TEXT NOT NULL,
                    UtilizadorId INTEGER NOT NULL,
                    TecnicoId INTEGER,
                    Estado INTEGER NOT NULL,
                    Prioridade INTEGER NOT NULL,
                    IdResolucao INTEGER,  -- Coluna para armazenar a solução do pedido
                    FOREIGN KEY (UtilizadorId) REFERENCES Utilizadores(Id),
                    FOREIGN KEY (TecnicoId) REFERENCES Utilizadores(Id),
                    FOREIGN KEY (Estado) REFERENCES EstadoPedido(Id),
                    FOREIGN KEY (Prioridade) REFERENCES Prioridade(Id),
                    FOREIGN KEY (IdResolucao) REFERENCES Solucoes(Id) -- Relacionamento com Soluções
                );
            ";
            using (var command = new SQLiteCommand(createPedidoTableQuery, _sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Método para criar a tabela Solucoes
        private static void CreateSolucoesTable()
        {
            string createSolucoesTableQuery = @"
                CREATE TABLE IF NOT EXISTS Solucoes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Assunto TEXT NOT NULL,
                    DescAssunto TEXT NOT NULL,
                    TipoPedido INTEGER NOT NULL,
                    TecnicoId INTEGER NOT NULL,
                    FOREIGN KEY (TipoPedido) REFERENCES TipoPedido(Id),
                    FOREIGN KEY (TecnicoId) REFERENCES Utilizadores(Id)
                );
            ";
            using (var command = new SQLiteCommand(createSolucoesTableQuery, _sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Método para inserir o usuário padrão "admin" caso não exista
        private static void InsertDefaultAdminUser()
        {
            string checkAdminQuery = "SELECT COUNT(*) FROM Utilizadores WHERE Id = 1;";
            using (var command = new SQLiteCommand(checkAdminQuery, _sqliteConnection))
            {
                var count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0) // Se não existir, insere o registro padrão
                {
                    string insertAdminQuery = @"
                        INSERT INTO Utilizadores (Id, Nome, Email, Telemovel, Password, Tecnico)
                        VALUES (1, 'admin', 'admin@gmail.com', '918120695', 'admin', 1);
                    ";
                    using (var insertCommand = new SQLiteCommand(insertAdminQuery, _sqliteConnection))
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
