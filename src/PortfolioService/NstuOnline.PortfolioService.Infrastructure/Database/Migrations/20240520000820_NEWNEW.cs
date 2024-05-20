using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.PortfolioService.Infrastructure.Database.Migrations
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
