using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class addMajorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "AppUsers");

            migrationBuilder.AddColumn<long>(
                name: "IdMajor",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserMajorIdMajor",
                table: "AppUsers",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a2ad3bb9-7102-46b1-9cd8-2f93ec6e2461");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "1e707fa2-7ccf-47ae-aaea-ab3e351260dc");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "77fdd176-35ec-4eee-ae33-5bf69af1f3a3", "AQAAAAEAACcQAAAAEHEBU9weNMjaRgIaGfIkOV9pigc+FMpnzMsVDx6Qa02bJY2zXNudAzVJGsv9ZnKh4w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8126a0f-8f0e-4d43-bb3e-8f1590a896eb", "AQAAAAEAACcQAAAAEIVvG2QxcrH6n7R4UHzPdvD1+MoGltDc/02vw0HL3SnmiJ4fw8BI7PUVe7Dxg76D4Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5e7d599-1cd7-4da7-b1eb-1faca8de7456", "AQAAAAEAACcQAAAAEE4Lvr5JmgSuFNFjcKn/WaJ00ilgGi4CZgQOXGSUco13BUlk0kArP9xjiIwOpBK+lg==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserMajorIdMajor",
                table: "AppUsers",
                column: "UserMajorIdMajor");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Majors_UserMajorIdMajor",
                table: "AppUsers",
                column: "UserMajorIdMajor",
                principalTable: "Majors",
                principalColumn: "IdMajor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Majors_UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IdMajor",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0e5662e7-3d50-4ceb-9be2-38812bbb1d66");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "9c0683db-6653-450c-bc20-8dc219d68a0e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28b10448-92fa-4b08-ab06-0b7ce69c3edd", "AQAAAAEAACcQAAAAECLpA5/XcoXw4/HZIu4ITIoMAGyKaVD62FUYtyg84NgwQ4uZC4XVFKev900tNaih3Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "446f526d-0d0d-4e20-a262-be4ccd3687eb", "AQAAAAEAACcQAAAAECcp5Xf7OonwWR0zZpXgjPHSiY9ys5iTnPhaoOwo/gj+t8RQWNvv4xO0WQXYkBA0vg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ee2f5a0-5bc7-43ea-ba96-2ed62af4e174", "AQAAAAEAACcQAAAAED4X38QnsXMxDrFOP2sQ2DCQAKjdmH/cwfn1veTh4qJcMUYOQKQleiWAcDWSlyWPCw==" });
        }
    }
}
