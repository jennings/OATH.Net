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

    public static class MiscExtensions
    {
        public static byte[] HexStringToByteArray(this string s)
        {
            return Enumerable.Range(0, s.Length - 1)
                             .Where(x => x % 2 == 0)
                             .Select(x => Byte.Parse(s.Substring(x, 2), NumberStyles.HexNumber))
                             .ToArray();
        }
    }
}
