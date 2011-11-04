//------------------------------------------------------------------------------------
// <copyright file="TimeBasedOtpGenerator.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Implements the OATH HOTP algorithm.
    /// </summary>
    /// <remarks>
    ///     OATH TOTP is a derevation of the HOTP algorithm,
    ///     where the counter is derived from the time since
    ///     the UNIX epoch.
    /// </remarks>
    /// <example>
    ///     <code>
    ///         TimeBasedOtp otp = new TimeBasedOtp("01234567", 6);
    ///         string expectedCode = otp.ComputeOtp(DateTime.UtcNow);
    ///         bool validCode = userSuppliedCode == expectedCode;
    ///     </code>
    /// </example>
    public class TimeBasedOtpGenerator
    {
        private CounterBasedOtpGenerator counterOtp;

        /// <summary>
        ///     Initializes a new instance of the TimeBasedOtpGenerator class. This
        ///     is used when the client and server do not share a counter
        ///     value but the clocks between the two are synchronized within
        ///     reasonable margins of each other.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="otpLength">The number of digits in the OTP to generate.</param>
        /// <param name="hmacAlgorithm">The HMAC algorithm to use.</param>
        public TimeBasedOtpGenerator(Key secretKey, int otpLength, IHMACAlgorithm hmacAlgorithm)
        {
            this.counterOtp = new CounterBasedOtpGenerator(secretKey, otpLength, hmacAlgorithm);
        }

        /// <summary>
        ///     Initializes a new instance of the TimeBasedOtpGenerator class. This
        ///     is used when the client and server do not share a counter
        ///     value but the clocks between the two are synchronized within
        ///     reasonable margins of each other.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="otpLength">The number of digits in the OTP to generate.</param>
        public TimeBasedOtpGenerator(Key secretKey, int otpLength)
            : this(secretKey, otpLength, new SHA1HMACAlgorithm())
        {
        }

        /// <summary>
        ///     Generates the OTP for the given <paramref name="time"/> parameter.
        ///     The client and server compute this independently and come up
        ///     with the same result, provided they use the same shared key.
        /// </summary>
        /// <param name="time">The date and time for which to generate an OTP.</param>
        /// <returns>The OTP for the given secret key and DateTime.</returns>
        public string GenerateOtp(DateTime time)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var span = time.ToUniversalTime() - unixEpoch;
            var steps = (int)(span.TotalSeconds / 30);

            return this.counterOtp.GenerateOtp(steps);
        }
    }
}
