using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeePosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeesId",
                table: "EmployeePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Positions_PositionsId",
                table: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.RenameColumn(
                name: "PositionsId",
                table: "EmployeePosition",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeePosition",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePosition_PositionsId",
                table: "EmployeePosition",
                newName: "IX_EmployeePosition_PositionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartPositionDate",
                table: "EmployeePosition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeeId",
                table: "EmployeePosition",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Positions_PositionId",
                table: "EmployeePosition",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeeId",
                table: "EmployeePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Positions_PositionId",
                table: "EmployeePosition");

            migrationBuilder.DropColumn(
                name: "StartPositionDate",
                table: "EmployeePosition");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "EmployeePosition",
                newName: "PositionsId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeePosition",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePosition_PositionId",
                table: "EmployeePosition",
                newName: "IX_EmployeePosition_PositionsId");

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StartPositionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => new { x.EmployeeId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeesId",
                table: "EmployeePosition",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Positions_PositionsId",
                table: "EmployeePosition",
                column: "PositionsId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
