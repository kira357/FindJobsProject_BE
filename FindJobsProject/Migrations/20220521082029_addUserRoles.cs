using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class addUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b43b4baa-e1b0-4fac-9ce8-c50bb9b7433d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "a8ec8192-94d6-416b-ba2f-2181e6c5ab5a");

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                column: "Discriminator",
                value: "IdentityUserRole<Guid>");

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") },
                column: "Discriminator",
                value: "IdentityUserRole<Guid>");

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"), new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0") },
                column: "Discriminator",
                value: "IdentityUserRole<Guid>");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "966d2af5-6820-45ec-8965-8e10d823eb95", "AQAAAAEAACcQAAAAEEre5ggYXRChVkNFg7ccgrw505pwmM5CCcvUaDstwqTurrdAoJuZQPkXx6sSamghYQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e18d7482-d1a1-4ad9-91c5-7c05374d57dc", "AQAAAAEAACcQAAAAENWD9ILgCrE0CNNClMCWiqp35B0n6kn1YCm9tkiG8fnUKLK75sOMV7FEctSk2RRqhg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "629e17d3-dbcd-49e6-aa7f-f8f3a0fbd392", "AQAAAAEAACcQAAAAEA4yD7wNvUXw4NmAjCGZ40hm19dIa5Svn2Lit0qMP+13GCXMWqBvhGlDYY8UZL9KMA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppUserRoles");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b02f02a6-be9e-435b-ac96-72b64ef852b4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "3696fdee-ca50-4142-a418-6968b9881a40");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bfa93ec1-072e-4ed8-8f64-448756e1f7fe", "AQAAAAEAACcQAAAAEM8oOuqSoHjian21NzSFyZiDK4zX1aYWwWMFTLBacffce9hD/jHCZE10E+W4M09VHg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52414b86-c56b-4d76-9e74-9d645fdfb17c", "AQAAAAEAACcQAAAAEJl/xQQGMHGR9Yl6FxdT7GqOTXEjGu7BPvzw5cK+tsl6tqELiHSfODG2EQMmaN2GHQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f02bd8ea-3960-4dd0-90bb-6f830edd3903", "AQAAAAEAACcQAAAAELwzu4Op1oQsVXtgh/hBIfVLIrxpNhpMXI7ZJsDZzBhufMUu8mIIX9ftSGgR+tCX/g==" });
        }
    }
}
