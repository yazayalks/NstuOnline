using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.WorkCompletion.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work", x => x.Id);
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
                name: "work_completion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<byte>(type: "smallint", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_completion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_work_completion_work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "work",
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
                name: "attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkCompletionId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_attachment_work_completion_WorkCompletionId",
                        column: x => x.WorkCompletionId,
                        principalTable: "work_completion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachment_WorkCompletionId",
                table: "attachment",
                column: "WorkCompletionId");

            migrationBuilder.CreateIndex(
                name: "IX_attachment_WorkId",
                table: "attachment",
                column: "WorkId");

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
                name: "work_completion");

            migrationBuilder.DropTable(
                name: "work");

            migrationBuilder.DropTable(
                name: "work_completion_result");

            migrationBuilder.DropTable(
                name: "work_completion_status");
        }
    }
}
