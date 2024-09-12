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
            usuario = new TextBox();
            senha = new TextBox();
            label2 = new Label();
            fazerlogin = new Button();
            criarlogin = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuário";
            // 
            // usuario
            // 
            usuario.Location = new Point(3, 22);
            usuario.Name = "usuario";
            usuario.Size = new Size(276, 23);
            usuario.TabIndex = 1;
            usuario.TextChanged += usuario_TextChanged;
            // 
            // senha
            // 
            senha.Location = new Point(3, 76);
            senha.Name = "senha";
            senha.Size = new Size(276, 23);
            senha.TabIndex = 3;
            senha.TextChanged += senha_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 58);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Senha";
            // 
            // fazerlogin
            // 
            fazerlogin.Location = new Point(3, 115);
            fazerlogin.Name = "fazerlogin";
            fazerlogin.Size = new Size(75, 35);
            fazerlogin.TabIndex = 4;
            fazerlogin.Text = "Faça login";
            fazerlogin.UseVisualStyleBackColor = true;
            // 
            // criarlogin
            // 
            criarlogin.Location = new Point(204, 115);
            criarlogin.Name = "criarlogin";
            criarlogin.Size = new Size(75, 35);
            criarlogin.TabIndex = 5;
            criarlogin.Text = "Criar conta";
            criarlogin.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(usuario);
            panel1.Controls.Add(criarlogin);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(fazerlogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(senha);
            panel1.Location = new Point(11, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 157);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_CoreCRUD;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(282, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 288);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox usuario;
        private TextBox senha;
        private Label label2;
        private Button fazerlogin;
        private Button criarlogin;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}