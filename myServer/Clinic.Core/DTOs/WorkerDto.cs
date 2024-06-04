using Factory.Core.DTOs;
using Factory.Core.Entities;
using Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.DTOs
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartJob { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<RoleToWorkerDto>? Roles { get; set; }

    }
}