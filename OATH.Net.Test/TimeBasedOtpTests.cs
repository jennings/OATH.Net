//------------------------------------------------------------------------------------
// <copyright file="TimeBasedOtpTests.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using OathNet;

    public class TimeBasedOtpTests
    {
        [Test]
        public void ComputeOtp_returns_reference_results_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            this.TestAndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "94287082");
            this.TestAndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "07081804");
            this.TestAndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "14050471");
            this.TestAndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "89005924");
            this.TestAndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "69279037");
            this.TestAndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "65353130");
        }

        [Test]
        public void ComputeOtp_returns_reference_results_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            this.TestAndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "94287082");
            this.TestAndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "07081804");
            this.TestAndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "14050471");
            this.TestAndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "89005924");
            this.TestAndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "69279037");
            this.TestAndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "65353130");
        }


        [Test]
        public void ComputeOtp_test_with_Google_Authenticator_1()
        {
            var key = "48656C6C6F21DEADBEEF"; // Base-32: JBSWY3DPEHPK3PXP

            this.TestAndAssert(key, 6, new DateTime(2011, 10, 17, 7, 49, 45, DateTimeKind.Utc), "010374");
        }

        [Test]
        public void ComputeOtp_test_with_Google_Authenticator_2()
        {
            var key = "DEADBEEF48656C6C6F21"; // Base-32: 32W3532IMVWGY3ZB

            this.TestAndAssert(key, 6, new DateTime(2011, 10, 17, 7, 52, 0, DateTimeKind.Utc), "139594");
        }

        private void TestAndAssert(byte[] key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtp(key, digits);
            var result = otp.ComputeOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestAndAssert(string key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtp(key, digits);
            var result = otp.ComputeOtp(time);
            Assert.AreEqual(expected, result);
        }
    }
}
