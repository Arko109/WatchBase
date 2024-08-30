using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WatchBase.Models;
using WatchBase.Services;
using WatchBase.Views;

namespace WatchBase.ViewModels;
public partial class FamiliesViewModel(WatchBaseService watchBaseService, INavigation navigation) : BaseViewModel<Brand>
{
    private Brand? _brand;

    public ObservableCollection<Family> Families { get; } = [];

    [ObservableProperty]
    private bool _isRefreshing;

    [RelayCommand]
    private async Task GoToWatches(Family family) => await navigation.PushAsync(new WatchesPage(new Tuple<Brand, Family>(_brand!, family)));

    public override async void OnNavigatedTo(Brand brand)
    {
        _brand = brand;

        IsRefreshing = true;
        var families = await watchBaseService.GetFamilies(brand);
        foreach (var family in families ?? [])
        {
            Families.Add(family);
        }
        IsRefreshing = false;
    }

    public override void OnNavigatedFrom() => Families.Clear();
}
