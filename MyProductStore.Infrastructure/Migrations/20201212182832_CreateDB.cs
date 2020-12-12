using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProductStore.Infrastructure.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Cantidad = table.Column<short>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    Imagen = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
