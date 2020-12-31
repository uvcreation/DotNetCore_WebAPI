# ASP.NET Core WebApi with Swagger

In this repository I want to give a plain starting point at how to build a WebAPI with ASP.NET Core.

This repository contains a controller which is dealing with Products. You can GET/POST/PUT and DELETE them.

Hope this helps.

Access the API endpoints from here: https://uttamwebapi.herokuapp.com/swagger

Use `(POST /api/Users/Authenticate)` endpoint to generate Jwt token.

For `(POST /api/Product/AddProducts)` endpoint payload [Click here](https://github.com/uvcreation/DotNetCore_WebAPI/blob/main/Data/Add%20Product.json)

For `(POST /api/Product/UpdateProducts)` endpoint payload [Click here](https://github.com/uvcreation/DotNetCore_WebAPI/blob/main/Data/Update%20Product.json) 

# Technologies
* ASP.NET Core 3.1
* Dapper
* MySQL 

# Features
- [x] Dapper ORM
- [x] Repository Pattern - Generic
- [x] Serilog
- [x] Swagger UI
- [x] Microsoft Identity with JWT Authentication
- [x] Custom Exception Handling Middlewares
- [x] Automapper
- [x] Docker File

# Prerequisites
* Visual Studio 2019 Community and above
* .NET Core 3.1 SDK and above

# Licensing
uvcreation/DotNetCore_WebAPI Project is licensed with the [MIT License](https://github.com/uvcreation/DotNetCore_WebAPI/blob/main/LICENSE).
