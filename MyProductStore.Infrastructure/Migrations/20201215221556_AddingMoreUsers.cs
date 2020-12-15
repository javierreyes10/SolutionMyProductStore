using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProductStore.Infrastructure.Migrations
{
    public partial class AddingMoreUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'John Dao', N'77978541', N'Dao.John', N'1980-05-05 00:00:00', N'john.dao@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Michael Jackson', N'77978541', N'Jackson.Michael', N'1980-05-05 00:00:00', N'michael.jackson@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Diego Maradona', N'77978541', N'Maradona.Diego', N'1980-05-05 00:00:00', N'diego.maradona@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Kobe Bryant', N'77978541', N'Bryant.Kobe', N'1980-05-05 00:00:00', N'kobe.bryant@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Scott Allen', N'77978541', N'Allen.Scott', N'1980-05-05 00:00:00', N'scott.allen@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Elon Musk', N'77978541', N'Musk.Allen', N'1980-05-05 00:00:00', N'elon.musk@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");

            migrationBuilder
                .Sql("INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Steve Ballmer', N'77978541', N'Ballmer.Steve', N'1980-05-05 00:00:00', N'steve.ballmer@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
