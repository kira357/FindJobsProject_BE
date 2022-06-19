using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class createMessAndRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UserCreateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_AppUsers_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Msg = table.Column<string>(maxLength: 500, nullable: false),
                    DateSend = table.Column<DateTime>(nullable: false),
                    IdRooom = table.Column<int>(nullable: false),
                    FromUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AppUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Room_IdRooom",
                        column: x => x.IdRooom,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f4b994fa-4b0c-450d-917f-6d34b9caba79");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "5d932d09-872d-4490-8c0c-bdc754044dd2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb81a458-7408-4d40-b269-5ebf1762bfd3", "AQAAAAEAACcQAAAAEDL5iwmQ4llzjYFnXdFXdRZdk7XV9aeUTRAFAZWRkrMVtvWuf2obb+sYxn0oG8O5/A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b680d1e6-6d6b-402a-a706-e3acb8d82120", "AQAAAAEAACcQAAAAEJF5n5BWgyOS73r2T8XAn2iwNwqnmqknjkrYHYP1oucGptajxiba39tQAu35J45SsA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5e0b2bb-5481-4922-be08-2df8f62ce299", "AQAAAAEAACcQAAAAEOYHR2oya9ZNP2XsHsOd/n2Qbo3rmTidXc9IzuUCzSvc3/i19/5JCtohxmBUNVjs8w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserId",
                table: "Message",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_IdRooom",
                table: "Message",
                column: "IdRooom");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserCreateId",
                table: "Room",
                column: "UserCreateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Room");

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
    }
}
