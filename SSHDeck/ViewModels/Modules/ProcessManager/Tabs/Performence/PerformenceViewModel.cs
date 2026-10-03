// Author: Filip Bambura, 282232 (xfipilko)
// Module: Process Manager

namespace SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence;

using System;
using System.ComponentModel;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SSHDeck.ViewModels;
using SSHDeck.Services.Interfaces;
using SSHDeck.ViewModels.Modules.ProcessManager.Tabs.Performence.Components;

public partial class PerformenceViewModel : ViewModelBase
{
    private readonly IProcessManagerService _processService;
    private DispatcherTimer _timer;

    public MetricListViewModel MetricList { get; } = new();
    
    [ObservableProperty]
    private MetricDetailViewModel _metricDetail = new MetricDetailViewModel("Loading...", "");

    public PerformenceViewModel(IProcessManagerService processService)
    {
        _processService = processService;
        
        // Listen to selection changes in the list
        MetricList.PropertyChanged += OnMetricListPropertyChanged;

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += async (sender, args) => await LoadDataAsync();
        _timer.Start();

        _ = LoadDataAsync();
    }

    private void OnMetricListPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Swap the displayed detail when selection changes
        if (e.PropertyName == nameof(MetricListViewModel.SelectedItem) && MetricList.SelectedItem != null)
        {
            MetricDetail = MetricList.SelectedItem.Detail;
        }
    }

    private async System.Threading.Tasks.Task LoadDataAsync()
    {
        var data = await _processService.GetSystemPerformanceAsync();
        MetricList.UpdateMetrics(data);
    }
}