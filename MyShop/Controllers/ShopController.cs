using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ShopController : Controller
    {
        SignInManager<User> _signInManager;
        private readonly IProductService _products;
        private readonly ICategoryService _category;
        private readonly IBasketService _basket;
		public ShopController(IProductService product, ICategoryService category, IBasketService basket)
        {
            _products = product;
            _category = category;
            _basket = basket;
        }
        [HttpGet]
        public async Task<IActionResult> ViewAllProducts()
        {
            ViewModelShopViewAllProducts data = new ViewModelShopViewAllProducts();
            data.Products = await _products.GetAll();
            data.Categories = await _category.GetAll();

            return View(data);
        }
        [HttpPost]
		public async Task<IActionResult> ViewAllProducts(FilterSettings filter)
		{
			ViewModelShopViewAllProducts data = new ViewModelShopViewAllProducts();
			data.Categories = await _category.GetAll();
			if (filter != null )
            {
                data.Products = _products.GetAll().Result.Where(x => x.CategoryName == filter.Category);
                if (filter.From < filter.To)
                {
                    var tmp = data.Products;
                    data.Products = tmp.Where(x => (x.Price >= filter.From) && (x.Price <= filter.To));
					return View(data);
				}
			}
			return View(data);
		}

        [HttpPost]
		public async Task<IActionResult> ViewInformationOfProduct(int ProductId)
        {
			var prod = await _products.GetById(ProductId);
			return View(prod);
        }
        public async Task<IActionResult> AddInBasket(int ProductId, string UserName)
        {
            await _basket.AddInBasket(ProductId, UserName);
            return RedirectToAction("ViewAllProducts");
		}
		public async Task<IActionResult> Basket()    
        {
            var UserName = HttpContext.User.Identity.Name;
            BasketDTO basket = _basket.GetBasket(UserName).Result;
            return View(basket);
        }


	}
}
