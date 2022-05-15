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
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
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
                    Gender = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    UrlAvatar = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyOfJobs = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    JobImage = table.Column<string>(nullable: false),
                    JobDetail = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Experience = table.Column<string>(nullable: false),
                    SalaryMin = table.Column<decimal>(nullable: false),
                    SalaryMax = table.Column<decimal>(nullable: false),
                    SalaryUnit = table.Column<string>(nullable: false),
                    WorkTime = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DealineForSubmission = table.Column<DateTimeOffset>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    IdBlog = table.Column<Guid>(nullable: false),
                    TItle = table.Column<string>(nullable: true),
                    IdMajor = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.IdBlog);
                    table.ForeignKey(
                        name: "FK_Blog_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateJob",
                columns: table => new
                {
                    CandicateId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    RecruitmentId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJob", x => new { x.CandicateId, x.JobId });
                    table.ForeignKey(
                        name: "FK_CandidateJob_AppUsers_CandicateId",
                        column: x => x.CandicateId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateJob_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentJob",
                columns: table => new
                {
                    RecruitmentId = table.Column<Guid>(nullable: false),
                    JobsId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentJob", x => new { x.RecruitmentId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_RecruitmentJob_Job_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitmentJob_AppUsers_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "0e5662e7-3d50-4ceb-9be2-38812bbb1d66", "Administrator role", "Admin", "ADMIN" },
                    { new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "9c0683db-6653-450c-bc20-8dc219d68a0e", "Recruitment role", "Recruitment", "RECRUITMENT" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Comment", "ConcurrencyStamp", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FirstName", "FullName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Major", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvatar", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, null, "28b10448-92fa-4b08-ab06-0b7ce69c3edd", null, null, "5951071014@st.utc2.edu.vn", true, "Đạt", "Trần Tiến Đạt", null, "Trần Tiến", false, null, null, "5951071014@st.utc2.edu.vn", "5951071014@st.utc2.edu.vn", "AQAAAAEAACcQAAAAECLpA5/XcoXw4/HZIu4ITIoMAGyKaVD62FUYtyg84NgwQ4uZC4XVFKev900tNaih3Q==", null, false, "", false, "Images/avt1.png", "5951071014@st.utc2.edu.vn" },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), 0, null, null, "1ee2f5a0-5bc7-43ea-ba96-2ed62af4e174", null, null, "5951071017@st.utc2.edu.vn", true, "Đông", "Hoàng Đình Thiên Đông", null, "Hoàng Đinh Thiên", false, null, null, "5951071017@st.utc2.edu.vn", "5951071017@st.utc2.edu.vn", "AQAAAAEAACcQAAAAED4X38QnsXMxDrFOP2sQ2DCQAKjdmH/cwfn1veTh4qJcMUYOQKQleiWAcDWSlyWPCw==", null, false, "", false, "Images/avt5.png", "5951071017@st.utc2.edu.vn" },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), 0, null, null, "446f526d-0d0d-4e20-a262-be4ccd3687eb", null, null, "5951071021@st.utc2.edu.vn", true, "Hảo", "Trần Minh Hảo", null, "Trần Minh", false, null, null, "5951071021@st.utc2.edu.vn", "5951071021@st.utc2.edu.vn", "AQAAAAEAACcQAAAAECcp5Xf7OonwWR0zZpXgjPHSiY9ys5iTnPhaoOwo/gj+t8RQWNvv4xO0WQXYkBA0vg==", null, false, "", false, "Images/avt6.png", "5951071021@st.utc2.edu.vn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJob_JobId",
                table: "CandidateJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJob_JobsId",
                table: "RecruitmentJob",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "RecruitmentJob");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
