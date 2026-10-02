// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class MetricDetailViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _heading = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;
    
    [ObservableProperty]
    private string _subHeading = string.Empty;
    
    [ObservableProperty]
    private string _subHeadingValue = string.Empty;

    public ChartViewModel Chart { get; } = new();
    
    public MetricDetailViewModel(string heading, string description, string subHeading, string subHeadingValue)
    {
        _heading = heading;
        _description = description;
        _subHeading = subHeading;
        _subHeadingValue = subHeadingValue;
    }
    
    public void SetHeaderData(string description, double chartValue)
    {
        Description = description;
        Chart.AppendValue(chartValue);
    }
}
