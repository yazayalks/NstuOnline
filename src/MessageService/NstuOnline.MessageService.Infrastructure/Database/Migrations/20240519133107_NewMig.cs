using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.MessageService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "message",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "MessageStatusId",
                table: "message",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MessageTypeId",
                table: "message",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "message",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "chat",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "chat",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "chat",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "chat",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "chat",
                type: "timestamp with time zone",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "attachment_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Документ", "document" },
                    { (byte)2, "Фото", "photo" },
                    { (byte)3, "Голосовое", "voice" }
                });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "Диалог", "dialog" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "Беседа", "conversation" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "Беседа группы", "group_conversation" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "Code", "Name" },
                values: new object[] { "Избранное", "favorite" });

            migrationBuilder.InsertData(
                table: "chat_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
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
                name: "IX_message_MessageStatusId",
                table: "message",
                column: "MessageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_message_MessageTypeId",
                table: "message",
                column: "MessageTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_message_message_status_MessageStatusId",
                table: "message",
                column: "MessageStatusId",
                principalTable: "message_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_message_type_MessageTypeId",
                table: "message",
                column: "MessageTypeId",
                principalTable: "message_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_message_status_MessageStatusId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_message_type_MessageTypeId",
                table: "message");

            migrationBuilder.DropTable(
                name: "message_status");

            migrationBuilder.DropTable(
                name: "message_type");

            migrationBuilder.DropIndex(
                name: "IX_message_MessageStatusId",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_message_MessageTypeId",
                table: "message");

            migrationBuilder.DeleteData(
                table: "attachment_type",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "attachment_type",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "attachment_type",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "message");

            migrationBuilder.DropColumn(
                name: "MessageStatusId",
                table: "message");

            migrationBuilder.DropColumn(
                name: "MessageTypeId",
                table: "message");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "message");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "chat");

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "dialog", "Диалог" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "conversation", "Беседа" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "system_conversation", "Беседа группы" });

            migrationBuilder.UpdateData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "Code", "Name" },
                values: new object[] { "favorite", "Избранное" });
        }
    }
}
