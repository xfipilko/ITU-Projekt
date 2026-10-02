// Authors: Team
// Module: Services

using System.Collections.Generic;
using System.Threading.Tasks;
using SSHDeck.Models;

namespace SSHDeck.Services.Interfaces;

public interface IProcessManagerService
{
    Task<SystemPerformanceModel> GetSystemPerformanceAsync();
    Task<List<ProcessItemModel>> GetProcessesAsync();
}
