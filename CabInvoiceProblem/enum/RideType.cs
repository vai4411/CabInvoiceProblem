﻿// <copyright file="RideType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System;

    /// <summary>
    /// This class use to give enum and fare value.
    /// </summary>
    public class RideType
    {
        /// <summary>
        /// This enum used for ride category.
        /// </summary>
        public enum RideCategory
        {
            PREMIUM,
            NORMAL,
        }

        /// <summary>
        /// This method used for calculate total fare.
        /// </summary>
        /// <param name="ride">Ride object.</param>
        /// <param name="category">Enum category.</param>
        /// <returns>Total fare.</returns>
        public static double GetFareOfRide(Ride ride, RideCategory category)
        {
            switch (category)
            {
                case RideCategory.NORMAL:
                    return GetFareByCategory(ride, 10, 1, 5);
                case RideCategory.PREMIUM:
                    return GetFareByCategory(ride, 15, 2, 20);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// This method used for get fare by category.
        /// </summary>
        /// <param name="ride">Ride object.</param>
        /// <param name="costPerKM">Cost per distance.</param>
        /// <param name="costPerMinute">Cost per time.</param>
        /// <param name="minCost">Integer Minimum cost.</param>
        /// <returns>Total fare.</returns>
        public static double GetFareByCategory(Ride ride, int costPerKM, int costPerMinute, int minCost)
        {
            return Math.Max((ride.Distance * costPerKM) + (ride.Time * costPerMinute), minCost);
        }
    }
}
