# Instruções
### Projeto Startup
O projeto de inicialização deve ser o MeuRobo

### pacotes do MeuRobo
Microsoft.EntityFrameworkCore.Design
Microsoft.VisualStudio.Web.CodeGenerator.Design
AutoMapper

### pacotes do MeuRoboDados
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SQLSERVER
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGenerator.Design
AutoMapper

### pacotes do MeuRoboAutomacao
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
Serilog
Serilog.Sinks.Console
Serilog.Sinks.File

### Arquivo appsettings.json
Altere a conexão de banco de dados sqlserver<br>
EX: <br>
Server=[IP do seu servidor ou localhost];<br>
Catalog=[Nome do seu banco];<br>


# Migrations
### Abra o console do Entity e execute os comandos <br>
  add-migration [Nome do seu banco aqui]<br> 
  update-database

# Start da aplicação MeuRobo
### ao executar a aplicação 
ao executar a aplicação aparecerar uma pagina com um input e um button
escreva uma coisa que deseja pesquisar na alura e clique no botão
uma ves feito isto será enviada uma requisição para a aplicação roboAutomação 
e será aberta uma nova pagina pesquisando o que você escreveu no input 
e todos os textos estaram sendo capturados e listados na aba cursos 
do menu superior mas ainda não gravados apesar da camada de dados 
já estar estruturada para receber os dados 

### Importante 
caso não consiga executar é possivel visualizar a execução do programa 
no  youtube no link https://www.youtube.com/watch?v=wTSbL7DEW1A



