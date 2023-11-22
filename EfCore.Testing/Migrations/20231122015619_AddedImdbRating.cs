﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Testing.Migrations
{
    /// <inheritdoc />
    public partial class AddedImdbRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImdbRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "Movies");
        }
    }
}
