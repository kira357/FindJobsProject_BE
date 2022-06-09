using System;

namespace FindJobsProject.ViewModels.VMFavourite
{
    public class VMGetFavourite
    {
        public Guid IdJob { get; set; }
        public Guid IdUser { get; set; }
        public string UserName { get; set; }

        public string? CompanyOfJobs { get; set; }

        public string Name { get; set; }
        public long? idMajor { get; set; }

        public string NameMajor { get; set; }

        public string? Position { get; set; }

        public string JobImage { get; set; }
        public string JobDetail { get; set; }

        public int Amount { get; set; }

        public string? Experience { get; set; }

        public decimal SalaryMin { get; set; }

        public decimal SalaryMax { get; set; }


        public int WorkTime { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public bool isLike { get; set; }
        public DateTimeOffset DateExpire { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
