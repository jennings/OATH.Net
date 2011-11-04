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
        ///     Initializes a new instance of the Key class and generates a random key.
        /// </summary>
        public Key()
        {
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
        public Key(string base32key)
        {
            throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}
