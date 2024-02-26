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
		Task DeleteFromBasket(int ProductId, string UserName);
		Task PlusCount(int ProductId, string UserName);
		Task MinusCount(int ProductId, string UserName);
		Task CloseBasket(string UserName);
	}
}
