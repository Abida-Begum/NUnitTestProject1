using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1.Methods
{
    public class ComputerDatabaseObjects
    {
        public string homeURL = "http://computer-database.gatling.io/computers";
        private IWebDriver driver;

        public ComputerDatabaseObjects()
        {
            driver = new FirefoxDriver();
       
        }

        // Start the browser
        public void StartBrowser()
        {
            driver.Navigate().GoToUrl(homeURL);
                       
        }

        // Close the browser 
        public void CloseBrowser()
        {
            driver.Close();
        }

        // Click on Add computer button
        public void AddNewComputer()
        {
           
            driver.FindElement(By.Id("Add")).Click();
        }

        // Enter input for the fields on Add computer page
        public void SetInput(string idName, string input)
        {
            driver.FindElement(By.Id(idName)).SendKeys(input);
           
           
        }

        // Selecting a value from the dropdown
        public void SelectCompany(string value)
        {
            IWebElement company = driver.FindElement(By.Id("company"));
            SelectElement select = new SelectElement(company);
            select.SelectByText(value);
        }

        // Click on Create this computer button
        public void CreateComputer()
        {
            driver.FindElement(By.CssSelector(".actions .btn.primary")).Click();
        }

        // Checking the message displayed on top of the table
        public string AlertMessage()
        {
            var message =  driver.FindElement(By.CssSelector(".alert-message")).Text.ToString();
            return message;

        }

        // Clicking onn any computer link
        public void ClickOnLink(string linkname)
        {
            driver.FindElement(By.LinkText(linkname)).Click();
        }

        // Clicking on Save this computer button
        public void SaveChanges()
        {
            driver.FindElement(By.CssSelector(".actions .btn.primary")).Click();
        }

        // Clicking on Delete computer button
        public void DeleteComputer()
        {
            driver.FindElement(By.CssSelector(".topRight")).Click();
        }

        // Reading and writing the data from the table

        public void ReadWriteTableRows()
        {
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            var ths = table.FindElements(By.TagName("th"));

            foreach (var colheading in ths)
            {
                // To display column headings
                Console.WriteLine(colheading.Text);

            }

            foreach (var row in rows)
            {

                var tds = row.FindElements(By.TagName("td"));
                foreach (var entry in tds)
                {
                    //To display table data
                    Console.WriteLine(entry.Text);

                }

                Console.WriteLine("\n");
            }

        }

        // Counting the rows displayed in the table
        public int CountTableRows()
        {
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            return rows.Count;
        
        }

        // Entering value in the filter box
        public void FilterComputer(string computerName)
        {
            driver.FindElement(By.Id("searchbox")).SendKeys(computerName);
            driver.FindElement(By.Id("searchsubmit")).Click();

        }

        // Click on Next button
        public void ClickNextButton()
        {

            driver.FindElement(By.XPath("//*[@id='pagination']/ul/li[3]/a")).Click();
        }

        // Click on previous button
        public void ClickPreviousButton()
        {
            driver.FindElement(By.XPath("//*[@id='pagination']/ul/li[1]/a")).Click();
        }
        
        // Checking which page is displayed in the table
        public string DisplayingRows()
        {
            var diplayRows = driver.FindElement(By.CssSelector(".current")).Text.ToString();
            return diplayRows;

        }
    }
}
