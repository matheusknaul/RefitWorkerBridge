using Application.Services.Refit;
using System.Diagnostics;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    _logger.LogInformation("Go to get post by id 1");
                    var sw = Stopwatch.StartNew();
                    var post = await JPlaceholderPostService.GetPostById(1);
                    sw.Stop();
                    _logger.LogInformation($"PostAAAA ID: {post.Id}, Title: {post.Title} elapsed time: {sw.ElapsedMilliseconds} ms");
                    var swc = Stopwatch.StartNew();
                    await ApiPostService.CreatePost(post);
                    swc.Stop();
                    _logger.LogInformation($"Post has been created in API and this process had during: {swc.ElapsedMilliseconds} ms");
                    Console.ReadLine();

                }

            }
        }
    }
}
