using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MocaMovies.Migrations
{
    public partial class TRYRAting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingMoviesByUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingMoviesByUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingMoviesByUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatingMoviesByUsers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieVideos_MovieId",
                table: "movieVideos",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatingMoviesByUsers_MovieId",
                table: "RatingMoviesByUsers",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingMoviesByUsers_UserId",
                table: "RatingMoviesByUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_movieVideos_Movies_MovieId",
                table: "movieVideos",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movieVideos_Movies_MovieId",
                table: "movieVideos");

            migrationBuilder.DropTable(
                name: "RatingMoviesByUsers");

            migrationBuilder.DropIndex(
                name: "IX_movieVideos_MovieId",
                table: "movieVideos");
        }
    }
}
