using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class changeTypeIdChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentJob_AppUsers_IdRecruitment",
                table: "RecruitmentJob");

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatRecruitment",
                columns: table => new
                {
                    IdChat = table.Column<Guid>(nullable: false),
                    IdSender = table.Column<Guid>(nullable: true),
                    IdReceiver = table.Column<Guid>(nullable: true),
                    Messages = table.Column<string>(nullable: true),
                    TimeSend = table.Column<DateTime>(nullable: false),
                    ConnectionId = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRecruitment", x => x.IdChat);
                    table.ForeignKey(
                        name: "FK_ChatRecruitment_AppUsers_IdReceiver",
                        column: x => x.IdReceiver,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatRecruitment_AppUsers_IdSender",
                        column: x => x.IdSender,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "43e89988-4bce-421a-ac4b-9d44cdb79606");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "f76bc32b-1808-436b-9046-6e183662dbce");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "62545326-d81d-4ff7-9f2c-03eff50a865e", "AQAAAAEAACcQAAAAEFMGfp9U4i2rPsnyMVrH4cuJd/oI4ihUiRNWNRKvkOi9Kyupq4bTSJO0XKzePXpj1g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dbf0552f-dd26-434a-bcba-6e24a27db1cc", "AQAAAAEAACcQAAAAEEXlvckAA83kV+x3vs2u1Eft5KmNIKB/2vAXQWkD4+VyTrltDpDHtSLTzf6mWMqY0w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "256e633a-f080-4648-8d38-65cc3fdeb919", "AQAAAAEAACcQAAAAEFESjbDUReKHWS686zUOxPmln8SR+Uw1stju3MYttvkIoppQVSDyYbQ2GADT/+XlBQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecruitment_IdReceiver",
                table: "ChatRecruitment",
                column: "IdReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecruitment_IdSender",
                table: "ChatRecruitment",
                column: "IdSender");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentJob_Recruitment_IdRecruitment",
                table: "RecruitmentJob",
                column: "IdRecruitment",
                principalTable: "Recruitment",
                principalColumn: "IdRecruitment",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentJob_Recruitment_IdRecruitment",
                table: "RecruitmentJob");

            migrationBuilder.DropTable(
                name: "ChatRecruitment");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Recruitment");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "06363ac4-5d8f-428e-943e-d6550f5fdea8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "dbe4718f-9759-49d1-a474-816fc8dcca5d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29b3c1c6-2d57-496f-84ce-c9ad6ac310b4", "AQAAAAEAACcQAAAAEFITymyw3GN1s2QfAGulQBW3KSK+QwAwY6WxjlIFH0/OaDjmA9kj+EZVTqDUTNyq2w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69905494-5772-404f-9a41-0ffc4413027d", "AQAAAAEAACcQAAAAEOr5zNOTkjzrs2RLXbsMkZWttmEJOZiYzyGdAcl4ojWT/+xsFft5VHuFWbDNgrZ/Rw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad562203-dc5b-45ef-875b-75dacbeed499", "AQAAAAEAACcQAAAAEA1C/Z5MuWIwdtnWRx0FE+xtBAM9btSLHh9osGZU89S/lq4agXCzXeF4xsLEi4z1YA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentJob_AppUsers_IdRecruitment",
                table: "RecruitmentJob",
                column: "IdRecruitment",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
