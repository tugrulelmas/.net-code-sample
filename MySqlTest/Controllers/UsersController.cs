using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MySqlTest
{
	[ServiceFilter(typeof(CustomActionFilter))]
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly DataContext dataContext;

		private readonly IUserService userService;

		public UsersController(DataContext dataContext, IUserService userService) {
			this.dataContext = dataContext;
			this.userService = userService;
		}

		public IActionResult Get() {
			userService.Add();

			var result = dataContext.Users.ToList();
			return Ok(result);
		}
	}
}
