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
    public partial class FormRelatorio : Form
    {

        private readonly TicketService _ticketService = new TicketService();
        private readonly FuncionarioService _funcionarioService = new FuncionarioService();
        private RelatorioResultado _ultimoResultado;


        public FormRelatorio()
        {
            InitializeComponent();
            CarregarFiltroFuncionarios();
        }

        private void CarregarFiltroFuncionarios()
        {
            // Puxa todos os funcionários do banco (para permitir relatórios de inativos também)
            var lista = _funcionarioService.Listar();

            
            // Id = 0 é uma opção coringa para mostrar todos os funcionários.
            lista.Insert(0, new Funcionario { Id = 0, Nome = "(Todos os Funcionários)" });

            cmbFuncionario.DataSource = lista;
            cmbFuncionario.DisplayMember = "Nome";
            cmbFuncionario.ValueMember = "Id";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            DateTime? dataInicio = dtpInicio.Checked ? dtpInicio.Value.Date : (DateTime?)null;
            DateTime? dataFim = dtpFim.Checked ? dtpFim.Value.Date : (DateTime?)null;

            // Verifica o funcionário no ComboBox 
            int? filtroFuncionario = null;

            if (cmbFuncionario.SelectedValue is int id && id > 0)
            {
                filtroFuncionario = id; 
            }

            //Validação básica de lógica de datas
            if (dataInicio.HasValue && dataFim.HasValue && dataInicio > dataFim)
            {
                MessageBox.Show("A data de início não pode ser maior que a data final.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Service faz a pesquisa no banco
                var resultado = _ticketService.GerarRelatorio(dataInicio, dataFim, filtroFuncionario);

                _ultimoResultado = resultado;

                //  Exibe os dados no Grid
                gridRelatorio.DataSource = null;
                gridRelatorio.DataSource = resultado.Itens;

                // Configurações visuais do Grid
                gridRelatorio.ReadOnly = true;
                gridRelatorio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridRelatorio.AllowUserToAddRows = false;

                // nome das colunas para o usuário final
                if (gridRelatorio.Columns["NomeFuncionario"] != null)
                    gridRelatorio.Columns["NomeFuncionario"].HeaderText = "Funcionário";

                if (gridRelatorio.Columns["QtdTickets"] != null)
                    gridRelatorio.Columns["QtdTickets"].HeaderText = "Qtd. de Registros";

                if (gridRelatorio.Columns["TotalQuantidade"] != null)
                    gridRelatorio.Columns["TotalQuantidade"].HeaderText = "Total de Tickets";

                // 6. Atualiza o Label do Total Geral
                lblTotalGeral.Text = $"Total Geral: {resultado.TotalGeral} tickets entregues";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_ultimoResultado == null || _ultimoResultado.Itens.Count == 0)
            {
                MessageBox.Show("Gere um relatório antes de exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abre a janela para o usuário escolher onde salvar
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Arquivo CSV (*.csv)|*.csv";
                sfd.FileName = $"RelatorioTickets_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // lista de strings para montar o arquivo
                        var linhas = new List<string>();

                        // Cabeçalho (separado por ponto e vírgula)
                        linhas.Add("Funcionario;Qtd. de Registros;Total de Tickets");

                        // Dados
                        foreach (var item in _ultimoResultado.Itens)
                        {
                            linhas.Add($"{item.NomeFuncionario};{item.QtdTickets};{item.TotalQuantidade}");
                        }

                        // Adiciona uma linha final com o Total Geral
                        linhas.Add($";TOTAL GERAL;{_ultimoResultado.TotalGeral}");

                        // Grava o arquivo no computador
                        System.IO.File.WriteAllLines(sfd.FileName, linhas, System.Text.Encoding.UTF8);

                        MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao exportar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
