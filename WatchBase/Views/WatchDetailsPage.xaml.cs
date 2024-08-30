using WatchBase.Helper;
using WatchBase.Models;
using WatchBase.ViewModels;

namespace WatchBase.Views;

#if ANDROID
[XamlCompilation(XamlCompilationOptions.Skip)]
#endif
public partial class WatchDetailsPage : ContentPage
{
    public WatchDetailsPage(Watch watch)
    {
        this.RegisterViewModel<WatchDetailsViewModel, Watch>(watch);
        InitializeComponent();
    }
}