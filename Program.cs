using ProjetoMVC;
using ProjetoMVC.Classes;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load(builder);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHostedService<GetWikipedia> ();

//GetWikipedia getWikipedia = new GetWikipedia();
//await getWikipedia.GetDadosWikipedia();

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

