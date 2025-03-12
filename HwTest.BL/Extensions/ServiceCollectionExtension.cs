using HwTest.BL.Interfaces;
using HwTest.BL.Models;
using HwTest.BL.Common;
using Microsoft.Extensions.DependencyInjection;
using HwTest.BL.Factories;

namespace HwTest.BL.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        services.AddSingleton<ITestEngine, TestEngine>();
        services.AddTransient<ITest, Test>();
        services.AddTransient<ITestStep, TestStep>();

        //services.AddAutoMapper(cfg =>
        //{ 

        //});

        return services;
    }

    public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
    where TService : class
    where TImplementation : class, TService
    {
        services.AddTransient<TService, TImplementation>();

        services.AddSingleton<Func<TService>>(x => x.GetRequiredService<TService>);

        services.AddSingleton<IFactory<TService>, Factory<TService>>();
    }
}
