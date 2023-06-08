using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Projekat_DataAccess.Migrations
{
    public partial class newbloglenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BlogText",
                table: "Blogs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(258)",
                oldMaxLength: 258);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BlogText",
                table: "Blogs",
                type: "nvarchar(258)",
                maxLength: 258,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);
        }
    }
}
