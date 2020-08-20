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
        private InvoiceService invoiceGenerator;
        private InvoiceSummary summary;
        private InvoiceSummary expectedInvoiceSummary;
        private InvoiceSummary invoiceSummary;
        private string userId = "a@b.com";
        private string wrongUserId = "a@b";
        private double firstRideDistance = 2;
        private int firstRideTime = 5;
        private double secondRideDistance = 0.1;
        private int secondRideTime = 1;
        private Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1), };

        /// <summary>
        /// This method is used for set up the initialization method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceGenerator = new InvoiceService();
        }

        /// <summary>
        /// Test case for normal ride calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenDistanceAndTimePass_ThenReturnFare()
        {
            double fare = this.invoiceGenerator.CalculateFare(new Ride(this.firstRideDistance, this.firstRideTime), RideCategory.NORMAL);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            double fare = this.invoiceGenerator.CalculateFare(new Ride(this.secondRideDistance, this.secondRideTime), RideCategory.NORMAL);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            double fare = this.invoiceGenerator.GiveFare(this.rides, RideCategory.NORMAL);
            Assert.AreEqual(30, fare);
        }

        /// <summary>
        /// Test case for normal ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            this.summary = this.invoiceGenerator.CalculateFare(this.rides, RideCategory.NORMAL);
            this.invoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(this.invoiceSummary, this.summary);
        }

        /// <summary>
        /// Test case for normal ride given user id and rides give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenUserIdAndRidesPass_ThenReturnInvoiceSummary()
        {
            this.invoiceGenerator.AddRides(this.userId, this.rides);
            this.summary = this.invoiceGenerator.GetInvoiceSummary(this.userId, RideCategory.NORMAL);
            this.expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(this.expectedInvoiceSummary, this.summary);
        }

        /// <summary>
        /// Test case for premium ride calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenDistanceAndTimePass_ThenReturnFare()
        {
            double fare = this.invoiceGenerator.CalculateFare(new Ride(this.firstRideDistance, this.firstRideTime), RideCategory.PREMIUM);
            Assert.AreEqual(40, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            double fare = this.invoiceGenerator.CalculateFare(new Ride(this.secondRideDistance, this.secondRideTime), RideCategory.PREMIUM);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            double fare = this.invoiceGenerator.GiveFare(this.rides, RideCategory.PREMIUM);
            Assert.AreEqual(60, fare);
        }

        /// <summary>
        /// Test case for premium ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            this.summary = this.invoiceGenerator.CalculateFare(this.rides, RideCategory.PREMIUM);
            this.invoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(this.invoiceSummary, this.summary);
        }

        /// <summary>
        /// Test case for premium ride given user id and rides give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenUserIdAndRidesPass_ThenReturnInvoiceSummary()
        {
            this.invoiceGenerator.AddRides(this.userId, this.rides);
            this.summary = this.invoiceGenerator.GetInvoiceSummary(this.userId, RideCategory.PREMIUM);
            this.expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(this.expectedInvoiceSummary, this.summary);
        }

        /// <summary>
        /// Test case for normal ride given invalid user id throw exception.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenInvalidUserIdPass_ThenThrowException()
        {
            var result = Assert.Throws<CabInvoiceException>(() => this.invoiceGenerator.AddRides(this.wrongUserId, this.rides));
            Assert.AreEqual("Please enter proper user id", result.Message);
        }
    }
}