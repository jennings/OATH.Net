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
        public void GenerateOtp_without_hmac_returns_SHA1_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            this.TestSHA1AndAssert(key, 6, 0, this.GetOtpWithImplicitHMAC(key, 6, 0));
            this.TestSHA1AndAssert(key, 6, 1, this.GetOtpWithImplicitHMAC(key, 6, 1));
            this.TestSHA1AndAssert(key, 6, 2, this.GetOtpWithImplicitHMAC(key, 6, 2));
            this.TestSHA1AndAssert(key, 6, 3, this.GetOtpWithImplicitHMAC(key, 6, 3));
            this.TestSHA1AndAssert(key, 6, 4, this.GetOtpWithImplicitHMAC(key, 6, 4));
            this.TestSHA1AndAssert(key, 6, 5, this.GetOtpWithImplicitHMAC(key, 6, 5));
            this.TestSHA1AndAssert(key, 6, 6, this.GetOtpWithImplicitHMAC(key, 6, 6));
            this.TestSHA1AndAssert(key, 6, 7, this.GetOtpWithImplicitHMAC(key, 6, 7));
            this.TestSHA1AndAssert(key, 6, 8, this.GetOtpWithImplicitHMAC(key, 6, 8));
            this.TestSHA1AndAssert(key, 6, 9, this.GetOtpWithImplicitHMAC(key, 6, 9));
        }

        [Test]
        public void GenerateOtp_without_hmac_returns_SHA1_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            this.TestSHA1AndAssert(key, 6, 0, this.GetOtpWithImplicitHMAC(key, 6, 0));
            this.TestSHA1AndAssert(key, 6, 1, this.GetOtpWithImplicitHMAC(key, 6, 1));
            this.TestSHA1AndAssert(key, 6, 2, this.GetOtpWithImplicitHMAC(key, 6, 2));
            this.TestSHA1AndAssert(key, 6, 3, this.GetOtpWithImplicitHMAC(key, 6, 3));
            this.TestSHA1AndAssert(key, 6, 4, this.GetOtpWithImplicitHMAC(key, 6, 4));
            this.TestSHA1AndAssert(key, 6, 5, this.GetOtpWithImplicitHMAC(key, 6, 5));
            this.TestSHA1AndAssert(key, 6, 6, this.GetOtpWithImplicitHMAC(key, 6, 6));
            this.TestSHA1AndAssert(key, 6, 7, this.GetOtpWithImplicitHMAC(key, 6, 7));
            this.TestSHA1AndAssert(key, 6, 8, this.GetOtpWithImplicitHMAC(key, 6, 8));
            this.TestSHA1AndAssert(key, 6, 9, this.GetOtpWithImplicitHMAC(key, 6, 9));
        }

        [Test]
        public void GenerateOtp_returns_SHA1_reference_values_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            this.TestSHA1AndAssert(key, 6, 0, "755224");
            this.TestSHA1AndAssert(key, 6, 1, "287082");
            this.TestSHA1AndAssert(key, 6, 2, "359152");
            this.TestSHA1AndAssert(key, 6, 3, "969429");
            this.TestSHA1AndAssert(key, 6, 4, "338314");
            this.TestSHA1AndAssert(key, 6, 5, "254676");
            this.TestSHA1AndAssert(key, 6, 6, "287922");
            this.TestSHA1AndAssert(key, 6, 7, "162583");
            this.TestSHA1AndAssert(key, 6, 8, "399871");
            this.TestSHA1AndAssert(key, 6, 9, "520489");
        }

        [Test]
        public void GenerateOtp_returns_SHA1_reference_values_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            this.TestSHA1AndAssert(key, 6, 0, "755224");
            this.TestSHA1AndAssert(key, 6, 1, "287082");
            this.TestSHA1AndAssert(key, 6, 2, "359152");
            this.TestSHA1AndAssert(key, 6, 3, "969429");
            this.TestSHA1AndAssert(key, 6, 4, "338314");
            this.TestSHA1AndAssert(key, 6, 5, "254676");
            this.TestSHA1AndAssert(key, 6, 6, "287922");
            this.TestSHA1AndAssert(key, 6, 7, "162583");
            this.TestSHA1AndAssert(key, 6, 8, "399871");
            this.TestSHA1AndAssert(key, 6, 9, "520489");
        }

        [Test]
        public void GenerateOtp_test_with_Google_Authenticator_1()
        {
            var key = "DEADBEEF48656C6C6F21"; // Base-32: 32W3532IMVWGY3ZB

            this.TestSHA1AndAssert(key, 6, 1, "092093");
            this.TestSHA1AndAssert(key, 6, 11, "266262");
        }

        private string GetOtpWithImplicitHMAC(byte[] key, int digits, int counter)
        {
            var otp = new CounterBasedOtpGenerator(key, digits);
            return otp.GenerateOtp(counter);
        }

        private string GetOtpWithImplicitHMAC(string key, int digits, int counter)
        {
            var otp = new CounterBasedOtpGenerator(key, digits);
            return otp.GenerateOtp(counter);
        }

        private void TestSHA1AndAssert(byte[] key, int digits, int counter, string expected)
        {
            var otp = new CounterBasedOtpGenerator(key, digits, new SHA1HMACAlgorithm());
            var result = otp.GenerateOtp(counter);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA1AndAssert(string key, int digits, int counter, string expected)
        {
            var otp = new CounterBasedOtpGenerator(key, digits, new SHA1HMACAlgorithm());
            var result = otp.GenerateOtp(counter);
            Assert.AreEqual(expected, result);
        }
    }
}
