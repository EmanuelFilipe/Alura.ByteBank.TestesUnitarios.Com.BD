using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {
        private IWebDriver driver;

        public AposRealizarLogin()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            var login = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");

            //act - faz o login
            btnLogar.Click();

            //assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));
            //var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            //act - faz o login
            btnLogar.Click();

            //assert
            Assert.Contains("The Email field is required", driver.PageSource);
            Assert.Contains("The Senha field is required", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            var login = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha010");

            //act - faz o login
            btnLogar.Click();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Name("Email"));
            var senha = driver.FindElement(By.Name("Senha"));
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();

            driver.FindElement(By.LinkText("Cliente")).Click();
            driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            driver.FindElement(By.Name("Identificador")).Click();
            driver.FindElement(By.Name("Identificador")).SendKeys(Guid.NewGuid().ToString());
            driver.FindElement(By.Name("CPF")).Click();
            driver.FindElement(By.Name("CPF")).SendKeys("07553474630");
            driver.FindElement(By.Name("Nome")).Click();
            driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
            driver.FindElement(By.Name("Profissao")).Click();
            driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

            //act - faz o login
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.LinkText("Home")).Click();

            //assert
            Assert.Contains("Logout", driver.PageSource);
        }

    }
}
