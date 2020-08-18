// <copyright file="RideType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System;

    public class RideType
    {
        public enum RideCategory
        {
            PREMIUM,
            NORMAL,
        }

        public static double GetFare(Ride ride, RideCategory category)
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

        public static double GetFareByCategory(Ride ride, int distance, int time, int minCost)
        {
            return Math.Max((ride.Distance * distance) + (ride.Time * time), minCost);
        }
    }
}
