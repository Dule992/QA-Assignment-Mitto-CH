using AutomationTask_MittoCH.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTask_MittoCH.TestSuite
{
    public class TestCase_GoogleSearch
    {
        //Test Data

        private string test_URL = "https://www.google.com/";

        private string parameter = "Mitto CH";

        private string expectedResult = "https://www.mitto.ch/";

        public IWebDriver driver;


        [SetUp]
        public void Start_Browser()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchForParameterAndVerifyIsDisplayFirst()
        {
            //Google Home Page

            GoogleHomePage site = new GoogleHomePage(driver);

            site.goToPage(test_URL);

            site.Search(parameter);

            System.Threading.Thread.Sleep(6000);

            //Google Result Page

            ResultPage resultPage = new ResultPage(driver);

            string actualResult = resultPage.FirstSite.GetAttribute("href");

            //Assert

            Assert.AreEqual(expectedResult, actualResult);

            if (actualResult == expectedResult)
            {
                Console.WriteLine("For parameter " + parameter + " in Google Result Page is displaying this site first: " + actualResult);

                resultPage.clickOnFirstSite();

                System.Threading.Thread.Sleep(6000);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TearDown]

        public void Close_Browser()
        {
            driver.Quit();
        }
    }

}