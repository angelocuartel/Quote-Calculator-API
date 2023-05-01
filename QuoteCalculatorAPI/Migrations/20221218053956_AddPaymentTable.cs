using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteCalculatorAPI.Migrations
{
    public partial class AddPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "QuoteInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "QuotePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteInformationId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyPayments = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotePayments_QuoteInformations_QuoteInformationId",
                        column: x => x.QuoteInformationId,
                        principalTable: "QuoteInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuotePayments_QuoteInformationId",
                table: "QuotePayments",
                column: "QuoteInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotePayments");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "QuoteInformations");
        }
    }
}
