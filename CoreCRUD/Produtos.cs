using System;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class Produtos : Form
    {
        private int? ProdutoId = null; // Variável para armazenar o ID do Produto selecionado

        public Produtos()
        {
            InitializeComponent();
            this.Load += Produtos_Load;
            this.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                // Definir a posição do formulário na lateral direita e inferior da tela
                this.Location = new Point(primaryScreen.WorkingArea.Width - this.Width, primaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void Produtos_Load(object? sender, EventArgs e)
        {
            // Ajustar o GENERATOR
            AjustarGenerator();

            // Definir o estado inicial dos botões
            Incluir.Enabled = true;
            Pesquisar.Enabled = true;
            Gravar.Enabled = false;
            Alterar.Enabled = false;
        }

        private void AjustarGenerator()
        {
            int maiorId = 0;
            string queryMaxId = "SELECT MAX(ID) FROM CADPRODUTOS";
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
                    ajustarGeneratorQuery = $"SET GENERATOR SEQ_CADPRODUTOS TO {maiorId + 1}";
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
            // Limpar os campos para inclusão de um novo Produto
            LimparCampos();
            ProdutoId = null; // Resetar o ID do Produto

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

            string insertQuery = "INSERT INTO CADPRODUTOS (ID, NOME, DESCRICAO, PRECO) " +
                                 "VALUES (@ID, @Nome, @Descricao, @Preco)";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", novoId);
                        // AdicionarParametros(command); // Adicione os parâmetros manualmente
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Novo Produto criado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
                Alterar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao criar novo Produto: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private int ObterProximoId()
        {
            int novoId = 0;
            string query = "SELECT NEXT VALUE FOR SEQ_CADPRODUTOS FROM RDB$DATABASE";

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

            string updateQuery = "UPDATE CADPRODUTOS SET NOME = @Nome, DESCRICAO = @Descricao, PRECO = @Preco WHERE ID = @ID";

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    using (var command = new FbCommand(updateQuery, connection))
                    {
                        // AdicionarParametros(command); // Adicione os parâmetros manualmente
                        command.Parameters.AddWithValue("@ID", ProdutoId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Produto atualizado com sucesso!");
                LimparCampos();

                // Alterar o estado dos botões
                Incluir.Enabled = true;
                Pesquisar.Enabled = true;
                Gravar.Enabled = false;
                Alterar.Enabled = false;
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao atualizar Produto: " + fbEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            using (var pesquisaForm = new PesquisaProdutos())
            {
                if (pesquisaForm.ShowDialog() == DialogResult.OK)
                {
                    var Produto = pesquisaForm.ProdutoSelecionado;
                    if (Produto != null)
                    {
                        ProdutoId = Convert.ToInt32(Produto["ID"]); // Armazenar o ID do Produto
                        // Preencher os campos com os dados do Produto selecionado
                        // NomeProduto.Text = Produto["NOME"].ToString();
                        // DescricaoProduto.Text = Produto["DESCRICAO"].ToString();
                        // PrecoProduto.Text = Produto["PRECO"].ToString();
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
            // NomeProduto.Text = "";
            // DescricaoProduto.Text = "";
            // PrecoProduto.Text = "";
        }

        private bool ValidarCampos()
        {
            // Adicione aqui a lógica de validação dos campos
            return true; // Ajuste conforme necessário
        }
    }
}
