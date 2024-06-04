using Factory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Core.Entities
{
    public class RoleToWorker
    {
        public int Id { get; set; }

        [ForeignKey("Worker")] // Foreign key annotation for WorkerId
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [ForeignKey("Role")] // Foreign key annotation for RoleId
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime StartRole { get; set; }
    }
}
