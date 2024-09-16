using MeuRoboDominio.Interfaces;
using MeuRoboNegocios.Interfaces;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;


using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.DevTools.V126.Runtime;
using MeuRoboDominio.Response;

namespace MeuRoboAutomacao
{
    public class Executor : IExecutorRepository
    {
        private readonly ICursosRepository _cursosRepository;
        public Executor()
        {
        }

        public Executor(ICursosRepository cursosRepository)
        {
            _cursosRepository = cursosRepository;
           
        }

        public List<string> Execute( string queryValue) {

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console() // Log para o console
            .WriteTo.File("Logs/meuapp-.txt", rollingInterval: RollingInterval.Day) // Log para arquivos, com rotação diária
            .CreateLogger();


            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {

                    driver.Navigate().GoToUrl("https://www.alura.com.br/");
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    // Encontrar o campo de pesquisa usando o nome do elemento
                    IWebElement searchBox = driver.FindElement(By.Name("query"));
                    Thread.Sleep(1000);
                    // Digitar "Selenium WebDriver" na caixa de pesquisa
                    searchBox.SendKeys(queryValue);
                    // Submeter o formulário de pesquisa
                    searchBox.Submit();
                    Thread.Sleep(2000);

                    IReadOnlyCollection<IWebElement> links = driver.FindElements(By.CssSelector("a.busca-resultado-link"));
                    List<CursosResponse> cursos = new List<CursosResponse>();
                    foreach (IWebElement link in links) {
                        try
                        {
                            CursosResponse curso = new CursosResponse();
                            string href = link.GetAttribute("href");
                            ((IJavaScriptExecutor)driver).ExecuteScript("window.open(arguments[0]);", href);
                            driver.SwitchTo().Window(driver.WindowHandles[1]);
                            wait.Until(d => d.Url == href);
                            //pega os textos e salva no banco 
                            IWebElement h1Element = driver.FindElement(By.CssSelector("h1.formacao-headline-titulo"));
                            // Obter o texto do elemento <h1>
                            curso.Titulo = h1Element.Text;

                            IWebElement divElement = driver.FindElement(By.CssSelector("div.formacao-descricao-texto"));
                            curso.Descricao = divElement.Text;

                            //pega professores
                            IReadOnlyCollection<IWebElement> instructorElements = driver.FindElements(By.CssSelector("h3.formacao-instrutor-nome"));
                            // Extrair os nomes dos instrutores
                            List<string> instructorNames = new List<string>();
                            foreach (IWebElement element in instructorElements)
                            {
                                instructorNames.Add(element.Text);
                            }

                            // Remover duplicatas (opcional)
                            instructorNames = instructorNames.Distinct().ToList();
                            string allInstructorNames = string.Join(", ", instructorNames);
                            curso.Professor = allInstructorNames;

                            //pega carga horária
                            IWebElement divElement2 = driver.FindElement(By.CssSelector("div.formacao__info-destaque"));
                            string divText = divElement2.Text;

                            curso.CargaHoraria = divText;

                            driver.Close();
                            driver.SwitchTo().Window(driver.WindowHandles[0]);
                            //adiciona curso a lista
                            cursos.Add(curso);

                            Thread.Sleep(2000);
                        }
                        catch(NoSuchElementException) {
                            Log.Error("Elemento não encontrado");
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Ocorreu uma exceção no aplicativo.");

                        }
                        
                    }

                    bool gravaCursos = _cursosRepository.SetCursos(cursos);

                    Thread.Sleep(1000);
                    driver.Quit();

                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocorreu uma exceção no aplicativo.");
                throw;
            }
            finally {
                Log.CloseAndFlush();
            }

        }
    }
}
