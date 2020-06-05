using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTask_MittoCH.PageObject
{
    class ResultPage
    {
        public IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#rso > div:nth-child(1) > div > div > div.r > a")]
        public IWebElement FirstSite { get; set; }

        public void clickOnFirstSite()
        {
            FirstSite.Click();
        }
    }
}
