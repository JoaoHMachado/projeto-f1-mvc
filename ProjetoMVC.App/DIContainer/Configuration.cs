using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.App.Repository;
using ProjetoMVC.App.Services;
using ProjetoMVC.App.Workers;
using ProjetoMVC.Data.ModelsEF;

namespace ProjetoMVC.App.DIContainer;

public static class Configuration
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        services.AddDbContext<Formula1Context>(e =>
        {
            e.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        

        return services;
    }
    public static IServiceCollection AddRepositoryPattern(this IServiceCollection services)
    {
        services.AddScoped<IRepository, EquipsRepository>(); 

        
        return services;
    }
    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Default", new CacheProfile
                {
                    Duration = 3600,
                });
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        
        return services;
    }
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IEquipServices, EquipServices>();
        return services;
    }
    
    
    public static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        
        
        return services;
    }
    
    public static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        
        return services;
    }
    
    public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        services.AddHostedService<WikipediaScrapper>();
        return services;
    }
}