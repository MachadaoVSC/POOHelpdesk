using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    public class Utilizador : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
        public string Password { get; set; }
        public bool Tecnico { get; set; }

        public Utilizador(int id, string nome, string email, string telemovel, string password, bool tecnico) : base(id)
        {
            Nome = nome;
            Email = email;
            Telemovel = telemovel;
            Password = password;
            Tecnico = tecnico;
        }
    }
}
