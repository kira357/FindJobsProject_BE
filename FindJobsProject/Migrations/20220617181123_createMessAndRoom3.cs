using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class createMessAndRoom3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f68a401d-dc33-4149-ab39-2c791a74554f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "9e10f460-ac42-4dc7-8e41-4b177531df4d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a99cf48-f68f-44c1-a7dd-5d004c61de20", "AQAAAAEAACcQAAAAEM0eAL2BtD+kTun7en07+NVAJcYdvYutOdRUoODa6HdVIxtZ70E+8gIy0+Ip0e6DWw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4faca5ee-9936-413c-b863-c521e5a19e58", "AQAAAAEAACcQAAAAEAKqQZhMEFox21PpN/xN28UAe45lUaXhLZpR1AnhsdLUc54msNa1bQHwowqzg7m1tg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a22f38fb-0597-4169-815c-f2418f220641", "AQAAAAEAACcQAAAAEErQghdSMPJHqJuGVeJjXqMpBlJtzn6GTJFKs8FrXz38NrWhY+Y3UjeUI7bzj8Qdeg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b2c4ef29-d4a1-45be-b20d-58c53a1594a0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "f6c0f003-f283-4381-8ce3-e89fbced1afc");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2243129b-00e2-401f-a74a-8340c39e7bb7", "AQAAAAEAACcQAAAAEDYXkMTNSRP6cbOqOzRkv24gmha0iIednLlSBMKfl0ciayDtEbrNu+D0crtl0hY7yQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "533e891a-39b4-4910-9cb2-64a6c5e0498e", "AQAAAAEAACcQAAAAEEn+43Y+Hk5LvYbQpnlNof8UCMW5oZQqsDlufutSyfxU7GEcwwRchvqCH7173tjAVA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9d79f90-b7f0-4447-8892-2e82884d216c", "AQAAAAEAACcQAAAAEETl4rsSN1tg6lFiODDFmqoZFLq3TcxDnSRlJTt8x/jzEe1k2mTTvINxOT8QpBI8pg==" });
        }
    }
}
