//------------------------------------------------------------------------------------
// <copyright file="CounterBasedOtpGenerator.cs" company="Stephen Jennings">
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
    /// <example>
    ///     <code>
    ///         CounterBasedOtp otp = new CounterBasedOtp("01234567", 6);
    ///         int counter = 5555;
    ///         string expectedCode = otp.ComputeOtp(counter);
    ///         bool validCode = userSuppliedCode == expectedCode;
    ///     </code>
    /// </example>
    public class CounterBasedOtpGenerator
    {
        private static int[] digits = new int[]
        { 
            1,        // 0
            10,       // 1
            100,      // 2
            1000,     // 3
            10000,    // 4
            100000,   // 5
            1000000,  // 6
            10000000, // 7
            100000000 // 8
        };

        private Key secretKey;

        private int otpLength;

        private IHMACAlgorithm hmacAlgorithm;

        /// <summary>
        ///     Initializes a new instance of the CounterBasedOtpGenerator class.
        ///     This is used when the client and server share a counter value.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="otpLength">The number of digits in the OTP to generate.</param>
        /// <param name="hmacAlgorithm">The hashing algorithm to use.</param>
        public CounterBasedOtpGenerator(Key secretKey, int otpLength, IHMACAlgorithm hmacAlgorithm)
        {
            this.secretKey = secretKey;
            this.otpLength = otpLength;
            this.hmacAlgorithm = hmacAlgorithm;
        }

        /// <summary>
        ///     Initializes a new instance of the CounterBasedOtpGenerator class.
        ///     This is used when the client and server share a counter value.
        /// </summary>
        /// <param name="secretKeyHex">The secret key represented as a sequence of hexadecimal digits.</param>
        /// <param name="otpLength">The number of digits in the OTP to generate.</param>
        public CounterBasedOtpGenerator(Key secretKey, int otpLength)
            : this(secretKey, otpLength, new SHA1HMACAlgorithm())
        {
        }

        /// <summary>
        ///     Generates the OTP for the given <paramref name="counter"/> value.
        ///     The client and server compute this independently and come up
        ///     with the same result, provided they use the same shared key.
        /// </summary>
        /// <param name="counter">The counter value to use.</param>
        /// <returns>The OTP for the given counter value.</returns>
        public virtual string GenerateOtp(int counter)
        {
            var text = new byte[8];
            var hex = counter.ToString("X16");
            text = hex.HexStringToByteArray();

            var hash = this.hmacAlgorithm.ComputeHash(this.secretKey.Binary, text);

            int offset = hash[hash.Length - 1] & 0xF;

            int binary = ((hash[offset] & 0x7F) << 24) |
                         ((hash[offset + 1] & 0xFF) << 16) |
                         ((hash[offset + 2] & 0xFF) << 8) |
                         (hash[offset + 3] & 0xFF);

            var otp = binary % CounterBasedOtpGenerator.digits[this.otpLength];

            var result = otp.ToString("D" + this.otpLength.ToString());

            return result;
        }
    }
}
