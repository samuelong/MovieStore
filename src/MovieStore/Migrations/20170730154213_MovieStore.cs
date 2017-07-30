using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Migrations
{
    public partial class MovieStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Movies_MovieID",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_MovieID",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Rentals");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Rentals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_Title",
                table: "Rentals",
                column: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Movies_Title",
                table: "Rentals",
                column: "Title",
                principalTable: "Movies",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Movies_Title",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_Title",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Rentals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MovieID",
                table: "Rentals",
                column: "MovieID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Movies_MovieID",
                table: "Rentals",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
