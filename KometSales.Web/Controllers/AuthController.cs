using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Exceptions;
using KometSales.Common.Utils;
using KometSales.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
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
