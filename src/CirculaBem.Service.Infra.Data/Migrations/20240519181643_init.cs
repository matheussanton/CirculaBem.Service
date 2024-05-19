using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CirculaBem.Service.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
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
                    table.ForeignKey(
                        name: "FK_product_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_user_ownerregistrationnumber",
                        column: x => x.ownerregistrationnumber,
                        principalTable: "user",
                        principalColumn: "registrationnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rent",
                columns: table => new
                {
                    userRegistrationNumber = table.Column<string>(type: "varchar", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rent", x => new { x.userRegistrationNumber, x.productid, x.StartDate, x.EndDate });
                    table.ForeignKey(
                        name: "FK_rent_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rent_user_userRegistrationNumber",
                        column: x => x.userRegistrationNumber,
                        principalTable: "user",
                        principalColumn: "registrationnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryid",
                table: "product",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_product_ownerregistrationnumber",
                table: "product",
                column: "ownerregistrationnumber");

            migrationBuilder.CreateIndex(
                name: "IX_rent_productid",
                table: "rent",
                column: "productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productavailability");

            migrationBuilder.DropTable(
                name: "productimage");

            migrationBuilder.DropTable(
                name: "rent");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
