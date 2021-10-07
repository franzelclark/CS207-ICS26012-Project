using System;
using System.Windows;
using OS.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using OS.Services;

namespace OS
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = ConfigureServices();
            var window = new MainWindow
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>()
            };
            window.Show();
        }

        private static IServiceProvider ConfigureServices() =>
            new ServiceCollection()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<AlgorithmService>()
                .BuildServiceProvider();
    }
}
