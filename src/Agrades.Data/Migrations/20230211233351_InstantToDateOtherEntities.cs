using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace Agrades.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstantToDateOtherEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDate>(
                name: "StartsAt",
                table: "StudentDetail",
                type: "date",
                nullable: false,
                oldClrType: typeof(Instant),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDate>(
                name: "EndsAt",
                table: "StudentDetail",
                type: "date",
                nullable: true,
                oldClrType: typeof(Instant),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDate>(
                name: "BornOn",
                table: "PersonDetail",
                type: "date",
                nullable: true,
                oldClrType: typeof(Instant),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Instant>(
                name: "StartsAt",
                table: "StudentDetail",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDate),
                oldType: "date");

            migrationBuilder.AlterColumn<Instant>(
                name: "EndsAt",
                table: "StudentDetail",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDate),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<Instant>(
                name: "BornOn",
                table: "PersonDetail",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDate),
                oldType: "date",
                oldNullable: true);
        }
    }
}
