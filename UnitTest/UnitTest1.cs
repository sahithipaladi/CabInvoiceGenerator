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
        /// <summary>
        /// Calculating total fare
        /// </summary>
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
        /// <summary>
        /// Calculating total are for multiple rides
        /// </summary>
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenDistanceAndTimeShouldReturnAggregateTotal()
        {
            ///AAA Methodology
            //Arrange
            Ride[] rides = { new Ride(12.0, 5), new Ride(3.5, 1) };
            //Act
            InvoiceSummary summary = invoice.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 161.0);
            var res = summary.Equals(expectedSummary);
            //Assert
            Assert.IsNotNull(res);
        }
    }
}

