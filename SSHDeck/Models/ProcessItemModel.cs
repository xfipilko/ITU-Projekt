// Authors: Team
// Module: Models

namespace SSHDeck.Models;

public class ProcessItemModel
{
    public int Pid { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Command { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Priority { get; set; }
    public int Threads { get; set; }
    public int OpenFiles { get; set; }
    public double CpuUsage { get; set; }
    public long MemoryUsage { get; set; }
    public long DiskReadBytesPerSec { get; set; }
    public long DiskWriteBytesPerSec { get; set; }
    public long NetworkSendBytesPerSec { get; set; }
    public long NetworkReceiveBytesPerSec { get; set; }
    public bool IsRoot { get; set; }
}
