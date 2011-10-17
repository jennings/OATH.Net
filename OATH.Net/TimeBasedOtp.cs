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
        private CounterBasedOtp counterOtp;

        public TimeBasedOtp(byte[] secretKey, int otpLength)
        {
            this.counterOtp = new CounterBasedOtp(secretKey, otpLength);
        }

        public TimeBasedOtp(string secretKeyHex, int otpLength)
        {
            this.counterOtp = new CounterBasedOtp(secretKeyHex, otpLength);
        }

        public string ComputeOtp(DateTime time)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var span = time.ToUniversalTime() - unixEpoch;
            var steps = (int)(span.TotalSeconds / 30);

            return this.counterOtp.ComputeOtp(steps);
        }
    }
}
