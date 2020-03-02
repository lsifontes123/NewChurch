using Microsoft.EntityFrameworkCore.Migrations;

namespace MyChurch.Web.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinistryTypes_MinistryTypes_MinistryTypeId",
                table: "MinistryTypes");

            migrationBuilder.RenameColumn(
                name: "MinistryTypeId",
                table: "MinistryTypes",
                newName: "MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_MinistryTypes_MinistryTypeId",
                table: "MinistryTypes",
                newName: "IX_MinistryTypes_MentorId");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Ministries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_AdminId",
                table: "Ministries",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ministries_Admins_AdminId",
                table: "Ministries",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MinistryTypes_Mentors_MentorId",
                table: "MinistryTypes",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ministries_Admins_AdminId",
                table: "Ministries");

            migrationBuilder.DropForeignKey(
                name: "FK_MinistryTypes_Mentors_MentorId",
                table: "MinistryTypes");

            migrationBuilder.DropIndex(
                name: "IX_Ministries_AdminId",
                table: "Ministries");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Ministries");

            migrationBuilder.RenameColumn(
                name: "MentorId",
                table: "MinistryTypes",
                newName: "MinistryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MinistryTypes_MentorId",
                table: "MinistryTypes",
                newName: "IX_MinistryTypes_MinistryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MinistryTypes_MinistryTypes_MinistryTypeId",
                table: "MinistryTypes",
                column: "MinistryTypeId",
                principalTable: "MinistryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
