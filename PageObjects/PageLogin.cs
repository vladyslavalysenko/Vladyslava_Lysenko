using System;
using OpenQA.Selenium;
using System.Threading;
using HW_selenium.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HW_selenium.PageObjects
{
    public class PageLogin
    {
        protected WebDriver driver;

        private readonly By usernameBy = By.Name("username");
        private readonly By passwordBy = By.Name("password");
        private readonly By signinBy = By.TagName("button");

        public PageLogin(WebDriver driver)
        {
            this.driver = driver;
        }
        public PageMain LoginValidUser(String userName, String password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(usernameBy));

            driver.FindElement(usernameBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(signinBy).Click();
            return new PageMain(driver);
        }
    }
    
        
}