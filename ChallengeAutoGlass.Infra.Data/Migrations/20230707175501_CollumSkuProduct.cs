﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeAutoGlass.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CollumSkuProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");
        }
    }
}
