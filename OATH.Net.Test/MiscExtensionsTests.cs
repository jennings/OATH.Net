//------------------------------------------------------------------------------------
// <copyright file="MiscExtensionsTests.cs" company="Stephen Jennings">
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

    public class MiscExtensionsTests
    {
        [Test]
        public void HexStringToByteArray_test_1()
        {
            var s = "01234567DEADBEEF";
            var result = s.HexStringToByteArray();
            var expected = new byte[] { 0x01, 0x23, 0x45, 0x67, 0xDE, 0xAD, 0xBE, 0xEF };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HexStringToByteArray_pads_upper_byte_1()
        {
            var s = "1234567DEADBEEF";
            var result = s.HexStringToByteArray();
            var expected = new byte[] { 0x01, 0x23, 0x45, 0x67, 0xDE, 0xAD, 0xBE, 0xEF };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ByteArrayToHexString_test_1()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0xDE, 0xAD, 0xBE, 0xEF };
            var result = data.ByteArrayToHexString();
            var expected = "01234567DEADBEEF";

            Assert.AreEqual(expected, result);
        }
    }
}
