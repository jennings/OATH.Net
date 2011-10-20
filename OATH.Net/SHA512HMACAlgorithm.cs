//------------------------------------------------------------------------------------
// <copyright file="SHA512HMACAlgorithm.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System.Security.Cryptography;

    /// <summary>
    ///     The SHA512 hashing algorithm.
    /// </summary>
    public class SHA512HMACAlgorithm : IHMACAlgorithm
    {
        /// <summary>
        ///     Computes a HMAC digest using the SHA512 algorithm.
        /// </summary>
        /// <param name="key">The key to use.</param>
        /// <param name="buffer">The data to hash.</param>
        /// <returns>The HMAC digest.</returns>
        public byte[] ComputeHash(byte[] key, byte[] buffer)
        {
            var hmac = new HMACSHA512(key);
            return hmac.ComputeHash(buffer);
        }
    }
}
