using System;
using System.Collections.Generic;
using System.Text;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FindJobsProject.Data.Extensions
{
  public static  class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var admin2Id = new Guid("157b9908-7d9c-4d3c-ad32-a15db858ac34");
            var admin3Id = new Guid("be6c06a9-e0c7-4d63-bd24-5f3ece98ebc0");
            var admin4Id = new Guid("041684eb-cf97-40c6-881c-b766ae9c416a");
            var rec1Id = new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9");
            var rec2Id = new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c");
            var recruitmentId = new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role"
            });
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = recruitmentId,
                Name = "Recruitment",
                NormalizedName = "RECRUITMENT",
                Description = "Recruitment role"
            });
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "5951071014@st.utc2.edu.vn",
                NormalizedUserName = "5951071014@st.utc2.edu.vn",
                Email = "5951071014@st.utc2.edu.vn",
                NormalizedEmail = "5951071014@st.utc2.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "abc123"),
                SecurityStamp = string.Empty,
                LastName = "Trần Tiến",
                FirstName = "Đạt",
                FullName= "Trần Tiến Đạt",
                UrlAvatar = "Images/avt1.png"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

  
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = rec1Id,
                UserName = "5951071017@st.utc2.edu.vn",
                NormalizedUserName = "5951071017@st.utc2.edu.vn",
                Email = "5951071017@st.utc2.edu.vn",
                NormalizedEmail = "5951071017@st.utc2.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "abc123"),
                SecurityStamp = string.Empty,
                LastName = "Hoàng Đinh Thiên",
                FirstName = "Đông",
                FullName = "Hoàng Đình Thiên Đông",
                UrlAvatar = "Images/avt5.png"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = recruitmentId,
                UserId = rec1Id
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = rec2Id,
                UserName = "5951071021@st.utc2.edu.vn",
                NormalizedUserName = "5951071021@st.utc2.edu.vn",
                Email = "5951071021@st.utc2.edu.vn",
                NormalizedEmail = "5951071021@st.utc2.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "abc123"),
                SecurityStamp = string.Empty,
                LastName = "Trần Minh",
                FirstName = "Hảo",
                FullName = "Trần Minh Hảo",
                UrlAvatar = "Images/avt6.png"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = recruitmentId,
                UserId = rec2Id
            });

        }
    }
}
