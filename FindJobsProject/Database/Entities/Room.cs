using System.Collections;
using System.Collections.Generic;

namespace FindJobsProject.Database.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUser UserCreate { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
