// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class StatPairViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _primaryValue = string.Empty;

    [ObservableProperty]
    private string _secondaryValue = string.Empty;

    [ObservableProperty]
    private double _percentage;
}
