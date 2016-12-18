using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FarmHouseDeliveryApp.Data.Migrations
{
    public partial class addedurlrewritemodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlRewrite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    PageContent = table.Column<string>(nullable: true),
                    PageSEOUrl = table.Column<string>(nullable: true),
                    PageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlRewrite", x => x.Id);
                });

            migrationBuilder.AddColumn<bool>(
                name: "IsPromo",
                table: "Product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPromo",
                table: "Product");

            migrationBuilder.DropTable(
                name: "UrlRewrite");
        }
    }
}
