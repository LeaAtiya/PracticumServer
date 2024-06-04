using Factory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities
{
    public enum Gender { MALE, FEMALE }
    public class Worker
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartJob { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<RoleToWorker> Roles { get; set; }= new List<RoleToWorker>();


    }
}
