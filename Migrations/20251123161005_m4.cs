using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnix.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstructorStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StatusId",
                table: "Instructors",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_InstructorStatus_StatusId",
                table: "Instructors",
                column: "StatusId",
                principalTable: "InstructorStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_InstructorStatus_StatusId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "InstructorStatus");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_StatusId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Instructors");
        }
    }
}
