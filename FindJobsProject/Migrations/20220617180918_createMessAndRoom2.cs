using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class createMessAndRoom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AppUsers_FromUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Room_IdRooom",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_AppUsers_UserCreateId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Message_FromUserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_IdRooom",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IdRooom",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_UserCreateId",
                table: "Rooms",
                newName: "IX_Rooms_UserCreateId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Message",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Message",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserCreateId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Message_IdUser",
                table: "Message",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AppUsers_IdUser",
                table: "Message",
                column: "IdUser",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Rooms_RoomId",
                table: "Message",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AppUsers_UserCreateId",
                table: "Rooms",
                column: "UserCreateId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AppUsers_IdUser",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Rooms_RoomId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AppUsers_UserCreateId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Message_IdUser",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_RoomId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_UserCreateId",
                table: "Room",
                newName: "IX_Room_UserCreateId");

            migrationBuilder.AddColumn<Guid>(
                name: "FromUserId",
                table: "Message",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRooom",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserCreateId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AppUsers_FromUserId",
                table: "Message",
                column: "FromUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Room_IdRooom",
                table: "Message",
                column: "IdRooom",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AppUsers_UserCreateId",
                table: "Room",
                column: "UserCreateId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
