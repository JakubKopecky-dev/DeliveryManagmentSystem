using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryService.Command.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailToDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Deliveries");
        }
    }
}
