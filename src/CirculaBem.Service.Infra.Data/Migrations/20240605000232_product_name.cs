using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CirculaBem.Service.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class product_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "product",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "product");
        }
    }
}
