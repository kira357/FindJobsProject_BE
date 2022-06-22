using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class changeFK : Migration
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
                    IdChat = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                value: "09a019ac-c10c-4c94-b028-a4589fc63f5c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "c865e48e-1b62-4dfa-b038-be850c57863f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7cbefed8-5119-4cac-83e0-c09693a87840", "AQAAAAEAACcQAAAAECVi5Yfeq90+BKQZh2ou1bSIell7j60Ma6aLQ4yPidZlrrjHNkyVCpvtvO0gSc8eQA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "026df604-4075-4d4e-984d-c71ea675c5b7", "AQAAAAEAACcQAAAAEDT9ppzK/YGxO3HR8bEi0RAQLFKJKTGiQIFPNk2nyJLCdkD5c09E0aC1JcAd2twjFA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2dcc35e-0494-4e28-97b7-af366885608c", "AQAAAAEAACcQAAAAEH9K29joWRU0MvOx0a1w2ix7IbQrO0EP5b1m4UZJZxEcL+I4t1Tn+Pp55/iiD1XboA==" });

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
