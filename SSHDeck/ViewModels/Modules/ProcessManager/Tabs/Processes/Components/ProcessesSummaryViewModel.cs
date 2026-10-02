// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public partial class ProcessesSummaryViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _totalProcesses;

    [ObservableProperty]
    private int _runningProcesses;
}
