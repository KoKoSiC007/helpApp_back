using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupService.Migrations
{
    public partial class AddTimestampToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CreatedAt",
                table: "Messages",
                nullable: false,
                defaultValue: $"{DateTime.Now}"
            );
            migrationBuilder.AddColumn<byte[]>(
                name: "CreatedAt",
                table: "Tickets",
                nullable: false,
                defaultValue: $"{DateTime.Now}"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreatedAt", table: "Messages");
            migrationBuilder.DropColumn(name: "CreatedAt", table: "Tickets");
        }
    }
}
