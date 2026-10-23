using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TesteTecnico.Models;
using TesteTecnico.Services;

namespace TesteTecnico.Views
{
    public partial class FormTicket : Form
    {
        private readonly TicketService _ticketService = new TicketService();
        private readonly FuncionarioService _funcionarioService = new FuncionarioService();
        private int _idEdicao = 0;

        public FormTicket()
        {
            InitializeComponent();
            CarregarFuncionarios();
            CarregarGrid();
        }



        private void CarregarFuncionarios()
        {

            var lista = _funcionarioService.ListarAtivos();

            cmbFuncionario.DataSource = lista;
            cmbFuncionario.DisplayMember = "Nome";
            cmbFuncionario.ValueMember = "Id";
            cmbFuncionario.SelectedIndex = -1;
        }

        private void CarregarGrid()
        {
            gridTickets.DataSource = null;
            gridTickets.DataSource = _ticketService.Listar();

            gridTickets.ReadOnly = true;
            gridTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTickets.AllowUserToAddRows = false;

            // Esconde a coluna de navegação para o grid não ficar poluído
            if (gridTickets.Columns["Funcionario"] != null)
                gridTickets.Columns["Funcionario"].Visible = false;

            if (gridTickets.Columns.Contains("FuncionarioId"))
                gridTickets.Columns["FuncionarioId"].Visible = false;

            if (!gridTickets.Columns.Contains("NomeFuncionario"))
            {
                DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
                colNome.Name = "NomeFuncionario";
                colNome.HeaderText = "Funcionário";
                gridTickets.Columns.Add(colNome);
            }
        }

        private void LimparCampos()
        {
            _idEdicao = 0;
            cmbFuncionario.SelectedIndex = -1;
            nudQuantidade.Value = 1;
            btnSalvar.Text = "Salvar";

            gridTickets.ClearSelection();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Pega o objeto Funcionario diretamente da lista
            if (cmbFuncionario.SelectedItem is not Funcionario funcionarioSelecionado)
            {
                MessageBox.Show("Selecione um funcionário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int funcionarioId = funcionarioSelecionado.Id;
            int quantidade = (int)nudQuantidade.Value;

            try
            {
                var resultado = _ticketService.Salvar(quantidade, funcionarioId, _idEdicao);

                if (resultado.Ok)
                {
                    MessageBox.Show(resultado.Msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show(resultado.Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Pega o objeto Ticket da linha selecionada
            var ticket = (Ticket)gridTickets.Rows[e.RowIndex].DataBoundItem;

            _idEdicao = ticket.Id;
            nudQuantidade.Value = ticket.Quantidade;

            // Seleciona o funcionário no combo correspondente
            cmbFuncionario.SelectedValue = ticket.FuncionarioId;

            btnSalvar.Text = "Atualizar";
        }

        private void gridTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Se a coluna que está sendo formatada for a que criamos
            if (gridTickets.Columns[e.ColumnIndex].Name == "NomeFuncionario" && e.RowIndex >= 0)
            {
                // Pega o objeto Ticket que está na linha atual
                var ticket = (Ticket)gridTickets.Rows[e.RowIndex].DataBoundItem;

                // Define o valor da célula como o nome do funcionário
                if (ticket.Funcionario != null)
                {
                    e.Value = ticket.Funcionario.Nome;
                }
                else
                {
                    e.Value = "Sem funcionário"; // Caso dê algum erro
                }
            }
        }
    }
}
