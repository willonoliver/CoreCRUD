using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace CoreCRUD
{
    public partial class PesquisaFornecedores : Form
    {
        // Evento para notificar a seleção de um fornecedor
        public event Action<int> FornecedorSelecionado;

        public PesquisaFornecedores()
        {
            InitializeComponent();
        }

        private void BarradePesquisas_TextChanged(object sender, EventArgs e)
        {
            // Você pode adicionar lógica de pesquisa em tempo real aqui, se necessário
        }

        private void GridPesquisaFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se a célula clicada é válida
            if (e.RowIndex >= 0)
            {
                // Obter o ID do fornecedor selecionado
                int fornecedorId = Convert.ToInt32(GridPesquisaFornecedores.Rows[e.RowIndex].Cells["ID"].Value);
                // Acionar o evento FornecedorSelecionado
                FornecedorSelecionado?.Invoke(fornecedorId);
                // Fechar o formulário de pesquisa
                this.Close();
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();

                    // Consulta para pesquisar fornecedores
                    string searchQuery = @"
                        SELECT ID, NOMEEMPRESA, NOMEFANTASIA, CNPJ, INSCRICAOESTADUAL, ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, CELULAR, TELEFONE, EMAIL, DATAALTERACAO
                        FROM CADFORNECEDORES
                        WHERE NOMEEMPRESA LIKE @searchTerm OR NOMEFANTASIA LIKE @searchTerm OR CNPJ LIKE @searchTerm";

                    using (var searchCommand = new FbCommand(searchQuery, connection))
                    {
                        searchCommand.Parameters.AddWithValue("@searchTerm", "%" + BarradePesquisas.Text + "%");

                        using (var reader = searchCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            GridPesquisaFornecedores.DataSource = dataTable;
                        }
                    }

                    connection.Close();
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
    }
}
