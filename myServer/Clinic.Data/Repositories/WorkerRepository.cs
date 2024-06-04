using Factory.Core.Entities;
using Factory.Core.Repositories;
using Factory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository

    {
        private readonly DataContext _context;
        public WorkerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Worker>> GetWorkersAsync()
        {
            //////////return only active workers
            return await _context.workers.Include(w => w.Roles).Where(w => w.Status == true).ToListAsync();

        }
        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            return await _context.workers.Include(w => w.Roles).FirstAsync(b => b.Id == id);
        }

        public async Task<Worker> AddWorkersAsync(Worker worker)
        {
            worker.Status = true;
            if (worker.BirthDate < worker.StartJob)
            {
                _context.workers.Add(worker);
                await _context.SaveChangesAsync();
                return worker;
            }
            return null;
        }

        public async Task<string> ToAddAsync(int id, RoleToWorker role)
        {
            var worker = await GetWorkerByIdAsync(id);
            if (worker == null)
                return "Worker Not Found";
            var regularRole = await _context.roles.FirstAsync(r => r.Id == role.RoleId);
            if (regularRole == null)
                return "This role is'nt exist in array of roles!\n Please add role to an array!";
            if (worker.Roles.Any(r => r.RoleId == role.RoleId))
                return "This Role Is Exist To This Worker!";
            if (role.StartRole >= worker.StartJob)
            {
                role.WorkerId = worker.Id;
                worker.Roles.Add(role);
                await _context.SaveChangesAsync();
                return "Good";
            }
            return "This start role date is invalid!";

        }
        public async Task<Worker> UpdateWorkerAsync(int id, Worker w)
        {
            Worker worker = await _context.workers.FirstAsync(b => b.Id == id);
            if (worker != null)
            {
                if (w.BirthDate < w.StartJob)
                {
                    worker.Tz = w.Tz;
                    worker.Status = true;
                    worker.FirstName = w.FirstName;
                    worker.LastName = w.LastName;
                    worker.StartJob = w.StartJob;
                    worker.BirthDate = w.BirthDate;
                    worker.Gender = w.Gender;
                    await _context.SaveChangesAsync();
                    return _context.workers.Include(e => e.Roles).FirstOrDefault(e => e.Id == id);
                }

            }
            return null;

        }

        public async Task<Worker> DeleteWorkerAsync(int id)
        {
            Worker worker = await _context.workers.FirstAsync(b => b.Id == id);
            worker.Status = !worker.Status;
            await _context.SaveChangesAsync();
            return worker;

        }

        public async Task<bool> DeleteRoleToWorkerAsync(int workerId, int roleId)
        {
            var rolesToRemove = _context.rolesToWorkers.Where(r => r.WorkerId == workerId && r.RoleId == roleId);
            _context.rolesToWorkers.RemoveRange(rolesToRemove);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
