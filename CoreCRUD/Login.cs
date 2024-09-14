using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centralizar a tela no meio do monitor
        }

        private void usuario_TextChanged(object sender, EventArgs e)
        {
            // Evento de mudança de texto do campo usuário
        }

        private void senha_TextChanged(object sender, EventArgs e)
        {
            // Evento de mudança de texto do campo senha
        }

        private void fazerlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usuario.Text) || string.IsNullOrWhiteSpace(senha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Verificar se o usuário e senha estão corretos
                    string loginQuery = @"
                        SELECT 1 FROM CADUSUARIOS WHERE USUARIO = @usuario AND SENHA = @senha";

                    using (var loginCommand = new FbCommand(loginQuery, connection))
                    {
                        loginCommand.Parameters.AddWithValue("@usuario", usuario.Text);
                        loginCommand.Parameters.AddWithValue("@senha", senha.Text);

                        var result = loginCommand.ExecuteScalar();
                        if (result != null)
                        {
                            MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Iniciar o formulário MenuPrincipal com o nome do usuário
                            MenuPrincipal menuPrincipalForm = new MenuPrincipal(usuario.Text);
                            menuPrincipalForm.Show();
                            this.Hide(); // Esconder o formulário de login
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show($"Erro do Firebird: {fbEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void criarlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usuario.Text) || string.IsNullOrWhiteSpace(senha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Verificar se a tabela CADUSUARIOS já existe
                    string checkTableQuery = @"
                        SELECT 1 FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = 'CADUSUARIOS'";

                    using (var checkCommand = new FbCommand(checkTableQuery, connection))
                    {
                        var result = checkCommand.ExecuteScalar();
                        if (result == null)
                        {
                            // Criar a tabela CADUSUARIOS
                            string createTableQuery = @"
                                CREATE TABLE CADUSUARIOS (
                                    ID INTEGER NOT NULL,
                                    USUARIO VARCHAR(100) NOT NULL,
                                    SENHA VARCHAR(255) NOT NULL,
                                    CONSTRAINT PK_CADUSUARIOS PRIMARY KEY (ID)
                                )";
                            using (var createCommand = new FbCommand(createTableQuery, connection))
                            {
                                createCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // Verificar se o usuário já existe
                    string checkUserQuery = @"
                        SELECT 1 FROM CADUSUARIOS WHERE USUARIO = @usuario";

                    using (var checkUserCommand = new FbCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@usuario", usuario.Text);
                        var userExists = checkUserCommand.ExecuteScalar();
                        if (userExists != null)
                        {
                            MessageBox.Show("Usuário já existe. Por favor, escolha outro nome de usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Obter o próximo valor de ID
                    string getNextIdQuery = "SELECT COALESCE(MAX(ID), 0) + 1 FROM CADUSUARIOS";
                    int nextId;
                    using (var getNextIdCommand = new FbCommand(getNextIdQuery, connection))
                    {
                        nextId = Convert.ToInt32(getNextIdCommand.ExecuteScalar());
                    }

                    // Comando SQL para inserir um novo usuário
                    string insertUserQuery = @"
                        INSERT INTO CADUSUARIOS (ID, USUARIO, SENHA)
                        VALUES (@id, @usuario, @senha)";

                    using (var insertCommand = new FbCommand(insertUserQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@id", nextId);
                        insertCommand.Parameters.AddWithValue("@usuario", usuario.Text);
                        insertCommand.Parameters.AddWithValue("@senha", senha.Text);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuário criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show($"Erro do Firebird: {fbEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados ou inserir o usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
