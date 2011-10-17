//------------------------------------------------------------------------------------
// <copyright file="TimeBasedOtp.cs" company="Stephen Jennings">
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

    public class TimeBasedOtp
    {
        private static int[] digits = new int[]
        { 
            1,        // 0
            10,       // 1
            100,      // 2
            1000,     // 3
            10000,    // 4
            100000,   // 5
            1000000,  // 6
            10000000, // 7
            100000000 // 8
        };

        private byte[] secretKey;

        private int otpLength;

        public TimeBasedOtp(byte[] secretKey, int otpLength)
        {
            this.secretKey = secretKey;
            this.otpLength = otpLength;
        }

        public TimeBasedOtp(string secretKeyHex, int otpLength)
        {
            this.secretKey = secretKeyHex.HexStringToByteArray();
            this.otpLength = otpLength;
        }

        public string ComputeOtp(DateTime time)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var span = time.ToUniversalTime() - unixEpoch;
            var steps = (int)(span.TotalSeconds / 30);
            var stepString = steps.ToString("X16");

            var counter = stepString.HexStringToByteArray();

            var hmac = new HMACSHA1(this.secretKey);
            var hash = hmac.ComputeHash(counter);

            int offset = hash[hash.Length - 1] & 0xF;

            int binary = ((hash[offset] & 0x7F) << 24) |
                         ((hash[offset + 1] & 0xFF) << 16) |
                         ((hash[offset + 2] & 0xFF) << 8) |
                         (hash[offset + 3] & 0xFF);

            var otp = binary % TimeBasedOtp.digits[this.otpLength];

            var result = otp.ToString("D" + this.otpLength.ToString());

            return result;
        }
    }
}
