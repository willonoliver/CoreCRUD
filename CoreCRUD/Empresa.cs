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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                this.Location = new Point(0, primaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            try
            {
                VerificarECriarTabela();
                CarregarDadosEmpresa();
                SetControlsEnabled(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o formulário: " + ex.Message);
            }
        }

        private void VerificarECriarTabela()
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();
                    string query = "SELECT 1 FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = 'CADEMPRESA'";
                    using (var command = new FbCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result == null)
                        {
                            string createTableQuery = @"
                                CREATE TABLE CADEMPRESA (
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
                            using (var createCommand = new FbCommand(createTableQuery, connection))
                            {
                                createCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar/criar tabela: " + ex.Message);
            }
        }

        private void CarregarDadosEmpresa()
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM CADEMPRESA ROWS 1";
                    using (var command = new FbCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NomeEmpresa.Text = reader["NOMEEMPRESA"].ToString();
                                NomeFantasia.Text = reader["NOMEFANTASIA"].ToString();
                                CNPJ.Text = reader["CNPJ"].ToString();
                                InscricaoEstadual.Text = reader["INSCRICAOESTADUAL"].ToString();
                                Endereco.Text = reader["ENDERECO"].ToString();
                                Numero.Text = reader["NUMERO"].ToString();
                                Complemento.Text = reader["COMPLEMENTO"].ToString();
                                CEP.Text = reader["CEP"].ToString();
                                NomeCidade.Text = reader["NOMECIDADE"].ToString();
                                comboBoxUF.SelectedItem = reader["UF"].ToString();
                                celular.Text = reader["CELULAR"].ToString();
                                telefone.Text = reader["TELEFONE"].ToString();
                                email.Text = reader["EMAIL"].ToString();
                            }
                            else
                            {
                                CriarNovoRegistro();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void CriarNovoRegistro()
        {
            try
            {
                using (var connection = ConfigReader.GetDatabaseConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO CADEMPRESA (ID, NOMEEMPRESA, NOMEFANTASIA, CNPJ, INSCRICAOESTADUAL, ENDERECO, NUMERO, COMPLEMENTO, CEP, NOMECIDADE, UF, CELULAR, TELEFONE, EMAIL, DATAALTERACAO) VALUES (1, '', '', '', '', '', '', '', '', '', '', '', '', '', CURRENT_TIMESTAMP)";
                    using (var command = new FbCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Novo registro criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar novo registro: " + ex.Message);
            }
        }

        private void NomeEmpresa_TextChanged(object sender, EventArgs e) { }

        private void NomeFantasia_TextChanged(object sender, EventArgs e) { }

        private void CNPJ_TextChanged(object sender, EventArgs e) { }

        private void InscricaoEstadual_TextChanged(object sender, EventArgs e) { }

        private void Endereco_TextChanged(object sender, EventArgs e) { }

        private void Numero_TextChanged(object sender, EventArgs e) { }

        private void Complemento_TextChanged(object sender, EventArgs e) { }

        private void CEP_TextChanged(object sender, EventArgs e) { }

        private void NomeCidade_TextChanged(object sender, EventArgs e) { }

        private void comboBoxUF_SelectedIndexChanged(object sender, EventArgs e) { }

        private void celular_TextChanged(object sender, EventArgs e) { }

        private void telefone_TextChanged(object sender, EventArgs e) { }

        private void email_TextChanged(object sender, EventArgs e) { }

        private void Alterar_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(true);
        }

        private void Gravar_Click(object sender, EventArgs e)
        {
            GravarDadosEmpresa();
            SetControlsEnabled(false);
        }

        private void GravarDadosEmpresa()
        {
            const int maxRetries = 3;
            int retryCount = 0;
            bool success = false;

            while (retryCount < maxRetries && !success)
            {
                try
                {
                    using (var connection = ConfigReader.GetDatabaseConnection())
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            string query = "UPDATE CADEMPRESA SET NOMEEMPRESA = @NomeEmpresa, NOMEFANTASIA = @NomeFantasia, CNPJ = @CNPJ, INSCRICAOESTADUAL = @InscricaoEstadual, ENDERECO = @Endereco, NUMERO = @Numero, COMPLEMENTO = @Complemento, CEP = @CEP, NOMECIDADE = @NomeCidade, UF = @UF, CELULAR = @Celular, TELEFONE = @Telefone, EMAIL = @Email, DATAALTERACAO = CURRENT_TIMESTAMP WHERE ID = 1";
                            using (var command = new FbCommand(query, connection, transaction))
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

                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                    }
                    success = true;
                    MessageBox.Show("Dados alterados com sucesso!");
                }
                catch (FbException ex) when (ex.ErrorCode == 335544345) // Deadlock error code
                {
                    retryCount++;
                    if (retryCount == maxRetries)
                    {
                        MessageBox.Show("Erro ao alterar dados: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar dados: " + ex.Message);
                    break;
                }
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            NomeEmpresa.Enabled = enabled;
            NomeFantasia.Enabled = enabled;
            CNPJ.Enabled = enabled;
            InscricaoEstadual.Enabled = enabled;
            Endereco.Enabled = enabled;
            Numero.Enabled = enabled;
            Complemento.Enabled = enabled;
            CEP.Enabled = enabled;
            NomeCidade.Enabled = enabled;
            comboBoxUF.Enabled = enabled;
            celular.Enabled = enabled;
            telefone.Enabled = enabled;
            email.Enabled = enabled;
            Gravar.Enabled = enabled;
        }
    }
}
