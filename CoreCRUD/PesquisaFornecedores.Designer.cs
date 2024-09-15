namespace CoreCRUD
{
    partial class PesquisaFornecedores
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewFornecedores;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.Button buttonPesquisar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewFornecedores = new DataGridView();
            textBoxPesquisa = new TextBox();
            buttonPesquisar = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFornecedores).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewFornecedores
            // 
            dataGridViewFornecedores.Location = new Point(0, 0);
            dataGridViewFornecedores.Name = "dataGridViewFornecedores";
            dataGridViewFornecedores.Size = new Size(696, 244);
            dataGridViewFornecedores.TabIndex = 0;
            // 
            // textBoxPesquisa
            // 
            textBoxPesquisa.Location = new Point(252, 250);
            textBoxPesquisa.Margin = new Padding(4, 3, 4, 3);
            textBoxPesquisa.Name = "textBoxPesquisa";
            textBoxPesquisa.Size = new Size(348, 23);
            textBoxPesquisa.TabIndex = 2;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(608, 247);
            buttonPesquisar.Margin = new Padding(4, 3, 4, 3);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(88, 27);
            buttonPesquisar.TabIndex = 3;
            buttonPesquisar.Text = "Pesquisar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += Pesquisar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridViewFornecedores);
            panel1.Controls.Add(textBoxPesquisa);
            panel1.Controls.Add(buttonPesquisar);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 287);
            panel1.TabIndex = 4;
            // 
            // PesquisaFornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 311);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PesquisaFornecedores";
            Text = "Pesquisa de Fornecedores";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFornecedores).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
    }
}
