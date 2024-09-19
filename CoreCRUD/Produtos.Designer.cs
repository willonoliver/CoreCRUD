namespace CoreCRUD
{
    partial class Produtos
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
            panel1 = new Panel();
            Alterar = new Button();
            Incluir = new Button();
            Gravar = new Button();
            Pesquisar = new Button();
            label1 = new Label();
            NomeProduto = new TextBox();
            DataCadastro = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(DataCadastro);
            panel1.Controls.Add(NomeProduto);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Alterar);
            panel1.Controls.Add(Incluir);
            panel1.Controls.Add(Gravar);
            panel1.Controls.Add(Pesquisar);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 437);
            panel1.TabIndex = 0;
            // 
            // Alterar
            // 
            Alterar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Alterar.Location = new Point(234, 17);
            Alterar.Name = "Alterar";
            Alterar.Size = new Size(101, 40);
            Alterar.TabIndex = 33;
            Alterar.Text = "Alterar";
            Alterar.UseVisualStyleBackColor = true;
            Alterar.Click += Alterar_Click;
            // 
            // Incluir
            // 
            Incluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Incluir.Location = new Point(20, 17);
            Incluir.Name = "Incluir";
            Incluir.Size = new Size(101, 40);
            Incluir.TabIndex = 31;
            Incluir.Text = "Incluir";
            Incluir.UseVisualStyleBackColor = true;
            Incluir.Click += Incluir_Click;
            // 
            // Gravar
            // 
            Gravar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Gravar.Location = new Point(127, 17);
            Gravar.Name = "Gravar";
            Gravar.Size = new Size(101, 40);
            Gravar.TabIndex = 30;
            Gravar.Text = "Gravar";
            Gravar.UseVisualStyleBackColor = true;
            Gravar.Click += Gravar_Click;
            // 
            // Pesquisar
            // 
            Pesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Pesquisar.Location = new Point(638, 17);
            Pesquisar.Name = "Pesquisar";
            Pesquisar.Size = new Size(101, 40);
            Pesquisar.TabIndex = 32;
            Pesquisar.Text = "Pesquisar";
            Pesquisar.UseVisualStyleBackColor = true;
            Pesquisar.Click += Pesquisar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 76);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 34;
            label1.Text = "label1";
            // 
            // NomeProduto
            // 
            NomeProduto.Location = new Point(20, 94);
            NomeProduto.Name = "NomeProduto";
            NomeProduto.Size = new Size(395, 23);
            NomeProduto.TabIndex = 35;
            // 
            // DataCadastro
            // 
            DataCadastro.Location = new Point(609, 94);
            DataCadastro.Name = "DataCadastro";
            DataCadastro.Size = new Size(130, 23);
            DataCadastro.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(609, 76);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 37;
            label2.Text = "label2";
            // 
            // Produtos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Name = "Produtos";
            Text = "Produtos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Alterar;
        private Button Incluir;
        private Button Gravar;
        private Button Pesquisar;
        private Label label2;
        private TextBox DataCadastro;
        private TextBox NomeProduto;
        private Label label1;
    }
}