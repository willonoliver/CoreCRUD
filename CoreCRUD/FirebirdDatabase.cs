using System;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

public class FirebirdDatabase
{
    private string _connectionString;

    public FirebirdDatabase()
    {
        // Obtém a string de conexão do app.config
        _connectionString = ConfigurationManager.ConnectionStrings["FirebirdConnection"].ConnectionString;
    }

    public void TestConnection()
    {
        using (FbConnection connection = new FbConnection(_connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }

    // Adicione outros métodos para interagir com o banco de dados conforme necessário
}
