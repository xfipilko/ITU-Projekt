// Authors: Team

namespace SSHDeck.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase? _currentPage;
}