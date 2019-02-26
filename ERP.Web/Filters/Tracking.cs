using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Models.Logging;

namespace ERP.Filters
{
    public class Tracking : IPageFilter
    {
        private readonly ILogger _logger;

        public Tracking(ILogger logger)
        {

            _logger = logger;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            _logger.LogDebug("Global OnPageHandlerSelectionAsync called.");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            _logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            Log log = new Log();
            log.ActionName = context.ActionDescriptor.PageTypeInfo.Name.ToString();
            log.UserName = context.HttpContext.User.Identity.Name;
            log.LogType = "Info";
            log.Message = "Global OnPageHandlerExecutionAsync called.";
            //log.
            var _svc = context.HttpContext.RequestServices.GetService(typeof(ICustomLogger)) as ICustomLogger;
            _svc.InfoLog(log);    
            //_svc.GetType
            //var service = host.
            _logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
            //_logger.Log()
            // _custom
            
        }
    }
}
