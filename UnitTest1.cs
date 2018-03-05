using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestesCarteirinhaVacinacao.ViewModel;

namespace TestesCarteirinhaVacinacao
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();
        
        [SetUp]
        public void Initialize()
        {
            //Open Browser
            driver.Navigate().GoToUrl("~/ProjetoMinhaVida/Views/Carteirinha/CadastraPessoa.cshtml");
        }
        [Test]
        public void ExecuteTest()
        {
            ViewModelPessoa p = ObtemInfoPessoa();
            IWebElement element = driver.FindElement(By.Id("Login"));
            element.SendKeys(p.Login);
            element = driver.FindElement(By.Id("Password"));
            element.SendKeys(p.Password);
            element = driver.FindElement(By.Id("Nome"));
            element.SendKeys(p.Nome);
            element = driver.FindElement(By.Id("CPF"));
            element.SendKeys(p.CPF);
            element = driver.FindElement(By.Id("Salvar"));
            element.Click();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();  
        }

        public ViewModelPessoa ObtemInfoPessoa()
        {
            DateTime data = DateTime.Now;
            ViewModelPessoa p = new ViewModelPessoa();
            p.Nome = "Arthur Vaz";
            p.Login = "arthurpereira9";
            p.Password = "yogaway";
            p.CPF = "732.611.970-80";
            p.Nascimento = data.AddDays(-25);
            return p;
        }
    }
}
