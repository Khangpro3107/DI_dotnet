using Testing.Middlewares;
using Testing.Services;
using Testing.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<FirstMiddleware>();

builder.Services.AddTransient<ParentService1>();
builder.Services.AddTransient<ParentService2>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddSingleton<SingletonService>();

builder.Services.AddSingleton<IConsoleWriteService, ConsoleWriteService>();     // note the use of interface, compared to line 20
//builder.Services.AddSingleton<ConsoleWriteService>();

builder.Services.AddTransient<ConsoleWriteServiceChild>();      // this will be required by ConsoleWriteService

// line 26 creates dependency (dep) with constructor (ctor) parameters (params)
// note that the IConsoleWriteService is required -> have to use GetRequiredService to match the ctor params
builder.Services.AddTransient<ManualService>(sp => new ManualService(sp.GetRequiredService<IConsoleWriteService>(), " ManualServiceId"));       // "Manual" because it is created using 'new', compared to line 27
//builder.Services.AddTransient<ManualService>();

//builder.Services.AddTransient<ManualService2>();      // this is for demonstrating capturing deps using IEnumerable

var app = builder.Build();
//Console.WriteLine(app.Services.GetService<IConsoleWriteService>());       // this is how to retrieve a dep manually, note that it must be done after building (builder.Build()) the app (note the diff between builder.Services and app.Services)

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
    
app.UseMiddleware<FirstMiddleware>();       // this middleware 'uses' those deps

app.Use(async (context, next) =>            // a random middleware, for fun
{
    Console.WriteLine("Middleware function");
    await next();
});

app.MapControllerRoute("lifetime", "controller={Lifetime}/action={Get}");       // controller for demonstrating the diffs between scopes, lifetimes

app.Run();
