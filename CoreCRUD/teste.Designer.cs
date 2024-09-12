namespace CoreCRUD
{
    partial class Teste
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTeste;
        private TextBox txtResposta;

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
            btnTeste = new Button();
            txtResposta = new TextBox();
            SuspendLayout();
            // 
            // btnTeste
            // 
            btnTeste.Location = new Point(100, 50);
            btnTeste.Name = "btnTeste";
            btnTeste.Size = new Size(100, 23);
            btnTeste.TabIndex = 0;
            btnTeste.Text = "Testar Conexão";
            btnTeste.UseVisualStyleBackColor = true;
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(44, 100);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(288, 88);
            txtResposta.TabIndex = 1;
            // 
            // Teste
            // 
            ClientSize = new Size(400, 200);
            Controls.Add(txtResposta);
            Controls.Add(btnTeste);
            Name = "Teste";
            Text = "Teste de Conexão";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
