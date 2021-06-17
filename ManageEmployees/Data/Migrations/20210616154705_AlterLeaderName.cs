using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterLeaderName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LeaderId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "LeaderName",
                table: "Employee",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaderName",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "LeaderId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LeaderId",
                table: "Employee",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee",
                column: "LeaderId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
