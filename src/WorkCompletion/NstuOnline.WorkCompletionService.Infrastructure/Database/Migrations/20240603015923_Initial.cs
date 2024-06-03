using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.WorkCompletion.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SyllabusSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work", x => x.Id);
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
                name: "work_completion_result",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Percent = table.Column<byte>(type: "smallint", nullable: true),
                    Mark = table.Column<byte>(type: "smallint", nullable: true),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion_result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "work_completion_status",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attachment_work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "work",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "work_completion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AttemptNumber = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<byte>(type: "smallint", nullable: false),
                    ChatStatusId = table.Column<byte>(type: "smallint", nullable: false),
                    FavoritesId = table.Column<byte>(type: "smallint", nullable: true),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_work_completion_favorites_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "favorites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_work_completion_work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_work_completion_work_completion_chat_status_ChatStatusId",
                        column: x => x.ChatStatusId,
                        principalTable: "work_completion_chat_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_work_completion_work_completion_result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "work_completion_result",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_work_completion_work_completion_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "work_completion_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_attachment_ExternalId",
                table: "attachment",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachment_WorkId",
                table: "attachment",
                column: "WorkId");

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
                name: "IX_work_ExternalId",
                table: "work",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_ChatStatusId",
                table: "work_completion",
                column: "ChatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_ExternalId",
                table: "work_completion",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_FavoritesId",
                table: "work_completion",
                column: "FavoritesId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_ResultId",
                table: "work_completion",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_StatusId",
                table: "work_completion",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_WorkId",
                table: "work_completion",
                column: "WorkId");

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

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_status_Code",
                table: "work_completion_status",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_completion_status_Name",
                table: "work_completion_status",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "work_completion_history");

            migrationBuilder.DropTable(
                name: "work_completion");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "work");

            migrationBuilder.DropTable(
                name: "work_completion_chat_status");

            migrationBuilder.DropTable(
                name: "work_completion_result");

            migrationBuilder.DropTable(
                name: "work_completion_status");
        }
    }
}
