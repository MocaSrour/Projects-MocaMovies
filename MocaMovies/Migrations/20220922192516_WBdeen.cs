using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MocaMovies.Migrations
{
    public partial class WBdeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MovieRate",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieRate",
                table: "Movies");
        }
    }
}
