using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class blogCommentAndReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AppUsers_UserId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "TItle",
                table: "Blog",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePost",
                table: "Blog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HotPost",
                table: "Blog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Blog",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NameMajor",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CommentId",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentMsg = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentOn = table.Column<string>(nullable: true),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdPosition = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyComment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyMsg = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IdUser = table.Column<Guid>(nullable: true),
                    IdComment = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyComment_Comment_IdComment",
                        column: x => x.IdComment,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyComment_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Blog_IdUser",
                table: "Blog",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CommentId",
                table: "AppUsers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdUser",
                table: "Comment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_IdComment",
                table: "ReplyComment",
                column: "IdComment");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_IdUser",
                table: "ReplyComment",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Comment_CommentId",
                table: "AppUsers",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AppUsers_IdUser",
                table: "Blog",
                column: "IdUser",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Comment_CommentId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AppUsers_IdUser",
                table: "Blog");

            migrationBuilder.DropTable(
                name: "ReplyComment");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Blog_IdUser",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CommentId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DatePost",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "HotPost",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "NameMajor",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "View",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blog",
                newName: "TItle");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Blog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AppUsers_UserId",
                table: "Blog",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
