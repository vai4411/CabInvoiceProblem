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
        /// Test case for calculate fare by distance and time.
        /// </summary>
        [Test]
        public void GivenCabInvoice_WhenDistanceAndTimePass_ThenReturnFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            double fare = invoiceGenerator.CalculateFare(2, 5);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Test case for calculate fare average for multiple rides.
        /// </summary>
        [Test]
        public void GivenCabInvoice_WhenMultipleRidesPass_ThenReturnTotalFare()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            double fare = invoiceGenerator.GiveFare(rides);
            Assert.AreEqual(27, fare);
        }

        /// <summary>
        /// Test case for give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoice_WhenMultipleRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceGenerator = new InvoiceService();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary invoiceSummary = new InvoiceSummary(2, 27.0);
            Assert.AreEqual(invoiceSummary, summary);
        }

        /// <summary>
        /// Test case for given user id and rides give invoice summary.
        /// </summary>
        [Test]
        public void GivenCabInvoice_WhenUserIdAndRidesPass_ThenReturnInvoiceSummary()
        {
            InvoiceService invoiceService = new InvoiceService();
            string userId = "a@b.com";
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 27.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}