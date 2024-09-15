namespace CoreCRUD
{
    partial class GerenciadorDeUsuarios
    {
        private System.ComponentModel.IContainer components = null;

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
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnGravar = new Button();
            btnAlterar = new Button();
            btnExcluir = new Button();
            listBoxUsuarios = new ListBox();
            lblUsuario = new Label();
            lblPassword = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtUsuario.Location = new Point(12, 88);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtPassword.Location = new Point(12, 148);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnGravar
            // 
            btnGravar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGravar.Location = new Point(12, 18);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(120, 40);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAlterar.Location = new Point(159, 18);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(120, 40);
            btnAlterar.TabIndex = 3;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExcluir.Location = new Point(297, 18);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(120, 40);
            btnExcluir.TabIndex = 5;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // listBoxUsuarios
            // 
            listBoxUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            listBoxUsuarios.FormattingEnabled = true;
            listBoxUsuarios.ItemHeight = 15;
            listBoxUsuarios.Location = new Point(12, 180);
            listBoxUsuarios.Name = "listBoxUsuarios";
            listBoxUsuarios.Size = new Size(318, 109);
            listBoxUsuarios.TabIndex = 6;
            listBoxUsuarios.SelectedIndexChanged += listBoxUsuarios_SelectedIndexChanged;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 70);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(49, 15);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Usuário";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 132);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(41, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Senha";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(btnAlterar);
            panel1.Controls.Add(listBoxUsuarios);
            panel1.Controls.Add(btnGravar);
            panel1.Controls.Add(btnExcluir);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(txtPassword);
            panel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 307);
            panel1.TabIndex = 9;
            // 
            // GerenciadorDeUsuarios
            // 
            ClientSize = new Size(454, 331);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GerenciadorDeUsuarios";
            Text = "Gerenciador de Usuários";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir; // Declarando o botão Excluir
        private System.Windows.Forms.ListBox listBoxUsuarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private Panel panel1;
    }
}
