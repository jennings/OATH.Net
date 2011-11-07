//------------------------------------------------------------------------------------
// <copyright file="Base32.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Contains methods to convert to and from base-32 according to RFC 3548.
    /// </summary>
    public static class Base32
    {
        private static readonly string[] Alphabet = new string[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z", "2", "3", "4", "5",
            "6", "7"
        };

        private static readonly char Padding = '=';

        /// <summary>
        ///     Converts a byte array to a base-32 representation.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <returns>A base-32 encoded string.</returns>
        public static string ToBase32(byte[] data)
        {
            string result = String.Empty;

            var fullSegments = data.Length / 5;
            var finalSegmentLength = data.Length % 5;
            var segments = fullSegments + (finalSegmentLength == 0 ? 0 : 1);

            for (int i = 0; i < segments; i++)
            {
                var segment = data.Skip(i * 5).Take(5).ToArray();
                result = String.Concat(result, Base32.ConvertSegmentToBase32(segment));
            }

            return result;
        }

        /// <summary>
        ///     Converts a base-32 encoded string to a byte array.
        /// </summary>
        /// <param name="base32">A base-32 encoded string.</param>
        /// <returns>The data represented by the base-32 string.</returns>
        public static byte[] ToBinary(string base32)
        {
            throw new NotImplementedException();
        }

        private static string ConvertSegmentToBase32(byte[] segment)
        {
            if (segment.Length == 0)
            {
                return String.Empty;
            }

            if (segment.Length > 5)
            {
                throw new ArgumentException("Segment must be five bytes or fewer.");
            }

            string result = String.Empty;

            int accumulator = 0;
            int bitsRemaining = 5;
            byte[] masks = new byte[] { 0x00, 0x01, 0x03, 0x07, 0x0F, 0x1F };

            foreach (var b in segment)
            {
                // Accumulate the bits remaining from the previous byte, if any
                int bottomBitsInThisByte = 8 - bitsRemaining;
                accumulator += (b >> bottomBitsInThisByte) & masks[Math.Min(bitsRemaining, 5)];

                // Add the accumulated character to the result string
                result = result + Alphabet[accumulator];

                if (bottomBitsInThisByte >= 5)
                {
                    bottomBitsInThisByte -= 5;

                    // Set the accumulator to the next 5 bits in this byte
                    accumulator = (b >> bottomBitsInThisByte) & masks[5];

                    // Add the accumulated character to the result string
                    result = result + Alphabet[accumulator];
                }

                // Decide how many more bits we need to accumulate from the next byte
                bitsRemaining = (5 - bottomBitsInThisByte) % 5;

                // Set the accumulator to the remaining bits in this byte
                accumulator = (b & masks[bottomBitsInThisByte]) << bitsRemaining;
            }

            if (bitsRemaining > 0)
            {
                // Capture the final accumulated value
                result = result + Alphabet[accumulator];
            }

            result = result.PadRight(8, Padding);

            return result;
        }
    }
}
