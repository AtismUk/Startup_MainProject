using Startup_MainProject;
using Startup_MainProject.Services.Operation;
using Startup_MainProject.Services.Operation.IOperation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
ServicesConstant.ApiUrl = builder.Configuration["ServicesUrl:ApiProduct"];
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBaseServices, BaseServices>();
builder.Services.AddScoped<ICrudOperation, CrudOperation>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
