using System;

namespace FindJobsProject.ViewModels.VMFavourite
{
    public class VMDeleteFavourite
    {
        public Guid idJob { get; set; }
        public Guid IdUser { get; set; }
        public bool isLike { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
