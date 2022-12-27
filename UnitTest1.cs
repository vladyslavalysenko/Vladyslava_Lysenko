using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HW_selenium.PageObjects;


namespace SeleniumTest
{
    class Sample1
    {
        readonly WebDriver driver = new ChromeDriver();

        [SetUp]

        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test() 
        { 
            PageLogin SignInPage = new PageLogin(driver);
            PageMain MainPage = SignInPage.LoginValidUser("Admin", "admin123");
            MainPage.GoToAdmin();
            MainPage.GoToPayGrades();
            MainPage.GoToAddGrades();
            PageAddPayGrade PageAddPayGrade = MainPage.GoToAddPayGradePage();
            PageAddPayGrade.AddName("RandomName");

            PageAddPayGrade.AddCurrency();
            PageEditPayGrade PageEditPayGrade = PageAddPayGrade.GoToAddPayGradePage();
            PageEditPayGrade.Wait();

            //Check if we added currency
            Assert.IsTrue(PageEditPayGrade.IsCurrencyPresent());
            PageEditPayGrade.DeleteCurrency();
            PageEditPayGrade.Wait1();

            //Check if we deleted currency
            Assert.IsFalse(PageEditPayGrade.IsCurrencyPresent());
            MainPage = PageEditPayGrade.GoToMainPage();
            MainPage.Wait();

            //Check if we have our grade
            Assert.IsTrue(MainPage.IsGradePresent());
            MainPage.DeleteGrade();
            MainPage.Wait();

            //Check if we deleted our grade
            Assert.IsFalse(MainPage.IsGradePresent());
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
    }
}