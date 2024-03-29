# Game Store

This project aims to be a perfect game store. It is dived in 2 applications, a web API developed in .NET 6 and a website using Angular 6.0.8. 

### Prerequisites

- You will need Visual Studio 2017 with the .NET Core SDK installed and the latest stable build of Node.js
- The latest SDK and tools can be downloaded from https://dot.net/core. 
- Read the .NET Core 3.1 [release announcement](https://blogs.msdn.microsoft.com/dotnet/2017/08/14/announcing-net-core-2-0/) for more information.
- the latest Node.js installer could be found [here](https://nodejs.org/en/).
- You can chose between Microsoft SQL Server and PostgreSQL. Ether way you will need a local db running instance for the selected database.

Also, you can run the application in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your environment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

### Installing

#### API

First cd to ``` src\1 - UI\GameStore.UI.WebApi ``` to install NuGet packages required and run

```
cd GameStore.UI.WebApi
dotnet restore
dotnet run
```

Now change the connection string on GameStore.UI.WebApi/appsettings.json, 
same for GameStore.UI.WebApi/appsettings.development.json

```
"ConnectionStrings": {
    "DefaultConnection": "Your Connection String"
}
```

If you are using PostgreSQL change the ```"PostgreSQLConnection"``` key under ```ConnectionStrings``` configuration

There is a detailed explanation on how to switch to the database service of your choice on the Startup.cs file. Note that the Postgre SQL version is the default.

#### UI

Npm used here for management of packages.

Npm is a open-source tool widely used around the world for sharing packages among projects

After installing node.js as required above you could open a terminal(or cmd) of your preference
in the GameStore.UI.Site folder.

Install npm packages required and run

```
cd GameStore.UI.Site
npm install
ng serve
```

### Documentation

See the API documentation using swagger calling

```
localhost:<random-port>/swagger
```

You can also import the GameStore.postman_collection.json on Postman to see detailed information and examples

*note for using postman examples you will need run the seed first wich happens automatically on the first run*
*and change de guid ids of every model for using whatever guid was generated by entity framework.*

## Technologies implemented:

- ASP.NET Core 3.1
- Entity Framework Core 2.0
- .NET Core Native DI
- AutoMapper
- Swagger UI

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Unit of Work
- Repository and Generic Repository
- CQRS

## Acknowledgments

Inspired by the [Equinox Project](https://github.com/EduardoPires/EquinoxProject) from [Eduardo Pires](http://www.eduardopires.net.br/)
