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
        /// <summary>
        /// This is ride repository object.
        /// </summary>
        private RideRepository rideRepository;

        /// <summary>
        /// User id regex pattern.
        /// </summary>
        private Regex regex = new Regex("[a-z]{1,}[a-z0-9]{0,}@[a-z]{1,}.[a-z]{3,}");

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService"/> class.
        /// </summary>
        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// This method used for get total invoice summary.
        /// </summary>
        /// <param name="rides">Ride records.</param>
        /// <param name="category">Ride category.</param>
        /// <returns>Total invoice summary.</returns>
        public InvoiceSummary CalculateFare(Ride[] rides, RideCategory category)
        {
            return new InvoiceSummary(rides.Length, this.TotalFare(rides, category));
        }

        /// <summary>
        /// This method used for calculate fare.
        /// </summary>
        /// <param name="ride">Ride information.</param>
        /// <param name="category">Category Enum.</param>
        /// <returns>Total fare.</returns>
        public double CalculateFare(Ride ride, RideCategory category)
        {
            return GetFareOfRide(ride, category);
        }

        /// <summary>
        /// This method used for calculate fare of multiple rides.
        /// </summary>
        /// <param name="rides">Multiple rides.</param>
        /// <param name="category">Ride category.</param>
        /// <returns>Total fare.</returns>
        public double TotalFare(Ride[] rides, RideCategory category)
        {
            double totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += this.CalculateFare(ride, category);
            }

            return totalFare;
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
                throw new CabInvoiceException("Please enter proper user id", CabInvoiceException.ExceptionType.INVALID_USER_NAME);
            }
        }

        /// <summary>
        /// This method used for get invoice summary basis of user id.
        /// </summary>
        /// <param name="userId">String user id.</param>
        /// <param name="category">Ride category.</param>
        /// <returns>Invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId, RideCategory category)
        {
            return this.CalculateFare(this.rideRepository.GetRides(userId), category);
        }
    }
}