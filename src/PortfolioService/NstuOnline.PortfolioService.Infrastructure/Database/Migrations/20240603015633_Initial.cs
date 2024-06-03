using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.PortfolioService.Infrastructure.Database.Migrations
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
                name: "portfolio_type",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_type", x => x.Id);
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
                name: "portfolio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    PortfolioTypeId = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolio_portfolio_type_PortfolioTypeId",
                        column: x => x.PortfolioTypeId,
                        principalTable: "portfolio_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_user",
                columns: table => new
                {
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_user", x => new { x.PortfolioId, x.UserId });
                    table.ForeignKey(
                        name: "FK_portfolio_user_portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portfolio_user_user_UserId",
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
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolio",
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
                table: "portfolio_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "educational", "Учебное" },
                    { (byte)2, "personal", "Личное" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_PortfolioTypeId",
                table: "portfolio",
                column: "PortfolioTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_type_Code",
                table: "portfolio_type",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_user_UserId",
                table: "portfolio_user",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_PortfolioId",
                table: "topic",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_topic_attachment_AttachmentId",
                table: "topic_attachment",
                column: "AttachmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolio_user");

            migrationBuilder.DropTable(
                name: "topic_attachment");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "portfolio");

            migrationBuilder.DropTable(
                name: "portfolio_type");
        }
    }
}
