using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class init1 : Migration
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
                    IdQrCode = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    UrlAvatar = table.Column<string>(nullable: true)
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
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "15904564-ae5f-4703-906e-c2b387a07397", "Administrator role", "Admin", "ADMIN" },
                    { new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"), "cc945dfa-7651-4517-95a9-9e9b2d9ec31f", "Recruitment role", "Recruitment", "RECRUITMENT" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
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

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Comment", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "FullName", "Gender", "IdQrCode", "LastName", "LockoutEnabled", "LockoutEnd", "Major", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvatar", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, null, "b1975d72-fa56-4f45-99b8-455036bec99f", null, "quochieu@gmail.com", true, "Hiếu", "Hồ Quốc Hiếu", null, null, "Hồ Quốc", false, null, null, "QUOCHIEU@GMAIL.COM", "QUOCHIEU@GMAIL.COM", "AQAAAAEAACcQAAAAEMvutHM2k7WgcN6CLyvtai76htCa9nVYlQZptDmZIL9tRigWENuXAeYo9C2ZiRmM8A==", null, false, "", false, "Images/avt1.png", "quochieu@gmail.com" },
                    { new Guid("157b9908-7d9c-4d3c-ad32-a15db858ac34"), 0, null, null, "76a363e8-8ae0-4f12-9fc5-52baf3dbfe3e", null, "lehieu@gmail.com", true, "Hiếu", "Nguyễn Phước Lê", null, null, "Nguyễn Phước Lê", false, null, null, "LEHIEU@GMAIL.COM", "LEHIEU@GMAIL.COM", "AQAAAAEAACcQAAAAEIvBkQ+85nsQL5AEYhEr5xa/xoxhl6g65u0wi5V9wQfmIJ4xoZGywfqlqNjf9Qe3Zw==", null, false, "", false, "Images/avt2.png", "lehieu@gmail.com" },
                    { new Guid("be6c06a9-e0c7-4d63-bd24-5f3ece98ebc0"), 0, null, null, "7b320121-c9cd-4c71-94f8-e08c2e83d0aa", null, "locpv@gmail.com", true, "Lộc", "Phan Văn Lộc", null, null, "Phan Văn", false, null, null, "LOCPV@GMAIL.COM", "LOCPV@GMAIL.COM", "AQAAAAEAACcQAAAAEDfyWWfL4tinl+7IK1V0fGkCcgMXL3W0uDlW1SAChRWKwy5Bzq3ZSOOKw+4j8pbPEg==", null, false, "", false, "Images/avt3.png", "locpv@gmail.com" },
                    { new Guid("041684eb-cf97-40c6-881c-b766ae9c416a"), 0, null, null, "56167ff9-fa9e-40b7-81d4-d7b18b73bea5", null, "giahuy@gmail.com", true, "Huy", "Huỳnh Gia Huy", null, null, "Huỳnh Gia", false, null, null, "GIAHUY@GMAIL.COM", "GIAHUY@GMAIL.COM", "AQAAAAEAACcQAAAAEDdQpru/A7cURNaORchdQYVIZwHZeiWwaIrwsaTi8UOmS6jl8LsSLsf1RGMb7kx30Q==", null, false, "", false, "Images/avt4.png", "giahuy@gmail.com" },
                    { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), 0, null, null, "0b29dbfe-30d4-438e-a53d-3b4126777956", null, "vanlong@gmail.com", true, "Long", "Sằn Văn Long", null, null, "Sằn Văn", false, null, null, "VANLONG@GMAIL.COM", "VANLONG@GMAIL.COM", "AQAAAAEAACcQAAAAEAiXY10zL+AYBLpAqJ2CwmsambXCLAQ2ZFqmMbRrsdUzsB5IaTX7f+XUrYV6PYivrA==", null, false, "", false, "Images/avt5.png", "vanlong@gmail.com" },
                    { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), 0, null, null, "82fcb3b2-7297-44b7-90f6-97709e811317", null, "ankhang@gmail.com", true, "Khang", "Đỗ Phúc An Khang", null, null, "Đỗ Phúc An Khang", false, null, null, "ANKHANG@GMAIL.COM", "ANKHANG@GMAIL.COM", "AQAAAAEAACcQAAAAEIIMWunlb/DtpEJf+2onBVqVtLF3V+eMSVVjSrjw8CMlodATO8kEhOpNhc5b5bvhZg==", null, false, "", false, "Images/avt6.png", "ankhang@gmail.com" }
                });

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
