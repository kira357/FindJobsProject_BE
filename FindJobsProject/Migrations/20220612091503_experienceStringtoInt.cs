using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class experienceStringtoInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Job",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
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
                value: "2236d83f-a02f-4688-9ac2-28359287df13");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "9f83717d-b818-4de1-96a7-c862872491ed");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c6876ef-127d-4123-ab1d-ce5fe27f42a2", "AQAAAAEAACcQAAAAEImyHxDC0wctQ1OFefPExZM++VUsuFzLdee41uB7yCRZm+DBYMqpMwpqzJoKXctXig==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a04c4905-a0b4-4e0a-887a-a81d19fba121", "AQAAAAEAACcQAAAAEFIVM4QwGcrxKYMPPUS/tfm7mDzdioqDe2LF8z6bjM9clXPEIbMh6kXqhR5tn1xrlQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0516dac-3890-4ed3-8cff-69de151d2517", "AQAAAAEAACcQAAAAEJVXhc/Exdo2KkoIduI/kXYChCnLi5UL0rKrDt+7//RvtLSM2m/dFbtUhX/I0qvTww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "38e80feb-6a44-4506-8cf6-ad61a52d6495");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "f88c892f-9f6f-408c-8141-99b0c8a5bc00");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0af10fe9-d636-4274-af09-4def29043746", "AQAAAAEAACcQAAAAEG5TfWjA8EbVFe26HToD+EeLVJXRVhL3PqYupZshePTspFeag5U/P8ozJvO5voxMvA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5644c0d-cbb1-4b85-85e5-d029717d8d50", "AQAAAAEAACcQAAAAEDX9cHx8jjr0N24bChAxZi/jazs2hHR9r8eWLkt2pmzu1EP85mSOVCLcDpP56pTSEA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44f81189-bcfd-49ae-9917-5f70141b31ee", "AQAAAAEAACcQAAAAEF9dRgmelUEhn7yjixtqB9mwWbAows7H7OheMPzaXBrtYx5gBXU8TYVdaQVEjMXTCg==" });
        }
    }
}
