using System;

namespace POOFinal.Models
{
    public enum EstadoPedido
    {
        Aberto = 1,
        EmResolucao = 2,
        Concluido = 3
    }

    public enum Prioridade
    {
        Baixa = 1,
        Normal = 2,
        Alta = 3,
        Urgente = 4
    }

    public class Pedido
    {
        public int ID { get; set; }
        public string Assunto { get; set; }
        public string DescAssunto { get; set; }
        public Categoria Categoria { get; set; }
        public SubCategoria SubCategoria { get; set; }
        public Produto Produto { get; set; }
        public Utilizador Utilizador { get; set; }
        public Utilizador Tecnico { get; set; }
        public EstadoPedido Estado { get; set; }
        public Prioridade Prioridade { get; set; }
        public Solucoes Solucao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Pedido(
            int id,
            string assunto,
            string descAssunto,
            Categoria categoria,
            SubCategoria subCategoria,
            Produto produto,
            Utilizador utilizador,
            Utilizador tecnico,
            EstadoPedido estado,
            Prioridade prioridade,
            Solucoes solucao,
            DateTime dataCriacao,
            DateTime? dataConclusao = null)
        {
            ID = id;
            Assunto = assunto;
            DescAssunto = descAssunto;
            Categoria = categoria;
            SubCategoria = subCategoria;
            Produto = produto;
            Utilizador = utilizador;
            Tecnico = tecnico;
            Estado = estado;
            Prioridade = prioridade;
            Solucao = solucao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
        }
    }
}
