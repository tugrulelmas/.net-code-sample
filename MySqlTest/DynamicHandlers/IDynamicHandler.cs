using Microsoft.AspNetCore.Mvc.Filters;

namespace MySqlTest {
	public interface IDynamicHandler {
		void Execute(ActionExecutingContext context);
	}
}
