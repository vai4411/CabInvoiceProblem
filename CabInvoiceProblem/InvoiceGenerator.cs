// <copyright file="InvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    /// <summary>
    /// This class used for manage the invoice operations.
    /// </summary>
    public class InvoiceGenerator
    {
        private static readonly double CostPerKM = 10;
        private static readonly double CostPerMinute = 1;

        /// <summary>
        /// This method used for calculate fare.
        /// </summary>
        /// <param name="distance">Distance in double format.</param>
        /// <param name="time">Time in double format.</param>
        /// <returns>Total fare.</returns>
        public double CalculateFare(double distance, int time)
        {
            return (distance * CostPerKM) + (time * CostPerMinute);
        }
    }
}