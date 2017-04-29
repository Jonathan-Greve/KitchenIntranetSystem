using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenIntranetSystem.Data.Migrations
{
    public partial class AddedPropertiesToExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingExpense",
                table: "Expenses",
                newName: "Subscription");

            migrationBuilder.AddColumn<decimal>(
                name: "EndBalance",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FoodIncome",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "KitchenAccountIncome",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShoppingIncome",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StartBalance",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndBalance",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "FoodIncome",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "KitchenAccountIncome",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ShoppingIncome",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "StartBalance",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Subscription",
                table: "Expenses",
                newName: "ShoppingExpense");
        }
    }
}
