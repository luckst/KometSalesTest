using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Exceptions;
using KometSales.Common.Utils;
using KometSales.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

namespace KometSales.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public AuthController(IConfiguration configuration, TokenService tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var token = await Authenticate(model.Username, model.Password);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var claimsPrincipal = _tokenService.ValidateToken(token);

                        if (claimsPrincipal == null)
                        {
                            ModelState.AddModelError(string.Empty, "Invalid credentials");
                        }

                        await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                        HttpContext.Session.SetString("Token", token);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid credentials");
                    }
                }
                catch (AppException)
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Auth error: " + ex.Message);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        private async Task<string> Authenticate(string username, string password)
        {
            var requestBody = new LoginModel
            {
                UserName = username,
                Password = password
            };

            var tokenResponse = await HttpUtil.SendAsync<LoginModel, TokenDto>("", $"{_configuration["ApiBaseUrl"]}auth/login", HttpMethod.Post, body: requestBody);

            return tokenResponse.Token;
        }
    }
}
