//------------------------------------------------------------------------------------
// <copyright file="CounterBasedOtpGeneratorTests.cs" company="Stephen Jennings">
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

    public class CounterBasedOtpGeneratorTests
    {
        [Test]
        public void GenerateOtp_returns_reference_values_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            this.TestAndAssert(key, 6, 0, "755224");
            this.TestAndAssert(key, 6, 1, "287082");
            this.TestAndAssert(key, 6, 2, "359152");
            this.TestAndAssert(key, 6, 3, "969429");
            this.TestAndAssert(key, 6, 4, "338314");
            this.TestAndAssert(key, 6, 5, "254676");
            this.TestAndAssert(key, 6, 6, "287922");
            this.TestAndAssert(key, 6, 7, "162583");
            this.TestAndAssert(key, 6, 8, "399871");
            this.TestAndAssert(key, 6, 9, "520489");
        }

        [Test]
        public void GenerateOtp_returns_reference_values_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            this.TestAndAssert(key, 6, 0, "755224");
            this.TestAndAssert(key, 6, 1, "287082");
            this.TestAndAssert(key, 6, 2, "359152");
            this.TestAndAssert(key, 6, 3, "969429");
            this.TestAndAssert(key, 6, 4, "338314");
            this.TestAndAssert(key, 6, 5, "254676");
            this.TestAndAssert(key, 6, 6, "287922");
            this.TestAndAssert(key, 6, 7, "162583");
            this.TestAndAssert(key, 6, 8, "399871");
            this.TestAndAssert(key, 6, 9, "520489");
        }

        [Test]
        public void GenerateOtp_test_with_Google_Authenticator_1()
        {
            var key = "DEADBEEF48656C6C6F21"; // Base-32: 32W3532IMVWGY3ZB

            this.TestAndAssert(key, 6, 1, "092093");
            this.TestAndAssert(key, 6, 11, "266262");
        }

        private void TestAndAssert(byte[] key, int digits, int counter, string expected)
        {
            var otp = new CounterBasedOtpGenerator(key, digits);
            var result = otp.GenerateOtp(counter);
            Assert.AreEqual(expected, result);
        }

        private void TestAndAssert(string key, int digits, int counter, string expected)
        {
            var otp = new CounterBasedOtpGenerator(key, digits);
            var result = otp.GenerateOtp(counter);
            Assert.AreEqual(expected, result);
        }
    }
}
