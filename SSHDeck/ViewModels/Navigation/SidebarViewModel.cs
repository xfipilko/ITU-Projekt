// Authors: Team
namespace SSHDeck.ViewModels.Navigation;

using System;
using CommunityToolkit.Mvvm.Input;
using SSHDeck.ViewModels.Modules.FileExplorer;
using SSHDeck.ViewModels.Modules.ProcessManager;
using SSHDeck.ViewModels.Modules.ServiceManager;

public partial class SidebarViewModel : ViewModelBase
{
    private readonly Action _navigateToProcesses;
    private readonly Action _navigateToServices;
    private readonly Action _navigateToFiles;

    public SidebarViewModel(
        Action navigateToProcesses,
        Action navigateToServices,
        Action navigateToFiles)
    {
        _navigateToProcesses = navigateToProcesses;
        _navigateToServices = navigateToServices;
        _navigateToFiles = navigateToFiles;
    }

    [RelayCommand]
    private void NavigateToProcesses() => _navigateToProcesses();

    [RelayCommand]
    private void NavigateToServices() => _navigateToServices();

    [RelayCommand]
    private void NavigateToFiles() => _navigateToFiles();
}