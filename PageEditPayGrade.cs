using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_selenium.PageObjects
{
    public class PageEditPayGrade
    {
        protected WebDriver driver;

        private readonly By minSalaryBy = By.XPath("//div//child::div[text()='10000.00']");
        private readonly By maxSalaryBy = By.XPath("//div//child::div[text()='12000.00']");
        private readonly By deleteBy = By.XPath("//div//child::div[text()='10000.00']//ancestor::div[@role=\"row\"]//child::i[@class='oxd-icon bi-trash']");
        private readonly By confirmDelete = By.XPath("//button[text()=' Yes, Delete ']");
        private readonly By recordFoundBy = By.XPath("//span[text()='(1) Record Found']");
        private readonly By cancelBy = By.XPath("//button[text()=' Cancel ']");
        private readonly By nofoundBy = By.XPath("//span[text()='No Records Found']");

        public PageEditPayGrade(WebDriver driver)
        {
            this.driver = driver;
        }
        public void Wait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(recordFoundBy));
        }
        public void Wait1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(nofoundBy));
        }

        public bool IsElementPresent(By el)
        {
            try
            {
                driver.FindElement(el);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsCurrencyPresent()
        {
            if (IsElementPresent(minSalaryBy) && IsElementPresent(maxSalaryBy))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void DeleteCurrency()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(deleteBy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(confirmDelete));
            driver.FindElement(confirmDelete).Click();
        }
        public PageMain GoToMainPage()
        {
            driver.FindElement(cancelBy).Click();
            return new PageMain(driver);
        }
    }
}
