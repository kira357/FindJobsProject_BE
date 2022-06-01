using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class addPendingDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CandidateJob",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "CandidateJob",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98d99ffd-bc94-4d62-bf9a-849da4b9f76d", "AQAAAAEAACcQAAAAEHHgUNfJe/2iLQ/G0l5VWhBQiLrOwRCbt7uXLUJJL0TVMtZE/H27jbWSQuJ9v78aaw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2a2e53c-23b3-45c0-b16b-afe1db2ff3f0", "AQAAAAEAACcQAAAAEFD3WDgihC59VuHyNT7RsFx1HLx8tOQGwDjFMTuzzjQ0IyDpxh4QfulErFlQf4uYgQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "684d864f-568d-4d30-a763-33c3a5aead6d", "AQAAAAEAACcQAAAAELMRLkVOj9YDEDR6vommuAF7X3VDDs8ijngaTHpCriRktwvGzLo0A7mNJtWYuFjtFw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CandidateJob");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "CandidateJob");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6e35ae24-0514-41d6-ab7e-bdef48a49491");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "a8b12395-193e-4684-b0bd-7f7307eec9a2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41ebb12d-b385-4ac7-a684-97f72a6636bf", "AQAAAAEAACcQAAAAEA3CzsNMX2qSMSLZV6aINvPFqrv7kkpEhmQsAiJyFWSNlICIHd+9jFbmgIewXGJ4jg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6bcc7df-6b5c-46b1-8f3c-97119d41bc93", "AQAAAAEAACcQAAAAEFiPD3NprBDtjLGHRreEWw9e+fNOJa9+DTf1U1eJa2ECqo7WQUkFihr7WovpN+uMjg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e822c9c-826e-4be0-aeae-268b065ea20f", "AQAAAAEAACcQAAAAEH1izaH+Y9z/BW0rDPJvRJNWBAMKW5/QG7WXvEyxJuNxDyoI3H2PyFVuhjPpl9ep4g==" });
        }
    }
}
