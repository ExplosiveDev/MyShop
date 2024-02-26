using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public string City {  get; set; }
		public string Street {  get; set; }
		public string UserName {  get; set; }
        public decimal TotalSum { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
    }
}
