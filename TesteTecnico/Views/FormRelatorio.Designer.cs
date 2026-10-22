namespace TesteTecnico.Views
{
    partial class FormRelatorio
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
            gbFiltroPesquisa = new GroupBox();
            btnGerar = new Button();
            dtpFim = new DateTimePicker();
            lblDataFim = new Label();
            dtpInicio = new DateTimePicker();
            lblDataInicio = new Label();
            cmbFuncionario = new ComboBox();
            lblFuncionarios = new Label();
            lblTotalGeral = new Label();
            gridRelatorio = new DataGridView();
            btnExportar = new Button();
            gbFiltroPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRelatorio).BeginInit();
            SuspendLayout();
            // 
            // gbFiltroPesquisa
            // 
            gbFiltroPesquisa.Controls.Add(btnExportar);
            gbFiltroPesquisa.Controls.Add(btnGerar);
            gbFiltroPesquisa.Controls.Add(dtpFim);
            gbFiltroPesquisa.Controls.Add(lblDataFim);
            gbFiltroPesquisa.Controls.Add(dtpInicio);
            gbFiltroPesquisa.Controls.Add(lblDataInicio);
            gbFiltroPesquisa.Controls.Add(cmbFuncionario);
            gbFiltroPesquisa.Controls.Add(lblFuncionarios);
            gbFiltroPesquisa.Dock = DockStyle.Top;
            gbFiltroPesquisa.Location = new Point(0, 0);
            gbFiltroPesquisa.Name = "gbFiltroPesquisa";
            gbFiltroPesquisa.Size = new Size(800, 107);
            gbFiltroPesquisa.TabIndex = 0;
            gbFiltroPesquisa.TabStop = false;
            gbFiltroPesquisa.Text = "Filtros de Pesquisa";
            // 
            // btnGerar
            // 
            btnGerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGerar.Location = new Point(484, 49);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(145, 29);
            btnGerar.TabIndex = 6;
            btnGerar.Text = "Gerar Relatório";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // dtpFim
            // 
            dtpFim.Format = DateTimePickerFormat.Short;
            dtpFim.Location = new Point(350, 51);
            dtpFim.Name = "dtpFim";
            dtpFim.ShowCheckBox = true;
            dtpFim.Size = new Size(115, 27);
            dtpFim.TabIndex = 5;
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Location = new Point(350, 23);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(72, 20);
            lblDataFim.TabIndex = 4;
            lblDataFim.Text = "Data Fim:";
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(187, 51);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.ShowCheckBox = true;
            dtpInicio.Size = new Size(129, 27);
            dtpInicio.TabIndex = 3;
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(187, 23);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(84, 20);
            lblDataInicio.TabIndex = 2;
            lblDataInicio.Text = "Data Inicio:";
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(15, 50);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(151, 28);
            cmbFuncionario.TabIndex = 1;
            // 
            // lblFuncionarios
            // 
            lblFuncionarios.AutoSize = true;
            lblFuncionarios.Location = new Point(15, 23);
            lblFuncionarios.Name = "lblFuncionarios";
            lblFuncionarios.Size = new Size(92, 20);
            lblFuncionarios.TabIndex = 0;
            lblFuncionarios.Text = "Funcionários";
            // 
            // lblTotalGeral
            // 
            lblTotalGeral.AutoSize = true;
            lblTotalGeral.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalGeral.Location = new Point(15, 124);
            lblTotalGeral.Name = "lblTotalGeral";
            lblTotalGeral.Size = new Size(133, 25);
            lblTotalGeral.TabIndex = 1;
            lblTotalGeral.Text = "Total Geral : 0";
            // 
            // gridRelatorio
            // 
            gridRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridRelatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRelatorio.Location = new Point(15, 186);
            gridRelatorio.Name = "gridRelatorio";
            gridRelatorio.RowHeadersWidth = 51;
            gridRelatorio.Size = new Size(757, 238);
            gridRelatorio.TabIndex = 2;
            // 
            // btnExportar
            // 
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportar.Location = new Point(645, 49);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(127, 29);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // FormRelatorio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridRelatorio);
            Controls.Add(lblTotalGeral);
            Controls.Add(gbFiltroPesquisa);
            Name = "FormRelatorio";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Relatórios de Tickets";
            gbFiltroPesquisa.ResumeLayout(false);
            gbFiltroPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRelatorio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbFiltroPesquisa;
        private Label lblFuncionarios;
        private DateTimePicker dtpInicio;
        private Label lblDataInicio;
        private ComboBox cmbFuncionario;
        private Button btnGerar;
        private DateTimePicker dtpFim;
        private Label lblDataFim;
        private Label lblTotalGeral;
        private DataGridView gridRelatorio;
        private Button btnExportar;
    }
}