# Instru��es
### Projeto Startup
O projeto de inicializa��o deve ser o MeuRobo

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
Altere a conex�o de banco de dados sqlserver<br>
EX: <br>
Server=[IP do seu servidor ou localhost];<br>
Catalog=[Nome do seu banco];<br>


# Migrations
### Abra o console do Entity e execute os comandos <br>
  add-migration [Nome do seu banco aqui]<br> 
  update-database

# Start da aplica��o MeuRobo
### ao executar a aplica��o 
ao executar a aplica��o aparecerar uma pagina com um input e um button
escreva uma coisa que deseja pesquisar na alura e clique no bot�o
uma ves feito isto ser� enviada uma requisi��o para a aplica��o roboAutoma��o 
e ser� aberta uma nova pagina pesquisando o que voc� escreveu no input 
e todos os textos estaram sendo capturados e listados na aba cursos 
do menu superior mas ainda n�o gravados apesar da camada de dados 
j� estar estruturada para receber os dados 

### Importante 
caso n�o consiga executar � possivel visualizar a execu��o do programa 
no  youtube no link https://www.youtube.com/watch?v=wTSbL7DEW1A



