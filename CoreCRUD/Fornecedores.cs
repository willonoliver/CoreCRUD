using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Fornecedores : Form
    {
        private int? fornecedorId = null; // Variável para armazenar o ID do fornecedor selecionado

        public Fornecedores()
        {
            InitializeComponent();
            this.Load += Fornecedores_Load;
            this.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                this.Location = new Point(0, primaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void Fornecedores_Load(object sender, EventArgs e)
        {
            // Definir o estado inicial dos botões
            Incluir.Enabled = true;
            Pesquisar.Enabled = true;
            Gravar.Enabled = false;
            Alterar.Enabled = false; // Novo botão Alterar
        }

        private void Incluir_Click(object sender, EventArgs e)
        {
            // Limpar os campos para inclusão de um novo fornecedor
            LimparCampos();
            fornecedorId = null; // Resetar o ID do fornecedor

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

            string insertQuery = "INSERT INTO CADFORNECEDORES (NOMEEMPRESA, NOMEFANTASIA, CNPJ, INSCRICAOESTADUAL, ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, CELULAR, TELEFONE, EMAIL, DATAALTERACAO) " +
                                 "VALUES (@NomeEmpresa, @NomeFantasia, @CNPJ, @InscricaoEstadual, @Endereco, @Numero, @Complemento, @CEP, @NomeCidade, @UF, @Celular, @Telefone, @Email, @DataAlteracao)";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

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
                Alterar.Enabled = false;
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

        private void Alterar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            string updateQuery = "UPDATE CADFORNECEDORES SET NOMEEMPRESA = @NomeEmpresa, NOMEFANTASIA = @NomeFantasia, CNPJ = @CNPJ, INSCRICAOESTADUAL = @InscricaoEstadual, ENDERECO = @Endereco, NUMERO = @Numero, COMPLEMENTO = @Complemento, CEP = @CEP, NOMECIDADE = @NomeCidade, UF = @UF, CELULAR = @Celular, TELEFONE = @Telefone, EMAIL = @Email, DATAALTERACAO = @DataAlteracao WHERE ID = @ID";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(updateQuery, connection))
                    {
                        AdicionarParametros(command);
                        command.Parameters.AddWithValue("@ID", fornecedorId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Fornecedor atualizado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
                Alterar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao atualizar Fornecedor: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            using (var pesquisaForm = new PesquisaFornecedores())
            {
                if (pesquisaForm.ShowDialog() == DialogResult.OK)
                {
                    var fornecedor = pesquisaForm.FornecedorSelecionado;
                    if (fornecedor != null)
                    {
                        fornecedorId = Convert.ToInt32(fornecedor["ID"]); // Armazenar o ID do fornecedor
                        NomeEmpresa.Text = fornecedor["NOMEEMPRESA"].ToString();
                        NomeFantasia.Text = fornecedor["NOMEFANTASIA"].ToString();
                        CNPJ.Text = fornecedor["CNPJ"].ToString();
                        InscricaoEstadual.Text = fornecedor["INSCRICAOESTADUAL"].ToString();
                        Endereco.Text = fornecedor["ENDERECO"].ToString();
                        Numero.Text = fornecedor["NUMERO"].ToString();
                        Complemento.Text = fornecedor["COMPLEMENTO"].ToString();
                        CEP.Text = fornecedor["CEP"].ToString();
                        NomeCidade.Text = fornecedor["NOMECIDADE"].ToString();
                        comboBoxUF.SelectedItem = fornecedor["UF"].ToString();
                        celular.Text = fornecedor["CELULAR"].ToString();
                        telefone.Text = fornecedor["TELEFONE"].ToString();
                        email.Text = fornecedor["EMAIL"].ToString();
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
