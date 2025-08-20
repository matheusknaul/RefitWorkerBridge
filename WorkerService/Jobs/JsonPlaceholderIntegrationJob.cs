using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Jobs
{
    public class JsonPlaceholderIntegrationJob
    {
        private readonly ILogger<JsonPlaceholderIntegrationJob> _logger;

        public JsonPlaceholderIntegrationJob(ILogger<JsonPlaceholderIntegrationJob> logger)
        {
            _logger = logger;
        }

        //public Task Execute(IJobExecutionContext context)
        //{
        //    _logger.LogInformation("JsonPlaceholderIntegrationJob is executing at: {time}", DateTimeOffset.Now);

        //}
    }
}
