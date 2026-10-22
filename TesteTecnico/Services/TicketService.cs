using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteTecnico.Data;
using TesteTecnico.Models;

namespace TesteTecnico.Services
{
    public class TicketService
    {
        public List<Ticket> Listar()
        {

            using var db = new TesteTecnicoContext();

            return db.Ticket
                .AsNoTracking()
                .Include(t => t.Funcionario)
                .OrderByDescending(t => t.DataModificacao)
                .ToList();



        }

        public(bool Ok, string Msg) Salvar(int quantidade,int funcionarioId, int id = 0)
        {

            if (quantidade <= 0)
                return (false,"Qauntidade de Tickets tem que ser maior que zero !");

            if (funcionarioId <= 0)
                return (false, "Selecione um funcionário");

            using var db = new TesteTecnicoContext();



            var funcionario = db.Funcionario.Find(funcionarioId);

            if (funcionario == null)
                return (false, "Funcionario não encontrado");

            if (funcionario.Situacao == 'I')
                return (false, "Funcionário Inativo não pode receber Tickets!");

            if(id == 0)
            {
                var novoticket = new Ticket(quantidade, funcionarioId);
                db.Ticket.Add(novoticket);
            }
            else
            {
                var ticketbanco = db.Ticket.Find(id);

                if (ticketbanco == null)
                    return (false, "Ticket não encontrado");

                ticketbanco.Quantidade = quantidade;
                ticketbanco.FuncionarioId = funcionarioId;
                ticketbanco.DataModificacao = DateTime.Now;

            }
            db.SaveChanges();

            return (true, "Ticket salvo com sucesso");

        }

        public RelatorioResultado GerarRelatorio(DateTime? datainicio = null, DateTime? datafim = null, int? funcionarioId = null)
        {
            using var db = new TesteTecnicoContext();

            // 1. Monta a query base (sem Include para evitar que o EF tente fazer JOINs complexos antes do ToList)
            var query = db.Ticket.AsNoTracking().AsQueryable();

            // 2. Aplica os filtros
            if (funcionarioId.HasValue && funcionarioId.Value > 0)
            {
                int id = funcionarioId.Value;
                query = query.Where(t => t.FuncionarioId == id);
            }

            if (datainicio.HasValue)
            {
                DateTime inicio = datainicio.Value.Date;
                query = query.Where(t => t.DataCriacao >= inicio);
            }

            if (datafim.HasValue)
            {
                var fimDoDia = datafim.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(t => t.DataCriacao <= fimDoDia);
            }

            // 3. Traz a lista de tickets para a memória do C# (Aqui a mágica acontece)
            var ticketsFiltrados = query.ToList();

            // 4. Como não usamos Include, precisamos buscar os nomes na memória. 
            // Mas para isso, vamos pegar a lista de funcionários de uma vez.
            var funcionarios = db.Funcionario.AsNoTracking().ToList();

            // 5. Agrupa os dados e junta com os nomes
            var itensagrupados = ticketsFiltrados
                .GroupBy(t => t.FuncionarioId)
                .Select(g => new RelatorioItem(
                    funcionarios.FirstOrDefault(f => f.Id == g.Key)?.Nome ?? "Desconhecido", // Pega o nome
                    g.Count(), // Quantidade de registros
                    g.Sum(t => t.Quantidade) // Soma dos tickets
                ))
                .OrderByDescending(i => i.TotalQuantidade)
                .ToList();

            int totalGeral = itensagrupados.Sum(i => i.TotalQuantidade);

            return new RelatorioResultado(
                datainicio ?? DateTime.MinValue,
                datafim ?? DateTime.MaxValue,
                totalGeral,
                itensagrupados
            );
        }


    }
}

public record RelatorioItem(string NomeFuncionario, int QtdTickets, int TotalQuantidade);

public record RelatorioResultado(DateTime DataInicio, DateTime DataFim, int TotalGeral, List<RelatorioItem> Itens);