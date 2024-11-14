using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "precio",
                table: "Articulo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "Articulo");
        }
    }
}
