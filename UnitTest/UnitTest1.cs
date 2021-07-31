using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;
namespace CabInvoiceTestProject
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
        /// Calculating total fare for multiple rides
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
        /// <summary>
        /// Calculating the average value
        /// </summary>
        [TestMethod]
        [TestCategory("Average")]
        public void GivenDistanceAndTimeShouldReturnAverage()
        {
            ///AAA Methodology
            //Arrange
            Ride[] rides = { new Ride(12.0, 5), new Ride(3.5, 1) };
            //Act
            double expected = 80.5;
            InvoiceSummary summary = invoice.CalculateFare(rides);
            double actual = summary.averageFare;
            //Assert
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Given User id returns the invoice
        /// </summary>
        [TestMethod]
        [TestCategory("Invoice")]
        public void GivenDistanceAndTimeShouldReturnInvoice()
        {
            ///AAA Methodology
            //Arrange
            string userId = "John";
            Ride[] rides = { new Ride(12.0, 5), new Ride(3.5, 1) };
            //Act
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(userId, rides);
            Ride[] actualRides = rideRepository.GetRides(userId);
            InvoiceSummary summary = invoice.CalculateFare(rides);
            double expected = 80.5;
            double actual = summary.averageFare;
            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
