using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WatchBase.Helper;
using WatchBase.Models;
using WatchBase.Services;
using WatchBase.Views;

namespace WatchBase.ViewModels;
public partial class BrandsViewModel(WatchBaseService watchBaseService, INavigation navigation) : BaseViewModel
{
    private readonly List<Brand> _brands = [];

    public ObservableCollection<Brand> FilteredBrands { get; } = [];

    [ObservableProperty]
    private string _searchText = "";
    [ObservableProperty]
    private bool _isRefreshing;

    [RelayCommand]
    private async Task GoToFamilies(Brand brand) => await navigation.PushAsync(new FamiliesPage(brand));

    public override async void OnNavigatedTo()
    {
        IsRefreshing = true;
        var brands = await watchBaseService.GetBrands();
        foreach (var brand in brands ?? [])
        {
            _brands.Add(brand);
        }
        FilterBrands();
        IsRefreshing = false;

        PropertyChanged += OnSearchTextChanged;
    }

    public override void OnNavigatedFrom()
    {
        PropertyChanged -= OnSearchTextChanged;
        _brands.Clear();
    }

    private void OnSearchTextChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SearchText))
        {
            FilterBrands();
        }
    }

    private void FilterBrands()
    {
        FilteredBrands.Clear();

        if (string.IsNullOrEmpty(SearchText))
        {
            FilteredBrands.AddRange(_brands);
            return;
        }

        FilteredBrands.AddRange(_brands.Where(brand => brand.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
    }
}
