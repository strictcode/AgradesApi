using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace Agrades.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClassDetailsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassDetail_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassDetail_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetail_ClassId",
                table: "ClassDetail",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetail_OperationId",
                table: "ClassDetail",
                column: "OperationId");

            migrationBuilder.AddColumn<int>(
                name: "RowCount",
                table: "Class",
                type: "integer",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\"");
            migrationBuilder.Sql("INSERT INTO \"ClassDetail\" (\"Id\",\"ClassId\",\"Name\",\"OperationId\",\"StartAt\",\"ValidSince\",\"CreatedAt\",\"CreatedBy\",\"ModifiedAt\",\"ModifiedBy\")\r\nSELECT uuid_generate_v4(),\"Id\",\"Name\",\"OperationId\",\"StartAt\",'2022-09-01T00:00:00Z',\"CreatedAt\",\"CreatedBy\",\"ModifiedAt\",\"ModifiedBy\"\r\nFROM \"Class\"");
            migrationBuilder.Sql("UPDATE \"Class\" SET \"RowCount\" = 1");
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Operation_OperationId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_OperationId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "Class");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassDetail");

            migrationBuilder.DropColumn(
                name: "RowCount",
                table: "Class");

            migrationBuilder.AddColumn<Instant>(
                name: "CreatedAt",
                table: "Class",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: NodaTime.Instant.FromUnixTimeTicks(0L));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Class",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Instant>(
                name: "DeletedAt",
                table: "Class",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Class",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Instant>(
                name: "ModifiedAt",
                table: "Class",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: NodaTime.Instant.FromUnixTimeTicks(0L));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Class",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Class",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OperationId",
                table: "Class",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Instant>(
                name: "StartAt",
                table: "Class",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: NodaTime.Instant.FromUnixTimeTicks(0L));

            migrationBuilder.CreateIndex(
                name: "IX_Class_OperationId",
                table: "Class",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Operation_OperationId",
                table: "Class",
                column: "OperationId",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
