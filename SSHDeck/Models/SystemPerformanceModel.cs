// Authors: Team
// Module: Models

using System;
using System.Collections.Generic;

namespace SSHDeck.Models;

public class SystemPerformanceModel
{
    public double CpuUtilization { get; set; }
    public int TotalProcesses { get; set; }
    public int TotalThreads { get; set; }
    public TimeSpan UpTime { get; set; }
    public int Cores { get; set; }
    public long TotalMemory { get; set; }
    public long InUseMemory { get; set; }
    public long AvailableMemory { get; set; }
    public long CachedMemory { get; set; }
    public long SwapTotal { get; set; }
    public long SwapUsed { get; set; }

    public List<DiskPerformanceModel> Disks { get; set; } = new();
    public List<NetworkPerformanceModel> Networks { get; set; } = new();
}

public class DiskPerformanceModel
{
    public string MountPoint { get; set; } = string.Empty;
    public long TotalSpaceBytes { get; set; }
    public long FreeSpaceBytes { get; set; }
    public string FileSystemType { get; set; } = string.Empty;
    public double ReadBytesPerSec { get; set; }
    public double WriteBytesPerSec { get; set; }
}

public class NetworkPerformanceModel
{
    public string InterfaceName { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public double SendBytesPerSec { get; set; }
    public double ReceiveBytesPerSec { get; set; }
}
