using System;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class MenuPrincipal : Form
    {
        private string nomeEmpresa = string.Empty; // Inicializa com uma string vazia
        private readonly string nomeUsuario;

        public MenuPrincipal(string usuario)
        {
            InitializeComponent();
            this.nomeUsuario = usuario;

            // Ajusta a posição do formulário para o topo da tela
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Ajusta o tamanho do formulário
            var screen = Screen.PrimaryScreen;
            if (screen != null)
            {
                this.Width = screen.WorkingArea.Width;
                this.Height = 170; // Ajusta a altura para 170
            }

            // Carrega os dados da empresa
            CarregarDadosEmpresa();

            // Inicializa o texto do ToolStripStatusLabel
            AtualizarStatusLabel();

            // Inicializa o Timer
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += Timer_Tick; // Adiciona o evento Tick
            timer1.Start(); // Inicia o Timer ao carregar o formulário
        }

        private void CarregarDadosEmpresa()
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();
                    string query = "SELECT NOMEEMPRESA FROM CADEMPRESA ROWS 1";
                    using (var command = new FbCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nomeEmpresa = reader["NOMEEMPRESA"]?.ToString() ?? string.Empty; // Verifica se é nulo
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da empresa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            AtualizarStatusLabel();
        }

        private void AtualizarStatusLabel()
        {
            toolStripStatusLabel1.Text = $"Software Licenciado para: {nomeEmpresa}         |         Usuário conectado: {nomeUsuario}         |         {DateTime.Now:dd 'de' MMMM 'de' yyyy - HH:mm:ss}";
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            // O Timer já está iniciado no construtor, então não é necessário iniciar aqui
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir o formulário "Sobre"
            using (var sobreForm = new Sobre())
            {
                sobreForm.ShowDialog();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Encerra toda a pilha de execução ao fechar a janela
        }

        private void EmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var empresaForm = new Empresa())
            {
                empresaForm.ShowDialog();
            }
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fornecedoresForm = new Fornecedores())
            {
                fornecedoresForm.ShowDialog();
            }
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var gerenciadorDeUsuariosForm = new GerenciadorDeUsuarios())
            {
                gerenciadorDeUsuariosForm.ShowDialog();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var Clientes = new Clientes())
            { 
                Clientes.ShowDialog();
            }
        }
    }
}
