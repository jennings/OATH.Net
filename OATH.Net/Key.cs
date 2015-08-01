//------------------------------------------------------------------------------------
// <copyright file="Key.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    ///     Represents a secret key used for the one-time password generation.
    /// </summary>
    public sealed class Key
    {
        /// <summary>
        ///     Initializes a new instance of the Key class and generates a random 20-byte key.
        /// </summary>
        public Key()
            : this(20)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the Key class and generates a random key with the specified seed.
        /// </summary>
        /// <param name="keyLength">Length in bytes of the generated key.</param>
        public Key(int keyLength)
        {
            this.Binary = new byte[keyLength];
            var gen = new RNGCryptoServiceProvider();
            gen.GetBytes(this.Binary);
        }

        /// <summary>
        ///     Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="keyData">The key to initialize.</param>
        public Key(byte[] keyData)
        {
            this.Binary = keyData;
        }

        /// <summary>
        ///     Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="base32key">The key to initialize.</param>
        /// <exception cref="ArgumentException">base32key is not a valid base32-encoded string.</exception>
        public Key(string base32key)
        {
            this.Binary = OathNet.Base32.ToBinary(base32key);
        }

        /// <summary>
        ///     Gets the key represented as a byte array.
        /// </summary>
        public byte[] Binary { get; private set; }

        /// <summary>
        ///     Gets the key represented as base32-encoded string.
        /// </summary>
        public string Base32
        {
            get
            {
                return OathNet.Base32.ToBase32(this.Binary);
            }
        }
    }
}
