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
            fbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            usuario = new TextBox();
            senha = new TextBox();
            criarlogin = new Button();
            fazerlogin = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(usuario);
            panel1.Controls.Add(senha);
            panel1.Controls.Add(criarlogin);
            panel1.Controls.Add(fazerlogin);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(426, 308);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CoreCRUD;
            pictureBox1.Location = new Point(83, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 50);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(102, 167);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 5;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(102, 90);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 4;
            label1.Text = "Usuário";
            // 
            // usuario
            // 
            usuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            usuario.Location = new Point(102, 123);
            usuario.Name = "usuario";
            usuario.Size = new Size(212, 25);
            usuario.TabIndex = 3;
            usuario.TextChanged += usuario_TextChanged;
            // 
            // senha
            // 
            senha.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            senha.Location = new Point(102, 185);
            senha.Name = "senha";
            senha.Size = new Size(212, 25);
            senha.TabIndex = 2;
            senha.TextChanged += senha_TextChanged;
            // 
            // criarlogin
            // 
            criarlogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            criarlogin.Location = new Point(278, 236);
            criarlogin.Name = "criarlogin";
            criarlogin.Size = new Size(126, 51);
            criarlogin.TabIndex = 1;
            criarlogin.Text = "Criar Login";
            criarlogin.UseVisualStyleBackColor = true;
            criarlogin.Click += criarlogin_Click;
            // 
            // fazerlogin
            // 
            fazerlogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            fazerlogin.Location = new Point(27, 236);
            fazerlogin.Name = "fazerlogin";
            fazerlogin.Size = new Size(126, 51);
            fazerlogin.TabIndex = 0;
            fazerlogin.Text = "Fazer Login";
            fazerlogin.UseVisualStyleBackColor = true;
            fazerlogin.Click += fazerlogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 331);
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

        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand1;
        private FirebirdSql.Data.FirebirdClient.FbConnection fbConnection1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private TextBox usuario;
        private TextBox senha;
        private Button criarlogin;
        private Button fazerlogin;
    }
}