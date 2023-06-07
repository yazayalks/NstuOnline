using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.MessageService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachment_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chat_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentTypeId = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attachment_attachment_type_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "attachment_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ChatTypeId = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chat_chat_type_ChatTypeId",
                        column: x => x.ChatTypeId,
                        principalTable: "chat_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_user",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_user", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_chat_user_chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message_attachment",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_attachment", x => new { x.MessageId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_message_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_attachment_attachment_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_attachment_message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachment_AttachmentTypeId",
                table: "attachment",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_attachment_type_Code",
                table: "attachment_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chat_ChatTypeId",
                table: "chat",
                column: "ChatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_type_Code",
                table: "chat_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_message_ChatId",
                table: "message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_AttachmentId",
                table: "message_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_AttachmentsId",
                table: "message_attachment",
                column: "AttachmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_user");

            migrationBuilder.DropTable(
                name: "message_attachment");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "attachment_type");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "chat_type");
        }
    }
}
