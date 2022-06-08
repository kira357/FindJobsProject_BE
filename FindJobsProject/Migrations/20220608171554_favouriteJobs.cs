using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindJobsProject.Migrations
{
    public partial class favouriteJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Blog_BlogIdBlog",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_BlogIdBlog",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "BlogIdBlog",
                table: "Favourites");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5347a0ae-fc5b-416d-802b-aac05ecae4cc");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "8f328806-0a77-4927-b7c9-9a7e0e340c44");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3486a40b-1930-4223-8927-0a363c25f8fa", "AQAAAAEAACcQAAAAEAnW15WS6fItuK+mk3oxQv8lIqQVomEVrf34qO9AmE8byjlldx37Mtky8hB5uM6/Cw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "490d2e5e-e968-4588-972d-6da4a225ec57", "AQAAAAEAACcQAAAAENASpiDKu7AgvF8E8VISy7g6LMOlLe+/LcnKSAbLQz8St6eOsTRMRqVGOGPzu16jkg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8116a1a-19d2-4088-9d05-6321edd62685", "AQAAAAEAACcQAAAAEAXHlCsAwSa0fP4X3tnDZlDmxQ7sTSm5KZo9cq+DKH8PWNjFQ4It1wpcZhXrlZAI5Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlogIdBlog",
                table: "Favourites",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2ee06a9c-db7e-44e0-8c75-ef17150d7f55");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f52734c6-4614-4bc8-894a-8feeab71bef0"),
                column: "ConcurrencyStamp",
                value: "b6809dc7-02bf-4e18-8ef0-25d18670e08e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d8e32ef-bd43-4d7f-a686-9d80bcdea9f7", "AQAAAAEAACcQAAAAEBewcjrY4rinP5mcsDW8XljZ+YnlRNj9F4u1bFbhnIH0zNSCwf0AW0PyAzOTb1S5HQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bc1bf33-d875-42b2-a39e-b0cfc3fb6f2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30247ef9-670d-4a86-820d-2e04ae2aa758", "AQAAAAEAACcQAAAAEP8IeGKH4hU/iqY3cweZUVDeqG4XFuGzAYCBcgMvUMkwF2RxDJti/bdTgKykzx3FWQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24599dd3-d752-42c2-8971-d1c18277ca68", "AQAAAAEAACcQAAAAECT6r1/O4/sobwDJlar2tIuiRG4M/jXnrUV2A9q2/APQH2v0d8+6dytQECm89kXvfQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_BlogIdBlog",
                table: "Favourites",
                column: "BlogIdBlog");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Blog_BlogIdBlog",
                table: "Favourites",
                column: "BlogIdBlog",
                principalTable: "Blog",
                principalColumn: "IdBlog",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
