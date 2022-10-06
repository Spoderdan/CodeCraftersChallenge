# CodeCraftersChallenge
The API exposes 2 endpoints:
- api/otp/generate/{id} - generates a one time password based on a user id and the current utc time, available for 30 seconds
- api/otp/verify/{otp} - returns a string indicating that the generated password is valid or not

It is deployed to https://code-crafters-challenge.herokuapp.com

Example of use:
- https://code-crafters-challenge.herokuapp.com/api/otp/generate/25 -> 497605
- https://code-crafters-challenge.herokuapp.com/api/otp/verify/497605 -> OTP is valid!
- https://code-crafters-challenge.herokuapp.com/api/otp/verify/123456 -> Invalid OTP!
