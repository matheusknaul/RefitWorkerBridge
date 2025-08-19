using WorkerService;

var builder = Host.CreateApplicationBuilder(args)//Create a HostApplicationBuilder.
    .ConfigureServices((HostBuilderContext, services)=>
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


