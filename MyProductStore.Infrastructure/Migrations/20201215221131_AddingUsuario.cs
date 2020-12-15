using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProductStore.Infrastructure.Migrations
{
    public partial class AddingUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'John Dao', N'77978541', N'Dao.John', N'1980-05-05 00:00:00', N'john.dao@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
