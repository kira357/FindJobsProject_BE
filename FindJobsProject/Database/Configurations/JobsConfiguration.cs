using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.Data.Configurations
{
    public class JobsConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");
            builder.HasKey(x => x.IdJob);
            builder.Property(x => x.CreatedOn).IsRequired();

            //builder.ToTable("Job");
            //builder.HasKey(x => x.IdJob);
            //builder.Property(x => x.CreatedOn).IsRequired();
            //builder.ToTable("Job")
            //        .HasOne<AppUser>(s => s.RecruitmentJob)
            //        .WithMany(g => g.RecruitmentJob)
            //        .HasForeignKey(s => s.IdRecruitment)
            //        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}