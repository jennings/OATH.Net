OATH.Net
====================

OATH.Net is a .NET library to perform OATH authentication.


## Requirements

* Microsoft .NET Framework 4.0


## Usage

    public bool AuthorizedWithHOTP(string userSuppliedCode, User user)
    {
        string secretKey = user.SecretKey;
        int otpDigits = 8;
        int counterValue = user.NextCounterValue();

        Key key = new Key(secretKey);
        CounterBasedOtpGenerator otp = new CounterBasedOtpGenerator(key, otpDigits);
        string validCode = otp.ComputeOtp(counterValue);

        return userSuppliedCode == validCode;
    }

    public bool AuthorizedWithTOTP(string userSuppliedCode, User user)
    {
        string secretKey = user.SecretKey;
        int otpDigits = 8;

        Key key = new Key(secretKey);
        TimeBasedOtpGenerator otp = new TimeBasedOtpGenerator(key, otpDigits);
        string validCode = otp.ComputeOtp(DateTime.UtcNow);

        return userSuppliedCode == validCode;
    }


## Source Code

OATH.Net is on GitHub:

    http://github.com/jennings/OATH.Net


## License

Copyright 2011 Stephen Jennings

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
