using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.AlbumService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class sgsdg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_album_UserId",
                table: "album",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_album_user_UserId",
                table: "album",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_album_user_UserId",
                table: "album");

            migrationBuilder.DropIndex(
                name: "IX_album_UserId",
                table: "album");
        }
    }
}
