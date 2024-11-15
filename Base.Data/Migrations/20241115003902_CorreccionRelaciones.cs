using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoArticulo_Articulo_ArticuloId",
                table: "CarritoArticulo");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoArticulo_Carrito_CarritoId",
                table: "CarritoArticulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoArticulo",
                table: "CarritoArticulo");

            migrationBuilder.RenameTable(
                name: "CarritoArticulo",
                newName: "carritoArticulos");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoArticulo_CarritoId",
                table: "carritoArticulos",
                newName: "IX_carritoArticulos_CarritoId");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoArticulo_ArticuloId",
                table: "carritoArticulos",
                newName: "IX_carritoArticulos_ArticuloId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Carrito",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_carritoArticulos",
                table: "carritoArticulos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_AspNetUsers_UsuarioId",
                table: "Carrito",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carritoArticulos_Articulo_ArticuloId",
                table: "carritoArticulos",
                column: "ArticuloId",
                principalTable: "Articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carritoArticulos_Carrito_CarritoId",
                table: "carritoArticulos",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_AspNetUsers_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_carritoArticulos_Articulo_ArticuloId",
                table: "carritoArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_carritoArticulos_Carrito_CarritoId",
                table: "carritoArticulos");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carritoArticulos",
                table: "carritoArticulos");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "carritoArticulos",
                newName: "CarritoArticulo");

            migrationBuilder.RenameIndex(
                name: "IX_carritoArticulos_CarritoId",
                table: "CarritoArticulo",
                newName: "IX_CarritoArticulo_CarritoId");

            migrationBuilder.RenameIndex(
                name: "IX_carritoArticulos_ArticuloId",
                table: "CarritoArticulo",
                newName: "IX_CarritoArticulo_ArticuloId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Carrito",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoArticulo",
                table: "CarritoArticulo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoArticulo_Articulo_ArticuloId",
                table: "CarritoArticulo",
                column: "ArticuloId",
                principalTable: "Articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoArticulo_Carrito_CarritoId",
                table: "CarritoArticulo",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
