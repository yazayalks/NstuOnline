using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NstuOnline.PortfolioService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NEWNEW3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_user_portfolio_PortfolioId1",
                table: "portfolio_user");

            migrationBuilder.DropForeignKey(
                name: "FK_topic_portfolio_PortfolioId1",
                table: "topic");

            migrationBuilder.DropIndex(
                name: "IX_topic_PortfolioId1",
                table: "topic");

            migrationBuilder.DropIndex(
                name: "IX_portfolio_user_PortfolioId1",
                table: "portfolio_user");

            migrationBuilder.DropColumn(
                name: "PortfolioId1",
                table: "topic");

            migrationBuilder.DropColumn(
                name: "PortfolioId1",
                table: "portfolio_user");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_user_UserId",
                table: "portfolio_user",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_user_user_UserId",
                table: "portfolio_user",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_user_user_UserId",
                table: "portfolio_user");

            migrationBuilder.DropIndex(
                name: "IX_portfolio_user_UserId",
                table: "portfolio_user");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId1",
                table: "topic",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId1",
                table: "portfolio_user",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_PortfolioId1",
                table: "topic",
                column: "PortfolioId1");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_user_PortfolioId1",
                table: "portfolio_user",
                column: "PortfolioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_user_portfolio_PortfolioId1",
                table: "portfolio_user",
                column: "PortfolioId1",
                principalTable: "portfolio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_topic_portfolio_PortfolioId1",
                table: "topic",
                column: "PortfolioId1",
                principalTable: "portfolio",
                principalColumn: "Id");
        }
    }
}
