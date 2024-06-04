using Factory.Core.Entities;
using Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Factory.Core.Services
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetWorkersAsync();
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<Worker> AddWorkerAsync(Worker worker);
        Task<string> ToAddAsync(int id,RoleToWorker role);
        Task<Worker> UpdateWorkerAsync(int id, Worker worker);
        Task<Worker> DeleteWorkerAsync(int id);
        Task<bool> DeleteRoleToWorkerAsync(int workerId,int roleId);

    }
}
