using System;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

public class FirebirdDatabase
{
    private string _connectionString;

    public FirebirdDatabase()
    {
        // Obt�m a string de conex�o do app.config
        _connectionString = ConfigurationManager.ConnectionStrings["FirebirdConnection"].ConnectionString;
    }

    public void TestConnection()
    {
        using (FbConnection connection = new FbConnection(_connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conex�o bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }

    // Adicione outros m�todos para interagir com o banco de dados conforme necess�rio
}
