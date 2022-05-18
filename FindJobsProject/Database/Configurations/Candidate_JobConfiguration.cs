using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.Data.Configurations
{
    public class Candidate_JobConfiguration : IEntityTypeConfiguration<CandidateJob>
    {
        public void Configure(EntityTypeBuilder<CandidateJob> builder)
        {
            builder.ToTable("CandidateJob").HasKey(sc => new { sc.IdCandicate, sc.IdJob});

            builder.ToTable("CandidateJob")
            .HasOne<AppUser>(sc => sc.Candicate)
            .WithMany(s => s.CandidateJob)
            .HasForeignKey(sc => sc.IdCandicate)
              .OnDelete(DeleteBehavior.Cascade); ;

            builder.ToTable("CandidateJob")
                .HasOne<Job>(sc => sc.Job)
                .WithMany(s => s.CandidateJob)
                .HasForeignKey(sc => sc.IdJob)
                  .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}