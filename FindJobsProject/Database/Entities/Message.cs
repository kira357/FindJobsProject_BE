using System;

namespace FindJobsProject.Database.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Msg { get; set; }

        public DateTime DateSend { get; set; }

        //public int IdRooom { get; set; }
        //public Room Room { get; set; }

        public Guid IdUser { get; set; }
        public AppUser FromUser { get; set; }
    }
}
