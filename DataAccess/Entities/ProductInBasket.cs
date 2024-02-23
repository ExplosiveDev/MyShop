using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class ProductInBasket
	{
		[Key]
		public int Id { get; set; }

		public int ProductId { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string? ImagePath { get; set; }
		public int CategoryId { get; set; }
		public int Count { get; set; }

		public int BasketCount { get; set; } = 1;
		public Basket Basket { get; set; }
        public int BasketId { get; set; }
    }
}
