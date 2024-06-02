using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "message_status",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "message_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_type", x => x.Id);
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
                    ChatTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_chat_user_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MessageStatusId = table.Column<byte>(type: "smallint", nullable: false),
                    MessageTypeId = table.Column<byte>(type: "smallint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_message_message_ParentId",
                        column: x => x.ParentId,
                        principalTable: "message",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_message_message_status_MessageStatusId",
                        column: x => x.MessageStatusId,
                        principalTable: "message_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_message_type_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "message_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
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

            migrationBuilder.InsertData(
                table: "attachment_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Документ", "document" },
                    { (byte)2, "Фото", "photo" },
                    { (byte)3, "Голосовое", "voice" }
                });

            migrationBuilder.InsertData(
                table: "chat_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Диалог", "dialog" },
                    { (byte)2, "Беседа", "conversation" },
                    { (byte)3, "Беседа группы", "group_conversation" },
                    { (byte)4, "Избранное", "favorite" },
                    { (byte)5, "Беседа по дисциплине", "subject_conversation" },
                    { (byte)6, "Диалог по работе", "work_dialog" }
                });

            migrationBuilder.InsertData(
                table: "message_status",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Отправленно", "sent" },
                    { (byte)2, "Прочитанно", "read" }
                });

            migrationBuilder.InsertData(
                table: "message_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Текст", "text" },
                    { (byte)2, "Вложения", "attachments" },
                    { (byte)3, "Текст и вложения", "text_and_attachments" },
                    { (byte)4, "Фото", "photo" },
                    { (byte)5, "Голосовое", "voice" }
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
                name: "IX_chat_user_UserId",
                table: "chat_user",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ChatId",
                table: "message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_message_MessageStatusId",
                table: "message",
                column: "MessageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_message_MessageTypeId",
                table: "message",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ParentId",
                table: "message",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_message_UserId",
                table: "message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_AttachmentId",
                table: "message_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachment_AttachmentsId",
                table: "message_attachment",
                column: "AttachmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_message_status_Code",
                table: "message_status",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_message_type_Code",
                table: "message_type",
                column: "Code",
                unique: true);
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
                name: "message_status");

            migrationBuilder.DropTable(
                name: "message_type");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "chat_type");
        }
    }
}
