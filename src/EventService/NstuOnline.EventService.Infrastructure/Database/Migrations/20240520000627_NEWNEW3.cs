using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.EventService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NEWNEW3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topic_event_EventId1",
                table: "topic");

            migrationBuilder.DropForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentId1",
                table: "topic_attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_topic_attachment_topic_TopicId1",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_attachment_AttachmentId1",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_attachment_TopicId1",
                table: "topic_attachment");

            migrationBuilder.DropIndex(
                name: "IX_topic_EventId1",
                table: "topic");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "topic_attachment");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "topic_attachment");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "topic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId1",
                table: "topic_attachment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId1",
                table: "topic_attachment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventId1",
                table: "topic",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId1",
                table: "topic_attachment",
                column: "AttachmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_TopicId1",
                table: "topic_attachment",
                column: "TopicId1");

            migrationBuilder.CreateIndex(
                name: "IX_topic_EventId1",
                table: "topic",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_event_EventId1",
                table: "topic",
                column: "EventId1",
                principalTable: "event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_attachment_attachment_AttachmentId1",
                table: "topic_attachment",
                column: "AttachmentId1",
                principalTable: "attachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_attachment_topic_TopicId1",
                table: "topic_attachment",
                column: "TopicId1",
                principalTable: "topic",
                principalColumn: "Id");
        }
    }
}
