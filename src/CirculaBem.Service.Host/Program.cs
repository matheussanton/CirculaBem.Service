using CirculaBem.Service.Host;

var builder = WebApplication.CreateBuilder(args);

// // Configure Kestrel to use the configuration from appsettings.json
// builder.Configuration.AddJsonFile

// Configure Kestrel to use the configuration from appsettings.json
builder.WebHost.ConfigureKestrel(options =>
{
    options.Configure(builder.Configuration.GetSection("Kestrel"));
});


var startup = new Startup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.Run();
