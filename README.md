# Challenge
Projeto contruído com base em um desafio para vaga de desenvolvimento.

## Lista com linguagem, framework e/ou tecnologias usadas
*Framework: .net 6*

*Linguagem de programação: C#*

*ORM: EntityFrameworkCore*

*IDE: Visual Studio*

*BD: SQLServer*

### Instruções para execução do projeto
1- Clone o projeto em sua máquina

2- Caso os pacotes NuGet não sejam instalados automaticamente, instale-os

3- No caminho "src->infrastructure->data" da solução, abra a classe AppDbContext e altere a connectionString dentro de 
```
optionsBuilder.UseSqlServer("") 
```
para a sua própria
string de conexão. Caso haja algum problema de certificado mantenha o "TrustServerCertificate=True"

4- Caso você use o Visual Studio, abra o 'console gerenciado de pacotes', altere o projeto padrão para "BackendTest.Infrastructure.DataAcess" e digite o comando 
```
Add-Migration InitialMigration
```
e então
```
Update-Database
```

5- Execute o projeto
