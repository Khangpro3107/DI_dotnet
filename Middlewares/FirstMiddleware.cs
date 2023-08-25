using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Testing.Services;

namespace Testing.Middlewares
{
    public class FirstMiddleware : IMiddleware
    {
        private readonly IConsoleWriteService writeService;
        private readonly ConsoleWriteServiceChild writeServiceChild;
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly ManualService manualService;
        //private readonly ManualService2 manualService2;

        public FirstMiddleware(IConsoleWriteService cws, ILogger<FirstMiddleware> logger, IServiceProvider serviceProvider, ConsoleWriteServiceChild writeServiceChild, ManualService manualService)
        {
            this.writeService = cws;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.writeServiceChild = writeServiceChild;
            this.manualService = manualService;
            //this.manualService2 = manualService2;
        }

        public Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            writeService.Write("InvokeAsync");              // writing just to show that this middleware runs
            writeServiceChild.Write("Child InvokeAsync");
            this.logger.LogInformation("Logger");           // logger as a dep
            return next(httpContext);
        }
    }
}
