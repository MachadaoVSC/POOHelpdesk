using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
        public class Pedido
        {
            public int ID { get; set; }                 
            public string Assunto { get; set; }    
            public string DescAssunto { get; set; }
            public TipoPedido TipoPedido { get; set; }
            public Utilizador Utilizador { get; set; }     
            public Utilizador Tecnico { get; set; }    
            public EstadoPedido Estado { get; set; }
            public Prioridade Prioridade { get; set; }
            public Solucoes IdResolucao { get; set; }
            

        public Pedido(int id, string assunto,string descassunto,TipoPedido tipopedido, Utilizador utilizador, Utilizador tecnico, EstadoPedido estado, Prioridade prioridade, Solucoes idresolucao)
            {
                ID = id;
                Assunto = assunto;
                DescAssunto = descassunto;
                TipoPedido=tipopedido;
                Utilizador = utilizador;
                Tecnico = tecnico;
                Estado = estado;
                Prioridade = prioridade;
                IdResolucao = idresolucao;
            }
        }
    public enum EstadoPedido
    {
        Aberto,
        EmResolucao,
        Concluido
    }
    public enum Prioridade
    {
        Baixa,
        Normal,
        Alta,
        Urgente
    }
    public enum TipoPedido
    {
        Software,
        Hardware
    }

}