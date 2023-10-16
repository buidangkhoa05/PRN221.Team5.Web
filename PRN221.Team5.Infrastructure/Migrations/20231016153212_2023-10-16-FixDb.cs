using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221.Team5.Application.Migrations
{
    /// <inheritdoc />
    public partial class _20231016FixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalGroups_GroupId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Meals_MealId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Cage_Animals_AnimalGroups_AnimalGroupId",
                table: "Cage_Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Cage_Animals_Cages_CageId",
                table: "Cage_Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Cages_AnimalSpecies_AnimalSpecieId",
                table: "Cages");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodTypes_TypeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineerProfiles_Accounts_TraineerId",
                table: "TraineerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineerProfiles_Animals_AnimalId",
                table: "TraineerProfiles");

            migrationBuilder.DropTable(
                name: "AnimalGroups");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_TraineerProfiles_AnimalId",
                table: "TraineerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TraineerProfiles_TraineerId",
                table: "TraineerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Foods_TypeId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Cage_Animals_AnimalGroupId",
                table: "Cage_Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_GroupId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_MealId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "TraineerProfiles");

            migrationBuilder.DropColumn(
                name: "IsTraning",
                table: "TraineerProfiles");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "AnimalGroupId",
                table: "Cage_Animals");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "zooSectionStatus",
                table: "ZooSections",
                newName: "ZooSectionStatus");

            migrationBuilder.RenameColumn(
                name: "TraineerId",
                table: "TraineerProfiles",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "TraineerProfiles",
                newName: "JoinDate");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "TraineerProfiles",
                newName: "Exprerience");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "TraineerProfiles",
                newName: "OutDate");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "Cage_Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AnimalTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTraining = table.Column<bool>(type: "bit", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalTrainings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalTrainings_TraineerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TraineerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal_Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Animals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meal_Animals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineerProfiles_AccountId",
                table: "TraineerProfiles",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTrainings_AnimalId",
                table: "AnimalTrainings",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTrainings_TrainerId",
                table: "AnimalTrainings",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Animals_AnimalId",
                table: "Meal_Animals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Animals_MealId",
                table: "Meal_Animals",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cage_Animals_Cages_CageId",
                table: "Cage_Animals",
                column: "CageId",
                principalTable: "Cages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cages_AnimalSpecies_AnimalSpecieId",
                table: "Cages",
                column: "AnimalSpecieId",
                principalTable: "AnimalSpecies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineerProfiles_Accounts_AccountId",
                table: "TraineerProfiles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cage_Animals_Cages_CageId",
                table: "Cage_Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Cages_AnimalSpecies_AnimalSpecieId",
                table: "Cages");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineerProfiles_Accounts_AccountId",
                table: "TraineerProfiles");

            migrationBuilder.DropTable(
                name: "AnimalTrainings");

            migrationBuilder.DropTable(
                name: "Meal_Animals");

            migrationBuilder.DropIndex(
                name: "IX_TraineerProfiles_AccountId",
                table: "TraineerProfiles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "ZooSectionStatus",
                table: "ZooSections",
                newName: "zooSectionStatus");

            migrationBuilder.RenameColumn(
                name: "OutDate",
                table: "TraineerProfiles",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "TraineerProfiles",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Exprerience",
                table: "TraineerProfiles",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "TraineerProfiles",
                newName: "TraineerId");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "TraineerProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsTraning",
                table: "TraineerProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "Cage_Animals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalGroupId",
                table: "Cage_Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AnimalGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodQuantity = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalGroups_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineerProfiles_AnimalId",
                table: "TraineerProfiles",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineerProfiles_TraineerId",
                table: "TraineerProfiles",
                column: "TraineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_TypeId",
                table: "Foods",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cage_Animals_AnimalGroupId",
                table: "Cage_Animals",
                column: "AnimalGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_GroupId",
                table: "Animals",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MealId",
                table: "Animals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalGroups_MealId",
                table: "AnimalGroups",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalGroups_GroupId",
                table: "Animals",
                column: "GroupId",
                principalTable: "AnimalGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Meals_MealId",
                table: "Animals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cage_Animals_AnimalGroups_AnimalGroupId",
                table: "Cage_Animals",
                column: "AnimalGroupId",
                principalTable: "AnimalGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cage_Animals_Cages_CageId",
                table: "Cage_Animals",
                column: "CageId",
                principalTable: "Cages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cages_AnimalSpecies_AnimalSpecieId",
                table: "Cages",
                column: "AnimalSpecieId",
                principalTable: "AnimalSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodTypes_TypeId",
                table: "Foods",
                column: "TypeId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineerProfiles_Accounts_TraineerId",
                table: "TraineerProfiles",
                column: "TraineerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineerProfiles_Animals_AnimalId",
                table: "TraineerProfiles",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
