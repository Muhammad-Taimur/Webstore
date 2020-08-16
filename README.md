
# Webstore API Backend

Webstore is a web application storing the and providing the user's input data to front end in JSON format Web Api. Using SQL server/SQL Relational DB to store data.

<img src="https://user-images.githubusercontent.com/27746978/90336630-00a40a00-dfd5-11ea-80af-26a7a4eaa524.png"> 
<img src="https://user-images.githubusercontent.com/27746978/90336740-b8391c00-dfd5-11ea-8135-83db2d3a5d1a.png">

## Features:
* Register new user.
* Authenticate user when request and provide Bearer Token to front end in the form on WebApi.
* Performing CRUD operation to Product and Order API. 
* User can post multiple images in backed along with single product.
* Restful API using MV design pattern. 


## Used libraries:
* [Autofac](https://autofac.org/) library perform Dependency Injection.
* [AutoMapper](https://automapper.org/) library to display model in Rest API.
* [EntityFramework](https://docs.microsoft.com/en-us/ef/) and [IdentityFramework](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity) libraries used to design backend Database, authenticate user and saving user's detials and provided data in DB
* [OWIN](https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api) library is used to defines an abstraction between .NET web servers and web applications.
* [OWINCORS](https://www.nuget.org/packages/Microsoft.Owin.Cors/) library used to enable Cross-Origin Resource Sharing (CORS) in OWIN middleware.
* [Newtonsoft](https://www.newtonsoft.com/json) library for serializing and deserializing.

## Design pattern
MVP (Model View Presenter) and SDP (Singleton Design Pattern) to keep it simple and make the code testable, robust and easier to maintain.

## Build from the source:

In order to build the app you must need to install .Net 

```
https://dotnet.microsoft.com/download/dotnet-framework
```

## License:
```
MIT License

Copyright (c) 2020, Muhammad Taimur

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
