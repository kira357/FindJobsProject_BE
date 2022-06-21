
using FindJobsProject.Data.Configurations;
using FindJobsProject.Data.Entities;
using FindJobsProject.Data.Extensions;
using FindJobsProject.Database.Configurations;
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
        public DbSet<AppUserRole> AppUserRoles { get; set; }
 
        public DbSet<RecruitmentJob> recruitmentJob { get; set; }
        public DbSet<ChatRecruitment> chatRecruitments { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CandidateJob> CandidateJobs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<FavouritesJob> FavouritesJobs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());

            builder.ApplyConfiguration(new JobsConfiguration());
            builder.ApplyConfiguration(new Candidate_JobConfiguration());
            builder.ApplyConfiguration(new Recruitment_JobConfiguration());
            builder.ApplyConfiguration(new BlogConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ReplyCommentConfiguration());
            builder.ApplyConfiguration(new FavouritesConfiguration());
            builder.ApplyConfiguration(new ChatRecruitmentConfiguration());

            builder.ApplyConfiguration(new MessageConfiguration());
            //builder.ApplyConfiguration(new RoomConfiguration());

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            builder.Entity<AppUser>()
            .HasOne(a => a.Recruitment)
            .WithOne(a => a.User)
            .HasForeignKey<Recruitment>(c => c.IdRecruitment)
            .OnDelete(DeleteBehavior.Cascade);


            builder.Seed();
        }

    }
}
