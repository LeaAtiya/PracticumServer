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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.roles.ToListAsync();
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            _context.roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }


        public async Task<bool> RoleExistsAsync(string roleName, bool isManagerial)
        {
            return await _context.roles.AnyAsync(r => r.Name == roleName && r.IsManagerial == isManagerial);
        }

        public async Task<IEnumerable<Role>> GetRolesToWorkerAsync(int id)
        {
            var worker = await _context.workers.Include(w => w.Roles).FirstAsync(b => b.Id == id);
            List<Role> rolesOfWorker = new List<Role>();
            foreach (var r in worker.Roles)
            {
                var role = await _context.roles.FirstAsync(x => x.Id == r.RoleId);
                rolesOfWorker.Add(role);
            }
            return rolesOfWorker;
        }
    }
}
