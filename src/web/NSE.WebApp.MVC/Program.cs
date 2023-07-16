using NSE.WebApp.MVC.Configuration;
using NSE.WebApp.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
//builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory());
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddIdentityConfiguration();
builder.Services.RegisterServices(builder.Configuration);

builder.Services.Configure<AppSettings>(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/erro/500");
app.UseStatusCodePagesWithRedirects("/erro/{0}");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityConfiguration();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogo}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
