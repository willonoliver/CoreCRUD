using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Inicialização do formulário, se necessário
        }

        private void usuario_TextChanged(object sender, EventArgs e)
        {
            // Lógica para quando o texto do usuário é alterado, se necessário
        }

        private void senha_TextChanged(object sender, EventArgs e)
        {
            // Lógica para quando o texto da senha é alterado, se necessário
        }
    }
}
