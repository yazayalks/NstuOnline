using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.MessageService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_message_UserId",
                table: "message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_user_UserId",
                table: "chat_user",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_chat_user_user_UserId",
                table: "chat_user",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_UserId",
                table: "message",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_user_user_UserId",
                table: "chat_user");

            migrationBuilder.DropForeignKey(
                name: "FK_message_user_UserId",
                table: "message");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_message_UserId",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_chat_user_UserId",
                table: "chat_user");
        }
    }
}
