using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace POOFinal.Models
{
    public class Utilizador : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
        public string Password { get; set; }
        public bool Tecnico { get; set; }
        public bool Ativo { get; set; } 
        public DateTime DataRegistro { get; set; } 

        public Utilizador(int id, string nome, string email, string telemovel, string password, bool tecnico, bool ativo, DateTime dataRegistro) : base(id)
        {
            Nome = nome;
            Email = email;
            Telemovel = telemovel;
            Password = password;
            Tecnico = tecnico;
            Ativo = ativo;
            DataRegistro = dataRegistro;
        }

    }
}