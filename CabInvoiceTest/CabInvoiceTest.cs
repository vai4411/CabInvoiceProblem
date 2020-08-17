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
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double fare = invoiceGenerator.CalculateFare(2, 5);
            Assert.AreEqual(25, fare);
        }
    }
}