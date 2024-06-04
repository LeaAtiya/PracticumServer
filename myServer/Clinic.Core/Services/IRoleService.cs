﻿using Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> AddRoleAsync(Role role);
        Task<bool> RoleExistsAsync(string roleName, bool isManagerial);
        Task<IEnumerable<Role>> GetRolesToWorkerAsync(int id);
    }
}
