// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public partial class ProcessTableViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<ProcessRowViewModel> _processes = new();

    [ObservableProperty]
    private ProcessRowViewModel? _selectedProcess;
}
