using Microsoft.Extensions.Logging;
using WatchBase.Services;
using WatchBase.ViewModels;
using WatchBase.Views;

namespace WatchBase;

public partial class App : Application
{
    public IServiceProvider Services { get; }
    public new static App Current => (App)Application.Current!;

    public App()
    {
        var services = new ServiceCollection();

        //Logging
        services.AddLogging(services => services.AddDebug());

        //HttpClient
        var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (_, _1, _2, _3) => true };
        services.AddSingleton(new HttpClient(handler));

        //Serices
        services.AddTransient<WatchBaseService>();

        //ViewModels
        services.AddTransient<BrandsViewModel>();
        services.AddTransient<FamiliesViewModel>();
        services.AddTransient<WatchesViewModel>();
        services.AddTransient<WatchDetailsViewModel>();

        //Navaigation
        var navigationPage = new NavigationPage();
        services.AddSingleton(navigationPage.Navigation);

        Services = services.BuildServiceProvider();

        InitializeComponent();

        MainPage = navigationPage;
        MainPage.Navigation.PushAsync(new BrandsPage());
    }
}
