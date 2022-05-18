
using FindJobsProject.Data.Configurations;
using FindJobsProject.Data.Entities;
using FindJobsProject.Data.Extensions;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Database
{
    public class FindJobsContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        
        public FindJobsContext(DbContextOptions<FindJobsContext> options ) :base (options)
        {

        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<Employees> employees { get; set; }
        //public DbSet<Company> companies { get; set; }
        //public DbSet<CompanyJobs> companyJobs { get; set; }
        //public DbSet<Jobs> jobs { get; set; }

        public DbSet<RecruitmentJob> recruitmentJob { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateJob> JobCandidates { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Major> Majors { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());

            builder.ApplyConfiguration(new JobsConfiguration());
            builder.ApplyConfiguration(new Candidate_JobConfiguration());
            builder.ApplyConfiguration(new Recruitment_JobConfiguration());
            builder.ApplyConfiguration(new BlogConfiguration());

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);



            builder.Seed();
        }

    }
}
