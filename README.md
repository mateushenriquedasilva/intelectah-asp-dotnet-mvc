#  ASP.NET - Web Api

**Códigos:**
```bash
# Criar o projeto
dotnet new web -o Intelectah -f net5.0
# Framework para fazer a conexão com o banco de dados
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5
# migrações
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5

# criar migrações
dotnet clean
dotnet build
dotnet ef migrations add InitialCreation
# update database
dotnet ef database update
```