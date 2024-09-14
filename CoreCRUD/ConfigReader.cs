using System;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreCRUD
{
    public static class ConfigReader
    {
        public static FbConnection GetDatabaseConnection()
        {
            string configContent;
            try
            {
                configContent = File.ReadAllText("database.json");
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException("O arquivo de configuração 'database.json' não foi encontrado.");
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Erro ao ler o arquivo de configuração: " + ex.Message);
            }

            if (string.IsNullOrEmpty(configContent))
            {
                throw new InvalidOperationException("O arquivo de configuração está vazio.");
            }

            JObject config;
            try
            {
                config = (JObject)JObject.Parse(configContent)["DatabaseConfig"];
            }
            catch (JsonReaderException ex)
            {
                throw new InvalidOperationException("Erro ao analisar o arquivo de configuração JSON: " + ex.Message);
            }

            if (config == null)
            {
                throw new InvalidOperationException("A configuração do banco de dados não foi encontrada no arquivo JSON.");
            }

            var connectionString = new FbConnectionStringBuilder
            {
                Database = (string?)config["Directory"] ?? throw new InvalidOperationException("O diretório do banco de dados não está especificado."),
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
