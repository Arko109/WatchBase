using WatchBase.Helper;
using WatchBase.Models;
using WatchBase.ViewModels;

namespace WatchBase.Views;

#if ANDROID
[XamlCompilation(XamlCompilationOptions.Skip)]
#endif
public partial class FamiliesPage : ContentPage
{
    public FamiliesPage(Brand brand)
    {
        Title = brand.Name;
        this.RegisterViewModel<FamiliesViewModel, Brand>(brand);
        InitializeComponent();
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            ((FamiliesViewModel)BindingContext).GoToWatchesCommand.Execute(e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
        }
    }
}