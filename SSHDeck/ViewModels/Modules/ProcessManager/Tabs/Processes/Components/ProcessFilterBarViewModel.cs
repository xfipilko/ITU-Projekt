// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public partial class ProcessFilterBarViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _searchText = string.Empty;
}
