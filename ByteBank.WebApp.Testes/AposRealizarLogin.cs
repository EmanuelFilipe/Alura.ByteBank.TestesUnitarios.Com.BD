using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using ByteBank.WebApp.Testes.PageObjects;
using ByteBank.WebApp.Testes.Utilitarios;

namespace ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Gerenciador>
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;

        public AposRealizarLogin(Gerenciador gerenciador, ITestOutputHelper saidaConsoleTeste)
        {
            driver = gerenciador.Driver;
            SaidaConsoleTeste = saidaConsoleTeste;
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            ////arrange
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));
            //var senha = driver.FindElement(By.Id("Senha"));
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");

            ////act - faz o login
            //btnLogar.Click();

            RealizaLogin();

            //assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //act
            loginPO.btnClick();

            //assert
            Assert.Contains("The Email field is required", driver.PageSource);
            Assert.Contains("The Senha field is required", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //act
            loginPO.PreencherCamposELogar("andre@email.com", "senha010");
            loginPO.btnClick();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            RealizaLogin();

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

            //act
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.LinkText("Home")).Click();

            //assert
            Assert.Contains("Logout", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaLisagemDeContas()
        {
            RealizaLogin();

            //act
            driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));

            foreach (IWebElement item in elements)
                SaidaConsoleTeste.WriteLine(item.Text);

            //assert
            Assert.True(elements.Count > 1);
        }

        [Fact]
        public void RealizarLoginAcessaLisagemDeContasEAcessaTelaDetalhes()
        {
            RealizaLogin();

            //act
            driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));

            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();

            //act
            elemento.Click();

            //assert
            Assert.Contains("Voltar", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaLisagemDeContasUsandoHomePO()
        {
            //arrange
            RealizaLogin();

            //act
            var homePO = new HomePO(driver);
            homePO.LinkContaCorrenteClick();

            //assert
            Assert.Contains("Adicionar Conta-Corrente", driver.PageSource);
        }

        private void RealizaLogin()
        {
            ////arrange
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            //var login = driver.FindElement(By.Name("Email"));
            //var senha = driver.FindElement(By.Name("Senha"));

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");
            //driver.FindElement(By.Id("btn-logar")).Click();

            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //act
            loginPO.PreencherCamposELogar("andre@email.com", "senha01");
            loginPO.btnClick();
        }
    }
}
