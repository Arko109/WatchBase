using CommunityToolkit.Mvvm.ComponentModel;
using WatchBase.Models;
using WatchBase.Services;

namespace WatchBase.ViewModels;
public partial class WatchDetailsViewModel(WatchBaseService watchBaseService) : BaseViewModel<Watch>
{
    [ObservableProperty]
    private WatchDetails? _watchDetails;

    public override async void OnNavigatedTo(Watch parameter)
    {
        var result = await watchBaseService.GetWatchDetails(parameter);
        if (result != null) WatchDetails = result;
    }
}
