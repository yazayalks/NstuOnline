using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.AlbumService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attachment_album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "attachment_user",
                columns: table => new
                {
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment_user", x => new { x.AttachmentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_attachment_user_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachment_user_attachment_AttachmentId1",
                        column: x => x.AttachmentId1,
                        principalTable: "attachment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachment_AlbumId",
                table: "attachment",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_attachment_user_AttachmentId1",
                table: "attachment_user",
                column: "AttachmentId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachment_user");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "album");
        }
    }
}
