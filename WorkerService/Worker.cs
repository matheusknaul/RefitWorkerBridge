using Application.Services.Refit;
using Domain.Interfaces.Worker;
using System.Diagnostics;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IAppLogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHostEnvironment _env;

        public Worker(IAppLogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInfo($"The service starts in: {DateTime.Now} - Environment: {_env.EnvironmentName}");
                while(!stoppingToken.IsCancellationRequested)
                {
                    using IServiceScope scope = _serviceScopeFactory.CreateScope();
                    var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();
                    await scopedProcessingService.DoWorkAsync(stoppingToken);
                    await Task.Delay(Timeout.Infinite, stoppingToken);
                }
            }
            catch (TaskCanceledException)
            {
                _logger.LogInfo("Service execution was cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error to start service", ex.GetBaseException());
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInfo("Stopping the service");
            await base.StopAsync(stoppingToken);
        }
    }
}
