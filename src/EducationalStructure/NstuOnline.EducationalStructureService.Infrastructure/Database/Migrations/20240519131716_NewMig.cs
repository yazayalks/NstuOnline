using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.EducationalStructure.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "group",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                name: "topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "topic_attachment",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic_attachment", x => new { x.TopicId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_topic_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topic_attachment_attachment_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topic_attachment_topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "attachment_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "document", "Документ" },
                    { (byte)2, "photo", "Фото" }
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
                name: "IX_topic_SubjectId",
                table: "topic",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId",
                table: "topic_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentsId",
                table: "topic_attachment",
                column: "AttachmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "topic_attachment");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "attachment_type");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "group");
        }
    }
}
