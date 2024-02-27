using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
		public int Count { get; set; }
		public int BasketCount { get; set; }
		public string? CategoryName { get; set; }
		public IEnumerable<Comments> Comments { get; set; }
	}
}
