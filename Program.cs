using Scoped_Transient_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

// Register lifetimes
//AddTransient: A new instance is provided every time it is requested.
builder.Services.AddTransient<TransientGuidService>();
//AddScoped: A new instance is created once per client request (connection).
builder.Services.AddScoped<ScopedGuidService>();
//AddSingleton: A single instance is created and shared throughout the application's lifetime.
builder.Services.AddSingleton<SingletonGuidService>();

var app = builder.Build();

// Show differences
//app.MapGet("/specifying my route", (constructor injection) => "What do you want to return and in what format...Hello World! Visit /guids to see GUIDs generated based on service lifetimes.");
app.MapGet("/guids", (
    //For each service type, we request two instances to demonstrate their lifetimes.
    TransientGuidService transient1,
    TransientGuidService transient2,
    ScopedGuidService scoped1,
    ScopedGuidService scoped2,
    SingletonGuidService singleton1,
    SingletonGuidService singleton2
) =>
{
    return Results.Json(new
    {
        transient_1 = transient1.Id, // request 1
        transient_2 = transient2.Id, // request 2

        scoped_1 = scoped1.Id,
        scoped_2 = scoped2.Id,

        singleton_1 = singleton1.Id,
        singleton_2 = singleton2.Id
    });
});

app.Run();