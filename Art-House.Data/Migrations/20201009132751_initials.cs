using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Art_House.Data.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Asnwer_AsnwerId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Asnwer_AsnwerId",
                table: "UserAnswer");

            migrationBuilder.DropTable(
                name: "Asnwer");

            migrationBuilder.DropIndex(
                name: "IX_Question_AsnwerId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "AsnwerId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "BtnQuestionId",
                table: "UserAnswer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "UserAnswer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BtnQuestion",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BtnQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BtnQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_QuestionId",
                table: "UserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BtnQuestion_QuestionId",
                table: "BtnQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_BtnQuestion_AsnwerId",
                table: "UserAnswer",
                column: "AsnwerId",
                principalTable: "BtnQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Question_QuestionId",
                table: "UserAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_BtnQuestion_AsnwerId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Question_QuestionId",
                table: "UserAnswer");

            migrationBuilder.DropTable(
                name: "BtnQuestion");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_QuestionId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "BtnQuestionId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "UserAnswer");

            migrationBuilder.AddColumn<string>(
                name: "AsnwerId",
                table: "Question",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Asnwer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Asnwers = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asnwer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_AsnwerId",
                table: "Question",
                column: "AsnwerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Asnwer_AsnwerId",
                table: "Question",
                column: "AsnwerId",
                principalTable: "Asnwer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Asnwer_AsnwerId",
                table: "UserAnswer",
                column: "AsnwerId",
                principalTable: "Asnwer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
