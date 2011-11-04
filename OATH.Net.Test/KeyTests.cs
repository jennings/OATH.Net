//------------------------------------------------------------------------------------
// <copyright file="KeyTests.cs" company="Stephen Jennings">
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

    public class KeyTests
    {
        [Test]
        public void Key_created_with_binary_returns_same_data_1()
        {
            var keyData = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };
            var key = new Key(keyData);

            Assert.AreEqual(keyData, key.Binary);
        }

        [Test]
        public void Key_created_with_binary_returns_same_data_2()
        {
            var keyData = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32
            };
            var key = new Key(keyData);

            Assert.AreEqual(keyData, key.Binary);
        }

        [Test]
        public void Key_created_with_binary_returns_correct_base32_1()
        {
            var keyData = new byte[]
            {
                0xDE, 0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };

            var key = new Key(keyData);
            var base32 = "32W3532IMVWGY3ZB";

            Assert.AreEqual(base32, key.Base32);
        }

        [Test]
        public void Key_created_with_binary_returns_correct_base32_2()
        {
            var keyData = new byte[]
            {
                0x48, 0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };

            var key = new Key(keyData);
            var base32 = "JBSWY3DPEHPK3PXP";

            Assert.AreEqual(base32, key.Base32);
        }

        [Test]
        public void Key_created_with_base32_returns_correct_base32_1()
        {
            var base32 = "32W3532IMVWGY3ZB";
            var key = new Key(base32);

            Assert.AreEqual(base32, key.Base32);
        }

        [Test]
        public void Key_created_with_base32_returns_correct_base32_2()
        {
            var base32 = "JBSWY3DPEHPK3PXP";
            var key = new Key(base32);

            Assert.AreEqual(base32, key.Base32);
        }

        [Test]
        public void Key_created_with_base32_returns_correct_binary_1()
        {
            var base32 = "32W3532IMVWGY3ZB";
            var key = new Key(base32);
            var binary = new byte[]
            {
                0xDE, 0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };

            Assert.AreEqual(binary, key.Binary);
        }

        [Test]
        public void Key_created_with_base32_returns_correct_binary_2()
        {
            var base32 = "JBSWY3DPEHPK3PXP";
            var key = new Key(base32);
            var binary = new byte[]
            {
                0x48, 0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };

            Assert.AreEqual(base32, key.Base32);
        }
    }
}
