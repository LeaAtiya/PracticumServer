using Factory.Core.Repositories;
using Factory.Core.Services;
using Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();

        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }


        public async Task<bool> RoleExistsAsync(string roleName, bool isManagerial)
        {
            return await _roleRepository.RoleExistsAsync(roleName, isManagerial);
        }
        public async Task<IEnumerable<Role>> GetRolesToWorkerAsync(int id)
        {
            return await _roleRepository.GetRolesToWorkerAsync(id);
        }
    }
}