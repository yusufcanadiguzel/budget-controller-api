using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BudgetControllerApi.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get controller
            var controller = context.RouteData.Values["controller"];

            // Get action
            var action = context.RouteData.Values["action"];

            // Get parameter with name contains dto
            var dto = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if (dto is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller} - Action: {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                return;
            }
        }
    }
}
