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
        public void Authorize_returns_same_result_as_reference_1()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc);
            var expected = "94287082";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_2()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc);
            var expected = "07081804";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_3()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc);
            var expected = "14050471";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_4()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            var expected = "89005924";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_5()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc);
            var expected = "69279037";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_6()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var otp = new TimeBasedOtp(seed, 8);

            var dateTime = new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc);
            var expected = "65353130";

            var result = otp.ComputeOtp(dateTime);
            Assert.AreEqual(expected, result);
        }
    }
}
