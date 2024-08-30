using CommunityToolkit.Mvvm.ComponentModel;

namespace WatchBase.ViewModels;
public abstract class BaseViewModel : ObservableObject
{
    public virtual void OnNavigatedTo()
    {
    }
    public virtual void OnNavigatedFrom()
    {
    }
}

public abstract class BaseViewModel<T> : ObservableObject
{
    public virtual void OnNavigatedTo(T parameter)
    {
    }
    public virtual void OnNavigatedFrom()
    {
    }
}