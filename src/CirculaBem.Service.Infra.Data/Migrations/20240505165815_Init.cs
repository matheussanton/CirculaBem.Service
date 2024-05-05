using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CirculaBem.Service.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", nullable: false),
                    price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    ownerregistrationnumber = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productavailability",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    availability = table.Column<short>(type: "int2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productavailability", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productimage",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productimage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    registrationnumber = table.Column<string>(type: "varchar", nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "varchar", nullable: false),
                    isverified = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.registrationnumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "productavailability");

            migrationBuilder.DropTable(
                name: "productimage");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
