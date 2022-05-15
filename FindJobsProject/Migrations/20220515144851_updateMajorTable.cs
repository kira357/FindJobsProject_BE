using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class updateMajorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Majors_UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserMajorIdMajor",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0996ae87-4649-4011-8177-6bada5295859");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "5dbe8c2c-897f-460e-bdec-2505e58d41ce");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f247932-c00a-43e5-ad35-871dd82d053e", "AQAAAAEAACcQAAAAEMgYx142l6/ityR66EEm7eESYT3T7OKWK7ZqMUk+O+u/A9XjsejIM3qduUi4lmEadg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3c6f61b-17b7-49a9-80a1-f5d6aff52bb2", "AQAAAAEAACcQAAAAEDjze0pvn9hpac2TqoTBQlrRMtInSc8ONE/jwd1ygvRNaoBixxvKMF/HDOz/cYfr1g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9a7725c-239e-4bf4-b127-c68911dc33b5", "AQAAAAEAACcQAAAAECES8x+8pq7DjPOKuHeRVhw7DoyBtfogkI+WrCbdwdVOV3DQJ8UwpkVDlUpwlFCgog==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_IdMajor",
                table: "AppUsers",
                column: "IdMajor");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Majors_IdMajor",
                table: "AppUsers",
                column: "IdMajor",
                principalTable: "Majors",
                principalColumn: "IdMajor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Majors_IdMajor",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_IdMajor",
                table: "AppUsers");

            migrationBuilder.AddColumn<long>(
                name: "UserMajorIdMajor",
                table: "AppUsers",
                type: "bigint",
                nullable: true);

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
    }
}
