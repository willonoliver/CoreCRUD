using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class PesquisaFornecedores : Form
    {
        public DataRow FornecedorSelecionado { get; private set; }

        public PesquisaFornecedores()
        {
            InitializeComponent();
            CenterToScreen();
            this.Load += PesquisaFornecedores_Load;
            this.dataGridViewFornecedores.CellDoubleClick += DataGridViewFornecedores_CellDoubleClick;
        }

        private void PesquisaFornecedores_Load(object sender, EventArgs e)
        {
            CarregarFornecedores();
        }

        private void CarregarFornecedores(string filtro = "")
        {
            string query = @"
                SELECT 
                    ID, NOMEEMPRESA, NOMEFANTASIA, CNPJ, INSCRICAOESTADUAL, 
                    ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, 
                    CELULAR, TELEFONE, EMAIL 
                FROM 
                    CADFORNECEDORES";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += @"
                    WHERE 
                        UPPER(NOMEEMPRESA) LIKE UPPER(@filtro) OR 
                        UPPER(NOMEFANTASIA) LIKE UPPER(@filtro) OR 
                        UPPER(CNPJ) LIKE UPPER(@filtro) OR 
                        UPPER(NOMECIDADE) LIKE UPPER(@filtro)";
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
                            DataTable fornecedores = new DataTable();
                            adapter.Fill(fornecedores);
                            dataGridViewFornecedores.DataSource = fornecedores;
                        }
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao carregar fornecedores: " + fbEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FornecedorSelecionado = ((DataRowView)dataGridViewFornecedores.Rows[e.RowIndex].DataBoundItem).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            string filtro = textBoxPesquisa.Text.Trim();
            CarregarFornecedores(filtro);
        }

    }
}
