using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.WorkCompletion.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_work_completion_WorkCompletionId",
                table: "attachment");

            migrationBuilder.DropIndex(
                name: "IX_attachment_WorkCompletionId",
                table: "attachment");

            migrationBuilder.DropColumn(
                name: "WorkCompletionId",
                table: "attachment");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "work",
                newName: "SyllabusSubjectId");

            migrationBuilder.AddColumn<int>(
                name: "AttemptNumber",
                table: "work_completion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "ChatStatusId",
                table: "work_completion",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "work_completion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "FavoritesId",
                table: "work_completion",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "work",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "work",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "work",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "work",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "work",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "AttachmentTypeId",
                table: "attachment",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

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
                name: "favorites",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "work_completion_chat_status",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion_chat_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "work_completion_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkCompletionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttemptNumber = table.Column<int>(type: "integer", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<byte>(type: "smallint", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_work_completion_history_work_completion_WorkCompletionId",
                        column: x => x.WorkCompletionId,
                        principalTable: "work_completion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_work_completion_history_work_completion_result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "work_completion_result",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_work_completion_history_work_completion_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "work_completion_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "attachment_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { (byte)1, "document", "Документ" });

            migrationBuilder.InsertData(
                table: "favorites",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "do_it_later", "Сделать позже" },
                    { (byte)2, "check_later", "Проверить позже" },
                    { (byte)3, "specify", "Уточнить" },
                    { (byte)4, "agree", "Соглосовать" }
                });

            migrationBuilder.InsertData(
                table: "work_completion_chat_status",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "no_chat", "Нет диалога" },
                    { (byte)2, "new_message", "Новое сообщение" },
                    { (byte)3, "read", "Прочитано" },
                    { (byte)4, "sent", "Отправлено" },
                    { (byte)5, "awaiting_response", "Ожидает ответа" }
                });

            migrationBuilder.InsertData(
                table: "work_completion_status",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "not_issued", "Не выдано" },
                    { (byte)2, "issued", "Выдано" },
                    { (byte)3, "in_progress", "В работе" },
                    { (byte)4, "awaiting_review", "Ожидает проверки" },
                    { (byte)5, "under_review", "На проверке" },
                    { (byte)6, "returned", "Возвращена" },
                    { (byte)7, "completed", "Выполнена" },
                    { (byte)8, "not_completed", "Не выполнена" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_ChatStatusId",
                table: "work_completion",
                column: "ChatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_FavoritesId",
                table: "work_completion",
                column: "FavoritesId");

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
                name: "IX_favorites_Code",
                table: "favorites",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_favorites_Name",
                table: "favorites",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_chat_status_Code",
                table: "work_completion_chat_status",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_chat_status_Name",
                table: "work_completion_chat_status",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_history_ResultId",
                table: "work_completion_history",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_history_StatusId",
                table: "work_completion_history",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_history_WorkCompletionId",
                table: "work_completion_history",
                column: "WorkCompletionId");

            migrationBuilder.AddForeignKey(
                name: "FK_attachment_attachment_type_AttachmentTypeId",
                table: "attachment",
                column: "AttachmentTypeId",
                principalTable: "attachment_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_work_completion_favorites_FavoritesId",
                table: "work_completion",
                column: "FavoritesId",
                principalTable: "favorites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_work_completion_work_completion_chat_status_ChatStatusId",
                table: "work_completion",
                column: "ChatStatusId",
                principalTable: "work_completion_chat_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachment_attachment_type_AttachmentTypeId",
                table: "attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_work_completion_favorites_FavoritesId",
                table: "work_completion");

            migrationBuilder.DropForeignKey(
                name: "FK_work_completion_work_completion_chat_status_ChatStatusId",
                table: "work_completion");

            migrationBuilder.DropTable(
                name: "attachment_type");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "work_completion_chat_status");

            migrationBuilder.DropTable(
                name: "work_completion_history");

            migrationBuilder.DropIndex(
                name: "IX_work_completion_ChatStatusId",
                table: "work_completion");

            migrationBuilder.DropIndex(
                name: "IX_work_completion_FavoritesId",
                table: "work_completion");

            migrationBuilder.DropIndex(
                name: "IX_attachment_AttachmentTypeId",
                table: "attachment");

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "work_completion_status",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DropColumn(
                name: "AttemptNumber",
                table: "work_completion");

            migrationBuilder.DropColumn(
                name: "ChatStatusId",
                table: "work_completion");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "work_completion");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "work_completion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "work");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "work");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "work");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "work");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "work");

            migrationBuilder.DropColumn(
                name: "AttachmentTypeId",
                table: "attachment");

            migrationBuilder.RenameColumn(
                name: "SyllabusSubjectId",
                table: "work",
                newName: "SubjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkCompletionId",
                table: "attachment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachment_WorkCompletionId",
                table: "attachment",
                column: "WorkCompletionId");

            migrationBuilder.AddForeignKey(
                name: "FK_attachment_work_completion_WorkCompletionId",
                table: "attachment",
                column: "WorkCompletionId",
                principalTable: "work_completion",
                principalColumn: "Id");
        }
    }
}
