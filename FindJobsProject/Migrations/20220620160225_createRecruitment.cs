using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class createRecruitment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruitment",
                columns: table => new
                {
                    IdRecruitment = table.Column<Guid>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    NameCompany = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    TypeCompany = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    TypeOfWork = table.Column<long>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitment", x => x.IdRecruitment);
                    table.ForeignKey(
                        name: "FK_Recruitment_AppUsers_IdRecruitment",
                        column: x => x.IdRecruitment,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruitment");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f68a401d-dc33-4149-ab39-2c791a74554f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "9e10f460-ac42-4dc7-8e41-4b177531df4d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a99cf48-f68f-44c1-a7dd-5d004c61de20", "AQAAAAEAACcQAAAAEM0eAL2BtD+kTun7en07+NVAJcYdvYutOdRUoODa6HdVIxtZ70E+8gIy0+Ip0e6DWw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4faca5ee-9936-413c-b863-c521e5a19e58", "AQAAAAEAACcQAAAAEAKqQZhMEFox21PpN/xN28UAe45lUaXhLZpR1AnhsdLUc54msNa1bQHwowqzg7m1tg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a22f38fb-0597-4169-815c-f2418f220641", "AQAAAAEAACcQAAAAEErQghdSMPJHqJuGVeJjXqMpBlJtzn6GTJFKs8FrXz38NrWhY+Y3UjeUI7bzj8Qdeg==" });
        }
    }
}
