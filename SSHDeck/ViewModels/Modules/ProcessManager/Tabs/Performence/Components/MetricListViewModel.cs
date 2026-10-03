// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

using System.Collections.ObjectModel;
using System.Linq;
using SSHDeck.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class MetricListViewModel : ViewModelBase
{
    public ObservableCollection<MetricListItemViewModel> Items { get; } = new();

    [ObservableProperty]
    private MetricListItemViewModel? _selectedItem;
    
    public void UpdateMetrics(SystemPerformanceModel data)
    {
        UpdateOrAddItem("CPU", $"{data.CpuUtilization:F1}% ({data.Cores} Cores)", data.CpuUtilization);

        double usedRamGb = data.InUseMemory / (1024.0 * 1024 * 1024);
        double totalRamGb = data.TotalMemory / (1024.0 * 1024 * 1024);
        double ramPercentage = totalRamGb > 0 ? (usedRamGb / totalRamGb) * 100 : 0;
        UpdateOrAddItem("Memory", $"{usedRamGb:F1}/{totalRamGb:F1} GB ({ramPercentage:F0}%)", ramPercentage);

        if (data.SwapTotal > 0)
        {
            double usedSwapMb = data.SwapUsed / (1024.0 * 1024);
            double totalSwapMb = data.SwapTotal / (1024.0 * 1024);
            double swapPercentage = (usedSwapMb / totalSwapMb) * 100;
            UpdateOrAddItem("Swap", $"{usedSwapMb:F0}/{totalSwapMb:F0} MB ({swapPercentage:F0}%)", swapPercentage);
        }

        foreach (var disk in data.Disks)
        {
            double usedDiskGb = (disk.TotalSpaceBytes - disk.FreeSpaceBytes) / (1024.0 * 1024 * 1024);
            double totalDiskGb = disk.TotalSpaceBytes / (1024.0 * 1024 * 1024);
            double activityMb = (disk.ReadBytesPerSec + disk.WriteBytesPerSec) / (1024.0 * 1024);
            
            string heading = $"Disk ({disk.MountPoint})";
            string desc = $"{usedDiskGb:F1}/{totalDiskGb:F1} GB ({disk.FileSystemType})";
            
            UpdateOrAddItem(heading, desc, activityMb);
        }

        foreach (var net in data.Networks)
        {
            double sendKb = net.SendBytesPerSec / 1024.0;
            double recvKb = net.ReceiveBytesPerSec / 1024.0;
            
            string heading = $"Network ({net.InterfaceName})";
            string desc = $"Up: {sendKb:F1} KB/s | Down: {recvKb:F1} KB/s";
            
            UpdateOrAddItem(heading, desc, sendKb + recvKb);
        }
    }

    private void UpdateOrAddItem(string heading, string description, double chartValue)
    {
        var existing = Items.FirstOrDefault(i => i.Heading == heading);
        if (existing != null)
        {
            existing.UpdateData(description, chartValue);
        }
        else
        {
            var newItem = new MetricListItemViewModel(heading, description);
            newItem.UpdateData(description, chartValue);
            Items.Add(newItem);
            
            // Automatically select the first item if nothing is selected yet
            if (SelectedItem == null)
            {
                SelectedItem = newItem;
            }
        }
    }
}