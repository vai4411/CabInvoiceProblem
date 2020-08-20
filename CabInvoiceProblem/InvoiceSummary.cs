// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    /// <summary>
    /// This class used for store invoice summary.
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// This variable used for storing number of rides.
        /// </summary>
        private int numberOfRides;

        /// <summary>
        /// This variable used for storing total fare.
        /// </summary>
        private double totalFare;

        /// <summary>
        /// This variable used for storing average fare.
        /// </summary>
        private double avgFare;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Number of rides.</param>
        /// <param name="totalFare">Total fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.avgFare = this.totalFare / this.numberOfRides;
        }

        /// <summary>
        /// This method is used for obejct eqaulity.
        /// </summary>
        /// <param name="obj">Invoice Summary object.</param>
        /// <returns>Boolean result.</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            InvoiceSummary that = (InvoiceSummary)obj;
            return this.numberOfRides == that.numberOfRides &&
                    Equals(this.totalFare, that.totalFare) == true &&
                    Equals(this.avgFare, that.avgFare) == true;
        }
    }
}
