using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    IdJob = table.Column<Guid>(nullable: false),
                    CompanyOfJobs = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdMajor = table.Column<long>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    JobImage = table.Column<string>(nullable: true),
                    JobDetail = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Experience = table.Column<string>(nullable: false),
                    SalaryMin = table.Column<decimal>(nullable: false),
                    SalaryMax = table.Column<decimal>(nullable: false),
                    WorkTime = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DateExpire = table.Column<DateTimeOffset>(nullable: false),
                    TypeJob = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.IdJob);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    IdMajor = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.IdMajor);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    IdBlog = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IdMajor = table.Column<long>(nullable: true),
                    NameMajor = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DatePost = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    View = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    HotPost = table.Column<bool>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.IdBlog);
                });

            migrationBuilder.CreateTable(
                name: "CandidateJob",
                columns: table => new
                {
                    IdCandicate = table.Column<Guid>(nullable: false),
                    IdJob = table.Column<Guid>(nullable: false),
                    IdRecruitment = table.Column<Guid>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsPending = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    DateApply = table.Column<DateTimeOffset>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJob", x => new { x.IdCandicate, x.IdJob });
                    table.ForeignKey(
                        name: "FK_CandidateJob_Job_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentMsg = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentOn = table.Column<string>(nullable: true),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdPosition = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    IdMajor = table.Column<long>(nullable: true),
                    UrlAvatar = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CommentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_Majors_IdMajor",
                        column: x => x.IdMajor,
                        principalTable: "Majors",
                        principalColumn: "IdMajor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesJob",
                columns: table => new
                {
                    idJob = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    isLike = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesJob", x => new { x.idJob, x.IdUser });
                    table.ForeignKey(
                        name: "FK_FavouritesJob_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritesJob_Job_idJob",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentJob",
                columns: table => new
                {
                    IdRecruitment = table.Column<Guid>(nullable: false),
                    IdJob = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentJob", x => new { x.IdRecruitment, x.IdJob });
                    table.ForeignKey(
                        name: "FK_RecruitmentJob_Job_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitmentJob_AppUsers_IdRecruitment",
                        column: x => x.IdRecruitment,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyComment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyMsg = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IdUser = table.Column<Guid>(nullable: true),
                    IdComment = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyComment_Comment_IdComment",
                        column: x => x.IdComment,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyComment_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "38e80feb-6a44-4506-8cf6-ad61a52d6495", "Administrator role", "Admin", "ADMIN" },
                    { new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "f88c892f-9f6f-408c-8141-99b0c8a5bc00", "Recruitment role", "Recruitment", "RECRUITMENT" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "IdentityUserRole<Guid>" },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "IdentityUserRole<Guid>" },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "IdentityUserRole<Guid>" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Comment", "CommentId", "ConcurrencyStamp", "DateOfBirth", "Description", "Email", "EmailConfirmed", "Experience", "FirstName", "FullName", "Gender", "IdMajor", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvatar", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, null, null, "0af10fe9-d636-4274-af09-4def29043746", null, null, "5951071014@st.utc2.edu.vn", true, null, "Đạt", "Trần Tiến Đạt", 0, null, null, "Trần Tiến", false, null, "5951071014@st.utc2.edu.vn", "5951071014@st.utc2.edu.vn", "AQAAAAEAACcQAAAAEG5TfWjA8EbVFe26HToD+EeLVJXRVhL3PqYupZshePTspFeag5U/P8ozJvO5voxMvA==", null, false, "", false, "Images/avt1.png", "5951071014@st.utc2.edu.vn" },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), 0, null, null, null, "44f81189-bcfd-49ae-9917-5f70141b31ee", null, null, "5951071017@st.utc2.edu.vn", true, null, "Đông", "Hoàng Đình Thiên Đông", 0, null, null, "Hoàng Đinh Thiên", false, null, "5951071017@st.utc2.edu.vn", "5951071017@st.utc2.edu.vn", "AQAAAAEAACcQAAAAEF9dRgmelUEhn7yjixtqB9mwWbAows7H7OheMPzaXBrtYx5gBXU8TYVdaQVEjMXTCg==", null, false, "", false, "Images/avt5.png", "5951071017@st.utc2.edu.vn" },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), 0, null, null, null, "c5644c0d-cbb1-4b85-85e5-d029717d8d50", null, null, "5951071021@st.utc2.edu.vn", true, null, "Hảo", "Trần Minh Hảo", 0, null, null, "Trần Minh", false, null, "5951071021@st.utc2.edu.vn", "5951071021@st.utc2.edu.vn", "AQAAAAEAACcQAAAAEDX9cHx8jjr0N24bChAxZi/jazs2hHR9r8eWLkt2pmzu1EP85mSOVCLcDpP56pTSEA==", null, false, "", false, "Images/avt6.png", "5951071021@st.utc2.edu.vn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CommentId",
                table: "AppUsers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_IdMajor",
                table: "AppUsers",
                column: "IdMajor");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_IdUser",
                table: "Blog",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJob_IdJob",
                table: "CandidateJob",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdUser",
                table: "Comment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesJob_IdUser",
                table: "FavouritesJob",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJob_IdJob",
                table: "RecruitmentJob",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_IdComment",
                table: "ReplyComment",
                column: "IdComment");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_IdUser",
                table: "ReplyComment",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AppUsers_IdUser",
                table: "Blog",
                column: "IdUser",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateJob_AppUsers_IdCandicate",
                table: "CandidateJob",
                column: "IdCandicate",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AppUsers_IdUser",
                table: "Comment",
                column: "IdUser",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Comment_CommentId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CandidateJob");

            migrationBuilder.DropTable(
                name: "FavouritesJob");

            migrationBuilder.DropTable(
                name: "RecruitmentJob");

            migrationBuilder.DropTable(
                name: "ReplyComment");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
