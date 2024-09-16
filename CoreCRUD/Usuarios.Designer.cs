namespace CoreCRUD
{
    partial class Usuarios
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
            lblUsuario = new Label();
            btnAlterar = new Button();
            listBoxUsuarios = new ListBox();
            btnGravar = new Button();
            btnExcluir = new Button();
            lblPassword = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
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
            panel1.Location = new Point(16, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 307);
            panel1.TabIndex = 10;
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
            // btnAlterar
            // 
            btnAlterar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAlterar.Location = new Point(159, 18);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(120, 40);
            btnAlterar.TabIndex = 3;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
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
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtUsuario.Location = new Point(12, 88);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtPassword.Location = new Point(12, 148);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 335);
            Controls.Add(panel1);
            Name = "Usuarios";
            Text = "Usuarios";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblUsuario;
        private Button btnAlterar;
        private ListBox listBoxUsuarios;
        private Button btnGravar;
        private Button btnExcluir;
        private Label lblPassword;
        private TextBox txtUsuario;
        private TextBox txtPassword;
    }
}