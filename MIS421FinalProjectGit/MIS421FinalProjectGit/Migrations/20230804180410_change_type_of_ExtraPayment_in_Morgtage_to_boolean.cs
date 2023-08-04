using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Migrations
{
    public partial class change_type_of_ExtraPayment_in_Morgtage_to_boolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ExtraPayment",
                table: "Mortgage",
                type: "bit",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ExtraPayment",
                table: "Mortgage",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldPrecision: 14,
                oldScale: 2);
        }
    }
}
