using Domain.Interfaces.Worker;
using Quartz;

namespace WorkerService
{
    public sealed class DefaultScopedProcessingService(IAppLogger<DefaultScopedProcessingService> logger, ISchedulerFactory schedulerFactory, IHostEnvironment env) : IScopedProcessingService
    {
        private IScheduler? _scheduler;

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            try
            {

            }
            catch (TaskCanceledException ex)
            {
                logger.LogInfo("Scheduler execution was cancelled.");
                await Task.FromException(ex);
            }
            catch (Exception ex)
            {
                logger.LogError("Unexpected error starting scheduler. ", ex.GetBaseException());
                await Task.FromException(ex);
            }
        }
    }
}
