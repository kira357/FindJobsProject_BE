using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class createChatRecruitment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
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
                value: "b35bcbfe-29cc-4131-9689-8e756113a25f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "39ac8e82-15a5-4052-8ff6-ddc98a69173b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15bb50be-d802-4e76-9a4d-4381cd44b3e0", "AQAAAAEAACcQAAAAEOMlhPXOA074EYlljNt4qiOw3X7axk79VINok9L56w4xQC1qLv5XZaHjuojALq1lVg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8122d41b-fb03-4631-b12f-d6cd41f37ed0", "AQAAAAEAACcQAAAAEG8ap+RV+1SYOGJ6v3A+vMFYIoMxhXUbc1ftegP+ybOLTOD67xCf2m4zVVoylzLXkA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b6de297-0877-4abe-b31e-060546f8f49b", "AQAAAAEAACcQAAAAEPcQymoBMKyoq+EHkKm/sU4atvcYKXvekgdTCbASsHb3gEUT4fvYdzqirbFdyWE+9g==" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecruitment_IdReceiver",
                table: "ChatRecruitment",
                column: "IdReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecruitment_IdSender",
                table: "ChatRecruitment",
                column: "IdSender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRecruitment");

            migrationBuilder.DropColumn(
                name: "Descriptions",
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
        }
    }
}
