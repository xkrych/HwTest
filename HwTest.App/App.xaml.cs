using HwTest.App.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Windows;
using HwTest.BL.Extensions;

namespace HwTest.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost host;

    public App()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");

        host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(ConfigureAppConfiguration)
            .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
            .Build();
    }

    private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
    {
        // builder.AddJsonFile(@"appsettings.json", false, false);
    }

    private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddBLServices();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await host.StartAsync();

        var mainWindow = host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (host)
        {
            await host.StopAsync(TimeSpan.FromSeconds(5));
        }

        base.OnExit(e);
    }
}
