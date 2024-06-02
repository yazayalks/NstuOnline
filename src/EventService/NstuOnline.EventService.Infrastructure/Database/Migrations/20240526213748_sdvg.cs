using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.EventService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class sdvg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_member_UserId",
                table: "member",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_user_UserId",
                table: "member",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_user_UserId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_UserId",
                table: "member");
        }
    }
}
