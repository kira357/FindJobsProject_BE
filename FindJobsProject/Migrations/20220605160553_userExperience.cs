using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class userExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "52ba51f0-f8fc-4075-922a-9edae94aebe6");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "a1dd434e-bef6-4408-9f15-e1c62076862a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4196a71-f070-4568-b4f0-9f73ab1e1b78", "AQAAAAEAACcQAAAAEEqKWHy09F22KcQwsWviKH5Oj/guh2B2w9efFFhky/+t8OYBQJrrwIQIs86NyCYVkA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eafa62bf-8ef7-49d4-9bd7-17b24195b5b1", "AQAAAAEAACcQAAAAEELFRtGxvLQRlzoGuKvucm5Iw30HYXTOLdK5uToXEGmCgpnLVun0oC4NYWwLHH+ZcQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf58d989-f3fb-4307-ad63-c5235d02228c", "AQAAAAEAACcQAAAAENnsWiOCcgvVt+lLJlOTfwfergiP+l6+lIK9z4wZcjujrcGiY9jjVFMqsPDxZA3Huw==" });
        }
    }
}
