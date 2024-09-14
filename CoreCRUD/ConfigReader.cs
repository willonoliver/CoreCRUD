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
                throw new InvalidOperationException("O arquivo de configura��o 'database.json' n�o foi encontrado.");
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Erro ao ler o arquivo de configura��o: " + ex.Message);
            }

            if (string.IsNullOrEmpty(configContent))
            {
                throw new InvalidOperationException("O arquivo de configura��o est� vazio.");
            }

            JObject config;
            try
            {
                config = (JObject)JObject.Parse(configContent)["DatabaseConfig"];
            }
            catch (JsonReaderException ex)
            {
                throw new InvalidOperationException("Erro ao analisar o arquivo de configura��o JSON: " + ex.Message);
            }

            if (config == null)
            {
                throw new InvalidOperationException("A configura��o do banco de dados n�o foi encontrada no arquivo JSON.");
            }

            var connectionString = new FbConnectionStringBuilder
            {
                Database = (string?)config["Directory"] ?? throw new InvalidOperationException("O diret�rio do banco de dados n�o est� especificado."),
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
