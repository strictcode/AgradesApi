using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace Agrades.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstantToDateClassDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDate>(
                name: "StartAt",
                table: "ClassDetail",
                type: "date",
                nullable: false,
                oldClrType: typeof(Instant),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Instant>(
                name: "StartAt",
                table: "ClassDetail",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDate),
                oldType: "date");
        }
    }
}
