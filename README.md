﻿# CodeCraftersChallenge
The API exposes 2 endpoints:
- api/otp/generate/{id} - generates a one time password based on a user id and the current utc time, available for 30 seconds
- api/otp/verify/{otp} - returns a string indicating that the generated password is valid or not
