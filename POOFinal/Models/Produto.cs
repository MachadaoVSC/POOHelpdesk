using System;

namespace POOFinal.Models
{
    public class Produto
    {
       
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public Categoria CategoriaTipo { get; set; }
        public SubCategoria SubCategoriaTipo { get; set; }
        public string Ref { get; set; }
        public bool Ativo { get; set; }

        public Produto(int idProduto, string nome, Categoria categoria, SubCategoria subCategoria,string referencia, bool ativo)
        {
            IdProduto = idProduto;
            Nome = nome;
            CategoriaTipo = categoria;
            SubCategoriaTipo = subCategoria;
            Ref = referencia;
            Ativo = ativo;
        }
    }
}
