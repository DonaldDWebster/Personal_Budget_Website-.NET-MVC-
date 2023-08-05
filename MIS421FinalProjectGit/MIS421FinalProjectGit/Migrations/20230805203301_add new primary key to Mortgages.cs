using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Migrations
{
    public partial class addnewprimarykeytoMortgages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mortgage",
                table: "Mortgage");

            migrationBuilder.AddColumn<Guid>(
                name: "MortgageID",
                table: "Mortgage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mortgage",
                table: "Mortgage",
                column: "MortgageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mortgage",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "MortgageID",
                table: "Mortgage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mortgage",
                table: "Mortgage",
                column: "ApplicationUserID");
        }
    }
}
