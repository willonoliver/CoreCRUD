using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoreCRUD
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            // Ajusta a posição do formulário para o topo da tela
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Ajusta o tamanho do formulário
            var screen = Screen.PrimaryScreen;
            if (screen != null)
            {
                this.Width = screen.WorkingArea.Width;
                this.Height = 200; // Ajusta a altura para 200
            }

            // Inicializa o texto do ToolStripStatusLabel
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy - HH:mm:ss");

            // Inicializa o Timer
            timer1.Interval = 1000; // 1 segundo
            timer1.Start(); // Inicia o Timer ao carregar o formulário
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy - HH:mm:ss");
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            // O Timer já está iniciado no construtor, então não é necessário iniciar aqui
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir o formulário "Sobre"
            Sobre sobreForm = new Sobre();
            sobreForm.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Encerra toda a pilha de execução ao fechar a janela
        }
    }
}
