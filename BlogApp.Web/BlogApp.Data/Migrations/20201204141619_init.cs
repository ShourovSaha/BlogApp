using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    UserName = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 250, nullable: false),
                    UserName = table.Column<string>(maxLength: 10, nullable: false),
                    Like = table.Column<int>(nullable: false),
                    Dislike = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    PostId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_Comments_Posts_PostId1",
                    //    column: x => x.PostId1,
                    //    principalTable: "Posts",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Created", "Title", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 1", "Admin" },
                    { 2, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 2", "Admin" },
                    { 3, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 3", "Admin" },
                    { 4, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 4", "User 1" },
                    { 5, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 5", "User 2" },
                    { 6, new DateTime(2020, 12, 4, 14, 16, 18, 775, DateTimeKind.Utc), "Post 6", "User 3" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Created", "Dislike", "Like", "PostId", "PostId1", "Text", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 3, 12, 1, null, "Test comment.", "User 1" },
                    { 3, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 1, 7, 2, null, "Test comment.", "User 3" },
                    { 2, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 5, 10, 3, null, "Test comment.", "User 2" },
                    { 4, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 2, 14, 3, null, "Test comment.", "Admin" },
                    { 5, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 2, 2, 5, null, "Test comment.", "User 1" },
                    { 6, new DateTime(2020, 12, 4, 14, 16, 18, 776, DateTimeKind.Utc), 1, 5, 6, null, "Test comment.", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId1",
                table: "Comments",
                column: "PostId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
