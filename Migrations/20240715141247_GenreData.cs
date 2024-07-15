using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroductionToEFCoreENG.Migrations
{
    /// <inheritdoc />
    public partial class GenreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Actors_ActorId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.RenameTable(
                name: "MovieActor",
                newName: "MoviesActors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActor_MovieId",
                table: "MoviesActors",
                newName: "IX_MoviesActors_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Identifier", "Id", "Name" },
                values: new object[,]
                {
                    { 5, 0, "Science Fiction" },
                    { 6, 0, "Animation" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Actors_ActorId",
                table: "MoviesActors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Actors_ActorId",
                table: "MoviesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Identifier",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Identifier",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "MoviesActors",
                newName: "MovieActor");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActors_MovieId",
                table: "MovieActor",
                newName: "IX_MovieActor_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Actors_ActorId",
                table: "MovieActor",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
