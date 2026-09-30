// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence;

using SSHDeck.ViewModels;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public class PerformenceViewModel : ViewModelBase
{
    public MetricListViewModel MetricList { get; } = new();
    public MetricDetailViewModel MetricDetail { get; } = new();
}