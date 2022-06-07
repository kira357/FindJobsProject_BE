using System;
using System.Collections.Generic;
using System.Text;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
    public class FavoritesBlogsConfiguration : IEntityTypeConfiguration<FavoritesBlogs>
    {
        public void Configure(EntityTypeBuilder<FavoritesBlogs> builder)
        {
            builder.ToTable("FavoritesBlogs");
            builder.HasKey(sc => new { sc.idBlog, sc.IdUser });

            builder.ToTable("FavoritesBlogs")
            .HasOne<AppUser>(sc => sc.Users)
            .WithMany(s => s.Favorites)
            .HasForeignKey(sc => sc.IdUser);

            //builder.ToTable("Favourites")
            //    .HasOne<Job>(sc => sc.Jobs)
            //    .WithMany(s => s.Favorites)
            //    .HasForeignKey(sc => sc.idPostion)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade); 


            builder.ToTable("FavoritesBlogs")
                .HasOne<Blog>(sc => sc.Blogs)
                .WithMany(s => s.Favorites)
                .HasForeignKey(sc => sc.idBlog);
        }
    }
}