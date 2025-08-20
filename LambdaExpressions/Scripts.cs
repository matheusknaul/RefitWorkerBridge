using WorkerService;

var builder = Host.CreateApplicationBuilder(args)//Create a HostApplicationBuilder.
    .ConfigureServices((HostBuilderContext, services) =>
    {
        services.AddHostedService<Worker>();//Call AddHostedService to register Worker as an hosted service.
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole(); //Show logs in console
        logging.AddDebug(); //Optional: Send the "Debug" tab in Visual Studio
    });

var host = builder.Build(); //Create a IHost with a constructor.
host.Run(); //Invoke Run in host instance, that run the app.


using Application.Services.Refit;

namespace WorkerService;

/// <summary>
/// Its a basic worker that have a little cicle of second by second that register the actual hour.
/// </summary>
/// <param name="logger"></param>
public class Worker(ILogger<Worker> logger) : BackgroundService
{
    private
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var posts = await RefitPostService.GetAllPosts();
            Console.WriteLine($"Total Posts: {posts.Count}");
            foreach (var post in posts)
            {
                Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}");
            }
            await Task.Delay(1_000, stoppingToken);

        }
    }
}