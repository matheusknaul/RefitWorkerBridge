using Quartz;

namespace WorkerService.Jobs
{
    public class JsonPlaceholderIntegrationJob : IJob
    {
        private readonly ILogger<JsonPlaceholderIntegrationJob> _logger;

        public JsonPlaceholderIntegrationJob(ILogger<JsonPlaceholderIntegrationJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        //public Task Execute(IJobExecutionContext context)
        //{
        //    _logger.LogInformation("JsonPlaceholderIntegrationJob is executing at: {time}", DateTimeOffset.Now);

        //}
    }
}
