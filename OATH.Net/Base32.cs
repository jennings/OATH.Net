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
        private static readonly char[] Alphabet = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
            '6', '7'
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
        /// <exception cref="ArgumentException">The argument is not a valid base32-encoded string.</exception>
        public static byte[] ToBinary(string base32)
        {
            base32 = base32.ToUpper();

            if (base32.Any(c => !Alphabet.Contains(c) && c != Padding))
            {
                throw new ArgumentException("String contains invalid characters.");
            }

            var fullSegments = base32.Length / 8;
            var finalSegmentLength = base32.Length % 8;
            var segments = fullSegments + (finalSegmentLength == 0 ? 0 : 1);

            IEnumerable<byte> result = new byte[0];

            for (int i = 0; i < segments; i++)
            {
                var segment = base32.Skip(i * 8).Take(8).ToArray();
                var slice = Base32.ConvertSegmentToBinary(segment);
                result = result.Concat(slice);
            }

            return result.ToArray();
        }

        private static byte[] ConvertSegmentToBinary(char[] segment)
        {
            if (segment.Length > 8)
            {
                throw new ArgumentException("Segment must be no more than 8 characters in length.");
            }

            byte[] result = new byte[5];
            var s = segment;

            // Find the length of the segment, up to the first padding
            // If no padding is found, use the entire segment
            var length = Array.FindIndex(segment, c => c == Padding);
            if (length == -1)
            {
                length = segment.Length;
            }

            var resized = false;

            switch (length)
            {
                case 8:
                    resized = true;
                    result[4] = (byte)(Array.IndexOf(Alphabet, s[6]) << 5 | Array.IndexOf(Alphabet, s[7]));
                    goto case 7;
                case 7:
                    if (!resized)
                    {
                        Array.Resize(ref result, 4);
                        resized = true;
                    }

                    result[3] = (byte)(Array.IndexOf(Alphabet, s[4]) << 7 | Array.IndexOf(Alphabet, s[5]) << 2 | Array.IndexOf(Alphabet, s[6]) >> 3);
                    goto case 5;
                case 5:
                    if (!resized)
                    {
                        Array.Resize(ref result, 3);
                        resized = true;
                    }

                    result[2] = (byte)(Array.IndexOf(Alphabet, s[3]) << 4 | Array.IndexOf(Alphabet, s[4]) >> 1);
                    goto case 4;
                case 4:
                    if (!resized)
                    {
                        Array.Resize(ref result, 2);
                        resized = true;
                    }

                    result[1] = (byte)(Array.IndexOf(Alphabet, s[1]) << 6 | Array.IndexOf(Alphabet, s[2]) << 1 | Array.IndexOf(Alphabet, s[3]) >> 4);
                    goto case 2;
                case 2:
                    if (!resized)
                    {
                        Array.Resize(ref result, 1);
                        resized = true;
                    }

                    result[0] = (byte)(Array.IndexOf(Alphabet, s[0]) << 3 | Array.IndexOf(Alphabet, s[1]) >> 2);
                    break;
                default:
                    throw new ArgumentException("Segment is not a valid 8 character block of base32.");
            }

            return result;
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
