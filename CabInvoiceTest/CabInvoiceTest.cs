// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceTest
{
    using CabInvoiceProblem;
    using NUnit.Framework;

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
            double fare = invoiceGenerator.CalculateFare(2, 5, false);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double fare = invoiceGenerator.CalculateFare(0.1, 1, false);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Test case for normal ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            double fare = invoiceGenerator.GiveFare(rides, false);
            Assert.AreEqual(30, fare);
        }

        /// <summary>
        /// Test case for normal ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoiceNormalRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides, false);
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
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId, false);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Test case for permium ride calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double fare = invoiceGenerator.CalculateFare(2, 5, true);
            Assert.AreEqual(40, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate minimum fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMinimumDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double fare = invoiceGenerator.CalculateFare(0.1, 1, true);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// Test case for premium ride calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            double fare = invoiceGenerator.GiveFare(rides, true);
            Assert.AreEqual(60, fare);
        }

        /// <summary>
        /// Test case for premium ride give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoicePremiumRide_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides, true);
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
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId, true);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}