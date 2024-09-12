using System;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json.Linq;

namespace CoreCRUD
{
    public static class ConfigReader
    {
        public static FbConnection GetDatabaseConnection()
        {
            var configContent = File.ReadAllText("database.json");
            if (string.IsNullOrEmpty(configContent))
            {
                throw new InvalidOperationException("O arquivo de configuração está vazio ou não foi encontrado.");
            }

            var config = JObject.Parse(configContent)["DatabaseConfig"];
            if (config == null)
            {
                throw new InvalidOperationException("A configuração do banco de dados não foi encontrada no arquivo JSON.");
            }

            var connectionString = new FbConnectionStringBuilder
            {
                Database = (string?)config["Directory"] ?? throw new InvalidOperationException("Database directory is not specified."),
                DataSource = (string?)config["Host"] ?? "localhost",
                Port = int.TryParse((string?)config["Port"], out int port) ? port : 3050,
                UserID = (string?)config["User"] ?? "SYSDBA",
                Password = (string?)config["Password"] ?? "masterkey",
                Charset = "UTF8", // Use UTF8 como o conjunto de caracteres
                Dialect = int.TryParse((string?)config["Dialect"], out int dialect) ? dialect : 3
            }.ToString();

            return new FbConnection(connectionString);
        }
    }
}
