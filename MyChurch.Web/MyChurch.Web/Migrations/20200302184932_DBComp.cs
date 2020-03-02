using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyChurch.Web.Migrations
{
    public partial class DBComp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ministries_MinistryImages_MinistryImageId",
                table: "Ministries");

            migrationBuilder.DropForeignKey(
                name: "FK_MinistryTypes_Mentors_MentorId",
                table: "MinistryTypes");

            migrationBuilder.DropTable(
                name: "MemberImages");

            migrationBuilder.DropTable(
                name: "MinistryImages");

            migrationBuilder.DropIndex(
                name: "IX_MinistryTypes_MentorId",
                table: "MinistryTypes");

            migrationBuilder.DropIndex(
                name: "IX_Ministries_MinistryImageId",
                table: "Ministries");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "MinistryTypes");

            migrationBuilder.DropColumn(
                name: "MinistryImageId",
                table: "Ministries");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Ministries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ministries",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "ChurchEvents",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ChurchEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    MinistryId = table.Column<int>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUpHistories_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowUpHistories_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurchEvents_AdminId",
                table: "ChurchEvents",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpHistories_MinistryId",
                table: "FollowUpHistories",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpHistories_ServiceTypeId",
                table: "FollowUpHistories",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChurchEvents_Admins_AdminId",
                table: "ChurchEvents",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChurchEvents_Admins_AdminId",
                table: "ChurchEvents");

            migrationBuilder.DropTable(
                name: "FollowUpHistories");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ChurchEvents_AdminId",
                table: "ChurchEvents");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Ministries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ministries");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "ChurchEvents");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ChurchEvents");

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "MinistryTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinistryImageId",
                table: "Ministries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscipleId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    MentorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberImages_Disciples_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "Disciples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberImages_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MinistryImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryTypes_MentorId",
                table: "MinistryTypes",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_MinistryImageId",
                table: "Ministries",
                column: "MinistryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberImages_DiscipleId",
                table: "MemberImages",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberImages_MentorId",
                table: "MemberImages",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ministries_MinistryImages_MinistryImageId",
                table: "Ministries",
                column: "MinistryImageId",
                principalTable: "MinistryImages",
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
    }
}
