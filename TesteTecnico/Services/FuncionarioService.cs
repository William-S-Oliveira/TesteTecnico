using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteTecnico.Data;
using TesteTecnico.Models;

namespace TesteTecnico.Services
{
    public class FuncionarioService
    {

        public List<Funcionario> Listar()
        {
            // Instanciando o Context (garanta que o using acima está correto)
            using var db = new TesteTecnicoContext();

            // Lembre-se: a propriedade DbSet chama-se "Funcionario" (singular)
            return db.Funcionario
                     .AsNoTracking()
                     .OrderBy(f => f.Nome)
                     .ToList();
        }
        
        public (bool ok, string msg) Salvar(string nome, string cpf, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return (false, "Um nome deve ser informar");

            cpf = cpf.Replace(".","").Replace("-","").Trim();

            if (cpf.Length != 11)
                return (false, "O CPF deve conter onze digitos");

            using var db = new TesteTecnicoContext();


            if(id == 0)
            {
                var novofuncionario = new Funcionario(nome, cpf);
                db.Funcionario.Add(novofuncionario);
            }
            else
            {
                var funcionarioBanco = db.Funcionario.Find(id);

                if (funcionarioBanco == null)
                    return (false, "Funcionario não encontrado");

                funcionarioBanco.Nome = nome;
                funcionarioBanco.CPF = cpf;
                funcionarioBanco.DataModificacao = DateTime.Now;

            }

            db.SaveChanges();

            return (true, "Funcionario cadastrado com sucesso!  ");

        }

        public (bool ok, string msg) AlterarSitucao(int id)
        {
            using var db = new TesteTecnicoContext();

            var funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
                return (false, "Funcionario não encontrado");

            funcionario.Situacao = funcionario.Situacao == 'A' ? 'I' : 'A';
            funcionario.DataModificacao = DateTime.Now;
            db.SaveChanges();

            string status = funcionario.Situacao == 'A' ? "Ativado" : "Inativado";
            return (true, $"Funcionari {status} com sucesso!");            
        }


    }
}
