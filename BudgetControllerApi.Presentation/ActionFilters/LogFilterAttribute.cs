using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.Entities.LogModels.Concrete;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BudgetControllerApi.Presentation.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _loggerService;

        public LogFilterAttribute(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _loggerService.LogInfo(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string modelName, Microsoft.AspNetCore.Routing.RouteData routeData)
        {
            var logDetail = new LogDetail
            {
                ModelName = modelName,
                Controller = routeData.Values["controller"],
                Action = routeData.Values["action"]
            };

            if(routeData.Values.Count > 3)
            {
                logDetail.Id = routeData.Values["Id"];
            }

            return logDetail.ToString();
        }
    }
}
