using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
