using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Projekat_DataAccess.Migrations
{
    public partial class updatatableblogReactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BlogReactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BlogReactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReactedAt",
                table: "BlogReactions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BlogReactions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BlogReactions");

            migrationBuilder.DropColumn(
                name: "ReactedAt",
                table: "BlogReactions");
        }
    }
}
