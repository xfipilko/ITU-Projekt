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
    public ProcessManagerViewModel ProcessManager { get; }
    public ServiceManagerViewModel ServiceManager { get; } = new();
    public FileExplorerViewModel FileExplorer { get; } = new();
                                                    
    public SidebarViewModel Sidebar { get; }

    private readonly SSHDeck.Services.Interfaces.IProcessManagerService _processService;

    public MainWindowViewModel()
    {
        _processService = new SSHDeck.Services.Mock.MockProcessManagerService();
        ProcessManager = new ProcessManagerViewModel(_processService);

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