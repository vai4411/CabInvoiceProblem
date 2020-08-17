// <copyright file="InvoiceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    /// <summary>
    /// This class used for manage the invoice operations.
    /// </summary>
    public class InvoiceService
    {
        private static readonly double CostPerKM = 10;
        private static readonly double CostPerMinute = 1;
        private RideRepository rideRepository;

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

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

        /// <summary>
        /// This method used for calculate fare of multiple rides.
        /// </summary>
        /// <param name="rides">Multiple rides.</param>
        /// <returns>Total fare.</returns>
        public double GiveFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += this.CalculateFare(ride.Distance, ride.Time);
            }

            return totalFare;
        }

        /// <summary>
        /// This method used for get total invoice summary.
        /// </summary>
        /// <param name="rides">Ride records.</param>
        /// <returns>Total invoice summary.</returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            return new InvoiceSummary(rides.Length, this.GiveFare(rides));
        }

        /// <summary>
        /// This method used for calculate fares.
        /// </summary>
        /// <param name="rides">Ride records.</param>
        /// <returns>Total fare.</returns>
        public double CalculateFares(Ride[] rides)
        {
            return this.GiveFare(rides);
        }

        /// <summary>
        /// This method used for adding new ride.
        /// </summary>
        /// <param name="userId">String user name.</param>
        /// <param name="rides">Ride records.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            this.rideRepository.AddRides(userId, rides);
        }

        /// <summary>
        /// This method used for get invoice summary basis of user id.
        /// </summary>
        /// <param name="userId">String user id.</param>
        /// <returns>Invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(this.rideRepository.GetRides(userId));
        }
    }
}