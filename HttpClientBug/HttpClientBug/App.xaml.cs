using HttpClientBug.Interfaces;
using HttpClientBug.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HttpClientBug
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            SetupServices();

            InitializeComponent();

            MainPage = new MainPage();
        }

        static void SetupServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddHttpClient()
                    .AddScoped<IHttpClientUsingService, HttpClientUsingService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
