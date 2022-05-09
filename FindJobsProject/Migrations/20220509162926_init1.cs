using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
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
                    IdQrCode = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    UrlAvatar = table.Column<string>(nullable: true),
                    IdEmployee = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameEmployee = table.Column<string>(nullable: true),
                    PostionEmployee = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Position = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ApplicationEmail = table.Column<string>(maxLength: 50, nullable: false),
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
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    dateExpire = table.Column<string>(nullable: true),
                    daysLeft = table.Column<string>(nullable: true),
                    descriptions = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Approve = table.Column<bool>(nullable: false),
                    IdEmployee = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "employees",
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
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJob", x => new { x.CandicateId, x.JobId });
                    table.ForeignKey(
                        name: "FK_CandidateJob_AspNetUsers_CandicateId",
                        column: x => x.CandicateId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_RecruitmentJob_AspNetUsers_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    dateWork = table.Column<string>(nullable: true),
                    descriptions = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    logo = table.Column<string>(nullable: true),
                    idUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companyJobs",
                columns: table => new
                {
                    companyId = table.Column<Guid>(nullable: false),
                    jobsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyJobs", x => new { x.companyId, x.jobsId });
                    table.ForeignKey(
                        name: "FK_companyJobs_companies_companyId",
                        column: x => x.companyId,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companyJobs_jobs_jobsId",
                        column: x => x.jobsId,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "d2a0f4df-9ae9-4cd5-9dc2-8a6cec8f6043", "Administrator role", "Admin", "ADMIN" },
                    { new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "5b6152a0-dfa9-4013-87c8-9a512bb5a42a", "Recruitment role", "Recruitment", "RECRUITMENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Comment", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "FullName", "Gender", "IdEmployee", "IdQrCode", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvatar", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, null, "d3c6408b-b39c-43c6-8ef0-ec8dba7573b8", null, "quochieu@gmail.com", true, "Hiếu", "Hồ Quốc Hiếu", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Hồ Quốc", false, null, "QUOCHIEU@GMAIL.COM", "QUOCHIEU@GMAIL.COM", "AQAAAAEAACcQAAAAEJJYqSaCoz21QU7FKOK+g3Xnj1K8t/BTFhceiOgNACQXmFPKPurdHpC207XbuO/T/w==", null, false, "", false, "Images/avt1.png", "quochieu@gmail.com" },
                    { new Guid("157b9908-7d9c-4d3c-ad32-a15db858ac34"), 0, null, null, "af5fb32d-6d79-4dc2-a582-f49acb60be06", null, "lehieu@gmail.com", true, "Hiếu", "Nguyễn Phước Lê", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Nguyễn Phước Lê", false, null, "LEHIEU@GMAIL.COM", "LEHIEU@GMAIL.COM", "AQAAAAEAACcQAAAAEFhI9TKxbirAMTITWy2KwsKImGT7A60PWsxy04KBOD3SopyQiG8xvOz7tFuPgjkgkA==", null, false, "", false, "Images/avt2.png", "lehieu@gmail.com" },
                    { new Guid("be6c06a9-e0c7-4d63-bd24-5f3ece98ebc0"), 0, null, null, "767ea431-4aec-43ba-b532-317418b1681e", null, "locpv@gmail.com", true, "Lộc", "Phan Văn Lộc", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Phan Văn", false, null, "LOCPV@GMAIL.COM", "LOCPV@GMAIL.COM", "AQAAAAEAACcQAAAAEF3YfR8Kvg4jrqVKdgturg7qIlPDfT6JaiiMLf7w3UVvFWCjoRZkj6SG3PDlmAtX7g==", null, false, "", false, "Images/avt3.png", "locpv@gmail.com" },
                    { new Guid("041684eb-cf97-40c6-881c-b766ae9c416a"), 0, null, null, "f9b8c262-aa16-4cdc-86d6-c554ff005334", null, "giahuy@gmail.com", true, "Huy", "Huỳnh Gia Huy", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Huỳnh Gia", false, null, "GIAHUY@GMAIL.COM", "GIAHUY@GMAIL.COM", "AQAAAAEAACcQAAAAEMJTm1K/8BkR6/y5CQSGCHVBseNXllPR5tn+sh32UFA8oRVKy+uVbGLlje3eyF/7DA==", null, false, "", false, "Images/avt4.png", "giahuy@gmail.com" },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), 0, null, null, "69d06257-451e-4d72-b563-98e7064cfa33", null, "vanlong@gmail.com", true, "Long", "Sằn Văn Long", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Sằn Văn", false, null, "VANLONG@GMAIL.COM", "VANLONG@GMAIL.COM", "AQAAAAEAACcQAAAAEF2lL57HAb7BWbH6+jIxGPOypvpJ0wuygEsTTiwACnbIbJxrovtiLJLO/4Pplsw4JQ==", null, false, "", false, "Images/avt5.png", "vanlong@gmail.com" },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), 0, null, null, "eb888e2d-38d3-4ca9-98ce-ea88cf8eaa31", null, "ankhang@gmail.com", true, "Khang", "Đỗ Phúc An Khang", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Đỗ Phúc An Khang", false, null, "ANKHANG@GMAIL.COM", "ANKHANG@GMAIL.COM", "AQAAAAEAACcQAAAAEIQy6gDFgUdv0uDbbRNWxMRiCqpLwHdVZlWJlubaLgoysWwiyvrvz/sZIIXK4+10tg==", null, false, "", false, "Images/avt6.png", "ankhang@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("157b9908-7d9c-4d3c-ad32-a15db858ac34"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("be6c06a9-e0c7-4d63-bd24-5f3ece98ebc0"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("041684eb-cf97-40c6-881c-b766ae9c416a"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJob_JobId",
                table: "CandidateJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_companies_idUser",
                table: "companies",
                column: "idUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyJobs_jobsId",
                table: "companyJobs",
                column: "jobsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJob_JobsId",
                table: "RecruitmentJob",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdEmployee",
                table: "User",
                column: "IdEmployee",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CandidateJob");

            migrationBuilder.DropTable(
                name: "companyJobs");

            migrationBuilder.DropTable(
                name: "RecruitmentJob");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
