using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    public class Solucoes
    {
        public int IdResolucao { get; set; }
        public string Assunto { get; set; }
        public string DescAssunto { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public Utilizador Tecnico { get; set; }


        public Solucoes(int id, string assunto, string descassunto, TipoPedido tipopedido, Utilizador tecnico)
        {
            IdResolucao = id;
            Assunto = assunto;
            DescAssunto = descassunto;
            TipoPedido = tipopedido;
            Tecnico = tecnico;
        }
    }

}