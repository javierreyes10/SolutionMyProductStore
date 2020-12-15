using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProductStore.Infrastructure.Migrations
{
    public partial class AddingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql("INSERT INTO Producto Values ('GUK-MED-G123-GUC', 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('BEL-MQD-G173-GUC', 'Belt', 20, 5.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('BOO-CAP-G100-GUC', 'Boots', 10, 21.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('JAC-MED-G123-JAC', 'Jacket', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('LEG-MED-G123-LEG', 'Leggings', 40, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('PAJ-MED-G123-GUC', 'Pajamas', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('POL-MED-G123-GUC', 'Polo Shirt', 15, 49.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('PUL-OVE-G123-GUC', 'Pull Over', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Rain Coat', 5, 24.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('SCA-MED-G123-GUC', 'Scarf', 11, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Short', 5, 17.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Swim Suit', 3, 50.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Gucci skirt', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values ('SKI-MED-G126-GUC', 'Gucci SweatPants', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Gucci Perfum', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");

            migrationBuilder
                .Sql("INSERT INTO Producto Values (null, 'Gucci Short', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
