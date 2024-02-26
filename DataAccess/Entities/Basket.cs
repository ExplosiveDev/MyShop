using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<ProductInBasket> Products { get; set; } = new List<ProductInBasket>();
        public ICollection<Order> Order { get; set; }
    }
}
