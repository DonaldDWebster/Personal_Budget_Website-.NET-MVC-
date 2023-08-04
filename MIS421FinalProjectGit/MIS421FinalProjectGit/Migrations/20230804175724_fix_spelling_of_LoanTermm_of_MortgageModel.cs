using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Migrations
{
    public partial class fix_spelling_of_LoanTermm_of_MortgageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanTermm",
                table: "Mortgage",
                newName: "LoanTerm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanTerm",
                table: "Mortgage",
                newName: "LoanTermm");
        }
    }
}
