using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class PesquisaProdutos : Form
    {
        public DataRow ProdutoSelecionado { get; private set; }

        public PesquisaProdutos()
        {
            InitializeComponent();
            CenterToScreen();
            this.Load += PesquisaProdutos_Load;
            this.dataGridViewProdutos.CellDoubleClick += DataGridViewProdutos_CellDoubleClick;
            this.buttonPesquisar.Click += buttonPesquisar_Click;
        }

        private void PesquisaProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos(string filtro = "")
        {
            string query = @"
                SELECT 
                    ID_PRODUTO, NOME_PRODUTO, PRECO, QUANTIDADE_ESTOQUE 
                FROM 
                    CADPRODUTOS";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += @"
                    WHERE 
                        UPPER(NOME_PRODUTO) LIKE UPPER(@filtro)";
            }

            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();
                    using (var command = new FbCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }

                        using (var adapter = new FbDataAdapter(command))
                        {
                            DataTable produtos = new DataTable();
                            adapter.Fill(produtos);
                            dataGridViewProdutos.DataSource = produtos;
                        }
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao carregar produtos: " + fbEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ProdutoSelecionado = ((DataRowView)dataGridViewProdutos.Rows[e.RowIndex].DataBoundItem).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            string filtro = textBoxPesquisa.Text.Trim();
            CarregarProdutos(filtro);
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            // Este método pode ser deixado vazio ou pode conter lógica adicional se necessário
        }
    }
}
