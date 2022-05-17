using OpenQA.Selenium;

namespace ByteBank.WebApp.Testes.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By campoEmail;
        private By campoSenha;
        private By btnLogar;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            campoEmail = By.Id("Email");
            campoSenha = By.Id("Senha");
            btnLogar = By.Id("btn-logar");
        }

        public void Navegar(string url) => driver.Navigate().GoToUrl(url);

        public void PreencherCamposELogar(string email, string senha)
        {
            driver.FindElement(campoEmail).SendKeys(email);
            driver.FindElement(campoSenha).SendKeys(senha);
        }

        public void btnClick() => driver.FindElement(btnLogar).Click();
    }
}
