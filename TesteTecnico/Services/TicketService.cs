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

        public(bool ok, string msg) Salvar(int quantidade,int funcionarioId, int id = 0)
        {

            if (quantidade <= 0)
                return (false,"Qauntidade de Tickets tem que ser maior que zero !");

            if (funcionarioId <= 0)
                return (false, "Selecione um funcionário");

            using var db = new TesteTecnicoContext();

            var funcionario = db.Ticket.Find(funcionarioId);

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

            var query = db.Ticket
                          .AsNoTracking()
                          .Include(t => t.Funcionario)
                          .AsQueryable();

            if(funcionarioId.HasValue && funcionarioId.Value > 0)
            {
                query = query.Where(t => t.DataCriacao >= datainicio.Value.Date);

            }

            if(datafim.HasValue)
            {
                var fimDoDia = datafim.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(t => t.DataCriacao <= fimDoDia);
            }

            var itensagrupados = query
                .GroupBy(t => t.Funcionario!.Nome)
                .Select(g => new RelatorioItem(
                    g.Key,
                    g.Count(),
                    g.Sum(t => t.Quantidade)
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