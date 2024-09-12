
---
# CoreCRUD

### Visão Geral
O **CoreCRUD** é um projeto básico em C# desenvolvido com a plataforma .NET, focado em operações CRUD (Create, Read, Update, Delete) usando o banco de dados **Firebird 5.0**. Ele faz parte de um plano para um projeto de extensão da disciplina de Banco de Dados da **Universidade Estácio de Sá**, com o objetivo de facilitar o aprendizado sobre manipulação de dados em aplicações .NET.

### Funcionalidades
- **Criar Registros**: Insere novos dados no banco de dados.
- **Ler Registros**: Exibe os dados armazenados no banco de dados.
- **Atualizar Registros**: Altera os dados existentes.
- **Excluir Registros**: Remove registros do banco de dados.

### Pré-requisitos
- **.NET SDK**: Versão 8.0 ou superior.
- **Firebird 5.0**: Banco de dados Firebird instalado e funcionando.

### Instalação

1. **Clone o Repositório**:

   ```bash
   git clone https://github.com/willonoliver/CoreCRUD.git
   cd CoreCRUD
   ```

2. **Restaurar Pacotes**:

   ```bash
   dotnet restore
   ```

3. **Configuração do Banco de Dados**:

   Edite o arquivo `database.json` com as informações corretas para conectar ao banco de dados:

   ```json
   {
     "DatabaseConfig": {
       "Directory": "C:\\CoreCRUD\\CRUD\\SISTEMA.FDB",
       "Host": "localhost",
       "Port": "3050",
       "User": "SYSDBA",
       "Password": "masterkey",
       "Charset": "UTF8",
       "Dialect": "3"
     }
   }
   ```

4. **Executar o Projeto**:

   Para compilar e rodar o projeto:

   ```bash
   dotnet build
   dotnet run
   ```

---
