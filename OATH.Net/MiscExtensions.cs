//------------------------------------------------------------------------------------
// <copyright file="MiscExtensions.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    ///     A collection of miscellaneous extension methods.
    /// </summary>
    public static class MiscExtensions
    {
        /// <summary>
        ///     Converts a hexadecimal string to a byte array.
        /// </summary>
        /// <param name="s">The hexadecimal string.</param>
        /// <returns>A byte array representing the given string.</returns>
        public static byte[] HexStringToByteArray(this string s)
        {
            if (s.Length % 2 == 1)
            {
                s = "0" + s;
            }

            return Enumerable.Range(0, s.Length - 1)
                             .Where(x => x % 2 == 0)
                             .Select(x => Byte.Parse(s.Substring(x, 2), NumberStyles.HexNumber))
                             .ToArray();
        }

        /// <summary>
        ///     Converts a byte array to a hexadecimal string.
        /// </summary>
        /// <param name="data">The byte array.</param>
        /// <returns>A hexadecimal string representing the given byte array.</returns>
        public static string ByteArrayToHexString(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", String.Empty);
        }
    }
}
