using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Projekat_DataAccess.Migrations
{
    public partial class newfkblogcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_UserId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
