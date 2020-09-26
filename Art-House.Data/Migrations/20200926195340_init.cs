using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Art_House.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Visit",
                table: "PostText",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PostTextVisits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTextVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTextVisits_PostText_PostId",
                        column: x => x.PostId,
                        principalTable: "PostText",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTextVisits_PostId",
                table: "PostTextVisits",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTextVisits");

            migrationBuilder.DropColumn(
                name: "Visit",
                table: "PostText");
        }
    }
}
