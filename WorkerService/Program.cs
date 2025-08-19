using WorkerService;
using WorkerService.Obsolete;

var builder = Host.CreateApplicationBuilder(args); //Create a HostApplicationBuilder.
builder.Services.AddHostedService<SimpleWorker>(); //Call AddHostedService to register Worker as an hosted service.

var host = builder.Build(); //Create a IHost with a constructor.
host.Run(); //Invoke Run in host instance, that run the app.


