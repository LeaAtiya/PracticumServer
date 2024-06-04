using Microsoft.AspNetCore.Mvc;
using Factory.Entities;
using System.Collections.Generic;
using System.Linq;
using Factory.Core.Services;
using AutoMapper;
using Factory.Service;
using Factory.Core.DTOs;
using Factory.API.Model;

namespace Factory.API.Controllers
{
    [Route("Factory/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult> GetRoles()
        {
            var roles = await _roleService.GetRolesAsync();
            var rolesDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(rolesDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolesToSpecificWorker(int id)
        {
            var roles = await _roleService.GetRolesToWorkerAsync(id);
            var rolesDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(rolesDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole([FromBody] RolePostModel role)
        {
            var roleToAdd = _mapper.Map<Role>(role);

            if (await _roleService.RoleExistsAsync(role.Name,role.IsManagerial))
            {
                return Conflict("Role already exists."); // Return 409 Conflict if role with same name already exists
            }

            var addedRole = await _roleService.AddRoleAsync(roleToAdd);
            var addedRoleDto = _mapper.Map<RoleDto>(addedRole);
            return Ok(addedRoleDto); // Return 200 OK with the added role DTO
        }
       


    }
}
