 = CRUD de Países – C#

Aplicação desenvolvida em C# utilizando Windows Forms para realizar o cadastro, edição, exclusão e listagem de países.

O sistema utiliza banco de dados relacional SQL Server e ADO.NET para persistência dos dados.

-/-

 = Funcionalidades
* Cadastrar países
* Listar países cadastrados
* Atualizar dados de um país
* Excluir países
* Validação de dados de entrada

-/-

 = Tecnologias Utilizadas
* C#
* .NET
* Windows Forms
* SQL Server
* ADO.NET

-/-

 = Como executar o projeto

 = Pré-requisitos
* Visual Studio
* SQL Server Express
* SQL Server Management Studio (SSMS)

 = Passos
1. Clonar o repositório
```bash
git clone https://github.com/decano-snake/crud-paises-csharp.git
```
2. Abrir a solução no Visual Studio
3. Criar o banco de dados no SQL Server com o script abaixo:

 ```
    CREATE DATABASE CrudPaisesDB;
      GO
      
      USE CrudPaisesDB;
      GO
      
      CREATE TABLE Pais (
          Codigo_pais INT IDENTITY PRIMARY KEY,
          Nome_pais VARCHAR(100) NOT NULL,
          Populacao BIGINT NOT NULL CHECK (Populacao > 0),
          Area_total FLOAT NOT NULL CHECK (Area_total > 0)
      );
```
4. Ajustar a connection string no arquivo PaisRepository.cs, se necessário
5. Executar o projeto WinForms pelo Visual Studio
