using Factory.Core.Entities;
using Factory.Entities;

namespace Factory.API.Model
{
    public class WorkerPutModel
    {
        public string Tz { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartJob { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

    }
}
