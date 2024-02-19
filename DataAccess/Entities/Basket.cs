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
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
