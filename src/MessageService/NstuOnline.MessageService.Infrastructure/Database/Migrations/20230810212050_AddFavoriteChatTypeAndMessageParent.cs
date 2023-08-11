using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.MessageService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteChatTypeAndMessageParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "message",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "chat_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { (byte)4, "favorite", "Избранное" });

            migrationBuilder.CreateIndex(
                name: "IX_message_ParentId",
                table: "message",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_message_message_ParentId",
                table: "message",
                column: "ParentId",
                principalTable: "message",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_message_ParentId",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_message_ParentId",
                table: "message");

            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "message");
        }
    }
}
