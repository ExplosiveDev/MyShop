using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime BirthDate { get; set; }
	}
}
