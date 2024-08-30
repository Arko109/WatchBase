using WatchBase.Helper;
using WatchBase.ViewModels;

namespace WatchBase.Views;

public partial class BrandsPage : ContentPage
{
    public BrandsPage()
    {
        this.RegisterViewModel<BrandsViewModel>();
        InitializeComponent();
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            ((BrandsViewModel)BindingContext).GoToFamiliesCommand.Execute(e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
        }
    }
}