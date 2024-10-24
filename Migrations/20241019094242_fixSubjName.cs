using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.Migrations
{
    /// <inheritdoc />
    public partial class fixSubjName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estimates_EdPrograms_EdProgrammId",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "EdProgrammId",
                table: "Estimates",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Estimates_EdProgrammId",
                table: "Estimates",
                newName: "IX_Estimates_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estimates_EdPrograms_SubjectId",
                table: "Estimates",
                column: "SubjectId",
                principalTable: "EdPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estimates_EdPrograms_SubjectId",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Estimates",
                newName: "EdProgrammId");

            migrationBuilder.RenameIndex(
                name: "IX_Estimates_SubjectId",
                table: "Estimates",
                newName: "IX_Estimates_EdProgrammId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estimates_EdPrograms_EdProgrammId",
                table: "Estimates",
                column: "EdProgrammId",
                principalTable: "EdPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
