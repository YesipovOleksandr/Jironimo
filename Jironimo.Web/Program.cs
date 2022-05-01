using Jironimo.Common.Abstract;
using Jironimo.Dependencies;
using Jironimo.Web.Providers;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.RegisterDependencyModules();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var cultures = RouteDataRequestCultureProvider.GetCultures();
var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = cultures,
    SupportedUICultures = cultures,
};

options.RequestCultureProviders = new[]
{
      new RouteDataRequestCultureProvider { Options = options }
 };
app.UseRequestLocalization(options);

app.UseAuthorization();

var routesConfigurator = app.Services.GetService<IRoutesConfigurator>();

app.UseEndpoints(routesConfigurator.BuildRoutesUsingTemplates);

app.Run();
