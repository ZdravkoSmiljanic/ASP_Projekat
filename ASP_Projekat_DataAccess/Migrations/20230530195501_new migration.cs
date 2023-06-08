using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Projekat_DataAccess.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogReactions",
                table: "BlogReactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogReactions",
                table: "BlogReactions",
                columns: new[] { "ReactionId", "BlogId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogReactions",
                table: "BlogReactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogReactions",
                table: "BlogReactions",
                columns: new[] { "ReactionId", "BlogId" });
        }
    }
}
