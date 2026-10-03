// Authors: Team
// Module: Models

using System;
using System.Collections.Generic;

namespace SSHDeck.Models;

public class SystemPerformanceModel
{
    // CPU
    public double CpuUtilization { get; set; }
    public int TotalProcesses { get; set; }
    public int TotalThreads { get; set; }
    public TimeSpan UpTime { get; set; }
    public int OpenFileDescriptors { get; set; }

    // Logical processors (threads), same as the number of items in PerCoreUtilization
    public int Cores { get; set; }
    public int PhysicalCores { get; set; }
    public int Sockets { get; set; }
    public string CpuModelName { get; set; } = string.Empty;
    public string Virtualization { get; set; } = string.Empty;
    public double BaseSpeedGhz { get; set; }
    public double CurrentSpeedGhz { get; set; }
    public long L1CacheBytes { get; set; }
    public long L2CacheBytes { get; set; }
    public long L3CacheBytes { get; set; }
    public List<double> PerCoreUtilization { get; set; } = new();
    public double LoadAverage1Min { get; set; }
    public double LoadAverage5Min { get; set; }
    public double LoadAverage15Min { get; set; }

    // Memory
    public long TotalMemory { get; set; }
    public long InUseMemory { get; set; }
    public long AvailableMemory { get; set; }
    public long CachedMemory { get; set; }
    public long SwapTotal { get; set; }
    public long SwapUsed { get; set; }
    public string MemoryType { get; set; } = string.Empty;
    public int MemorySpeedMhz { get; set; }
    public int MemorySlotsUsed { get; set; }
    public int MemorySlotsTotal { get; set; }

    public List<DiskPerformanceModel> Disks { get; set; } = new();
    public List<NetworkPerformanceModel> Networks { get; set; } = new();
}

public class DiskPerformanceModel
{
    public string MountPoint { get; set; } = string.Empty;
    public string DeviceName { get; set; } = string.Empty;
    public string DiskModel { get; set; } = string.Empty;

    // "SSD" or "HDD"
    public string DiskType { get; set; } = string.Empty;
    public long TotalSpaceBytes { get; set; }
    public long FreeSpaceBytes { get; set; }
    public string FileSystemType { get; set; } = string.Empty;
    public double ReadBytesPerSec { get; set; }
    public double WriteBytesPerSec { get; set; }
    public double ActiveTimePercent { get; set; }
    public double AvgResponseTimeMs { get; set; }
}

public class NetworkPerformanceModel
{
    public string InterfaceName { get; set; } = string.Empty;

    // "Ethernet" or "Bridge"
    public string InterfaceType { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string Ipv6Address { get; set; } = string.Empty;
    public string MacAddress { get; set; } = string.Empty;
    public int LinkSpeedMbps { get; set; }
    public double SendBytesPerSec { get; set; }
    public double ReceiveBytesPerSec { get; set; }
}
