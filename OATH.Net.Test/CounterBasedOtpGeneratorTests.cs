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
    using Moq;
    using OathNet;
    using Xunit;

    public class CounterBasedOtpGeneratorTests
    {
        [Fact]
        public void GenerateOtp_without_hmac_returns_SHA1_with_bytearray_key()
        {
            var keyData = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };
            var key = new Key(keyData);

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

        [Fact]
        public void GenerateOtp_returns_SHA1_reference_values_with_bytearray_key()
        {
            var keyData = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };
            var key = new Key(keyData);

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

        [Fact]
        public void GenerateOtp_test_with_Google_Authenticator_1()
        {
            var keyData = new byte[] // Base-32: 32W3532IMVWGY3ZB
            {
                0xDE, 0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var key = new Key(keyData);

            this.TestSHA1AndAssert(key, 6, 1, "092093");
            this.TestSHA1AndAssert(key, 6, 11, "266262");
        }

        private string GetOtpWithImplicitHMAC(Key key, int digits, int counter)
        {
            var otp = new CounterBasedOtpGenerator(key, digits);
            return otp.GenerateOtp(counter);
        }

        private void TestSHA1AndAssert(Key key, int digits, int counter, string expected)
        {
            var otp = new CounterBasedOtpGenerator(key, digits, new SHA1HMACAlgorithm());
            var result = otp.GenerateOtp(counter);
            Assert.Equal(expected, result);
        }
    }
}
