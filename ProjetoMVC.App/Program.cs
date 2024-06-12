using ProjetoMVC;
using ProjetoMVC.App.DIContainer;
using ProjetoMVC.App.Repository;
using ProjetoMVC.App.Services;
using ProjetoMVC.App.Workers;
using ProjetoMVC.Data.ModelsEF;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load(builder);

// Add services to the container.
builder
    .Services
        .AddBackgroundServices()
        .AddScopedServices()
        .AddTransientServices()
        .AddSingletonServices()
        .ConfigureControllers()
        .AddResponseCaching()
        .AddDatabaseContext()
        .AddRepositoryPattern();

var app = builder.Build();

app.UseExceptionHandler("/Equip/Error");

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseResponseCaching();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Equip}/{action=Home}/{id?}");

app.Run();

