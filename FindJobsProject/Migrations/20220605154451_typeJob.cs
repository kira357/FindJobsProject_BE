using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class typeJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeJob",
                table: "Job",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AppUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "AppUsers",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "a4196a71-f070-4568-b4f0-9f73ab1e1b78", 0, "AQAAAAEAACcQAAAAEEqKWHy09F22KcQwsWviKH5Oj/guh2B2w9efFFhky/+t8OYBQJrrwIQIs86NyCYVkA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "eafa62bf-8ef7-49d4-9bd7-17b24195b5b1", 0, "AQAAAAEAACcQAAAAEELFRtGxvLQRlzoGuKvucm5Iw30HYXTOLdK5uToXEGmCgpnLVun0oC4NYWwLHH+ZcQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "bf58d989-f3fb-4307-ad63-c5235d02228c", 0, "AQAAAAEAACcQAAAAENnsWiOCcgvVt+lLJlOTfwfergiP+l6+lIK9z4wZcjujrcGiY9jjVFMqsPDxZA3Huw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeJob",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "44823b84-572c-4528-919a-6ca34ce54f12");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "f4241390-ea5e-43b8-9cdf-02a7d00eda7c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "98d99ffd-bc94-4d62-bf9a-849da4b9f76d", null, "AQAAAAEAACcQAAAAEHHgUNfJe/2iLQ/G0l5VWhBQiLrOwRCbt7uXLUJJL0TVMtZE/H27jbWSQuJ9v78aaw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "b2a2e53c-23b3-45c0-b16b-afe1db2ff3f0", null, "AQAAAAEAACcQAAAAEFD3WDgihC59VuHyNT7RsFx1HLx8tOQGwDjFMTuzzjQ0IyDpxh4QfulErFlQf4uYgQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash" },
                values: new object[] { "684d864f-568d-4d30-a763-33c3a5aead6d", null, "AQAAAAEAACcQAAAAELMRLkVOj9YDEDR6vommuAF7X3VDDs8ijngaTHpCriRktwvGzLo0A7mNJtWYuFjtFw==" });
        }
    }
}
