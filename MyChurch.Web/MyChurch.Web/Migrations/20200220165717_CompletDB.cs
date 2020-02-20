using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyChurch.Web.Migrations
{
    public partial class CompletDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FixedPhone = table.Column<string>(maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciples", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "MinistryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    MentorId = table.Column<int>(nullable: true),
                    DiscipleId = table.Column<int>(nullable: true)
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
                name: "Ministries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    Fund = table.Column<decimal>(nullable: false),
                    Leader = table.Column<string>(nullable: false),
                    SubLeader = table.Column<string>(nullable: false),
                    BiblicalWord = table.Column<int>(nullable: false),
                    MeetStartDate = table.Column<DateTime>(nullable: false),
                    MeetEndDate = table.Column<DateTime>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    MinistryTypeId = table.Column<int>(nullable: true),
                    MentorId = table.Column<int>(nullable: true),
                    DiscipleId = table.Column<int>(nullable: true),
                    MinistryImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ministries_Disciples_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "Disciples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ministries_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ministries_MinistryImages_MinistryImageId",
                        column: x => x.MinistryImageId,
                        principalTable: "MinistryImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ministries_MinistryTypes_MinistryTypeId",
                        column: x => x.MinistryTypeId,
                        principalTable: "MinistryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChurchEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MentorId = table.Column<int>(nullable: true),
                    MinistryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChurchEvents_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChurchEvents_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurchEvents_MentorId",
                table: "ChurchEvents",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChurchEvents_MinistryId",
                table: "ChurchEvents",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberImages_DiscipleId",
                table: "MemberImages",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberImages_MentorId",
                table: "MemberImages",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_DiscipleId",
                table: "Ministries",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_MentorId",
                table: "Ministries",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_MinistryImageId",
                table: "Ministries",
                column: "MinistryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_MinistryTypeId",
                table: "Ministries",
                column: "MinistryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChurchEvents");

            migrationBuilder.DropTable(
                name: "MemberImages");

            migrationBuilder.DropTable(
                name: "Ministries");

            migrationBuilder.DropTable(
                name: "Disciples");

            migrationBuilder.DropTable(
                name: "MinistryImages");

            migrationBuilder.DropTable(
                name: "MinistryTypes");
        }
    }
}
