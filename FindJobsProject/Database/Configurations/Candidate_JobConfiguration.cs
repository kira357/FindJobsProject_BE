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
            builder.ToTable("CandidateJob");
            builder.HasKey(sc => new { sc.CandicateId, sc.JobId });
            builder
            .HasOne<AppUser>(sc => sc.Candicate)
            .WithMany(s => s.CandidateJob)
            .HasForeignKey(sc => sc.CandicateId);
            builder
                .HasOne<Job>(sc => sc.Job)
                .WithMany(s => s.CandidateJob)
                .HasForeignKey(sc => sc.JobId);
        }
    }
}