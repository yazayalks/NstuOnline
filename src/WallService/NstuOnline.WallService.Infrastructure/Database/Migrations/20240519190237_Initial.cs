﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.WallService.Infrastructure.Database.Migrations
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
                name: "record",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_record_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_attachment_user_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "record_attachment",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_attachment", x => new { x.RecordId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_record_attachment_attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_record_attachment_record_RecordId",
                        column: x => x.RecordId,
                        principalTable: "record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "record_user",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_user", x => new { x.RecordId, x.UserId });
                    table.ForeignKey(
                        name: "FK_record_user_record_RecordId",
                        column: x => x.RecordId,
                        principalTable: "record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_record_user_record_RecordId1",
                        column: x => x.RecordId1,
                        principalTable: "record",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_record_user_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
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
                name: "IX_attachment_user_AttachmentId1",
                table: "attachment_user",
                column: "AttachmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_attachment_user_UserId",
                table: "attachment_user",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_record_UserId",
                table: "record",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_record_attachment_AttachmentId",
                table: "record_attachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_record_user_RecordId1",
                table: "record_user",
                column: "RecordId1");

            migrationBuilder.CreateIndex(
                name: "IX_record_user_UserId",
                table: "record_user",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachment_user");

            migrationBuilder.DropTable(
                name: "record_attachment");

            migrationBuilder.DropTable(
                name: "record_user");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "record");

            migrationBuilder.DropTable(
                name: "attachment_type");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
