// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using System.Collections.ObjectModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class ChartViewModel : ViewModelBase
{
    [ObservableProperty]
    private IBrush _accentColor = Brushes.CornflowerBlue;

    [ObservableProperty]
    private ObservableCollection<double> _values = new();
}
