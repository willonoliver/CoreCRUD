namespace CoreCRUD
{
    partial class Empresa
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
            InscricaoEstadual = new TextBox();
            email = new TextBox();
            label12 = new Label();
            celular = new TextBox();
            label11 = new Label();
            telefone = new TextBox();
            label10 = new Label();
            label9 = new Label();
            comboBoxUF = new ComboBox();
            label8 = new Label();
            Complemento = new TextBox();
            label7 = new Label();
            CNPJ = new TextBox();
            label6 = new Label();
            NomeCidade = new TextBox();
            Cidade = new Label();
            label5 = new Label();
            CEP = new TextBox();
            label4 = new Label();
            Numero = new TextBox();
            Endereco = new TextBox();
            label3 = new Label();
            NomeFantasia = new TextBox();
            label2 = new Label();
            NomeEmpresa = new TextBox();
            Gravar = new Button();
            Alterar = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(InscricaoEstadual);
            panel1.Controls.Add(email);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(celular);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(telefone);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(comboBoxUF);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(Complemento);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(CNPJ);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(NomeCidade);
            panel1.Controls.Add(Cidade);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(CEP);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(Numero);
            panel1.Controls.Add(Endereco);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(NomeFantasia);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(NomeEmpresa);
            panel1.Controls.Add(Gravar);
            panel1.Controls.Add(Alterar);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(443, 439);
            panel1.TabIndex = 0;
            // 
            // InscricaoEstadual
            // 
            InscricaoEstadual.Font = new Font("Segoe UI", 9F);
            InscricaoEstadual.Location = new Point(235, 123);
            InscricaoEstadual.Name = "InscricaoEstadual";
            InscricaoEstadual.Size = new Size(187, 23);
            InscricaoEstadual.TabIndex = 28;
            InscricaoEstadual.TextChanged += InscricaoEstadual_TextChanged;
            // 
            // email
            // 
            email.Font = new Font("Segoe UI", 9F);
            email.Location = new Point(12, 343);
            email.Name = "email";
            email.Size = new Size(413, 23);
            email.TabIndex = 26;
            email.TextChanged += email_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(12, 325);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 27;
            label12.Text = "E-mail:";
            // 
            // celular
            // 
            celular.Font = new Font("Segoe UI", 9F);
            celular.Location = new Point(12, 299);
            celular.Name = "celular";
            celular.Size = new Size(187, 23);
            celular.TabIndex = 25;
            celular.TextChanged += celular_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(235, 281);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 24;
            label11.Text = "Telefone:";
            // 
            // telefone
            // 
            telefone.Font = new Font("Segoe UI", 9F);
            telefone.Location = new Point(235, 299);
            telefone.Name = "telefone";
            telefone.Size = new Size(190, 23);
            telefone.TabIndex = 23;
            telefone.TextChanged += telefone_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(12, 281);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 22;
            label10.Text = "Celular:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(345, 237);
            label9.Name = "label9";
            label9.Size = new Size(25, 15);
            label9.TabIndex = 20;
            label9.Text = "UF:";
            // 
            // comboBoxUF
            // 
            comboBoxUF.Font = new Font("Segoe UI", 9F);
            comboBoxUF.FormattingEnabled = true;
            comboBoxUF.Items.AddRange(new object[] { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" });
            comboBoxUF.Location = new Point(345, 255);
            comboBoxUF.Name = "comboBoxUF";
            comboBoxUF.Size = new Size(80, 23);
            comboBoxUF.TabIndex = 19;
            comboBoxUF.SelectedIndexChanged += comboBoxUF_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(136, 193);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 18;
            label8.Text = "Complemento:";
            // 
            // Complemento
            // 
            Complemento.Font = new Font("Segoe UI", 9F);
            Complemento.Location = new Point(136, 211);
            Complemento.Name = "Complemento";
            Complemento.Size = new Size(133, 23);
            Complemento.TabIndex = 17;
            Complemento.TextChanged += Complemento_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(235, 105);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 16;
            label7.Text = "Inscrição Estadual";
            // 
            // CNPJ
            // 
            CNPJ.Font = new Font("Segoe UI", 9F);
            CNPJ.Location = new Point(12, 123);
            CNPJ.Name = "CNPJ";
            CNPJ.Size = new Size(187, 23);
            CNPJ.TabIndex = 13;
            CNPJ.TextChanged += CNPJ_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 105);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 14;
            label6.Text = "CNPJ";
            // 
            // NomeCidade
            // 
            NomeCidade.Font = new Font("Segoe UI", 9F);
            NomeCidade.Location = new Point(12, 255);
            NomeCidade.Name = "NomeCidade";
            NomeCidade.Size = new Size(282, 23);
            NomeCidade.TabIndex = 11;
            NomeCidade.TextChanged += NomeCidade_TextChanged;
            // 
            // Cidade
            // 
            Cidade.AutoSize = true;
            Cidade.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Cidade.Location = new Point(12, 237);
            Cidade.Name = "Cidade";
            Cidade.Size = new Size(44, 15);
            Cidade.TabIndex = 12;
            Cidade.Text = "Cidade";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(289, 193);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 10;
            label5.Text = "CEP:";
            // 
            // CEP
            // 
            CEP.Font = new Font("Segoe UI", 9F);
            CEP.Location = new Point(289, 211);
            CEP.Name = "CEP";
            CEP.Size = new Size(136, 23);
            CEP.TabIndex = 9;
            CEP.TextChanged += CEP_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 193);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 8;
            label4.Text = "Número: ";
            // 
            // Numero
            // 
            Numero.Font = new Font("Segoe UI", 9F);
            Numero.Location = new Point(12, 211);
            Numero.Name = "Numero";
            Numero.Size = new Size(95, 23);
            Numero.TabIndex = 7;
            Numero.TextChanged += Numero_TextChanged;
            // 
            // Endereco
            // 
            Endereco.Font = new Font("Segoe UI", 9F);
            Endereco.Location = new Point(12, 167);
            Endereco.Name = "Endereco";
            Endereco.Size = new Size(413, 23);
            Endereco.TabIndex = 5;
            Endereco.TextChanged += Endereco_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 6;
            label3.Text = "Endereço";
            // 
            // NomeFantasia
            // 
            NomeFantasia.Font = new Font("Segoe UI", 9F);
            NomeFantasia.Location = new Point(12, 79);
            NomeFantasia.Name = "NomeFantasia";
            NomeFantasia.Size = new Size(413, 23);
            NomeFantasia.TabIndex = 0;
            NomeFantasia.TextChanged += NomeFantasia_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome fantasia:";
            // 
            // NomeEmpresa
            // 
            NomeEmpresa.Font = new Font("Segoe UI", 9F);
            NomeEmpresa.Location = new Point(12, 35);
            NomeEmpresa.Name = "NomeEmpresa";
            NomeEmpresa.Size = new Size(413, 23);
            NomeEmpresa.TabIndex = 3;
            NomeEmpresa.TextChanged += NomeEmpresa_TextChanged;
            // 
            // Gravar
            // 
            Gravar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Gravar.Location = new Point(305, 385);
            Gravar.Name = "Gravar";
            Gravar.Size = new Size(120, 40);
            Gravar.TabIndex = 2;
            Gravar.Text = "Gravar";
            Gravar.UseVisualStyleBackColor = true;
            Gravar.Click += Gravar_Click;
            // 
            // Alterar
            // 
            Alterar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Alterar.Location = new Point(12, 385);
            Alterar.Name = "Alterar";
            Alterar.Size = new Size(120, 40);
            Alterar.TabIndex = 1;
            Alterar.Text = "Alterar";
            Alterar.UseVisualStyleBackColor = true;
            Alterar.Click += Alterar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome empresa:";
            // 
            // Empresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 466);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Empresa";
            Text = "Empresa";
            Load += Empresa_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Gravar;
        private Button Alterar;
        private Label label1;
        private TextBox NomeEmpresa;
        private Label label2;
        private TextBox NomeFantasia;
        private Label label6;
        private TextBox CNPJ;
        private Label label7;
        private TextBox InscricaoEstadual;
        private Label label3;
        private TextBox Endereco;
        private Label label4;
        private TextBox Numero;
        private Label label8;
        private TextBox Complemento;
        private Label label5;
        private TextBox CEP;
        private Label Cidade;
        private TextBox NomeCidade;
        private Label label9;
        private ComboBox comboBoxUF;
        private Label label10;
        private TextBox celular;
        private Label label11;
        private TextBox telefone;
        private Label label12;
        private TextBox email;

    }
}