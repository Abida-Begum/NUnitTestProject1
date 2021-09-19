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
        
        public void StartBrowser()
        {
            driver.Navigate().GoToUrl(homeURL);
                       
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public void AddNewComputer()
        {
           
            driver.FindElement(By.Id("Add")).Click();
        }

        public void SetInput(string idName, string input)
        {
            driver.FindElement(By.Id(idName)).SendKeys(input);
           
           
        }

        public void SelectCompany(string value)
        {
            IWebElement company = driver.FindElement(By.Id("company"));
            SelectElement select = new SelectElement(company);
            select.SelectByText(value);
        }

        public void CreateComputer()
        {
            driver.FindElement(By.CssSelector(".actions .btn.primary")).Click();
        }

        public string AlertMessage()
        {
            var message =  driver.FindElement(By.CssSelector(".alert-message")).Text.ToString();
            return message;

        }

        public void ClickOnLink(string linkname)
        {
            driver.FindElement(By.LinkText(linkname)).Click();
        }

        public void SaveChanges()
        {
            driver.FindElement(By.CssSelector(".actions .btn.primary")).Click();
        }
        public void DeleteComputer()
        {
            driver.FindElement(By.CssSelector(".topRight")).Click();
        }

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

        public int CountTableRows()
        {
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            return rows.Count;
        
        }

        public void FilterComputer(string computerName)
        {
            driver.FindElement(By.Id("searchbox")).SendKeys(computerName);
            driver.FindElement(By.Id("searchsubmit")).Click();

        }

        public void ClickNextButton()
        {

            driver.FindElement(By.XPath("//*[@id='pagination']/ul/li[3]/a")).Click();
        }

        public void ClickPreviousButton()
        {
            driver.FindElement(By.XPath("//*[@id='pagination']/ul/li[1]/a")).Click();
        }

        public string DisplayingRows()
        {
            var diplayRows = driver.FindElement(By.CssSelector(".current")).Text.ToString();
            return diplayRows;

        }
    }
}
