using Microsoft.Extensions.Options;
using Startup_MainProject;
using Startup_MainProject.Services.Operation;
using Startup_MainProject.Services.Operation.IOperation;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
ServicesConstant.ApiUrl = builder.Configuration["ServicesUrl:ApiProduct"];
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBaseServices, BaseServices>();
builder.Services.AddScoped<ICrudOperation, CrudOperation>();

//Settings Jwt

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultScheme = "Cookies";
    Options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServicesUrl:IdentityApi"];

        options.ClientId = "sturtup";
        options.ClientSecret = "Rhfcy";
        options.ResponseType = "code";

        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("StartupApi");
        options.SaveTokens = true;
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
