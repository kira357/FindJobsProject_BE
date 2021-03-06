// <auto-generated />
using System;
using FindJobsProject.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindJobsProject.Migrations
{
    [DbContext(typeof(FindJobsContext))]
    [Migration("20220617072735_createMessAndRoom")]
    partial class createMessAndRoom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FindJobsProject.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "f4b994fa-4b0c-450d-917f-6d34b9caba79",
                            Description = "Administrator role",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                            ConcurrencyStamp = "5d932d09-872d-4490-8c0c-bdc754044dd2",
                            Description = "Recruitment role",
                            Name = "Recruitment",
                            NormalizedName = "RECRUITMENT"
                        });
                });

            modelBuilder.Entity("FindJobsProject.Data.Entities.CandidateJob", b =>
                {
                    b.Property<Guid>("IdCandicate")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJob")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateApply")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("IdRecruitment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPending")
                        .HasColumnType("bit");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("IdCandicate", "IdJob");

                    b.HasIndex("IdJob");

                    b.ToTable("CandidateJob");
                });

            modelBuilder.Entity("FindJobsProject.Data.Entities.Job", b =>
                {
                    b.Property<Guid>("IdJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CompanyOfJobs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateExpire")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Experience")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<long?>("IdMajor")
                        .HasColumnType("bigint");

                    b.Property<string>("JobDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalaryMax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalaryMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("TypeJob")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("WorkTime")
                        .HasColumnType("int");

                    b.HasKey("IdJob");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CommentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long?>("IdMajor")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UrlAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("IdMajor");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fb81a458-7408-4d40-b269-5ebf1762bfd3",
                            Email = "5951071014@st.utc2.edu.vn",
                            EmailConfirmed = true,
                            FirstName = "Đạt",
                            FullName = "Trần Tiến Đạt",
                            Gender = 0,
                            LastName = "Trần Tiến",
                            LockoutEnabled = false,
                            NormalizedEmail = "5951071014@st.utc2.edu.vn",
                            NormalizedUserName = "5951071014@st.utc2.edu.vn",
                            PasswordHash = "AQAAAAEAACcQAAAAEDL5iwmQ4llzjYFnXdFXdRZdk7XV9aeUTRAFAZWRkrMVtvWuf2obb+sYxn0oG8O5/A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UrlAvatar = "Images/avt1.png",
                            UserName = "5951071014@st.utc2.edu.vn"
                        },
                        new
                        {
                            Id = new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c5e0b2bb-5481-4922-be08-2df8f62ce299",
                            Email = "5951071017@st.utc2.edu.vn",
                            EmailConfirmed = true,
                            FirstName = "Đông",
                            FullName = "Hoàng Đình Thiên Đông",
                            Gender = 0,
                            LastName = "Hoàng Đinh Thiên",
                            LockoutEnabled = false,
                            NormalizedEmail = "5951071017@st.utc2.edu.vn",
                            NormalizedUserName = "5951071017@st.utc2.edu.vn",
                            PasswordHash = "AQAAAAEAACcQAAAAEOYHR2oya9ZNP2XsHsOd/n2Qbo3rmTidXc9IzuUCzSvc3/i19/5JCtohxmBUNVjs8w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UrlAvatar = "Images/avt5.png",
                            UserName = "5951071017@st.utc2.edu.vn"
                        },
                        new
                        {
                            Id = new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b680d1e6-6d6b-402a-a706-e3acb8d82120",
                            Email = "5951071021@st.utc2.edu.vn",
                            EmailConfirmed = true,
                            FirstName = "Hảo",
                            FullName = "Trần Minh Hảo",
                            Gender = 0,
                            LastName = "Trần Minh",
                            LockoutEnabled = false,
                            NormalizedEmail = "5951071021@st.utc2.edu.vn",
                            NormalizedUserName = "5951071021@st.utc2.edu.vn",
                            PasswordHash = "AQAAAAEAACcQAAAAEJF5n5BWgyOS73r2T8XAn2iwNwqnmqknjkrYHYP1oucGptajxiba39tQAu35J45SsA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UrlAvatar = "Images/avt6.png",
                            UserName = "5951071021@st.utc2.edu.vn"
                        });
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Blog", b =>
                {
                    b.Property<Guid>("IdBlog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DatePost")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HotPost")
                        .HasColumnType("bit");

                    b.Property<long?>("IdMajor")
                        .HasColumnType("bigint");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameMajor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("View")
                        .HasColumnType("int");

                    b.HasKey("IdBlog");

                    b.HasIndex("IdUser");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentMsg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdPosition")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.FavouritesJob", b =>
                {
                    b.Property<Guid>("idJob")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isLike")
                        .HasColumnType("bit");

                    b.HasKey("idJob", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("FavouritesJob");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Major", b =>
                {
                    b.Property<long>("IdMajor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMajor");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FromUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdRooom")
                        .HasColumnType("int");

                    b.Property<string>("Msg")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("IdRooom");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.RecruitmentJob", b =>
                {
                    b.Property<Guid>("IdRecruitment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJob")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("IdRecruitment", "IdJob");

                    b.HasIndex("IdJob");

                    b.ToTable("RecruitmentJob");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.ReplyComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdComment")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReplyMsg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdComment");

                    b.HasIndex("IdUser");

                    b.ToTable("ReplyComment");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        },
                        new
                        {
                            UserId = new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                            RoleId = new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0")
                        },
                        new
                        {
                            UserId = new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                            RoleId = new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.AppUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasDiscriminator().HasValue("AppUserRole");
                });

            modelBuilder.Entity("FindJobsProject.Data.Entities.CandidateJob", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "Candicate")
                        .WithMany("CandidateJob")
                        .HasForeignKey("IdCandicate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJobsProject.Data.Entities.Job", "Job")
                        .WithMany("CandidateJob")
                        .HasForeignKey("IdJob")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.AppUser", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.Comment", null)
                        .WithMany("Users")
                        .HasForeignKey("CommentId");

                    b.HasOne("FindJobsProject.Database.Entities.Major", "UserMajor")
                        .WithMany("UserMajor")
                        .HasForeignKey("IdMajor");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Blog", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "UserBlog")
                        .WithMany("UserBlog")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Comment", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "UserComment")
                        .WithMany("UserComment")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.FavouritesJob", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "Users")
                        .WithMany("Favorites")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJobsProject.Data.Entities.Job", "Jobs")
                        .WithMany("Favorites")
                        .HasForeignKey("idJob")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Message", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "FromUser")
                        .WithMany("Messages")
                        .HasForeignKey("FromUserId");

                    b.HasOne("FindJobsProject.Database.Entities.Room", "Room")
                        .WithMany("Messages")
                        .HasForeignKey("IdRooom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.RecruitmentJob", b =>
                {
                    b.HasOne("FindJobsProject.Data.Entities.Job", "Jobs")
                        .WithMany("RecruitmentJobTable")
                        .HasForeignKey("IdJob")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "Recruitments")
                        .WithMany("RecruitmentJobTable")
                        .HasForeignKey("IdRecruitment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.ReplyComment", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.Comment", "Comment")
                        .WithMany("Replies")
                        .HasForeignKey("IdComment");

                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "User")
                        .WithMany("UserReplyComment")
                        .HasForeignKey("IdUser");
                });

            modelBuilder.Entity("FindJobsProject.Database.Entities.Room", b =>
                {
                    b.HasOne("FindJobsProject.Database.Entities.AppUser", "UserCreate")
                        .WithMany("Rooms")
                        .HasForeignKey("UserCreateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
