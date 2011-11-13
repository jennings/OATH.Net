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
    using System.Text;

    /// <summary>
    ///     Represents a secret key used for the one-time password generation.
    /// </summary>
    public class Key
    {
        private byte[] keyData;

        /// <summary>
        ///     Initializes a new instance of the Key class and generates a random 10-byte key.
        /// </summary>
        public Key()
            : this(10, (new Random()).Next())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the Key class and generates a random key with the specified seed.
        /// </summary>
        /// <param name="keyLength">Length in bytes of the generated key.</param>
        /// <param name="seed">A seed to use for the random key generation.</param>
        public Key(int keyLength, int seed)
        {
            this.keyData = new byte[keyLength];
            var gen = new Random(seed);
            gen.NextBytes(this.keyData);
        }

        /// <summary>
        ///     Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="data">The key to initialize.</param>
        public Key(byte[] data)
        {
            this.keyData = data;
        }

        /// <summary>
        ///     Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="base32key">The key to initialize.</param>
        /// <exception cref="ArgumentException">base32key is not a valid base32-encoded string.</exception>
        public Key(string base32key)
        {
            this.keyData = OathNet.Base32.ToBinary(base32key);
        }

        /// <summary>
        ///     Gets the key represented as a byte array.
        /// </summary>
        public virtual byte[] Binary
        {
            get
            {
                return this.keyData;
            }
        }

        /// <summary>
        ///     Gets the key represented as base32-encoded string.
        /// </summary>
        public virtual string Base32
        {
            get
            {
                return OathNet.Base32.ToBase32(this.keyData);
            }
        }
    }
}
