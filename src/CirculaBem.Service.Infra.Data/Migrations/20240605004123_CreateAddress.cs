using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CirculaBem.Service.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userregistrationnumber = table.Column<string>(type: "varchar", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    state = table.Column<string>(type: "char(2)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    number = table.Column<short>(type: "smallint", nullable: false),
                    complement = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_adresses_user_userregistrationnumber",
                        column: x => x.userregistrationnumber,
                        principalTable: "user",
                        principalColumn: "registrationnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresses_userregistrationnumber",
                table: "adresses",
                column: "userregistrationnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adresses");
        }
    }
}
