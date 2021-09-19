using NUnit.Framework;
using NUnitTestProject1.Methods;

namespace NUnitTestProject1.ComputerDBTests
{
    public class CrudTests
    {
 
        private ComputerDatabaseObjects ComputerDatabaseObjects1 = new ComputerDatabaseObjects();

        [Test, Order(1)]
        public void CreateRecord()
        {          

            ComputerDatabaseObjects1.StartBrowser();
            ComputerDatabaseObjects1.AddNewComputer();     
            ComputerDatabaseObjects1.SetInput("name", "Microsoft Pocket PC 2000");
            ComputerDatabaseObjects1.SetInput("introduced", "2020-09-17");
            ComputerDatabaseObjects1.SetInput("discontinued", "2021-01-20");
            ComputerDatabaseObjects1.SelectCompany("RCA");
            ComputerDatabaseObjects1.CreateComputer();
            var message = ComputerDatabaseObjects1.AlertMessage();
            Assert.That(message.Contains("created"));           

        }

        [Test, Order(2)]
        public void ReadAndWriteTableData()
        {
            ComputerDatabaseObjects1.ReadWriteTableRows();

        }

        [Test, Order(3)]
        public void UpdateRecord()
        {
            ComputerDatabaseObjects1.ClickOnLink("ACE");
            ComputerDatabaseObjects1.SetInput("introduced", "2020-09-17");
            ComputerDatabaseObjects1.SetInput("discontinued", "2021-01-20");
            ComputerDatabaseObjects1.SelectCompany("RCA");
            ComputerDatabaseObjects1.SaveChanges();
            var message = ComputerDatabaseObjects1.AlertMessage();
            Assert.That(message.Contains("updated"));

        }

        [Test, Order(4)]
        public void DeleteRecord()
        {
            ComputerDatabaseObjects1.ClickOnLink("ACE");
            ComputerDatabaseObjects1.DeleteComputer();
            var message = ComputerDatabaseObjects1.AlertMessage();
            Assert.That(message.Contains("deleted"));
        }

        [Test, Order(5)]

        public void NavigatingNextAndPreviousOnTable()
        {
            ComputerDatabaseObjects1.ClickNextButton();
            var displayNextRows = ComputerDatabaseObjects1.DisplayingRows();
            Assert.That(displayNextRows.Contains("Displaying 11 to 20 of 574"));
            ComputerDatabaseObjects1.ClickPreviousButton();
            var displayPreviousRows = ComputerDatabaseObjects1.DisplayingRows();
            Assert.That(displayPreviousRows.Contains("Displaying 1 to 10 of 574"));

        }

        [Test, Order(6)]
        public void FilterTest()
        {
            ComputerDatabaseObjects1.FilterComputer("ARRA");
            int numberOfRows = ComputerDatabaseObjects1.CountTableRows();
            Assert.AreEqual(2, numberOfRows);           
        }


        [OneTimeTearDown]
            public void OneTimeTearDown()
            {
               ComputerDatabaseObjects1.CloseBrowser();
            }
      }    
}
