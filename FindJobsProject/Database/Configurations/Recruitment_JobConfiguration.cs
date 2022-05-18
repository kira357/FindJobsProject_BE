using System;
using System.Collections.Generic;
using System.Text;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
    public class Recruitment_JobConfiguration : IEntityTypeConfiguration<RecruitmentJob>
    {
        public void Configure(EntityTypeBuilder<RecruitmentJob> builder)
        {
            builder.ToTable("RecruitmentJob");
            builder.HasKey(sc => new { sc.IdRecruitment, sc.IdJob });

            builder.ToTable("RecruitmentJob")
            .HasOne<AppUser>(sc => sc.Recruitments)
            .WithMany(s => s.RecruitmentJobTable)
            .HasForeignKey(sc => sc.IdRecruitment);

            builder.ToTable("RecruitmentJob")
                .HasOne<Job>(sc => sc.Jobs)
                .WithMany(s => s.RecruitmentJobTable)
                .HasForeignKey(sc => sc.IdJob);
        }
    }
}