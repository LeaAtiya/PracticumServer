using Factory.Core.Entities;
using Factory.Core.Repositories;
using Factory.Core.Services;
using Factory.Entities;
using NUnit.Framework.Constraints;

namespace Factory.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public async Task<IEnumerable<Worker>> GetWorkersAsync()
        {
            return await _workerRepository.GetWorkersAsync();
        }
        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            return await _workerRepository.GetWorkerByIdAsync(id);
        }
        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
            return await _workerRepository.AddWorkersAsync(worker);
        }
        public async Task<string> ToAddAsync(int id, RoleToWorker role)
        {
            return await _workerRepository.ToAddAsync(id, role);
        }
        public async Task<Worker> UpdateWorkerAsync(int id, Worker worker)
        {
            return await _workerRepository.UpdateWorkerAsync(id, worker);
        }
        public async Task<Worker> DeleteWorkerAsync(int id)
        {
            return await _workerRepository.DeleteWorkerAsync(id);
        }
        public async Task<bool> DeleteRoleToWorkerAsync(int workerId, int roleId)
        {
             return await _workerRepository.DeleteRoleToWorkerAsync(workerId,roleId);
        }
    }
}
