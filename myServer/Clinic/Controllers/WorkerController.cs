using AutoMapper;
using Factory.API.Model;
using Factory.Core.Entities;
using Factory.Core.Services;
using Factory.DTOs;
using Factory.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.Controllers
{
    [ApiController]
    [Route("Factory/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        private readonly IMapper _mapper;

        public WorkersController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult> GetWorkers()
        {
            var workers = await _workerService.GetWorkersAsync();
            var workersDto = _mapper.Map<IEnumerable<WorkerDto>>(workers);
            return Ok(workersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorker(int id)
        {
            var worker = await _workerService.GetWorkerByIdAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            var workerDto = _mapper.Map<WorkerDto>(worker);
            return Ok(workerDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddWorker([FromBody] WorkerPostModel worker)
        {
            var workerToAdd = _mapper.Map<Worker>(worker);

            var newWorker = await _workerService.AddWorkerAsync(workerToAdd);
            if (newWorker != null)
            {
                var workerDto = _mapper.Map<WorkerDto>(newWorker);
                return Ok(workerDto);
            }
            return Conflict("BirthDate must be before Date of Start Job");
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> AddRoleToWorker(int id, [FromBody] RoleToWorkerPostPutModel role)
        {
            var roleToAdd = _mapper.Map<RoleToWorker>(role);
            var message = await _workerService.ToAddAsync(id, roleToAdd);
            if (message == "Good")
            {
                return Ok(message);
            }
            return Conflict(message); // Return 409 Conflict if role with same name already exists

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorker(int id, [FromBody] WorkerPutModel worker)
        {
            var workerToUpdate = _mapper.Map<Worker>(worker);
            var result = await _workerService.UpdateWorkerAsync(id, workerToUpdate);
            if (result == null)
            {
                return NotFound();
            }
            var workerDto = _mapper.Map<WorkerDto>(result);
            return Ok(workerDto);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var result = await _workerService.DeleteWorkerAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            var workerDto = _mapper.Map<WorkerDto>(result);
            return Ok(workerDto);
        }
        [HttpDelete("{workerId}/{roleId}")]
        public async Task<ActionResult> Delete(int workerId, int roleId)
        {
            bool flag = await _workerService.DeleteRoleToWorkerAsync(workerId, roleId);
            if (flag)
            {
                return Ok();
            }
            return Conflict("Cannot Delete");


        }

    }
}


