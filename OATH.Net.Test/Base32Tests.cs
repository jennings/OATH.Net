//------------------------------------------------------------------------------------
// <copyright file="Base32Tests.cs" company="Stephen Jennings">
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

    public class Base32Tests
    {
        [Test]
        public void ToBase32_10_bytes_1()
        {
            var binary = new byte[]
            {
                0xDE, 0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var expected = "32W3532IMVWGY3ZB";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_10_bytes_2()
        {
            var binary = new byte[]
            {
                0x48, 0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var expected = "JBSWY3DPEHPK3PXP";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_9_bytes_1()
        {
            var binary = new byte[]
            {
                      0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var expected = "VW7O6SDFNRWG6II=";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_9_bytes_2()
        {
            var binary = new byte[]
            {
                      0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var expected = "MVWGY3ZB32W353Y=";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_8_bytes_1()
        {
            var binary = new byte[]
            {
                            0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var expected = "X3XUQZLMNRXSC===";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_8_bytes_2()
        {
            var binary = new byte[]
            {
                            0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var expected = "NRWG6IO6VW7O6===";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_7_bytes_1()
        {
            var binary = new byte[]
            {
                                  0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var expected = "55EGK3DMN4QQ====";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_7_bytes_2()
        {
            var binary = new byte[]
            {
                                  0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var expected = "NRXSDXVNX3XQ====";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_6_bytes_1()
        {
            var binary = new byte[]
            {
                                        0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var expected = "JBSWY3DPEE======";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBase32_6_bytes_2()
        {
            var binary = new byte[]
            {
                                        0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var expected = "N4Q55LN654======";
            var actual = Base32.ToBase32(binary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_10_bytes_1()
        {
            var expected = new byte[]
            {
                0xDE, 0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var base32 = "32W3532IMVWGY3ZB";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_10_bytes_2()
        {
            var expected = new byte[]
            {
                0x48, 0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var base32 = "JBSWY3DPEHPK3PXP";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_9_bytes_1()
        {
            var expected = new byte[]
            {
                      0xAD, 0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var base32 = "VW7O6SDFNRWG6II=";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_9_bytes_2()
        {
            var expected = new byte[]
            {
                      0x65, 0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var base32 = "MVWGY3ZB32W353Y=";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_8_bytes_1()
        {
            var expected = new byte[]
            {
                            0xBE, 0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var base32 = "X3XUQZLMNRXSC===";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_8_bytes_2()
        {
            var expected = new byte[]
            {
                            0x6C, 0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var base32 = "NRWG6IO6VW7O6===";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_7_bytes_1()
        {
            var expected = new byte[]
            {
                                  0xEF, 0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var base32 = "55EGK3DMN4QQ====";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_7_bytes_2()
        {
            var expected = new byte[]
            {
                                  0x6C, 0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var base32 = "NRXSDXVNX3XQ====";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_6_bytes_1()
        {
            var expected = new byte[]
            {
                                        0x48,
                0x65, 0x6C, 0x6C, 0x6F, 0x21
            };
            var base32 = "JBSWY3DPEE======";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_6_bytes_2()
        {
            var expected = new byte[]
            {
                                        0x6F,
                0x21, 0xDE, 0xAD, 0xBE, 0xEF
            };
            var base32 = "N4Q55LN654======";
            var actual = Base32.ToBinary(base32);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_with_invalid_string_throws_ArgumentException()
        {
            var invalidChars = new List<string>()
            { 
                "1", "8", "9", "0",
                "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+",
                "[", "]", "{", "}", "|", "\\",
                ";", ":", "'", "\"",
                ",", ".", "<", ">", "/", "?"
            };

            foreach (var s in invalidChars)
            {
                Assert.Throws<ArgumentException>(() => new Key("ABCD" + s + "EFG"), "'" + s + "' is not part of the alphabet");
            }
        }
    }
}
