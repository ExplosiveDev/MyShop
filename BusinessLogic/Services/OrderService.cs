using AutoMapper;
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
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order> _orderRepository;
		private readonly IRepository<Basket> _basketRepository;
		private readonly IMapper _mapper;

		public OrderService(IRepository<Order> orderRepository, IMapper mapper, IRepository<Basket> basketRepository)
		{
			_orderRepository = orderRepository;
			_basketRepository = basketRepository;
			_mapper = mapper;
		}

		public async Task CreateOrder(string UserName, int BasketId)
		{
			var baskets = await _basketRepository.Get(includeProperties: new[] { "Products" });
			Basket basket = baskets.FirstOrDefault(x => x.UserName == UserName && x.Active == true);
			decimal sum = 0;
			Order order = new Order();
			order.UserName = UserName;
			order.BasketId = BasketId;
			order.Basket = basket;
			order.City = "NonCity";
			order.Street = "NonStreet";

			foreach (var item in basket.Products)
				sum += item.Price * item.BasketCount;

			order.TotalSum = sum;

			await _orderRepository.Insert(order);
		}
	}
}
