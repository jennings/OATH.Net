//------------------------------------------------------------------------------------
// <copyright file="SHA1HMACAlgorithm.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System.Security.Cryptography;

    /// <summary>
    ///     The SHA1 hashing algorithm.
    /// </summary>
    public class SHA1HMACAlgorithm : IHMACAlgorithm
    {
        /// <summary>
        ///     Computes a HMAC digest using the SHA1 algorithm.
        /// </summary>
        /// <param name="key">The key to use.</param>
        /// <param name="buffer">The data to hash.</param>
        /// <returns>The HMAC digest.</returns>
        public byte[] ComputeHash(byte[] key, byte[] buffer)
        {
            var hmac = new HMACSHA1(key);
            return hmac.ComputeHash(buffer);
        }
    }
}
