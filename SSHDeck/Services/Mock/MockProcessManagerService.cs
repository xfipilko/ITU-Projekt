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
    private const long Gb = 1024L * 1024 * 1024;
    private const int LogicalCores = 8;

    private readonly List<ProcessItemModel> _mockProcesses;
    private readonly Random _random = new();

    // Pretend the server has been running for a while
    private readonly DateTime _startTime = DateTime.Now - new TimeSpan(4, 4, 38, 21);
    private readonly double[] _coreLoad = new double[LogicalCores];

    public MockProcessManagerService()
    {
        _mockProcesses = GenerateInitialProcesses();

        for (int i = 0; i < _coreLoad.Length; i++)
        {
            _coreLoad[i] = 10 + _random.NextDouble() * 30;
        }
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

        long totalRam = 16 * Gb;
        long usedRam = (long)(totalRam * (0.4 + _random.NextDouble() * 0.1));

        var coreLoads = UpdateCoreLoads();
        double cpu = coreLoads.Average();

        var perf = new SystemPerformanceModel
        {
            CpuUtilization = cpu,
            TotalProcesses = _mockProcesses.Count,
            TotalThreads = _mockProcesses.Count * 12,
            UpTime = DateTime.Now - _startTime,
            OpenFileDescriptors = _mockProcesses.Sum(p => p.OpenFiles),
            Cores = LogicalCores,
            PhysicalCores = 4,
            Sockets = 1,
            CpuModelName = "Intel(R) Xeon(R) CPU E3-1230 v5 @ 3.40GHz",
            Virtualization = "KVM",
            BaseSpeedGhz = 3.4,
            CurrentSpeedGhz = 3.4 + cpu / 100 * 0.4,
            L1CacheBytes = 256 * 1024,
            L2CacheBytes = 1024 * 1024,
            L3CacheBytes = 8 * 1024 * 1024,
            PerCoreUtilization = coreLoads,
            LoadAverage1Min = cpu / 100 * LogicalCores,
            LoadAverage5Min = cpu / 100 * LogicalCores * 0.9,
            LoadAverage15Min = cpu / 100 * LogicalCores * 0.8,
            TotalMemory = totalRam,
            InUseMemory = usedRam,
            AvailableMemory = totalRam - usedRam,
            CachedMemory = 2 * Gb,
            SwapTotal = 4 * Gb,
            SwapUsed = 500L * 1024 * 1024,
            MemoryType = "DDR4",
            MemorySpeedMhz = 2400,
            MemorySlotsUsed = 2,
            MemorySlotsTotal = 4,
            Disks = new List<DiskPerformanceModel>
            {
                CreateDisk("/", "vda1", "Samsung SSD 860 EVO 500GB", "SSD", "ext4", 256, 136, 40000000, 15000000),
                CreateDisk("/data", "vdb1", "WDC WD20EZRZ 2TB", "HDD", "xfs", 1800, 950, 20000000, 10000000),
                CreateDisk("/mnt/backup", "vdc1", "Seagate ST4000DM004 4TB", "HDD", "ext4", 3600, 2100, 500000, 200000)
            },
            Networks = new List<NetworkPerformanceModel>
            {
                CreateNetwork("eth0", "Ethernet", "192.168.1.100", "fe80::5054:ff:fe12:3456", "52:54:00:12:34:56", 1000, 1500000, 3000000),
                CreateNetwork("eth1", "Ethernet", "10.0.0.15", "fe80::5054:ff:fe65:4321", "52:54:00:65:43:21", 10000, 200000, 400000),
                CreateNetwork("docker0", "Bridge", "172.17.0.1", "fe80::42:a1ff:fe0b:9c3d", "02:42:a1:0b:9c:3d", 10000, 50000, 80000)
            }
        };

        return perf;
    }

    private List<double> UpdateCoreLoads()
    {
        // Random walk so the charts don't jump around
        for (int i = 0; i < _coreLoad.Length; i++)
        {
            _coreLoad[i] = Math.Clamp(_coreLoad[i] + (_random.NextDouble() * 2 - 1) * 8, 1, 95);
        }

        return _coreLoad.ToList();
    }

    private DiskPerformanceModel CreateDisk(string mountPoint, string deviceName, string diskModel, string diskType,
        string fileSystem, long totalGb, long usedGb, double maxReadBytes, double maxWriteBytes)
    {
        double read = _random.NextDouble() * maxReadBytes;
        double write = _random.NextDouble() * maxWriteBytes;
        bool isSsd = diskType == "SSD";

        // Active time = share of the disk's max throughput that is currently used
        double maxThroughput = isSsd ? 500000000 : 150000000;

        return new DiskPerformanceModel
        {
            MountPoint = mountPoint,
            DeviceName = deviceName,
            DiskModel = diskModel,
            DiskType = diskType,
            TotalSpaceBytes = totalGb * Gb,
            FreeSpaceBytes = (totalGb - usedGb) * Gb,
            FileSystemType = fileSystem,
            ReadBytesPerSec = read,
            WriteBytesPerSec = write,
            ActiveTimePercent = Math.Min(100, (read + write) / maxThroughput * 100),
            AvgResponseTimeMs = isSsd ? 0.1 + _random.NextDouble() * 0.9 : 4 + _random.NextDouble() * 10
        };
    }

    private NetworkPerformanceModel CreateNetwork(string name, string type, string ipv4, string ipv6, string mac,
        int linkSpeedMbps, double maxSendBytes, double maxReceiveBytes)
    {
        return new NetworkPerformanceModel
        {
            InterfaceName = name,
            InterfaceType = type,
            IpAddress = ipv4,
            Ipv6Address = ipv6,
            MacAddress = mac,
            LinkSpeedMbps = linkSpeedMbps,
            SendBytesPerSec = _random.NextDouble() * maxSendBytes,
            ReceiveBytesPerSec = _random.NextDouble() * maxReceiveBytes
        };
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
