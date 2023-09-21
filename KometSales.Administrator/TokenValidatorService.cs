using KometSales.Common.Entities.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KometSales.Administrator
{
    public class TokenValidatorService
    {
        private static bool isAdmin;

        public static bool IsAdmin
        {
            get { return isAdmin; }
            private set { isAdmin = value; }
        }

        public static bool TokenHasExpired()
        {
            DateTime tokenExpiration = GetTokenExpiration();
            return DateTime.UtcNow > tokenExpiration;
        }

        private static DateTime GetTokenExpiration()
        {
            var jwtToken = AppContext.AuthToken;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out _);
                if (principal != null)
                {
                    var expirationClaim = principal.FindFirst("exp");
                    var roleClaim = principal.FindFirst(ClaimTypes.Role);

                    isAdmin = roleClaim != null && roleClaim.Value == RoleEnum.Administrator.ToString();

                    if (expirationClaim != null && long.TryParse(expirationClaim.Value, out long unixTimestamp))
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).DateTime;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Token validation exception: " + ex.Message);
                return DateTime.MinValue;
            }

            return DateTime.MinValue;
        }

        public static void Logout(Form currentForm)
        {
            AppContext.AuthToken = null;

            currentForm.Close();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
