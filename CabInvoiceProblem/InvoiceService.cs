// <copyright file="InvoiceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System.Text.RegularExpressions;
    using static CabInvoiceProblem.RideType;

    /// <summary>
    /// This class used for manage the invoice operations.
    /// </summary>
    public class InvoiceService
    {
        private RideRepository rideRepository;
        private Regex regex = new Regex("[a-z]{1,}[a-z0-9]{0,}@[a-z]{1,}.[a-z]{3,}");

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// This method used for calculate fare.
        /// </summary>
        /// <param name="ride">Ride information.</param>
        /// <param name="category">Category Enum.</param>
        /// <returns>Total fare.</returns>
        public double CalculateFare(Ride ride, RideCategory category)
        {
            return GetFare(ride, category);
        }

        /// <summary>
        /// This method used for calculate fare of multiple rides.
        /// </summary>
        /// <param name="rides">Multiple rides.</param>
        /// <returns>Total fare.</returns>
        public double GiveFare(Ride[] rides, RideCategory category)
        {
            double totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += this.CalculateFare(ride, category);
            }

            return totalFare;
        }

        /// <summary>
        /// This method used for get total invoice summary.
        /// </summary>
        /// <param name="rides">Ride records.</param>
        /// <returns>Total invoice summary.</returns>
        public InvoiceSummary CalculateFare(Ride[] rides, RideCategory category)
        {
            return new InvoiceSummary(rides.Length, this.GiveFare(rides, category));
        }

        /// <summary>
        /// This method used for calculate fares.
        /// </summary>
        /// <param name="rides">Ride records.</param>
        /// <returns>Total fare.</returns>
        public double CalculateFares(Ride[] rides, RideCategory category)
        {
            return this.GiveFare(rides, category);
        }

        /// <summary>
        /// This method used for adding new ride.
        /// </summary>
        /// <param name="userId">String user name.</param>
        /// <param name="rides">Ride records.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            if (this.regex.IsMatch(userId))
            {
                this.rideRepository.AddRides(userId, rides);
            }
            else
            {
                throw new CabInvoiceException("Please enter proper user id");
            }
        }

        /// <summary>
        /// This method used for get invoice summary basis of user id.
        /// </summary>
        /// <param name="userId">String user id.</param>
        /// <returns>Invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId, RideCategory category)
        {
            return this.CalculateFare(this.rideRepository.GetRides(userId), category);
        }
    }
}