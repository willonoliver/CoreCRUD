using System;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Clientes : Form
    {
        private int? ClienteId = null; // Variável para armazenar o ID do Cliente selecionado

        public Clientes()
        {
            InitializeComponent();
            this.Load += Clientes_Load;
            this.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                this.Location = new Point(0, primaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void Clientes_Load(object? sender, EventArgs e)
        {
            // Ajustar o GENERATOR
            AjustarGenerator();

            // Definir o estado inicial dos botões
            Incluir.Enabled = true;
            Pesquisar.Enabled = true;
            Gravar.Enabled = false;
            Alterar.Enabled = false; // Novo botão Alterar

            // Preencher o ComboBox fisicooujuridico com as opções "Físico" e "Jurídico"
            fisicooujuridico.Items.Clear();
            fisicooujuridico.Items.Add("Físico");
            fisicooujuridico.Items.Add("Jurídico");
        }

        private void AjustarGenerator()
        {
            int maiorId = 0;
            string queryMaxId = "SELECT MAX(ID) FROM CADCLIENTES";
            string ajustarGeneratorQuery;

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Obter o maior ID atual
                    using (var command = new FbCommand(queryMaxId, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            maiorId = Convert.ToInt32(result);
                        }
                    }

                    // Ajustar o valor do GENERATOR
                    ajustarGeneratorQuery = $"SET GENERATOR SEQ_CADCLIENTES TO {maiorId + 1}";
                    using (var command = new FbCommand(ajustarGeneratorQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao ajustar o GENERATOR: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void Incluir_Click(object sender, EventArgs e)
        {
            // Limpar os campos para inclusão de um novo Cliente
            LimparCampos();
            ClienteId = null; // Resetar o ID do Cliente

            // Alterar o estado dos botões
            Incluir.Enabled = false;
            Pesquisar.Enabled = false;
            Gravar.Enabled = true;
            Alterar.Enabled = false;
        }

        private void Gravar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Gerar o próximo valor do ID usando um GENERATOR no Firebird
            int novoId = ObterProximoId();

            string insertQuery = "INSERT INTO CADCLIENTES (ID, NOMECLIENTE, NOMEFANTASIA, CNPJCPF, INSCRICAOESTADUAL, ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, CELULAR, TELEFONE, EMAIL, TIPOCLIENTE) " +
                                 "VALUES (@ID, @NomeCliente, @NomeFantasia, @CNPJCPF, @InscricaoEstadual, @Endereco, @Numero, @Complemento, @CEP, @NomeCidade, @UF, @Celular, @Telefone, @Email, @TipoCliente)";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", novoId);
                        AdicionarParametros(command);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Novo Cliente criado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
                Alterar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao criar novo Cliente: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private int ObterProximoId()
        {
            int novoId = 0;
            string query = "SELECT NEXT VALUE FOR SEQ_CADCLIENTES FROM RDB$DATABASE";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(query, connection))
                    {
                        novoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao obter próximo ID: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }

            return novoId;
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            string updateQuery = "UPDATE CADCLIENTES SET NOMECLIENTE = @NomeCliente, NOMEFANTASIA = @NomeFantasia, CNPJCPF = @CNPJCPF, INSCRICAOESTADUAL = @InscricaoEstadual, ENDERECO = @Endereco, NUMERO = @Numero, COMPLEMENTO = @Complemento, CEP = @CEP, NOMECIDADE = @NomeCidade, UF = @UF, CELULAR = @Celular, TELEFONE = @Telefone, EMAIL = @Email, TIPOCLIENTE = @TipoCliente WHERE ID = @ID";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(updateQuery, connection))
                    {
                        AdicionarParametros(command);
                        command.Parameters.AddWithValue("@ID", ClienteId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cliente atualizado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
                Alterar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao atualizar Cliente: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            using (var pesquisaForm = new PesquisaClientes())
            {
                if (pesquisaForm.ShowDialog() == DialogResult.OK)
                {
                    var Cliente = pesquisaForm.ClienteSelecionado;
                    if (Cliente != null)
                    {
                        ClienteId = Convert.ToInt32(Cliente["ID"]); // Armazenar o ID do Cliente
                        NomeEmpresaOuCliente.Text = Cliente["NOMECLIENTE"].ToString();
                        NomeFantasia.Text = Cliente["NOMEFANTASIA"].ToString();
                        CNPJ.Text = Cliente["CNPJCPF"].ToString();
                        InscricaoEstadual.Text = Cliente["INSCRICAOESTADUAL"].ToString();
                        Endereco.Text = Cliente["ENDERECO"].ToString();
                        Numero.Text = Cliente["NUMERO"].ToString();
                        Complemento.Text = Cliente["COMPLEMENTO"].ToString();
                        CEP.Text = Cliente["CEP"].ToString();
                        NomeCidade.Text = Cliente["NOMECIDADE"].ToString();
                        comboBoxUF.SelectedItem = Cliente["UF"].ToString();
                        celular.Text = Cliente["CELULAR"].ToString();
                        telefone.Text = Cliente["TELEFONE"].ToString();
                        email.Text = Cliente["EMAIL"].ToString();
                        fisicooujuridico.SelectedItem = Cliente["TIPOCLIENTE"].ToString() == "F" ? "Físico" : "Jurídico";
                        // Alterar o estado dos botões
                        Incluir.Enabled = false;
                        Gravar.Enabled = false;
                        Alterar.Enabled = true;
                    }
                }
            }
        }

        private void LimparCampos()
        {
            NomeEmpresaOuCliente.Text = "";
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
            fisicooujuridico.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            // Adicione aqui a lógica de validação dos campos
            return !string.IsNullOrWhiteSpace(NomeEmpresaOuCliente.Text) &&
                   !string.IsNullOrWhiteSpace(NomeFantasia.Text) &&
                   !string.IsNullOrWhiteSpace(CNPJ.Text) &&
                   !string.IsNullOrWhiteSpace(Endereco.Text) &&
                   !string.IsNullOrWhiteSpace(Numero.Text) &&
                   !string.IsNullOrWhiteSpace(CEP.Text) &&
                   !string.IsNullOrWhiteSpace(NomeCidade.Text) &&
                   comboBoxUF.SelectedIndex != -1 &&
                   !string.IsNullOrWhiteSpace(celular.Text) &&
                   !string.IsNullOrWhiteSpace(telefone.Text) &&
                   !string.IsNullOrWhiteSpace(email.Text) &&
                   fisicooujuridico.SelectedIndex != -1;
        }

        private void AdicionarParametros(FbCommand command)
        {
            command.Parameters.AddWithValue("@NomeCliente", NomeEmpresaOuCliente.Text);
            command.Parameters.AddWithValue("@NomeFantasia", NomeFantasia.Text);
            command.Parameters.AddWithValue("@CNPJCPF", CNPJ.Text);
            command.Parameters.AddWithValue("@InscricaoEstadual", string.IsNullOrWhiteSpace(InscricaoEstadual.Text) ? (object)DBNull.Value : InscricaoEstadual.Text);
            command.Parameters.AddWithValue("@Endereco", Endereco.Text);
            command.Parameters.AddWithValue("@Numero", Numero.Text);
            command.Parameters.AddWithValue("@Complemento", Complemento.Text);
            command.Parameters.AddWithValue("@CEP", CEP.Text);
            command.Parameters.AddWithValue("@NomeCidade", NomeCidade.Text);
            command.Parameters.AddWithValue("@UF", comboBoxUF.SelectedItem?.ToString() ?? string.Empty);
            command.Parameters.AddWithValue("@Celular", celular.Text);
            command.Parameters.AddWithValue("@Telefone", telefone.Text);
            command.Parameters.AddWithValue("@Email", email.Text);
            command.Parameters.AddWithValue("@TipoCliente", fisicooujuridico.SelectedItem?.ToString() == "Físico" ? "F" : "J");
        }
    }
}
