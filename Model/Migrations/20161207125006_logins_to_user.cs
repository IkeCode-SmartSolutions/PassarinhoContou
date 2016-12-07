
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PassarinhoContou.Model.Migrations
{
    public partial class logins_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }
    }
}
