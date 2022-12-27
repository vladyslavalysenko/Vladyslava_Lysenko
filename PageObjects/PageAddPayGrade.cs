using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using HW_selenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_selenium.PageObjects
{
    public class PageAddPayGrade
    {
        protected WebDriver driver;


        private readonly By nameBy = By.XPath("//div[@data-v-2fe357a6]//child::input[@data-v-844e87dc]");
        private readonly By saveBy = By.XPath("//button[text()=' Save ']");
        private readonly By addCurrencyBy = By.XPath("//button[text()=' Add ']");
        private readonly By selectCurrencyBy = By.XPath("//div[text()='-- Select --']");
        private readonly By currencyBy = By.XPath("//span[text()='AFN - Afghanistan Afghani']");
        private readonly By minSalaryBy = By.XPath("//label[text()='Minimum Salary']//ancestor::div[@data-v-77a413b5]//child::input");
        private readonly By maxSalaryBy = By.XPath("//label[text()='Maximum Salary']//ancestor::div[@data-v-77a413b5]//child::input");
        private readonly By saveCurrencyBy = By.XPath("//h6[text()='Add Currency']//parent::div//child::button[text()=' Save ']");

        public PageAddPayGrade(WebDriver driver)
        {
            this.driver = driver;
        }

        public void AddName(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(nameBy));
            driver.FindElement(nameBy).SendKeys(name);
            driver.FindElement(saveBy).Click();
        }
        public void AddCurrency()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(addCurrencyBy));
            driver.FindElement(addCurrencyBy).Click();
            driver.FindElement(selectCurrencyBy).Click();
            driver.FindElement(currencyBy).Click();
            driver.FindElement(minSalaryBy).SendKeys(10000.ToString());
            driver.FindElement(maxSalaryBy).SendKeys(12000.ToString());
            driver.FindElement(saveCurrencyBy).Click();
        }
        public PageEditPayGrade GoToAddPayGradePage()
        {
            return new PageEditPayGrade(driver);
        }
    }
}
