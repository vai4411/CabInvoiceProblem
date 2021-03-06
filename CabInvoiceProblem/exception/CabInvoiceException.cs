﻿// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceProblem
{
    using System;

    /// <summary>
    /// This class used to generate custom exception.
    /// </summary>
    public class CabInvoiceException : Exception
    {
        public ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="message">String exception message.</param>
        public CabInvoiceException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.exceptionType = exceptionType;
        }

        public enum ExceptionType
        {
            INVALID_USER_NAME,
        }
    }
}
