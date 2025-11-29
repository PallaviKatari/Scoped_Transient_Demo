using Scoped_Transient_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

// Register lifetimes
builder.Services.AddTransient<TransientGuidService>();
builder.Services.AddScoped<ScopedGuidService>();
builder.Services.AddSingleton<SingletonGuidService>();

var app = builder.Build();

// Show differences
app.MapGet("/guids", (
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
        transient_1 = transient1.Id,
        transient_2 = transient2.Id,

        scoped_1 = scoped1.Id,
        scoped_2 = scoped2.Id,

        singleton_1 = singleton1.Id,
        singleton_2 = singleton2.Id
    });
});

app.Run();