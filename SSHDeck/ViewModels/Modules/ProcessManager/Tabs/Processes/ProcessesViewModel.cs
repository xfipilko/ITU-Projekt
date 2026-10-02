// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes;

using System;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using SSHDeck.ViewModels;
using SSHDeck.Services.Interfaces;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Processes.Components;

public class ProcessesViewModel : ViewModelBase
{
    private readonly IProcessManagerService _processService;
    private DispatcherTimer _timer;

    public ObservableCollection<ProcessRowViewModel> Processes { get; } = new();

    public ProcessesViewModel(IProcessManagerService processService)
    {
        _processService = processService;
        
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += async (sender, args) => await LoadDataAsync();
        _timer.Start();
        
        _ = LoadDataAsync();
    }

    private async System.Threading.Tasks.Task LoadDataAsync()
    {
        var data = await _processService.GetProcessesAsync();
        
        Processes.Clear();
        foreach(var item in data)
        {
            Processes.Add(new ProcessRowViewModel
            {
                Pid = item.Pid,
                Name = item.Name,
                CpuUsage = item.CpuUsage,
                MemoryUsage = item.MemoryUsage,
                Status = item.Status
            });
        }
    }
}