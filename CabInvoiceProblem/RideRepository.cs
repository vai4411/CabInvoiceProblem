// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System.Collections.Generic;
    using System.Linq;

    public class RideRepository
    {
        private Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// This method used for add new rides.
        /// </summary>
        /// <param name="userId">String user id.</param>
        /// <param name="rides">Ride records.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            this.userRides.Add(userId, new List<Ride>(rides.ToList()));
        }

        /// <summary>
        /// This method used for display ride basis of user id.
        /// </summary>
        /// <param name="userId">String user id.</param>
        /// <returns>Ride record.</returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
