using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameHotelIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHotel",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdHotel",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
