using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging.EventLog;
using WorkerService;
using CronExpressionDescriptor;
using Quartz;
using Quartz.Spi;
using Application.DependencyInjection;
using WorkerService.Helper;
using WorkerService.Jobs;
using WorkerService.QuartzConfiguration;
using Domain.Interfaces.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEnvironmentVariables(); //TODO: Make the json settings files

builder.Services.Configure<HostOptions>(options =>
{
    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.StopHost;
});

builder.Logging.ClearProviders();
builder.Logging.AddEventLog(new EventLogSettings
{ 
    LogName = EventViewerLogger<Program>.LOG_NAME,
    SourceName = EventViewerLogger<Program>.SOURCE_NAME
});

//create dependency injecton the api requests
builder.Services.AddAppBootstrapper(builder.Configuration);

builder.Services.AddQuartz(q =>
{
    var quartzSettings = builder.Configuration.GetSection(nameof(QuartzSettings)).Get<QuartzSettings>() ?? new QuartzSettings();
    using var tempProvider = builder.Services.BuildServiceProvider();
    var logger = tempProvider.GetRequiredService<IAppLogger<Program>>();

    var jsonPlaceholderIntegrationJob = new JobKey("JsonPlaceholderJob");

    q.UseJobFactory<ScopedJobFactory>();

    q.AddJob<JsonPlaceholderIntegrationJob>(opts => opts.WithIdentity(jsonPlaceholderIntegrationJob));

    if (Environment.UserInteractive)
    {
        q.AddTrigger(opts => opts
        .ForJob(jsonPlaceholderIntegrationJob)
        .WithIdentity($"{jsonPlaceholderIntegrationJob.Name}-trigger")
        .StartNow());

        logger.LogInfo("Started now...");
    }
    else
    {
        q.AddTrigger(opts => opts
        .ForJob(jsonPlaceholderIntegrationJob)
        .WithIdentity($"{jsonPlaceholderIntegrationJob.Name}-trigger")
        .StartNow()
        .WithCronSchedule(quartzSettings.JsonPlaceholderIntervalCron));

        var JsonPlaceholderCronDesc = ExpressionDescriptor.GetDescription(quartzSettings.JsonPlaceholderIntervalCron, new CronExpressionDescriptor.Options
        {
            Locale = "en",
            Use24HourTimeFormat = true
        });

        logger.LogInfo($"JsonPlaceholder Cron Schedule: {JsonPlaceholderCronDesc}");
    }
});

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "JsonPlaceholder.Integration";
});

builder.Services.AddSingleton<IJobFactory, ScopedJobFactory>();

builder.Services.AddTransient<JsonPlaceholderIntegrationJob>();

builder.Services.AddHostedService<Worker>();

builder.Services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();

var host = builder.Build();
host.Run();
