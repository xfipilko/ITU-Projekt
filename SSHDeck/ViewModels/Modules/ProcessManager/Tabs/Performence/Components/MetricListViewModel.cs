// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using System.Collections.ObjectModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public class MetricListViewModel : ViewModelBase
{
    public ObservableCollection<MetricListItemViewModel> Items { get; } = new()
    {
        new MetricListItemViewModel("CPU", "12% 4.19 GHz"),
        new MetricListItemViewModel("RAM", "18.5/47.7 GB (39%)"),
        new MetricListItemViewModel("Disk 0 (vda1)", "SSD 0%"),
        new MetricListItemViewModel("Disk 1 (vdb1)", "HDD 0%"),
        new MetricListItemViewModel("Ethernet (eth0)", "O: 8.0 - P: 80.0 Kbps"),
        new MetricListItemViewModel("Swap (Odkladaci)", "180 MB / 2.0 GB (9%)"),
    };
}