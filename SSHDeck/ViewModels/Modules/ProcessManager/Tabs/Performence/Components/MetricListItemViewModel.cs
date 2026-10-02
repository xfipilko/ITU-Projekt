// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class MetricListItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _heading;

    [ObservableProperty]
    private string _description;

    public MetricListItemViewModel(string heading, string description)
    {
        _heading = heading;
        _description = description;
    }
}