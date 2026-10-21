using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTecnico.Models
{
    public  class Funcionario
    {
        // Construtor vazio obdecendo a regra do EF Core
        public Funcionario() { }

        public Funcionario(string nome,string cpf)
        {
            Nome = nome;
            CPF = cpf;
            Situacao = 'A';
            DataModificacao = DateTime.Now;
        }

       

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty; 
        public char Situacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public List<Ticket> Tickets { get; set; } = new(); 




      
    }
}
