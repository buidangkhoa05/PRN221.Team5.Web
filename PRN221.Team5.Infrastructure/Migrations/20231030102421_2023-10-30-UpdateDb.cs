using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221.Team5.Application.Migrations
{
    /// <inheritdoc />
    public partial class _20231030UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "Meal_Food",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Food_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meal_Food_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Food_FoodId",
                table: "Meal_Food",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Food_MealId",
                table: "Meal_Food",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal_Food");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodId",
                table: "Meals",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }
    }
}
