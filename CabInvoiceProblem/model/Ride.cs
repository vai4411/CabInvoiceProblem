// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    /// <summary>
    /// This is ride class used for create rides.
    /// </summary>
    public class Ride
    {
        public double Distance;
        public int Time;

    /// <summary>
    /// Initializes a new instance of the <see cref="Ride"/> class.
    /// </summary>
    /// <param name="distance">Distance in double.</param>
    /// <param name="time">Time in integer.</param>
        public Ride(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }
    }
}
