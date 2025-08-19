namespace WorkerService.Obsolete;


/// <summary>
/// Its a basic worker that have a little cicle of second by second that register the actual hour.
/// </summary>
/// <param name="logger"></param>
public class SimpleWorker(ILogger<SimpleWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }
}