// Authors: Team
// Module: Services

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSHDeck.Models;
using SSHDeck.Services.Interfaces;

namespace SSHDeck.Services.Mock;

public class MockProcessManagerService : IProcessManagerService
{
    private readonly List<ProcessItemModel> _mockProcesses;
    private readonly Random _random = new();
    private DateTime _startTime = DateTime.Now;

    public MockProcessManagerService()
    {
        _mockProcesses = GenerateInitialProcesses();
    }

    public async Task<List<ProcessItemModel>> GetProcessesAsync()
    {
        // Simulate network latency
        await Task.Delay(200);

        // Slightly alter CPU and Memory to simulate live behavior
        foreach (var process in _mockProcesses)
        {
            if (_random.NextDouble() > 0.5)
            {
                process.CpuUsage = Math.Max(0, Math.Min(100, process.CpuUsage + (_random.NextDouble() * 2 - 1)));
                process.MemoryUsage = Math.Max(1024, process.MemoryUsage + (long)(_random.NextDouble() * 500000 - 250000));
            }
        }

        return _mockProcesses.OrderByDescending(p => p.CpuUsage).ToList();
    }

    public async Task<SystemPerformanceModel> GetSystemPerformanceAsync()
    {
        // Simulate network latency
        await Task.Delay(200);

        long totalRam = 16L * 1024 * 1024 * 1024; // 16 GB
        long usedRam = (long)(totalRam * (0.4 + _random.NextDouble() * 0.1));

        var perf = new SystemPerformanceModel
        {
            CpuUtilization = 15.0 + _random.NextDouble() * 10.0,
            TotalProcesses = _mockProcesses.Count,
            TotalThreads = _mockProcesses.Count * 12,
            UpTime = DateTime.Now - _startTime,
            Cores = 8,
            TotalMemory = totalRam,
            InUseMemory = usedRam,
            AvailableMemory = totalRam - usedRam,
            CachedMemory = 2L * 1024 * 1024 * 1024,
            SwapTotal = 4L * 1024 * 1024 * 1024,
            SwapUsed = 500L * 1024 * 1024,
            Disks = new List<DiskPerformanceModel>
            {
                new DiskPerformanceModel
                {
                    MountPoint = "/",
                    TotalSpaceBytes = 256L * 1024 * 1024 * 1024,
                    FreeSpaceBytes = 120L * 1024 * 1024 * 1024,
                    FileSystemType = "ext4",
                    ReadBytesPerSec = _random.NextDouble() * 5000000,
                    WriteBytesPerSec = _random.NextDouble() * 1000000
                }
            },
            Networks = new List<NetworkPerformanceModel>
            {
                new NetworkPerformanceModel
                {
                    InterfaceName = "eth0",
                    IpAddress = "192.168.1.100",
                    SendBytesPerSec = _random.NextDouble() * 1500000,
                    ReceiveBytesPerSec = _random.NextDouble() * 3000000
                }
            }
        };

        return perf;
    }

    private List<ProcessItemModel> GenerateInitialProcesses()
    {
        var list = new List<ProcessItemModel>();
        string[] names = { "systemd", "kthreadd", "sshd", "bash", "nginx", "mysql", "docker", "python3", "htop", "node" };
        string[] users = { "root", "xfipilko", "www-data", "mysql" };

        for (int i = 1; i <= 30; i++)
        {
            string name = names[_random.Next(names.Length)];
            list.Add(new ProcessItemModel
            {
                Pid = i * 10 + _random.Next(9),
                Name = name,
                Command = $"/usr/bin/{name} --start",
                User = users[_random.Next(users.Length)],
                Status = _random.NextDouble() > 0.9 ? "Sleeping" : "Running",
                Priority = 20,
                Threads = _random.Next(1, 50),
                OpenFiles = _random.Next(10, 200),
                CpuUsage = _random.NextDouble() * 5.0,
                MemoryUsage = (long)(_random.NextDouble() * 500 * 1024 * 1024), // up to 500MB
                IsRoot = (name == "systemd" || name == "kthreadd")
            });
        }
        return list;
    }
}
