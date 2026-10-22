namespace TesteTecnico.Views
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btnRelatorios = new Button();
            btnTickets = new Button();
            btnFuncionarios = new Button();
            lblTitulo = new Label();
            pnlConteudo = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ControlDark;
            pnlMenu.Controls.Add(btnRelatorios);
            pnlMenu.Controls.Add(btnTickets);
            pnlMenu.Controls.Add(btnFuncionarios);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.MinimumSize = new Size(200, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(250, 721);
            pnlMenu.TabIndex = 0;
            // 
            // btnRelatorios
            // 
            btnRelatorios.Dock = DockStyle.Top;
            btnRelatorios.Location = new Point(0, 118);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(250, 50);
            btnRelatorios.TabIndex = 3;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = true;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // btnTickets
            // 
            btnTickets.Dock = DockStyle.Top;
            btnTickets.Location = new Point(0, 68);
            btnTickets.Name = "btnTickets";
            btnTickets.Size = new Size(250, 50);
            btnTickets.TabIndex = 2;
            btnTickets.Text = "Tickets";
            btnTickets.UseVisualStyleBackColor = true;
            btnTickets.Click += btnTickets_Click;
            // 
            // btnFuncionarios
            // 
            btnFuncionarios.Dock = DockStyle.Top;
            btnFuncionarios.Location = new Point(0, 18);
            btnFuncionarios.Name = "btnFuncionarios";
            btnFuncionarios.Size = new Size(250, 50);
            btnFuncionarios.TabIndex = 1;
            btnFuncionarios.Text = "Funcionários";
            btnFuncionarios.UseVisualStyleBackColor = true;
            btnFuncionarios.Click += btnFuncionarios_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 18);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Gestão de Tickets";
            lblTitulo.Click += label1_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(250, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(756, 721);
            pnlConteudo.TabIndex = 1;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlMenu);
            MinimumSize = new Size(1024, 768);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestão de Tickets";
            WindowState = FormWindowState.Maximized;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlConteudo;
        private Button btnFuncionarios;
        private Label lblTitulo;
        private Button btnRelatorios;
        private Button btnTickets;
    }
}