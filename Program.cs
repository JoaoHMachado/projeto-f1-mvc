using ProjetoMVC;
using ProjetoMVC.Classes;
using ProjetoMVC.Repository;
using ProjetoMVC.Services;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load(builder);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHostedService<GetWikipedia>();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IEquipServices, EquipServices>();

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

