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
    public partial class FormFuncionario : Form
    {
        private readonly FuncionarioService _service = new FuncionarioService();
        private int _idEdicao = 0; 

        public FormFuncionario()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            // Configurações visuais do Grid
            gridFuncionarios.DataSource = null; // Limpa antes de recarregar
            gridFuncionarios.DataSource = _service.Listar();

            gridFuncionarios.ReadOnly = true;
            gridFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Esconde a coluna de navegação (Tickets) que vem do Model
            if (gridFuncionarios.Columns["Tickets"] != null)
                gridFuncionarios.Columns["Tickets"].Visible = false;
        }

        private void LimparCampos()
        {
            _idEdicao = 0;
            txtNome.Clear();
            txtCpf.Clear();
            lblStatus.Text = "Status: -";
            btnSalvar.Text = "Salvar"; // Volta ao modo de inserção

            gridFuncionarios.ClearSelection();
            txtNome.Focus();
        }

        private void gridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            // Pega o objeto Funcionário da linha selecionada
            var funcionario = (Funcionario)gridFuncionarios.Rows[e.RowIndex].DataBoundItem;

            // Passa os dados para os campos da tela
            _idEdicao = funcionario.Id;
            txtNome.Text = funcionario.Nome;
            txtCpf.Text = funcionario.CPF;

            // Atualiza o status e o botão
            lblStatus.Text = funcionario.Situacao == 'A' ? "Status: Ativo" : "Status: Inativo";
            btnSalvar.Text = "Atualizar";

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try 
            {

                var resultado = _service.Salvar(txtNome.Text, txtCpf.Text, _idEdicao);

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

            }catch(Exception ex)
            {
                MessageBox.Show("Erro na tela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (_idEdicao == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show("Deseja alterar a situação deste funcionário?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                var resultado = _service.AlterarSituacao(_idEdicao);
                MessageBox.Show(resultado.msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarGrid();
                LimparCampos();
            }
        }
    }
}
