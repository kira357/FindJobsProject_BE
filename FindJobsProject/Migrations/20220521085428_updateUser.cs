using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AppUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c88d2606-47a3-46c5-846e-0740ff7dce05");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "635276d7-fb05-4c1b-920c-2a369a03dce2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb9cabd7-2a1d-456b-b1c7-2c5d380ede33", "AQAAAAEAACcQAAAAEMqihBrOM6PsGnMgUTNgCSj/ZUb8htmZnhZRR5c3if/qUbNiELC62wLSnH5JYKj5VA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80bdf527-6e23-49d7-9f71-460d479d764e", "AQAAAAEAACcQAAAAEIgemt6z4fb5qr/BvKLqrSX0kgVHTztDGcVFYNAlM/vChhpoWyZ7hc2CiVY9c646UA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98c3728d-dc29-421a-9f02-498f0762d184", "AQAAAAEAACcQAAAAEOTryX+cxkY5Ha82C7knIE3bxBWDy+PtGRQzKTx5Mfd94mGSFoKu1Ia+kipiFc1KoQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

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
    }
}
