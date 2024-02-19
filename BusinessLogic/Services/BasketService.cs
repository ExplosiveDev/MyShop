using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
	public class BasketService : IBasketService
	{
		private readonly IRepository<Basket> _basketRepository;
		private readonly IRepository<Product> _productRepository;
		private readonly IMapper _mapper;
		public BasketService(IRepository<Basket> basketRepository, IRepository<Product> productRepository, IMapper mapper)
		{
			_basketRepository = basketRepository;
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public async Task AddInBasket(int ProductId, string UserName)
		{
			var basket = GetUserBasket(UserName).Result;
			if(basket.Products.Where(x => x.Id == ProductId).FirstOrDefault() != null) 
			{
                basket.Products.Add(await _productRepository.GetByID(ProductId));
                await _basketRepository.Update(basket);
            }

		}

		public async Task DeleteFromBasket(int BasketId)
		{
			await _basketRepository.Delete(BasketId);
		}

		public async Task<IEnumerable<BasketDTO>> GetBasket(string UserName)
		{
			var basket = await _basketRepository.Get(includeProperties: new[] { "Product" });
			return _mapper.Map<IEnumerable<BasketDTO>>(basket.Where(x => x.UserName == UserName));
		}
		private async Task<Basket> GetUserBasket(string UserName)
		{
            var baskets = await _basketRepository.Get(includeProperties: new[] { "Products" });
            var basket = baskets.FirstOrDefault(x => x.UserName == UserName);
            if (basket == null)
			{
				Basket NewBasket = new Basket();
				NewBasket.UserName = UserName;
				await _basketRepository.Insert(NewBasket);
				await GetUserBasket(UserName);
			}
			return basket;
		}
	}
}
