using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmHouseDeliveryApp.Data.Migrations
{
    public partial class addedcontactnameandaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Billing_Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_PostalCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Province",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CCType",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping_Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping_City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping_PostalCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping_Province",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Billing_Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Billing_City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Billing_PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Billing_Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CCType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Shipping_Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Shipping_City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Shipping_PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Shipping_Province",
                table: "AspNetUsers");
        }
    }
}
