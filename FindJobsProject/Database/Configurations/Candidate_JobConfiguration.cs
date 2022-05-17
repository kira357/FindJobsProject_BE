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
            builder.ToTable("CandidateJob").HasKey(sc => new { sc.CandicateId, sc.JobId });

            builder.ToTable("CandidateJob")
            .HasOne<AppUser>(sc => sc.Candicate)
            .WithMany(s => s.CandidateJob)
            .HasForeignKey(sc => sc.CandicateId);

            builder.ToTable("CandidateJob")
                .HasOne<Job>(sc => sc.Job)
                .WithMany(s => s.CandidateJob)
                .HasForeignKey(sc => sc.JobId);
        }
    }
}