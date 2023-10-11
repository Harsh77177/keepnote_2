using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keep_Note2_EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsertableFluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_categories_users_usersUserId",
                        column: x => x.usersUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reminders",
                columns: table => new
                {
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemniderCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminders", x => x.ReminderId);
                    table.ForeignKey(
                        name: "FK_reminders_users_usersUserId",
                        column: x => x.usersUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_notes_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notes_reminders_ReminderId",
                        column: x => x.ReminderId,
                        principalTable: "reminders",
                        principalColumn: "ReminderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_notes_users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_usersUserId",
                table: "categories",
                column: "usersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_CategoryId",
                table: "notes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_CreatedBy",
                table: "notes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_notes_ReminderId",
                table: "notes",
                column: "ReminderId");

            migrationBuilder.CreateIndex(
                name: "IX_reminders_usersUserId",
                table: "reminders",
                column: "usersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "reminders");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
