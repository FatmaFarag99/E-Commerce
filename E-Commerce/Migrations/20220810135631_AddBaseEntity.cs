using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Product_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyStamp",
                table: "ProductCategories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyStamp",
                table: "Category",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyStamp",
                table: "Products",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Product_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
