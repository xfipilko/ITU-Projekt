// Authors: Team
namespace SSHDeck.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using SSHDeck.ViewModels.Navigation;
using SSHDeck.ViewModels.Modules.FileExplorer;
using SSHDeck.ViewModels.Modules.ProcessManager;
using SSHDeck.ViewModels.Modules.ServiceManager;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase? _currentPage;

    // Keep instances in memory
    public ProcessManagerViewModel ProcessManager { get; } = new();
    public ServiceManagerViewModel ServiceManager { get; } = new();
    public FileExplorerViewModel FileExplorer { get; } = new();
                                                    
    public SidebarViewModel Sidebar { get; }

    public MainWindowViewModel()
    {
        // Set default view
        CurrentPage = ProcessManager;

        // Navigation only swaps references
        Sidebar = new SidebarViewModel(
            navigateToProcesses: () => CurrentPage = ProcessManager,
            navigateToServices: () => CurrentPage = ServiceManager,
            navigateToFiles: () => CurrentPage = FileExplorer
        );                          
    }                       
}