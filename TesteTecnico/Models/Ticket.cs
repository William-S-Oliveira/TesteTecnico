using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTecnico.Models
{
    public class Ticket
    {
        //Construtor vazio obdecendo a regra do EF Core
        public Ticket() { } 
            
        public Ticket(int quantidade, int funcionarioId)
        {
       
            Quantidade = quantidade;
            FuncionarioId = funcionarioId;
            Situacao = 'A';
            DataModificacao = DateTime.Now;
            DataCriacao = DateTime.Now;
        }

        

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public char Situacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public DateTime DataCriacao { get; set; }

        // Propriedades definidas para que o relacionamento das tabelas seja construida de maneira correta pelo EF Core
        public int FuncionarioId { get; set; }

        public Funcionario? Funcionario { get; set; }

    }
}
