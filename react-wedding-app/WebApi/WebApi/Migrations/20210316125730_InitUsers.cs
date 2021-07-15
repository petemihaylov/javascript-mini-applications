using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<byte[]>("varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>("varbinary(max)", nullable: false),
                    FirstName = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: true),
                    Username = table.Column<string>("nvarchar(450)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Users_Username",
                "Users",
                "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Users");
        }
    }
}