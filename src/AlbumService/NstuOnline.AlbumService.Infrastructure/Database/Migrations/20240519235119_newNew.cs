using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.AlbumService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class newNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_user_attachment_AttachmentId1",
                table: "attachment_user");

            migrationBuilder.DropIndex(
                name: "IX_attachment_user_AttachmentId1",
                table: "attachment_user");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "attachment_user");

            migrationBuilder.CreateIndex(
                name: "IX_attachment_user_UserId",
                table: "attachment_user",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_attachment_user_user_UserId",
                table: "attachment_user",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_user_user_UserId",
                table: "attachment_user");

            migrationBuilder.DropIndex(
                name: "IX_attachment_user_UserId",
                table: "attachment_user");

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "attachment_user",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachment_user_AttachmentId1",
                table: "attachment_user",
                column: "AttachmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_attachment_user_attachment_AttachmentId1",
                table: "attachment_user",
                column: "AttachmentId1",
                principalTable: "attachment",
                principalColumn: "Id");
        }
    }
}
