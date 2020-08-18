// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceTest
{
    using CabInvoiceProblem;
    using NUnit.Framework;
    using static CabInvoiceProblem.RideType;

    /// <summary>
    /// This class use as test class.
    /// </summary>
    public class CabInvoiceTest
    {
        /// <summary>
        /// This method is used for set up the initialization method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test case for normal ride calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double distance = 2;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time), RideCategory.NORMAL);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time), RideCategory.NORMAL);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            double fare = invoiceGenerator.GiveFare(rides, RideCategory.NORMAL);
            Assert.AreEqual(30, fare);
        }

        /// <summary>
        /// Test case for normal ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides, RideCategory.NORMAL);
            InvoiceSummary invoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(invoiceSummary, summary);
        }

        /// <summary>
        /// Test case for normal ride given user id and rides give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenUserIdAndRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceService = new InvoiceService();
            string userId = "a@b.com";
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId, RideCategory.NORMAL);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Test case for premium ride calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double distance = 2;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time), RideCategory.PREMIUM);
            Assert.AreEqual(40, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(new Ride(distance, time), RideCategory.PREMIUM);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            double fare = invoiceGenerator.GiveFare(rides, RideCategory.PREMIUM);
            Assert.AreEqual(60, fare);
        }

        /// <summary>
        /// Test case for premium ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides, RideCategory.PREMIUM);
            InvoiceSummary invoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(invoiceSummary, summary);
        }

        /// <summary>
        /// Test case for premium ride given user id and rides give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenUserIdAndRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceService = new InvoiceService();
            string userId = "a@b.com";
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId, RideCategory.PREMIUM);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Test case for normal ride given invalid user id throw exception.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenInvalidUserIdPass_ThenThrowException()
        {
            InvoiceService invoiceService = new InvoiceService();
            string userId = "a@b";
            double firstRideDistance = 2;
            int firstRideTime = 5;
            double secondRideDistance = 0.1;
            int secondRideTime = 1;
            Ride[] rides = { new Ride(firstRideDistance, firstRideTime), new Ride(secondRideDistance, secondRideTime), };
            var result = Assert.Throws<CabInvoiceException>(() => invoiceService.AddRides(userId, rides));
            Assert.AreEqual("Please enter proper user id", result.Message);
        }
    }
}