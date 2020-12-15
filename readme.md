# Let's get started - Settings

## Overview

My Product Store API Elaniin is part of the tecnical assesmet at Elaniin. Basically, it's a CRUD over a Product and User tables. For user, some other features were added, such as: authentication, registration, forgot and reset password. For authentication JWT has been implemented.

You can find the API deployed and its documentation on the following URL
https://myproductstoreapi.azurewebsites.net/index.html

API Implemented by [Javier Reyes](https://www.linkedin.com/in/javier-reyes-06299678/)

All Rights Reserved :)

## Postman Request collection for testing

1. Use the `MyProductStoreApiElaniin.postman_collection` provided with the repository.
2. In postman, some endpoints required autentication or admin level (see the documentation above for more details). In that case, you will need to be logged in thru the User authentication endpoint and use the JWT token provided.
3. In the postman request, go to "Authorization" tab, then to "Type" and select "Bearer token" on the dropdown.
4. In token section, put your token provided by the Authenticate / Registration endpoints.
5. Click on send and have fun :)

## Tools

- Visual Studio 2019
- SQL Server
- Postman

## Framework, libraries and patterns

- C#
- Net Core 3.1
- EF Core and FluentAPI
- FluentValidation
- MailKit
- JWT authorization
- Clean Architecture
- Unit of Work and Repository Pattern
- Mediator and CQRS pattern
- SOLID
- Microsfot Azure
- and more ...

## Settings

1. Clone this project using the command `git clone` and checkout to `master`
2. File Structure

```
SolutionMyProductStore
│   MyProductStore.API
│   MyProductStore.Application
│   MyProductStore.Core
|   MyProductStore.Infrastructure
|   myProductStore.sql
|   MyProductStoreApiElaniin.postman_collection
```

3. Solution Project Structure

```
SolutionMyProductStore
└───src
|   └───Web.API
│       │   MyProductStore.API - Presentation layer
│       │   MyProductStore.Application -  Business Cases. Mediator and CQRS pattern.
|       |   MyProductStore.Core - Domain Entities and Abstractions.
│       │   MyProductStore.Infrastructure -  Unit of Work and Repository implementation, migrations and dependencies to other third-party libraries such as Mail Kit or JWT
│
└───tests Xunit project template added.
```

3. On project take the script `myProductStore.sql` and execute it in an instance of SQL Server. This will create the database `ProductStoreDB`
4. Open the project on Visual Studio 2019 and go to

```
SolutionMyProductStore
└───src
|   └───Web.API
│       └─── MyProductStore.API
│            │   appsettings.json
```

5. In section `ConnectionStrings:Default` put your own connection string. Example `"Server=(localdb)\\MSSQLLocalDB;DataBase=ProductStoreDB;Trusted_Connection=True"`
6. For testing and `EmailConfiguration` section, you can create a free account in one click at https://ethereal.email/ and copy the options below the title SMTP configuration.

## Launching the Web.API

1. On Visual Studio Right click on `MyProductStore.API` and then `Set up as Startup project`
2. Click on `IIS Express` and the Swagger page should open. The URL could be like this `https://localhost:44301/index.html`
3. Now you can use the collection provided in postman `MyProductStoreApiElaniin.postman_collection`. Make sure you are consuming the correct URL API.
