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

    public ChartViewModel Chart { get; } = new();

    // The detail view model specific to this list item
    public MetricDetailViewModel Detail { get; } 

    public MetricListItemViewModel(string heading, string description)
    {
        _heading = heading;
        _description = description;
        
        Detail = new MetricDetailViewModel(heading, description); 
    }

    public void UpdateData(string description, double chartValue)
    {
        Description = description;
        Chart.AppendValue(chartValue);
        
        // Note: You will later update Detail data here as well when implemented
    }
}