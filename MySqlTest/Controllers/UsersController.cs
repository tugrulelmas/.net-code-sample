using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

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

		public async Task<IActionResult> Get() {
			userService.Add();
			await SendEmail();

			var result = dataContext.Users.ToList();
			return Ok(result);
		}

		private async Task SendEmail() {
			var form = new Dictionary<string, string>{
				{"from","Sanal Davetiye <mailgun@knowyourbarbas.com>"},
				{"to", "tugrulelmas@gmail.com"},
				{"subject", "Şifremi unuttum"},
				{"text", "Şifrenizi belirlemek için lütfen aşağıdaki linke tıklayınız."}

			};

			FormUrlEncodedContent urlEncodedContent = new FormUrlEncodedContent(form);

			using (var client = new HttpClient()) {
				client.BaseAddress = new Uri("https://api.mailgun.net/v3/");
				var key = Convert.ToBase64String(Encoding.UTF8.GetBytes("api:key-xxxxx"));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", key);

				HttpResponseMessage response = await client.PostAsync("mg.knowyourbarbas.com/messages", urlEncodedContent);

				if (!response.IsSuccessStatusCode) {
					var message = await response.Content.ReadAsStringAsync();
					throw new HttpRequestException(message);
				}
			}
		}
	}
}
