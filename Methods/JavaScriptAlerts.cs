using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace NUnitTestProject1.Methods
{
    public class JavaScriptAlerts
    {

        public string homeURL = "https://the-internet.herokuapp.com/javascript_alerts";
        private IWebDriver driver;

       public JavaScriptAlerts()
        {
            driver = new FirefoxDriver();
        }
        public void StartBrowser()
        {
            driver.Navigate().GoToUrl(homeURL);
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public void ClickOnButtons(int buttonNumber)
        {
            var example = driver.FindElement(By.CssSelector(".example"));
            var buttons = example.FindElements(By.TagName("button"));
             buttons[buttonNumber].Click();
        }

        public void ClickOKButton()
        {
           
            driver.SwitchTo().Alert().Accept();           
        }

        public void ClickCancelButton()
        {
            
            driver.SwitchTo().Alert().Dismiss();
        }

        public void WriteOnPopUpWindow(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        public string Result()
        {
            var result = driver.FindElement(By.Id("result")).Text;
            //Console.WriteLine(result);
            return result;
        }

    }
}
