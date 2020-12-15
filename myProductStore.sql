create database ProductStoreDB
GO
use ProductStoreDB
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Producto] (
    [Id] int NOT NULL IDENTITY,
    [SKU] varchar(20) NULL,
    [Nombre] nvarchar(100) NOT NULL,
    [Cantidad] smallint NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [Descripcion] nvarchar(250) NULL,
    [Imagen] varchar(500) NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212182832_CreateDB', N'3.1.1');

GO

INSERT INTO Producto Values ('GUK-MED-G123-GUC', 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('BEL-MQD-G173-GUC', 'Belt', 20, 5.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('BOO-CAP-G100-GUC', 'Boots', 10, 21.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('JAC-MED-G123-JAC', 'Jacket', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('LEG-MED-G123-LEG', 'Leggings', 40, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('PAJ-MED-G123-GUC', 'Pajamas', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('POL-MED-G123-GUC', 'Polo Shirt', 15, 49.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('PUL-OVE-G123-GUC', 'Pull Over', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Rain Coat', 5, 24.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('SCA-MED-G123-GUC', 'Scarf', 11, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Short', 5, 17.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Swim Suit', 3, 50.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci skirt', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('SKI-MED-G126-GUC', 'Gucci SweatPants', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci Perfum', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci Short', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212184614_InitialDB', N'3.1.1');

GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Telefono] nvarchar(10) NOT NULL,
    [Usuario] nvarchar(20) NOT NULL,
    [FechaNacimiento] datetime2 NOT NULL,
    [Email] nvarchar(20) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [ResetToken] nvarchar(max) NULL,
    [ResetTokenExpires] datetime2 NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201213172856_Created User Table', N'3.1.1');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuario]') AND [c].[name] = N'Usuario');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuario] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usuario] ALTER COLUMN [Usuario] nvarchar(50) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuario]') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Usuario] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Usuario] ALTER COLUMN [Email] nvarchar(100) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201213213553_Changing_Email_UserName_lenght', N'3.1.1');

GO

INSERT INTO Producto Values ('GUK-MED-G123-GUC', 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('BEL-MQD-G173-GUC', 'Belt', 20, 5.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('BOO-CAP-G100-GUC', 'Boots', 10, 21.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('JAC-MED-G123-JAC', 'Jacket', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('LEG-MED-G123-LEG', 'Leggings', 40, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('PAJ-MED-G123-GUC', 'Pajamas', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('POL-MED-G123-GUC', 'Polo Shirt', 15, 49.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('PUL-OVE-G123-GUC', 'Pull Over', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Rain Coat', 5, 24.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('SCA-MED-G123-GUC', 'Scarf', 11, 9.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Short', 5, 17.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Swim Suit', 3, 50.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci skirt', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values ('SKI-MED-G126-GUC', 'Gucci SweatPants', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci jeans', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci Perfum', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO Producto Values (null, 'Gucci Short', 5, 19.99, 'New arrival', 'https://via.placeholder.com/150/0000FF/808080?Text=Digital.comhttps://placeholder.com/')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215221017_AddingUsers', N'3.1.1');

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'John Dao', N'77978541', N'Dao.John', N'1980-05-05 00:00:00', N'john.dao@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215221131_AddingUsuario', N'3.1.1');

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'John Dao', N'77978541', N'Dao.John', N'1980-05-05 00:00:00', N'john.dao@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Michael Jackson', N'77978541', N'Jackson.Michael', N'1980-05-05 00:00:00', N'michael.jackson@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Diego Maradona', N'77978541', N'Maradona.Diego', N'1980-05-05 00:00:00', N'diego.maradona@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Kobe Bryant', N'77978541', N'Bryant.Kobe', N'1980-05-05 00:00:00', N'kobe.bryant@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Scott Allen', N'77978541', N'Allen.Scott', N'1980-05-05 00:00:00', N'scott.allen@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Elon Musk', N'77978541', N'Musk.Allen', N'1980-05-05 00:00:00', N'elon.musk@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO[dbo].[Usuario] ([Nombre], [Telefono], [Usuario], [FechaNacimiento], [Email], [PasswordHash], [ResetToken], [ResetTokenExpires]) VALUES(N'Steve Ballmer', N'77978541', N'Ballmer.Steve', N'1980-05-05 00:00:00', N'steve.ballmer@test.com', N'$2a$11$FS1QcNLDbTbXy9W6P4xZh.Z6zGFZsRLncM97SskdV2FfASKSl0pQi', NULL, NULL)

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215221556_AddingMoreUsers', N'3.1.1');

GO
