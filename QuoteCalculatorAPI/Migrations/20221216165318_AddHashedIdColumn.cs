using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteCalculatorAPI.Migrations
{
    public partial class AddHashedIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedId",
                table: "QuoteInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedId",
                table: "QuoteInformations");
        }
    }
}
