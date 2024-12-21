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
        public string DescAssunto { get; set; }
        public Categoria CategoriaTipo { get; set; }
        public SubCategoria SubCategoriaTipo { get; set; }
        public Produto ProdutoTipo { get; set; }
        public bool Geral { get; set; }
        public Utilizador Tecnico { get; set; }


        public Solucoes(int id, string descassunto, Categoria categoria, SubCategoria subCategoria, Produto produto, bool geral, Utilizador tecnico)
        {
            IdResolucao = id;
            DescAssunto = descassunto;
            CategoriaTipo = categoria;
            SubCategoriaTipo = subCategoria;
            ProdutoTipo = produto;
            Geral = geral;
            Tecnico = tecnico;
        }
    }

}