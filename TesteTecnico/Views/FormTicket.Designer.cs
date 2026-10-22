namespace TesteTecnico.Views
{
    partial class FormTicket
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
            label1 = new Label();
            cmbFuncionario = new ComboBox();
            label2 = new Label();
            nudQuantidade = new NumericUpDown();
            btnNovo = new Button();
            btnSalvar = new Button();
            gridTickets = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridTickets).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Funcionário:";
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(127, 28);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(151, 28);
            cmbFuncionario.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 36);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "Quantidade:";
            // 
            // nudQuantidade
            // 
            nudQuantidade.Location = new Point(457, 36);
            nudQuantidade.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(150, 27);
            nudQuantidade.TabIndex = 3;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(31, 90);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(94, 29);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(184, 90);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // gridTickets
            // 
            gridTickets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTickets.Location = new Point(37, 192);
            gridTickets.Name = "gridTickets";
            gridTickets.RowHeadersWidth = 51;
            gridTickets.Size = new Size(714, 188);
            gridTickets.TabIndex = 6;
            gridTickets.CellClick += gridTickets_CellClick;
            gridTickets.CellFormatting += gridTickets_CellFormatting;
            // 
            // FormTicket
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridTickets);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(nudQuantidade);
            Controls.Add(label2);
            Controls.Add(cmbFuncionario);
            Controls.Add(label1);
            Name = "FormTicket";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestão de Tickets";
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbFuncionario;
        private Label label2;
        private NumericUpDown nudQuantidade;
        private Button btnNovo;
        private Button btnSalvar;
        private DataGridView gridTickets;
    }
}