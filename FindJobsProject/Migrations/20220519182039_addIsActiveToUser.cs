using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class addIsActiveToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "AppUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ed90f873-f437-4c4f-ad0b-c4aac771aa2e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "5977ac7c-7ccd-47ca-ac8e-aa658bee530c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9648427-2851-4c2a-a0ae-7941a8ecb393", "AQAAAAEAACcQAAAAEGKMq51wZs8pZ2XhbEPSXJg72D7GuvpUJkgAaCd1or6HdbV32jWQsFkfQFytZ9qfeg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6790caad-2e13-483e-ba68-791a65ccdc54", "AQAAAAEAACcQAAAAEE7KKeea8PkRNHkQOy/zbd4Y44MjYThxQFHnkvgztTAVCHm5hwSetldKxd58CgNnnw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7c52e21-1beb-4c1c-abbd-d7ca5dbafdd6", "AQAAAAEAACcQAAAAEF39Dy/8y81nwmYV3nCWetBnaRnS5EqfXWgvuyyVFrBBAEkhxVxX+dWRHoGHeDiRfQ==" });
        }
    }
}
