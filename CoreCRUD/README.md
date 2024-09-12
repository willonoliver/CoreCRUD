
---

# CoreCRUD

### Visão Geral
O **CoreCRUD** é um projeto em C# desenvolvido com a plataforma .NET, com foco em operações CRUD (Create, Read, Update, Delete) utilizando o banco de dados **Firebird 5.0**. Este projeto faz parte de um plano de extensão da disciplina de Banco de Dados da **Universidade Estácio de Sá**, com o objetivo de facilitar o aprendizado sobre manipulação de dados em aplicações .NET.

### Funcionalidades
- **Criar Registros**: Inserção de novos dados no banco de dados.
- **Ler Registros**: Exibição dos dados armazenados no banco de dados.
- **Atualizar Registros**: Alteração dos dados existentes.
- **Excluir Registros**: Remoção de registros do banco de dados.

### Pré-requisitos
- **.NET SDK**: Versão 8.0 ou superior.
- **Firebird 5.0**: Banco de dados Firebird instalado e funcionando. No momento, está disponível apenas a versão 32 bits. Você pode [baixar o Firebird 5.0 para Windows 32 bits aqui](https://objects.githubusercontent.com/github-production-release-asset-2e65be/54005538/8a8b3f62-3ff6-4861-846c-d3d41ee81ad0?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=releaseassetproduction%2F20240912%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20240912T021252Z&X-Amz-Expires=300&X-Amz-Signature=421392a7e5b9c195ff4e45134cc607b471a0a88be1e441e81e2035f03084f6ea&X-Amz-SignedHeaders=host&actor_id=144534898&key_id=0&repo_id=54005538&response-content-disposition=attachment%3B%20filename%3DFirebird-5.0.1.1469-0-windows-x64.exe&response-content-type=application%2Foctet-stream). O Firebird está configurado para rodar na porta remota 3050.

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