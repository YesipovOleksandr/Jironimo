using System;
using Jironimo.BLL.Services;
using Jironimo.Common.Abstract;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Concrete;
using Jironimo.Common.Models.Email;
using Jironimo.DAL.Context;
using Jironimo.DAL.MappingProfile;
using Jironimo.DAL.Repository;
using Jironimo.Dependencies;
using Jironimo.Web.Helper;
using Jironimo.Web.MappingProfile;
using Jironimo.Web.Providers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Jironimo.DAL;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProdConnection"),
    opt => opt.MigrationsAssembly("Jironimo.DAL"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
        });

builder.Services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

builder.Services.AddAutoMapper(typeof(WebMappingProfile), typeof(DataAccessMapingProfile));
builder.Services.AddControllersWithViews();

builder.Services.RegisterDependencyModules();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IApplicationDetailsRepository, ApplicationDetailsRepository>();
builder.Services.AddScoped<IApplicationDetailsService, ApplicationDetailsService>();

builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();

builder.Services.AddScoped<IApplicationDeveloperRepository, ApplicationDeveloperRepository>();

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
app.UseAuthentication();

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

app.UseAuthentication();
app.UseAuthorization();

var routesConfigurator = app.Services.GetService<IRoutesConfigurator>();

app.UseEndpoints(routesConfigurator.BuildRoutesUsingTemplates);

app.MigrateDatabase();
app.Run();
