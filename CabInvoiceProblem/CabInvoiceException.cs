// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System;

    public class CabInvoiceException : Exception
    {
        public CabInvoiceException(string message)
            : base(message)
        {
        }
    }
}
