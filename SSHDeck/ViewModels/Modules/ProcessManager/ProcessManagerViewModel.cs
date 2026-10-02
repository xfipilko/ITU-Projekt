// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes;

namespace SSHDeck.ViewModels.Modules.ProcessManager;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class ProcessManagerViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _currentTab;

    // Tab view model instances
    public ProcessesViewModel ProcessesTab { get; }
    public PerformenceViewModel PerformenceTab { get; }

    public ProcessManagerViewModel(SSHDeck.Services.Interfaces.IProcessManagerService processService)
    {
        ProcessesTab = new ProcessesViewModel(processService);
        PerformenceTab = new PerformenceViewModel(processService);

        // Default active tab
        CurrentTab = ProcessesTab;
    }

    [RelayCommand]
    private void NavigateToProcesses()
    {
        CurrentTab = ProcessesTab;
    }

    [RelayCommand]
    private void NavigateToPerformance()
    {
        CurrentTab = PerformenceTab;
    }
}