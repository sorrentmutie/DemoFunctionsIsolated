using DemoFunctionsIsolated.Library;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IClock, SystemClock>();
        services.AddScoped<IStudentsData, StudentsService>();
    })
    .Build();

host.Run();
