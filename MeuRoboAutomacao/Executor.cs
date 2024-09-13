﻿using MeuRoboDominio.Interfaces;
using MeuRoboNegocios.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            using (IWebDriver driver = new ChromeDriver()) {

                driver.Navigate().GoToUrl("https://www.alura.com.br/");
                Thread.Sleep(3000);
                // Encontrar o campo de pesquisa usando o nome do elemento
                IWebElement searchBox = driver.FindElement(By.Name("query"));
                Thread.Sleep(1000);
                // Digitar "Selenium WebDriver" na caixa de pesquisa
                searchBox.SendKeys(queryValue);
                // Submeter o formulário de pesquisa
                searchBox.Submit();
                Thread.Sleep(2000);

                var h4Elements = driver.FindElements(By.CssSelector("h4.busca-resultado-nome"));
                List<string> h4Texts = new List<string>();
                foreach (var element in h4Elements)
                {
                    h4Texts.Add(element.Text);
                }
                bool gravaCursos = _cursosRepository.SetCursos(h4Texts);

                Thread.Sleep(1000);
                driver.Quit();

                return h4Texts;
            }
 
        }
    }
}
