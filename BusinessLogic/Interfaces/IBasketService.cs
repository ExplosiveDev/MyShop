using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IBasketService
	{
		Task<BasketDTO> GetBasket(string UserName);
		Task AddInBasket(int ProductId, string UserName);
		Task DeleteFromBasket(int BasketId);
	}
}
