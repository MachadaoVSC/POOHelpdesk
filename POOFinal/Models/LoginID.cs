using System;

namespace POOFinal.Models
{
    public class SessionManager
    {
        // Singleton
        private static SessionManager _instance;
        public static SessionManager Instance => _instance ??= new SessionManager();

        // Dados do utilizador logado
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Telemovel { get; private set; } // Mudança para string
        public bool Tecnico { get; private set; } // Mudança para bool

        // Método para inicializar a sessão
        public void Login(int id, string nome, string email, string telemovel, bool tecnico)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telemovel = telemovel;
            Tecnico = tecnico;
        }

        // Método para finalizar a sessão
        public void Logout()
        {
            Id = 0;
            Nome = null;
            Email = null;
            Telemovel = null;
            Tecnico = false;
        }

        // Construtor privado para garantir que apenas uma instância exista
        private SessionManager() { }
    }
}

