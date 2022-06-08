using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class favouriteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    idJob = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    isLike = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    BlogIdBlog = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.idJob, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Favourites_Blog_BlogIdBlog",
                        column: x => x.BlogIdBlog,
                        principalTable: "Blog",
                        principalColumn: "IdBlog",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favourites_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Job_idJob",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2ee06a9c-db7e-44e0-8c75-ef17150d7f55");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "b6809dc7-02bf-4e18-8ef0-25d18670e08e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d8e32ef-bd43-4d7f-a686-9d80bcdea9f7", "AQAAAAEAACcQAAAAEBewcjrY4rinP5mcsDW8XljZ+YnlRNj9F4u1bFbhnIH0zNSCwf0AW0PyAzOTb1S5HQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30247ef9-670d-4a86-820d-2e04ae2aa758", "AQAAAAEAACcQAAAAEP8IeGKH4hU/iqY3cweZUVDeqG4XFuGzAYCBcgMvUMkwF2RxDJti/bdTgKykzx3FWQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24599dd3-d752-42c2-8971-d1c18277ca68", "AQAAAAEAACcQAAAAECT6r1/O4/sobwDJlar2tIuiRG4M/jXnrUV2A9q2/APQH2v0d8+6dytQECm89kXvfQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_BlogIdBlog",
                table: "Favourites",
                column: "BlogIdBlog");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_IdUser",
                table: "Favourites",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9110fae0-3817-4f9b-9301-6daae9e4537f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "2d104941-1fff-4b8a-a110-dc8d13d49b8e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fa1d284-7d2d-493d-9dc3-d79830f67e28", "AQAAAAEAACcQAAAAEDCjLHqrgO9MPibSgEP63VSzmetuYaaD91oJq3feBC1TAQzEG+ynECrmy+X87FGG2Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9dd05056-c505-4fc5-bdc2-43a54b241fdf", "AQAAAAEAACcQAAAAEK4gOo/4+XiUWUY5EJFobKwZ5zc1WtUo5dY9hI8MBl/Ibo8ULaA8dIMCGJSI4zVMfg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04179f32-b611-4a45-b2a3-e3005afd4b07", "AQAAAAEAACcQAAAAEB8O9memNgfmXUzf6iIrMB4SlEeqMnexyLbV/aYQ8JU0Lg04YdZQ9fJFXf1fXGSutg==" });
        }
    }
}
