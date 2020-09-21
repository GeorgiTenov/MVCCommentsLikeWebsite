using Microsoft.EntityFrameworkCore.Migrations;

namespace Komentirai.Migrations
{
    public partial class AddedSubjectIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubjectId",
                table: "Users",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SubjectId",
                table: "Comments",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subjects_SubjectId",
                table: "Comments",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subjects_SubjectId",
                table: "Users",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subjects_SubjectId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subjects_SubjectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubjectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SubjectId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Comments");
        }
    }
}
