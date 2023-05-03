var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var isDevelopment = builder.Environment.IsDevelopment();

string environmentName = null;
#if DEBUG
environmentName = "Development";
#elif RELEASE
environmentName = "Development";
#elif TESTPUBLISH 
environmentName = "TestPublish";
#elif STAGINGPUBLISH 
environmentName = "StagingPublish";
#else
environmentName = "ProductionPublish";
#endif

builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
builder.Configuration.AddEnvironmentVariables();
// projectwide instances

//builder.Configuration.Get()"DefaultConnection");


// Add services to the container.
builder.Services.AddRazorPages();

 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
