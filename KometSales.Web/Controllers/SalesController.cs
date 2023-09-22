using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Exceptions;
using KometSales.Common.Utils;
using KometSales.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace KometSales.Web.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        private readonly IConfiguration _configuration;

        public SalesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Remove("Cart");

            var model = new SalesViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleModel saleModel)
        {
            try
            {
                var cartJson = HttpContext.Session.GetString("Cart");

                var cart = string.IsNullOrEmpty(cartJson) ? new List<SaleItem>() : JsonConvert.DeserializeObject<List<SaleItem>>(cartJson);

                if (cart == null || !cart.Any())
                {
                    return BadRequest("You must add products to cart");
                }

                cart.ForEach(item =>
                {
                    saleModel.SaleDetails.Add(new SaleDetailModel
                    {
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity
                    });
                });

                var url = $"{_configuration["ApiBaseUrl"]}sales";

                await HttpUtil.SendAsync<SaleModel, object>(HttpContext.Session.GetString("Token"), url, HttpMethod.Post, body: saleModel);

                HttpContext.Session.Remove("Cart");
                return Ok();
            }
            catch (AppException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized) 
                {
                    return Unauthorized("User not authorized");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> SearchProducts(string term)
        {
            try
            {
                var queryString = new Dictionary<string, string>() { { "filter", term } };
                var url = $"{_configuration["ApiBaseUrl"]}products/search";

                var products = await HttpUtil.SendAsync<object, List<ProductDto>>(HttpContext.Session.GetString("Token"), url, HttpMethod.Get, queryString: queryString);

                return Json(products);
            }
            catch (AppException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized("User not authorized");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> SearchCustomers(string term)
        {
            try
            {
                var queryString = new Dictionary<string, string>() { { "filter", term } };
                var url = $"{_configuration["ApiBaseUrl"]}customers/search";

                var customers = await HttpUtil.SendAsync<object, List<CustomerDto>>(HttpContext.Session.GetString("Token"), url, HttpMethod.Get, queryString: queryString);

                return Json(customers);
            }
            catch (AppException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized("User not authorized");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> GetProductDetails(Guid productId)
        {
            try
            {
                var url = $"{_configuration["ApiBaseUrl"]}products/{productId}";

                var product = await HttpUtil.SendAsync<object, ProductDto>(HttpContext.Session.GetString("Token"), url, HttpMethod.Get);

                return Json(product);
            }
            catch (AppException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized("User not authorized");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            try
            {
                var cartJson = HttpContext.Session.GetString("Cart");
                var cart = string.IsNullOrEmpty(cartJson) ? new List<SaleItem>() : JsonConvert.DeserializeObject<List<SaleItem>>(cartJson);

                var product = await HttpUtil.SendAsync<object, ProductDto>(HttpContext.Session.GetString("Token"), $"{_configuration["ApiBaseUrl"]}products/{productId}", HttpMethod.Get);

                if (product != null)
                {
                    var existingCartItem = cart.FirstOrDefault(item => item.Product.Id == productId);
                    if (existingCartItem != null)
                    {
                        existingCartItem.Quantity += quantity;
                    }
                    else
                    {
                        cart.Add(new SaleItem
                        {
                            Product = product,
                            Quantity = quantity,
                            Price = product.Price
                        });
                    }

                    HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
                    return Ok("Product added to the cart.");
                }
                else
                {
                    return NotFound("Product not found.");
                }
            }
            catch (AppException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized("User not authorized");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Cart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson) ? new List<SaleItem>() : JsonConvert.DeserializeObject<List<SaleItem>>(cartJson);
            var salesModel = new SalesViewModel { CartItems = cart };
            return PartialView("_Cart", salesModel);
        }
    }
}
