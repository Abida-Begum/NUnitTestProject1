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

        // Navigating to the application
        public void StartBrowser()
        {
            driver.Navigate().GoToUrl(homeURL);
        }

        // Closing the browser
        public void CloseBrowser()
        {
            driver.Close();
        }

        // Click on the buttons
        public void ClickOnButtons(int buttonNumber)
        {
            var example = driver.FindElement(By.CssSelector(".example"));
            var buttons = example.FindElements(By.TagName("button"));
             buttons[buttonNumber].Click();
        }

        // Click OK Button on the pop up
        public void ClickOKButton()
        {
           
            driver.SwitchTo().Alert().Accept();           
        }

        // Click Cancel button on the pop up
        public void ClickCancelButton()
        {
            
            driver.SwitchTo().Alert().Dismiss();
        }

        // Enter input on the pop up
        public void WriteOnPopUpWindow(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        // Checking the result in the result section
        public string Result()
        {
            var result = driver.FindElement(By.Id("result")).Text;
            //Console.WriteLine(result);
            return result;
        }

    }
}
