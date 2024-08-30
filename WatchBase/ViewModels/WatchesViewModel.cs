using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WatchBase.Models;
using WatchBase.Services;
using WatchBase.Views;

namespace WatchBase.ViewModels;

public partial class WatchesViewModel(WatchBaseService watchBaseService, INavigation navigation) : BaseViewModel<Tuple<Brand, Family>>
{
    public ObservableCollection<Watch> Watches { get; } = [];

    [ObservableProperty]
    private bool _isRefreshing;

    [RelayCommand]
    private async Task GoToWatchDetails(Watch watch) => await navigation.PushAsync(new WatchDetailsPage(watch));

    public override async void OnNavigatedTo(Tuple<Brand, Family> parameter)
    {
        IsRefreshing = true;
        var watches = await watchBaseService.GetWatches(parameter.Item1, parameter.Item2);
        foreach (var watch in watches ?? [])
        {
            Watches.Add(watch);
        }
        IsRefreshing = false;
    }

    public override void OnNavigatedFrom() => Watches.Clear();
}
