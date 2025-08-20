using Quartz;
using Quartz.Spi;

namespace WorkerService.Helper
{
    public class ScopedJobFactory : IJobFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedJobFactory(IServiceScopeFactory serviceScopeFactory)
        { 
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var job = (IJob)scope.ServiceProvider.GetRequiredService(bundle.JobDetail.JobType);

            return job;
        }

        public void ReturnJob(IJob job)
        {
            if (job is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
