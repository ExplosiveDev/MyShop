﻿using AutoMapper;
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
			if(basket.Products.Where(x => x.Id == ProductId).FirstOrDefault() == null) 
			{
                basket.Products.Add(await _productRepository.GetByID(ProductId));
                await _basketRepository.Update(basket);
            }

		}

		public async Task DeleteFromBasket(int BasketId)
		{
			await _basketRepository.Delete(BasketId);
		}

		public async Task<BasketDTO> GetBasket(string UserName)
		{
			Basket basket = GetUserBasket(UserName).Result;
			return _mapper.Map<BasketDTO>(basket);
		}
		private async Task<Basket> GetUserBasket(string UserName)
		{
            var baskets = await _basketRepository.Get(includeProperties: new[] { "Products" });
            Basket basket = baskets.FirstOrDefault(x => x.UserName == UserName);
            if (basket == null)
			{
				Basket NewBasket = new Basket();
				NewBasket.UserName = UserName;
				await _basketRepository.Insert(NewBasket);
				await GetUserBasket(UserName);
			}
			return basket;
		}
		public async Task MinusCount(int Id, string UserName)
		{
			Basket basket = GetUserBasket(UserName).Result;
			foreach (var item in basket.Products)
			{
				if(item.Id == Id)
				{
					if (item.BasketCount > 1)item.BasketCount--;
					await _productRepository.Update(item);
				}
			}
		}

		public async Task PlusCount(int Id, string UserName)
		{
			Basket basket = GetUserBasket(UserName).Result;
			foreach (var item in basket.Products)
			{
				if (item.Id == Id)
				{
					item.BasketCount++;
					await _productRepository.Update(item);
				}
			}
		}
	}
}
