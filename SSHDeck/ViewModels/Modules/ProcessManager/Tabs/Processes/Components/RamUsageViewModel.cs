// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public partial class RamUsageViewModel : ViewModelBase
{
    [ObservableProperty]
    private double _usage;

    [ObservableProperty]
    private string _usageText = string.Empty;

    public ChartViewModel Chart { get; } = new();
}
