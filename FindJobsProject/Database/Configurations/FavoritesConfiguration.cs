using System;
using System.Collections.Generic;
using System.Text;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
    public class FavouritesConfiguration : IEntityTypeConfiguration<FavouritesJob>
    {
        public void Configure(EntityTypeBuilder<FavouritesJob> builder)
        {
            builder.ToTable("FavouritesJob");
            builder.HasKey(sc => new { sc.idJob, sc.IdUser });

            builder.ToTable("FavouritesJob")
            .HasOne<AppUser>(sc => sc.Users)
            .WithMany(s => s.Favorites)
            .HasForeignKey(sc => sc.IdUser)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("FavouritesJob")
                .HasOne<Job>(sc => sc.Jobs)
                .WithMany(s => s.Favorites)
                .HasForeignKey(sc => sc.idJob)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}