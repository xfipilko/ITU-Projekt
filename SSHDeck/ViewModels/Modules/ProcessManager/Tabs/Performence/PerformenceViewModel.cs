// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence;

using System;
using Avalonia.Threading;
using SSHDeck.ViewModels;
using SSHDeck.Services.Interfaces;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public class PerformenceViewModel : ViewModelBase
{
    private readonly IProcessManagerService _processService;
    private DispatcherTimer _timer;

    public MetricListViewModel MetricList { get; } = new();
    public MetricDetailViewModel MetricDetail { get; } = new();

    public PerformenceViewModel(IProcessManagerService processService)
    {
        _processService = processService;
        
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        _timer.Tick += async (sender, args) => await LoadDataAsync();
        _timer.Start();

        _ = LoadDataAsync();
    }

    private async System.Threading.Tasks.Task LoadDataAsync()
    {
        var data = await _processService.GetSystemPerformanceAsync();
        
        // Example logic for UI update
        MetricDetail.Heading = "CPU";
        MetricDetail.Description = $"Utilization: {data.CpuUtilization:F1}% | Processes: {data.TotalProcesses} | Threads: {data.TotalThreads}";
    }
}