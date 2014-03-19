OATH.Net
====================

OATH.Net is a .NET library to perform OATH authentication.


## Requirements

* Microsoft .NET Framework 4.0


## Usage

Add to your project with "`Install-Package OATH.Net`".

    // Time-based OTP

    public bool CreateTOTPCode(User user)
    {
        string secretKey = user.SecretKey;
        int otpDigits = 8;

        Key key = new Key(secretKey);
        TimeBasedOtpGenerator otp = new TimeBasedOtpGenerator(key, otpDigits);
        return otp.GenerateOtp(DateTime.UtcNow);
    }

    public bool AuthorizedWithTOTP(string userSuppliedCode, User user)
    {
        string secretKey = user.SecretKey;
        int otpDigits = 8;

        Key key = new Key(secretKey);
        TimeBasedOtpGenerator otp = new TimeBasedOtpGenerator(key, otpDigits);
        return otp.ValidateOtp(userSuppliedCode, DateTime.UtcNow);
    }


    // Counter-based OTP

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


## Building ##

Visual Studio should build the project correctly with no effort.

A [Psake](https://github.com/psake/psake) build script is included for running
tests and creating NuGet packages. To use Psake:

1. Open Psake by importing `Psake.psm1` into a PowerShell session, or run
   `Psake.cmd` to create a session with Psake already imported.

2. Run `Invoke-psake build` to build the project.

3. Run `Invoke-psake test` to run all unit tests.


## Source Code

OATH.Net is on GitHub:

    https://github.com/jennings/OATH.Net


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
