using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.WallService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_user_attachment_AttachmentId1",
                table: "attachment_user");

            migrationBuilder.DropForeignKey(
                name: "FK_record_user_record_RecordId1",
                table: "record_user");

            migrationBuilder.DropIndex(
                name: "IX_record_user_RecordId1",
                table: "record_user");

            migrationBuilder.DropIndex(
                name: "IX_attachment_user_AttachmentId1",
                table: "attachment_user");

            migrationBuilder.DropColumn(
                name: "RecordId1",
                table: "record_user");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "attachment_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecordId1",
                table: "record_user",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "attachment_user",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_user_RecordId1",
                table: "record_user",
                column: "RecordId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_record_user_record_RecordId1",
                table: "record_user",
                column: "RecordId1",
                principalTable: "record",
                principalColumn: "Id");
        }
    }
}
