using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        private IWebDriver driver;

        public NavegandoNaPaginaHome()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            //arrange
            //act
            driver.Navigate().GoToUrl("https://localhost:44309/");

            //assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            //arrange
            //act
            driver.Navigate().GoToUrl("https://localhost:44309/");

            //assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/");
            var linkLogin = driver.FindElement(By.LinkText("Login"));

            //act
            linkLogin.Click();

            //assert
            Assert.Contains("img", driver.PageSource);
        }

        [Fact]
        public void TentaAcessarPaginaSemEstarLogado()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //act
            //assert
            Assert.Contains("401", driver.PageSource);
        }
    }
}
