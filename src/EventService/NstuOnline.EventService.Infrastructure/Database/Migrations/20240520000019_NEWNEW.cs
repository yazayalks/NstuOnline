using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.EventService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NEWNEW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentsId",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_attachment_AttachmentsId",
                table: "topic_attachment");

            migrationBuilder.DropColumn(
                name: "AttachmentsId",
                table: "topic_attachment");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId1",
                table: "topic_attachment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_TopicId1",
                table: "topic_attachment",
                column: "TopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_attachment_topic_TopicId1",
                table: "topic_attachment",
                column: "TopicId1",
                principalTable: "topic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topic_attachment_topic_TopicId1",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_attachment_TopicId1",
                table: "topic_attachment");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "topic_attachment");

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentsId",
                table: "topic_attachment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentsId",
                table: "topic_attachment",
                column: "AttachmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentsId",
                table: "topic_attachment",
                column: "AttachmentsId",
                principalTable: "attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
