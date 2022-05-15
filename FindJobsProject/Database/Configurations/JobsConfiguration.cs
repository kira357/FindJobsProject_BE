using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;

namespace FindJobsProject.Data.Configurations
{
    public class JobsConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}