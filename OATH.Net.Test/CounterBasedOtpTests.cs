//------------------------------------------------------------------------------------
// <copyright file="CounterBasedOtpTests.cs" company="Stephen Jennings">
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

    public class CounterBasedOtpTests
    {
        [Test]
        public void Authorize_returns_same_result_as_reference_0_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 0;
            var expected = "755224";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_0_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 0;
            var expected = "755224";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_1_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 1;
            var expected = "287082";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_1_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 1;
            var expected = "287082";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_2_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 2;
            var expected = "359152";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_2_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 2;
            var expected = "359152";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_3_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 3;
            var expected = "969429";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_3_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 3;
            var expected = "969429";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_4_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 4;
            var expected = "338314";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_4_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 4;
            var expected = "338314";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_5_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 5;
            var expected = "254676";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_5_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 5;
            var expected = "254676";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_6_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 6;
            var expected = "287922";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_6_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 6;
            var expected = "287922";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_7_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 7;
            var expected = "162583";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_7_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 7;
            var expected = "162583";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_8_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 8;
            var expected = "399871";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_8_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 8;
            var expected = "399871";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_9_with_bytearray_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var seed = str.HexStringToByteArray();
            var count = 9;
            var expected = "520489";

            var result = this.TestWithByteArrayKey(seed, 6, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Authorize_returns_same_result_as_reference_9_with_string_key()
        {
            var str = "3132333435363738393031323334353637383930";
            var count = 9;
            var expected = "520489";

            var result = this.TestWithStringKey(str, 6, count);
            Assert.AreEqual(expected, result);
        }

        private string TestWithByteArrayKey(byte[] key, int digits, int counter)
        {
            var otp = new CounterBasedOtp(key, digits);
            return otp.ComputeOtp(counter);
        }

        private string TestWithStringKey(string key, int digits, int counter)
        {
            var otp = new CounterBasedOtp(key, digits);
            return otp.ComputeOtp(counter);
        }
    }
}
