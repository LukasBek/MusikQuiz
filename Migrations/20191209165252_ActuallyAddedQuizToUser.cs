using Microsoft.EntityFrameworkCore.Migrations;

namespace MusikQuiz.Migrations
{
    public partial class ActuallyAddedQuizToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Quiz",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_User_UserId",
                table: "Quiz",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_User_UserId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quiz");
        }
    }
}
