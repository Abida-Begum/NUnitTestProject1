using NUnit.Framework;
using NUnitTestProject1.Methods;

namespace NUnitTestProject1.JavaAlertsTest
{
    
    public class JavaAlertests
    {
      
        private JavaScriptAlerts JavaScriptAlerts1 = new JavaScriptAlerts();
        
        [Test, Order(1)]
        public void ClickOnJSAlert()
        {
            JavaScriptAlerts1.StartBrowser();
            JavaScriptAlerts1.ClickOnButtons(0);
            JavaScriptAlerts1.ClickOKButton();
            Assert.That(JavaScriptAlerts1.Result().Contains("You successfully clicked an alert"));
        }

        [Test, Order(2)]
        public void ClickOnJSConfirm()
        {
            //JavaScriptAlerts1.StartBrowser();
            JavaScriptAlerts1.ClickOnButtons(1);
            JavaScriptAlerts1.ClickOKButton();
            Assert.That(JavaScriptAlerts1.Result().Contains("You clicked: Ok"));

            //clicking on cancel button for JS Confirm
            JavaScriptAlerts1.ClickOnButtons(1);
            JavaScriptAlerts1.ClickCancelButton();
            Assert.That(JavaScriptAlerts1.Result().Contains("You clicked: Cancel"));
        }

        [Test, Order(3)]
        public void ClickForJSPrompt()
        {
            //JavaScriptAlerts1.StartBrowser();
            JavaScriptAlerts1.ClickOnButtons(2);
            JavaScriptAlerts1.WriteOnPopUpWindow("Accepted");
            JavaScriptAlerts1.ClickOKButton();
            Assert.That(JavaScriptAlerts1.Result().Contains("You entered: Accepted"));

            // Clicking cancel button for JS Prompt

            JavaScriptAlerts1.ClickOnButtons(2);
            JavaScriptAlerts1.ClickCancelButton();
            Assert.That(JavaScriptAlerts1.Result().Contains("You entered: null"));
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            JavaScriptAlerts1.CloseBrowser();
        }

    }

}

    

