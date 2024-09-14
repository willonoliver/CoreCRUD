using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Fornecedores : Form
    {
        public Fornecedores()
        {
            InitializeComponent();
            this.Load += Fornecedores_Load;
        }

        private void Fornecedores_Load(object sender, EventArgs e)
        {
            // Definir o estado inicial dos botões
            Incluir.Enabled = true;
            Pesquisar.Enabled = true;
            Gravar.Enabled = false;
            Alterar.Enabled = false;
        }

        private void Incluir_Click(object sender, EventArgs e)
        {
            // Limpar os campos para inclusão de um novo fornecedor
            LimparCampos();

            // Alterar o estado dos botões
            Incluir.Enabled = false;
            Pesquisar.Enabled = false;
            Gravar.Enabled = true;
        }

        private void Gravar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            string createTableQuery = @"
                   CREATE TABLE CADFORNECEDORES (
                       ID INTEGER NOT NULL PRIMARY KEY,
                       NOMEEMPRESA VARCHAR(100),
                       NOMEFANTASIA VARCHAR(100),
                       CNPJ VARCHAR(20),
                       INSCRICAOESTADUAL VARCHAR(20),
                       ENDERECO VARCHAR(100),
                       NUMERO VARCHAR(10),
                       COMPLEMENTO VARCHAR(50),
                       CEP VARCHAR(10),
                       NOMECIDADE VARCHAR(50),
                       UF VARCHAR(2),
                       CELULAR VARCHAR(15),
                       TELEFONE VARCHAR(15),
                       EMAIL VARCHAR(100),
                       DATAALTERACAO TIMESTAMP
                   )";

            string insertQuery = "INSERT INTO CADFORNECEDORES (NOMEEMPRESA, NOMEFANTASIA, CNPJ, INSCRICAOESTADUAL, ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, CELULAR, TELEFONE, EMAIL, DATAALTERACAO) " +
                                 "VALUES (@NomeEmpresa, @NomeFantasia, @CNPJ, @InscricaoEstadual, @Endereco, @Numero, @Complemento, @CEP, @NomeCidade, @UF, @Celular, @Telefone, @Email, @DataAlteracao)";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Verificar se a tabela existe e criar se necessário
                    if (!TabelaExiste(connection, "CADFORNECEDORES"))
                    {
                        using (var createCommand = new FbCommand(createTableQuery, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }

                        // Criar gerador e gatilho
                        using (var createGeneratorCommand = new FbCommand("CREATE GENERATOR GEN_CADFORNECEDORES_ID; SET GENERATOR GEN_CADFORNECEDORES_ID TO 0;", connection))
                        {
                            createGeneratorCommand.ExecuteNonQuery();
                        }

                        using (var createTriggerCommand = new FbCommand(@"
                               CREATE TRIGGER BI_CADFORNECEDORES_ID FOR CADFORNECEDORES
                               ACTIVE BEFORE INSERT POSITION 0
                               AS
                               BEGIN
                                 IF (NEW.ID IS NULL) THEN
                                   NEW.ID = GEN_ID(GEN_CADFORNECEDORES_ID, 1);
                               END;", connection))
                        {
                            createTriggerCommand.ExecuteNonQuery();
                        }
                    }

                    using (var command = new FbCommand(insertQuery, connection))
                    {
                        AdicionarParametros(command);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Novo Fornecedor criado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao criar novo Fornecedor: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private bool TabelaExiste(FbConnection connection, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = '{tableName.ToUpper()}'";
            using (var command = new FbCommand(query, connection))
            {
                return (long)command.ExecuteScalar() > 0;
            }
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            // Lógica para alterar um fornecedor existente
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            // Lógica para pesquisar fornecedores
        }

        private void LimparCampos()
        {
            NomeEmpresa.Text = "";
            NomeFantasia.Text = "";
            CNPJ.Text = "";
            InscricaoEstadual.Text = "";
            Endereco.Text = "";
            Numero.Text = "";
            Complemento.Text = "";
            CEP.Text = "";
            NomeCidade.Text = "";
            comboBoxUF.SelectedIndex = -1;
            celular.Text = "";
            telefone.Text = "";
            email.Text = "";
        }

        private bool ValidarCampos()
        {
            // Adicione aqui a lógica de validação dos campos
            return !string.IsNullOrWhiteSpace(NomeEmpresa.Text) &&
                   !string.IsNullOrWhiteSpace(NomeFantasia.Text) &&
                   !string.IsNullOrWhiteSpace(CNPJ.Text) &&
                   !string.IsNullOrWhiteSpace(InscricaoEstadual.Text) &&
                   !string.IsNullOrWhiteSpace(Endereco.Text) &&
                   !string.IsNullOrWhiteSpace(Numero.Text) &&
                   !string.IsNullOrWhiteSpace(CEP.Text) &&
                   !string.IsNullOrWhiteSpace(NomeCidade.Text) &&
                   comboBoxUF.SelectedIndex != -1 &&
                   !string.IsNullOrWhiteSpace(celular.Text) &&
                   !string.IsNullOrWhiteSpace(telefone.Text) &&
                   !string.IsNullOrWhiteSpace(email.Text);
        }

        private void AdicionarParametros(FbCommand command)
        {
            command.Parameters.AddWithValue("@NomeEmpresa", NomeEmpresa.Text);
            command.Parameters.AddWithValue("@NomeFantasia", NomeFantasia.Text);
            command.Parameters.AddWithValue("@CNPJ", CNPJ.Text);
            command.Parameters.AddWithValue("@InscricaoEstadual", InscricaoEstadual.Text);
            command.Parameters.AddWithValue("@Endereco", Endereco.Text);
            command.Parameters.AddWithValue("@Numero", Numero.Text);
            command.Parameters.AddWithValue("@Complemento", Complemento.Text);
            command.Parameters.AddWithValue("@CEP", CEP.Text);
            command.Parameters.AddWithValue("@NomeCidade", NomeCidade.Text);
            command.Parameters.AddWithValue("@UF", comboBoxUF.SelectedItem?.ToString() ?? string.Empty);
            command.Parameters.AddWithValue("@Celular", celular.Text);
            command.Parameters.AddWithValue("@Telefone", telefone.Text);
            command.Parameters.AddWithValue("@Email", email.Text);
            command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
        }
    }
}
