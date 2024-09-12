using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();
            btnTeste.Click += new EventHandler(btnTeste_Click);
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Verificar se a tabela USUARIOS já existe
                    string checkTableQuery = @"
                        SELECT 1 FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = 'USUARIOS'";

                    using (var checkCommand = new FbCommand(checkTableQuery, connection))
                    {
                        var result = checkCommand.ExecuteScalar();
                        if (result != null)
                        {
                            txtResposta.Text = "A tabela USUARIOS já existe.";
                            return;
                        }
                    }

                    // Comando SQL para criar a tabela USUARIOS
                    string createTableQuery = @"
                        CREATE TABLE USUARIOS (
                            ID INTEGER NOT NULL,
                            NOME VARCHAR(100) NOT NULL,
                            EMAIL VARCHAR(100) UNIQUE NOT NULL,
                            SENHA VARCHAR(255) NOT NULL,
                            DATA_CRIACAO TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            ATIVO BOOLEAN DEFAULT TRUE,
                            CONSTRAINT PK_USUARIOS PRIMARY KEY (ID)
                        )";

                    using (var command = new FbCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    txtResposta.Text = "Tabela USUARIOS criada com sucesso!";
                    connection.Close();
                }
            }
            catch (FbException fbEx)
            {
                txtResposta.Text = $"Erro do Firebird: {fbEx.Message}";
            }
            catch (Exception ex)
            {
                txtResposta.Text = $"Erro ao conectar ao banco de dados ou criar a tabela: {ex.Message}";
            }
        }
    }
}