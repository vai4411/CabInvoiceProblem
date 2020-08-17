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
        private readonly int numberOfRides;
        private readonly double totalFare;
        private readonly double avgFare;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.avgFare = this.totalFare / this.numberOfRides;
        }

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
                    Equals(that.totalFare, this.totalFare) == true &&
                    Equals(that.avgFare, this.avgFare) == true;
        }
    }
}
