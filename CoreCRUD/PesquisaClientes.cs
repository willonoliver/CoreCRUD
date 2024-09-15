using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class PesquisaClientes : Form
    {
        public DataRow ClienteSelecionado { get; private set; }

        public PesquisaClientes()
        {
            InitializeComponent();
            CenterToScreen();
            this.Load += PesquisaClientes_Load;
            this.dataGridViewClientes.CellDoubleClick += DataGridViewClientes_CellDoubleClick;
        }

        private void PesquisaClientes_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes(string filtro = "")
        {
            string query = @"
                SELECT 
                    ID, NOMECLIENTE, RG, CPF, ENDERECO, NUMERO, COMPLEMENTO, 
                    CEP, CIDADE, UF, CELULAR, TELEFONE, EMAIL 
                FROM 
                    CADCLIENTES";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += @"
                    WHERE 
                        UPPER(NOMECLIENTE) LIKE UPPER(@filtro) OR 
                        UPPER(RG) LIKE UPPER(@filtro) OR 
                        UPPER(CPF) LIKE UPPER(@filtro) OR 
                        UPPER(CIDADE) LIKE UPPER(@filtro)";
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
                            DataTable clientes = new DataTable();
                            adapter.Fill(clientes);
                            dataGridViewClientes.DataSource = clientes;
                        }
                    }
                }
            }
            catch (FbException fbEx)
            {
                MessageBox.Show("Erro ao carregar clientes: " + fbEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClienteSelecionado = ((DataRowView)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            string filtro = textBoxPesquisa.Text.Trim();
            CarregarClientes(filtro);
        }
    }
}
