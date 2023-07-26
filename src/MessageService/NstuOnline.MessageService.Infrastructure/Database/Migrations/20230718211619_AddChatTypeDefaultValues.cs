using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NstuOnline.MessageService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddChatTypeDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "chat_type",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { (byte)1, "dialog", "Диалог" },
                    { (byte)2, "conversation", "Беседа" },
                    { (byte)3, "system_conversation", "Беседа группы" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "chat_type",
                keyColumn: "Id",
                keyValue: (byte)3);
        }
    }
}
