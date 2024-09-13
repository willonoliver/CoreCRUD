namespace CoreCRUD
{
    partial class PesquisaFornecedores
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
            Pesquisar = new Button();
            panel1 = new Panel();
            GridPesquisaFornecedores = new DataGridView();
            progressBar1 = new ProgressBar();
            BarradePesquisas = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridPesquisaFornecedores).BeginInit();
            SuspendLayout();
            // 
            // Pesquisar
            // 
            Pesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Pesquisar.Location = new Point(662, 414);
            Pesquisar.Name = "Pesquisar";
            Pesquisar.Size = new Size(120, 52);
            Pesquisar.TabIndex = 0;
            Pesquisar.Text = "Pesquisar";
            Pesquisar.UseVisualStyleBackColor = true;
            Pesquisar.Click += Pesquisar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(BarradePesquisas);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(GridPesquisaFornecedores);
            panel1.Controls.Add(Pesquisar);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 500);
            panel1.TabIndex = 1;
            // 
            // GridPesquisaFornecedores
            // 
            GridPesquisaFornecedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPesquisaFornecedores.Location = new Point(13, 14);
            GridPesquisaFornecedores.Name = "GridPesquisaFornecedores";
            GridPesquisaFornecedores.Size = new Size(769, 362);
            GridPesquisaFornecedores.TabIndex = 2;
            GridPesquisaFornecedores.CellContentClick += GridPesquisaFornecedores_CellContentClick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(601, 266);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(8, 8);
            progressBar1.TabIndex = 3;
            // 
            // BarradePesquisas
            // 
            BarradePesquisas.AcceptsTab = true;
            BarradePesquisas.Location = new Point(254, 430);
            BarradePesquisas.Name = "BarradePesquisas";
            BarradePesquisas.Size = new Size(387, 23);
            BarradePesquisas.TabIndex = 4;
            BarradePesquisas.TextChanged += BarradePesquisas_TextChanged;
            // 
            // PesquisaFornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 524);
            Controls.Add(panel1);
            Name = "PesquisaFornecedores";
            Text = "PesquisaFornecedores";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridPesquisaFornecedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Pesquisar;
        private Panel panel1;
        private DataGridView GridPesquisaFornecedores;
        private ProgressBar progressBar1;
        private TextBox BarradePesquisas;
    }
}