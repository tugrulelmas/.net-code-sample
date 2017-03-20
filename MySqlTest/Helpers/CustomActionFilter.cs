using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MySqlTest
{
	public class CustomActionFilter : ActionFilterAttribute
	{
		private readonly IEnumerable<IDynamicHandler> dynamicHandlers;

		public CustomActionFilter(IEnumerable<IDynamicHandler> dynamicHandlers) {
			this.dynamicHandlers = dynamicHandlers;
		}

		public override void OnActionExecuting(ActionExecutingContext context) {
			foreach (var dynamicHandlerItem in dynamicHandlers) {
				dynamicHandlerItem.Execute(context);
			}

			base.OnActionExecuting(context);
		}

		public override void OnActionExecuted(ActionExecutedContext context) {
			base.OnActionExecuted(context);
		}
	}
}
