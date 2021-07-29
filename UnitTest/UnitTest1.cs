using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        InvoiceGenerator invoice;
        [TestInitialize]
        public void SetUp()
        {
            invoice = new InvoiceGenerator();
        }

        [TestMethod]
        [TestCategory("Total Fare")]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            ///AAA Methodology
            //Arrange
            double distance = 2.0;
            int time = 5;
            //Act
            double fare = invoice.CalculateFare(distance, time);
            double expected = 25;
            //Assert
            Assert.AreEqual(expected, fare);
        }
    }
}

