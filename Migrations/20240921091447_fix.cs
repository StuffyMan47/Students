using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Students",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EdProgramId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "FullTime",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parents",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReportCard",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudyYear",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EdProgrammId",
                table: "Estimates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EdPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdPrograms_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_EdProgramId",
                table: "Students",
                column: "EdProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_EdProgrammId",
                table: "Estimates",
                column: "EdProgrammId");

            migrationBuilder.CreateIndex(
                name: "IX_EdPrograms_ClassId",
                table: "EdPrograms",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EdPrograms_Id",
                table: "EdPrograms",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estimates_EdPrograms_EdProgrammId",
                table: "Estimates",
                column: "EdProgrammId",
                principalTable: "EdPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EdPrograms_EdProgramId",
                table: "Students",
                column: "EdProgramId",
                principalTable: "EdPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estimates_EdPrograms_EdProgrammId",
                table: "Estimates");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_EdPrograms_EdProgramId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "EdPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Students_EdProgramId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Estimates_EdProgrammId",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EdProgramId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FullTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Parents",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ReportCard",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudyYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EdProgrammId",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Students",
                newName: "ShortName");
        }
    }
}
