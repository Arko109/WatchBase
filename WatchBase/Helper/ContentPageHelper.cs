using WatchBase.ViewModels;

namespace WatchBase.Helper;
public static class ContentPageHelper
{
    public static void RegisterViewModel<TViewModel>(this ContentPage contentPage) where TViewModel : BaseViewModel
    {
        var vm = App.Current.Services.GetRequiredService<TViewModel>();
        contentPage.BindingContext = vm;

        void NavigatedToHandler(object? sender, EventArgs e) => vm.OnNavigatedTo();
        void NavigatedFromHandler(object? sender, EventArgs e) => vm.OnNavigatedFrom();

        contentPage.NavigatedTo += NavigatedToHandler;
        contentPage.NavigatedFrom += NavigatedFromHandler;
    }

    public static void RegisterViewModel<TViewModel, TParameter>(this ContentPage contentPage, TParameter parameter) where TViewModel : BaseViewModel<TParameter>
    {
        var vm = App.Current.Services.GetRequiredService<TViewModel>();
        contentPage.BindingContext = vm;

        void NavigatedToHandler(object? sender, EventArgs e) => vm.OnNavigatedTo(parameter);
        void NavigatedFromHandler(object? sender, EventArgs e) => vm.OnNavigatedFrom();

        contentPage.NavigatedTo += NavigatedToHandler;
        contentPage.NavigatedFrom += NavigatedFromHandler;
    }
}
