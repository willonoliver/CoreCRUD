namespace CoreCRUD
{
    partial class Login
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
            label2 = new Label();
            fazerlogin = new Button();
            criarlogin = new Button();
            usuario = new TextBox();
            senha = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.Location = new Point(36, 105);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 0;
            label1.Text = "Usuário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(36, 168);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 1;
            label2.Text = "Senha";
            // 
            // fazerlogin
            // 
            fazerlogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            fazerlogin.Location = new Point(36, 251);
            fazerlogin.Name = "fazerlogin";
            fazerlogin.Size = new Size(130, 50);
            fazerlogin.TabIndex = 2;
            fazerlogin.Text = "Fazer Login";
            fazerlogin.UseVisualStyleBackColor = true;
            // 
            // criarlogin
            // 
            criarlogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            criarlogin.Location = new Point(196, 251);
            criarlogin.Name = "criarlogin";
            criarlogin.Size = new Size(130, 50);
            criarlogin.TabIndex = 3;
            criarlogin.Text = "Criar Cadastro";
            criarlogin.UseVisualStyleBackColor = true;
            // 
            // usuario
            // 
            usuario.Location = new Point(36, 133);
            usuario.Name = "usuario";
            usuario.Size = new Size(189, 23);
            usuario.TabIndex = 4;
            // 
            // senha
            // 
            senha.Location = new Point(36, 196);
            senha.Name = "senha";
            senha.Size = new Size(189, 23);
            senha.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(criarlogin);
            panel1.Controls.Add(senha);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(usuario);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(fazerlogin);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 334);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CoreCRUD;
            pictureBox1.Location = new Point(55, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(259, 55);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 362);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button fazerlogin;
        private Button criarlogin;
        private TextBox usuario;
        private TextBox senha;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}