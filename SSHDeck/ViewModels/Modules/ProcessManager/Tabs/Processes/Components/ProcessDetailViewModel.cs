// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public partial class ProcessDetailViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _pid;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _status = string.Empty;

    [ObservableProperty]
    private double _cpuUsage;

    [ObservableProperty]
    private double _memoryUsage;

    [ObservableProperty]
    private string _user = string.Empty;
}
