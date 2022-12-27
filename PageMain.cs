using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HW_selenium.PageObjects
{
    public class PageMain
    {
        protected WebDriver driver;

        private readonly By adminBy = By.XPath("//span[text()='Admin']");
        private readonly By jobBy = By.XPath("//span[text()='Job ']");
        private readonly By jobPayGradesBy = By.XPath("//a[text()='Pay Grades']");
        private readonly By jobPayGradesTitleBy = By.XPath("//h6[text()='Pay Grades']");
        private readonly By AddBy = By.XPath("//button[text()=' Add ']");
        private readonly By payGradesBy = By.XPath("//h6[text()='Pay Grades']");
        private readonly By gradeCurrencyBy = By.XPath("//div[not(text()) and @data-v-c186142a]");
        private readonly By deleteGradeBy = By.XPath("//div//child::div[text()='RandomName']//ancestor::div[@role='row']//child::i[@class='oxd-icon bi-trash']");
        private readonly By confirmDeleteBy = By.XPath("//button[text()=' Yes, Delete ']");
        private readonly By nameBy = By.XPath("//div[text()='Name']");
        private readonly By gradeTitleBy;

        public PageMain(WebDriver driver, string title = "RandomName")
        {
            this.driver = driver;
            gradeTitleBy = By.XPath("//div//child::div[text()='" + title + "']");
    }
        public void GoToAdmin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(adminBy));
            driver.FindElement(adminBy).Click();
        }
        public void Wait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(nameBy));
        }
        public void GoToPayGrades()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(jobBy));

            driver.FindElement(jobBy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(jobPayGradesBy));
            driver.FindElement(jobPayGradesBy).Click();
        }
        public void GoToAddGrades()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(jobPayGradesTitleBy));
            driver.FindElement(AddBy).Click();
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
        public bool IsGradePresent()
        {
            if (IsElementPresent(gradeTitleBy) && IsElementPresent(gradeCurrencyBy))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void DeleteGrade()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(deleteGradeBy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(confirmDeleteBy));
            driver.FindElement(confirmDeleteBy).Click();

        }
        public PageAddPayGrade GoToAddPayGradePage()
        {
            return new PageAddPayGrade(driver);
        }
    }
}
