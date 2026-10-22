using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TesteTecnico.Views
{
    public partial class FormPrincipal : Form
    {
        private Form _formAtual;
        public FormPrincipal()
        {
            InitializeComponent();
            AbrirFormulario(new FormFuncionario());
        }

        private void AbrirFormulario(Form formFilho)
        {
            if (_formAtual != null)
            {
                _formAtual.Close();
                _formAtual.Dispose();
            }

            _formAtual = formFilho;
            formFilho.TopLevel = false;
            formFilho.FormBorderStyle = FormBorderStyle.None;
            formFilho.Dock = DockStyle.Fill;

            pnlConteudo.Controls.Clear();
            pnlConteudo.Controls.Add(formFilho);
            formFilho.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormFuncionario());
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormTicket());
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormRelatorio());
        }
    }
}
