using System;
using System.Data.SQLite;
using System.IO;

namespace POOFinal.Models
{
    public static class BdConnection
    {
        private static readonly string DatabasePath = @"C:\Users\leandro.machado\source\repos\POOHelpdesk\helpdesk.sqlite";

        public static SQLiteConnection Connection()
        {
            if (!File.Exists(DatabasePath))
            {
                SQLiteConnection.CreateFile(DatabasePath);
                Console.WriteLine("Database criada.");
            }

            var connection = new SQLiteConnection($"Data Source={DatabasePath}; Version=3;");

            connection.Open();

            return connection;
        }
    }
}
