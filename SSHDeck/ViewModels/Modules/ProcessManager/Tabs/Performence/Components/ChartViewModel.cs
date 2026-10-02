// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using System.Collections.ObjectModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class ChartViewModel : ViewModelBase
{
    private const int MaxHistoryPoints = 120;

    [ObservableProperty]
    private IBrush _accentColor = Brushes.CornflowerBlue;
    
    [ObservableProperty]
    private double _currentValue;
    
    public ObservableCollection<double> Values { get; } = new();
    
    public void AppendValue(double value)
    {
        Values.Add(value);
        CurrentValue = value;
        
        if (Values.Count > MaxHistoryPoints)
        {
            Values.RemoveAt(0);
        }
    }
}
