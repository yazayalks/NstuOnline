using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.EventService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NEWNEW2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "topic_attachment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId1",
                table: "topic_attachment",
                column: "AttachmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentId1",
                table: "topic_attachment",
                column: "AttachmentId1",
                principalTable: "attachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentId1",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_attachment_AttachmentId1",
                table: "topic_attachment");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "topic_attachment");
        }
    }
}
