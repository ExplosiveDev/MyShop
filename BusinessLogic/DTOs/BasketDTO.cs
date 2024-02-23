using DataAccess.Entities;

namespace BusinessLogic.DTOs
{
	public class BasketDTO
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public ICollection<ProductInBasket> Products { get; set; }
	}
}
