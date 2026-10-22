namespace TesteTecnico.Views
{
    partial class FormFuncionario
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
            lblNome = new Label();
            lblCPF = new Label();
            txtNome = new TextBox();
            txtCpf = new MaskedTextBox();
            lblStatus = new Label();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnInativar = new Button();
            gridFuncionarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridFuncionarios).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(25, 27);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(57, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome :";
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(296, 27);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(36, 20);
            lblCPF.TabIndex = 1;
            lblCPF.Text = "CPF:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(88, 20);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(125, 27);
            txtNome.TabIndex = 2;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(338, 24);
            txtCpf.Mask = "000\\.000\\.000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(125, 27);
            txtCpf.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(560, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status :";
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(41, 85);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(94, 29);
            btnNovo.TabIndex = 5;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(189, 85);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnInativar
            // 
            btnInativar.Location = new Point(338, 85);
            btnInativar.Name = "btnInativar";
            btnInativar.Size = new Size(125, 29);
            btnInativar.TabIndex = 7;
            btnInativar.Text = "Inativar/Ativar";
            btnInativar.UseVisualStyleBackColor = true;
            btnInativar.Click += btnInativar_Click;
            // 
            // gridFuncionarios
            // 
            gridFuncionarios.AllowUserToAddRows = false;
            gridFuncionarios.AllowUserToDeleteRows = false;
            gridFuncionarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFuncionarios.Location = new Point(42, 192);
            gridFuncionarios.Name = "gridFuncionarios";
            gridFuncionarios.RowHeadersWidth = 51;
            gridFuncionarios.Size = new Size(728, 231);
            gridFuncionarios.TabIndex = 8;
            gridFuncionarios.CellClick += gridFuncionarios_CellClick;
            // 
            // FormFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridFuncionarios);
            Controls.Add(btnInativar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(lblStatus);
            Controls.Add(txtCpf);
            Controls.Add(txtNome);
            Controls.Add(lblCPF);
            Controls.Add(lblNome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormFuncionario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestão de Funcionários";
            ((System.ComponentModel.ISupportInitialize)gridFuncionarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblCPF;
        private TextBox txtNome;
        private MaskedTextBox txtCpf;
        private Label lblStatus;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnInativar;
        private DataGridView gridFuncionarios;
    }
}