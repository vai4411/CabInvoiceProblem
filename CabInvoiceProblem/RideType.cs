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
            double cost;
            switch (category)
            {
                case RideCategory.NORMAL:
                    cost = (ride.Distance * 10) + (ride.Time * 1);
                    return Math.Max(cost, 5);
                case RideCategory.PREMIUM:
                    cost = (ride.Distance * 15) + (ride.Time * 2);
                    return Math.Max(cost, 20);
                default:
                    return 0;
            }
        }
    }
}
