using FindJobsProject.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.Database.Entities
{
    public class FavoritesJobs
    {
 

        public Guid idJob { get; set; }
        public Job Jobs { get; set; }
        public Guid IdUser { get; set; }
        public AppUser Users { get; set; }
        public bool isLike { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
