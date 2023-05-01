using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteCalculatorAPI.Migrations
{
    public partial class AddNewColumnsInQuotePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstablishmentFee",
                table: "QuotePayments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestFee",
                table: "QuotePayments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRepayments",
                table: "QuotePayments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentFee",
                table: "QuotePayments");

            migrationBuilder.DropColumn(
                name: "InterestFee",
                table: "QuotePayments");

            migrationBuilder.DropColumn(
                name: "TotalRepayments",
                table: "QuotePayments");
        }
    }
}
