using WatchBase.Helper;
using WatchBase.Models;
using WatchBase.ViewModels;

namespace WatchBase.Views;

#if ANDROID
[XamlCompilation(XamlCompilationOptions.Skip)]
#endif
public partial class WatchesPage : ContentPage
{
    public WatchesPage(Tuple<Brand, Family> brandAndFamily)
    {
        Title = brandAndFamily.Item2.Name;
        this.RegisterViewModel<WatchesViewModel, Tuple<Brand, Family>>(brandAndFamily);
        InitializeComponent();
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            ((WatchesViewModel)BindingContext).GoToWatchDetailsCommand.Execute(e.CurrentSelection[0]);
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}