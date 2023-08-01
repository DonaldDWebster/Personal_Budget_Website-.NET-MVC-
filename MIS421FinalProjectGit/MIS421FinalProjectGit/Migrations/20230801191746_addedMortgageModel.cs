using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Migrations
{
    public partial class addedMortgageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mortgage",
                columns: table => new
                {
                    ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomePrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    DownPayment = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    LoanTermm = table.Column<int>(type: "int", precision: 14, scale: 2, nullable: false),
                    AnnualInsurance = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    PropertyTaxes = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    MonthlyHOA = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ExtraPayment = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgage", x => x.ApplicationUserID);
                    table.ForeignKey(
                        name: "FK_Mortgage_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mortgage_ID",
                table: "Mortgage",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mortgage");
        }
    }
}
