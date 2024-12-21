using System;

namespace POOFinal.Models
{
    public class SubCategoria
    {
        public int IdSubCategoria { get; set; } 
        public string Nome { get; set; }       
        public Categoria Categoria { get; set; }   
        public bool Ativa { get; set; }       
        public DateTime DataCriacao { get; set; } 

    
        public SubCategoria(int id, string nome, Categoria categoria, bool ativa, DateTime dataCriacao)
        {
            IdSubCategoria = id;
            Nome = nome;
            Categoria = categoria;
            Ativa = ativa;
            DataCriacao = dataCriacao;
        }        
    }
}
