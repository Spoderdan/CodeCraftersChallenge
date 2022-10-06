using Microsoft.AspNetCore.Mvc;
using OtpNet;

namespace CodeCraftersChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        [HttpGet("generate/{id:int}")]
        public string GenerateOtp(int id)
        {
            HttpContext.Session.SetString("secret", id.ToString());

            // default time step window of 30s
            var totp = new Totp(Base32Encoding.ToBytes(HttpContext.Session.GetString("secret")));
            var totpCode = totp.ComputeTotp(DateTime.UtcNow);

            return totpCode;
        }

        [HttpGet("verify/{otp}")]
        public string VerifyOtp(string otp)
        {
            var secret = HttpContext.Session.GetString("secret");

            if (secret is null)
                return "OTP is not yet generated!";

            var totp = new Totp(Base32Encoding.ToBytes(secret));

            return totp.VerifyTotp(otp, out _, VerificationWindow.RfcSpecifiedNetworkDelay)
                ? "OTP is valid."
                : "Invalid OTP!";
        }
    }
}