using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.EventService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "event_status",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "event_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "member_status",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member_status", x => x.Id);
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
                name: "event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    EventTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    EventStatusId = table.Column<byte>(type: "smallint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_event_status_EventStatusId",
                        column: x => x.EventStatusId,
                        principalTable: "event_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_event_type_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "event_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberStatusId = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_member_member_status_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "member_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_member_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_member",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_member", x => new { x.EventId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_event_member_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_member_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic_attachment",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_topic_attachment_topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "event_status",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "pending", "В ожидании" },
                    { (byte)2, "started", "Началось" },
                    { (byte)3, "ended", "Закончилось" }
                });

            migrationBuilder.InsertData(
                table: "event_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "olympics", "Олимпиада" },
                    { (byte)2, "hackathon", "Хакатон" },
                    { (byte)3, "conference", "Конференция" },
                    { (byte)4, "holiday", "Праздник" },
                    { (byte)5, "concert", "Концерт" }
                });

            migrationBuilder.InsertData(
                table: "member_status",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "go", "Пойду" },
                    { (byte)2, "maybe_go", "Возможно пойду" },
                    { (byte)3, "assigned", "Назначено" },
                    { (byte)4, "not_go", "Не пойду" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_EventStatusId",
                table: "event",
                column: "EventStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_event_EventTypeId",
                table: "event",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_event_member_MemberId",
                table: "event_member",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_event_status_Code",
                table: "event_status",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_type_Code",
                table: "event_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_member_MemberStatusId",
                table: "member",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_member_UserId",
                table: "member",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_member_status_Code",
                table: "member_status",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_EventId",
                table: "topic",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId",
                table: "topic_attachment",
                column: "AttachmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_member");

            migrationBuilder.DropTable(
                name: "topic_attachment");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "member_status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "event_status");

            migrationBuilder.DropTable(
                name: "event_type");
        }
    }
}
