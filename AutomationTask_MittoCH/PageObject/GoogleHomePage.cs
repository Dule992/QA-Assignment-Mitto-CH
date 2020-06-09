using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTask_MittoCH.PageObject
{
    public class GoogleHomePage
    {
        public IWebDriver driver;

        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[name = 'q']")]
        [CacheLookup]
        public IWebElement SearchBar { get; set; }

        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public GoogleHomePage Search(string text)
        {
            SearchBar.SendKeys(text);

            SearchBar.SendKeys(Keys.Enter);

            return new GoogleHomePage(driver);
        }


    }
}
