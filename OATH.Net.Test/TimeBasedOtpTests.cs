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
        public void Authorize_returns_same_result_as_reference_1_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc);
            var expected = "94287082";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_1_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc);
            var expected = "94287082";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_2_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc);
            var expected = "07081804";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_2_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc);
            var expected = "07081804";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_3_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc);
            var expected = "14050471";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_3_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc);
            var expected = "14050471";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_4_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            var expected = "89005924";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_4_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            var expected = "89005924";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_5_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc);
            var expected = "69279037";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_5_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc);
            var expected = "69279037";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_6_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();

            var dateTime = new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc);
            var expected = "65353130";

            var result = this.TestWithByteArrayKey(seed, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_6_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";

            var dateTime = new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc);
            var expected = "65353130";

            var result = this.TestWithStringKey(str, 8, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ComputeOtp_test_with_Google_Authenticator_1()
        {
            var str = "48656C6C6F21DEADBEEF"; // Base-32: JBSWY3DPEHPK3PXP

            var dateTime = new DateTime(2011, 10, 17, 7, 49, 45, DateTimeKind.Utc);
            var expected = "010374";

            var result = this.TestWithStringKey(str, 6, dateTime);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ComputeOtp_test_with_Google_Authenticator_2()
        {
            var str = "DEADBEEF48656C6C6F21"; // Base-32: 32W3532IMVWGY3ZB

            var dateTime = new DateTime(2011, 10, 17, 7, 52, 0, DateTimeKind.Utc);
            var expected = "139594";

            var result = this.TestWithStringKey(str, 6, dateTime);
            Assert.AreEqual(expected, result);
        }

        private string TestWithByteArrayKey(byte[] key, int digits, DateTime dt)
        {
            var otp = new TimeBasedOtp(key, digits);
            return otp.ComputeOtp(dt);
        }

        private string TestWithStringKey(string key, int digits, DateTime dt)
        {
            var otp = new TimeBasedOtp(key, digits);
            return otp.ComputeOtp(dt);
        }
    }
}
