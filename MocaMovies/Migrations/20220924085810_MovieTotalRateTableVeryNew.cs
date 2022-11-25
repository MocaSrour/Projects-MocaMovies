using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MocaMovies.Migrations
{
    public partial class MovieTotalRateTableVeryNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies_Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<double>(type: "float", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Rates_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Rates_MovieId",
                table: "Movies_Rates",
                column: "MovieId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies_Rates");
        }
    }
}
