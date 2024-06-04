using Factory.Core.Entities;
using Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Core.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetWorkersAsync();
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<Worker> AddWorkersAsync(Worker Worker);
        Task<string> ToAddAsync(int id, RoleToWorker role);
        Task<Worker> UpdateWorkerAsync(int id, Worker value);
        Task<Worker> DeleteWorkerAsync(int id);
        Task<bool> DeleteRoleToWorkerAsync(int workerId, int roleId);

    }
}
