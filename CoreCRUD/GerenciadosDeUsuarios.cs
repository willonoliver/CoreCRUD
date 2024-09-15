using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace CoreCRUD
{
    public partial class GerenciadorDeUsuarios : Form
    {
        private const int maxRetries = 3;

        public GerenciadorDeUsuarios()
        {
            InitializeComponent();
            InicializarEstado();
            CarregarUsuarios();
            this.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                this.Location = new Point(0, primaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void InicializarEstado()
        {
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void CarregarUsuarios()
        {
            try
            {
                using var connection = ConfigReader.GetDatabaseConnection();
                connection.Open();
                string query = "SELECT ID, USUARIO, SENHA FROM CADUSUARIOS";
                using var command = new FbCommand(query, connection);
                using var adapter = new FbDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                listBoxUsuarios.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    listBoxUsuarios.Items.Add($"ID: {row["ID"]}, Usuário: {row["USUARIO"]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarios.SelectedIndex >= 0)
            {
                var selectedUser = listBoxUsuarios.SelectedItem.ToString();
                var userId = selectedUser.Split(',')[0].Split(':')[1].Trim();

                try
                {
                    using var connection = ConfigReader.GetDatabaseConnection();
                    connection.Open();
                    string query = "SELECT USUARIO, SENHA FROM CADUSUARIOS WHERE ID = @id";
                    using var command = new FbCommand(query, connection);
                    command.Parameters.AddWithValue("@id", userId);
                    using var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtUsuario.Text = reader.GetString(0);
                        txtPassword.Text = reader.GetString(1);
                        txtUsuario.Enabled = true;
                        txtPassword.Enabled = true;
                        btnGravar.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados do usuário: {ex.Message}");
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int retryCount = 0;
            bool success = false;

            while (retryCount < maxRetries && !success)
            {
                try
                {
                    using var connection = ConfigReader.GetDatabaseConnection();
                    connection.Open();
                    using var transaction = connection.BeginTransaction();

                    var selectedUser = listBoxUsuarios.SelectedItem.ToString();
                    var userId = selectedUser.Split(',')[0].Split(':')[1].Trim();

                    string query = "UPDATE CADUSUARIOS SET USUARIO = @usuario, SENHA = @senha WHERE ID = @id";
                    using var command = new FbCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    command.Parameters.AddWithValue("@senha", txtPassword.Text);
                    command.Parameters.AddWithValue("@id", userId);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    success = true;
                    CarregarUsuarios();
                    InicializarEstado();
                    MessageBox.Show("Dados atualizados com sucesso!");
                }
                catch (FbException ex) when (ex.ErrorCode == 335544345)
                {
                    retryCount++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao gravar: {ex.Message}");
                    break;
                }
            }

            if (!success)
            {
                MessageBox.Show("Falha ao gravar os dados após várias tentativas.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarios.SelectedIndex >= 0)
            {
                var selectedUser = listBoxUsuarios.SelectedItem.ToString();
                var userId = selectedUser.Split(',')[0].Split(':')[1].Trim();

                try
                {
                    using var connection = ConfigReader.GetDatabaseConnection();
                    connection.Open();
                    using var transaction = connection.BeginTransaction();

                    string query = "DELETE FROM CADUSUARIOS WHERE ID = @id";
                    using var command = new FbCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@id", userId);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    CarregarUsuarios();
                    InicializarEstado();
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir usuário: {ex.Message}");
                }
            }
        }

        private void listBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementar se necessário
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            // Implementar se necessário
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Implementar se necessário
        }

    }
}
