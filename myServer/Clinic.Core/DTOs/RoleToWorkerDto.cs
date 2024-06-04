using Factory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Core.DTOs
{
    public class RoleToWorkerDto
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
        public DateTime StartRole { get; set; }
    }
}
