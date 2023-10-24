# BusinessLab
BusinessLab is an API developed following the Domain-Driven Design (DDD) pattern. It leverages C# .NET 6.0 Web API, Entity Framework Core, Linq, Nunit for unit testing, Moq for mocking, and FluentAssertions for assertion.

Installation
To run this project locally, you will need to follow these steps:

Prerequisites
&bull; .NET 6 SDK
&bull; Visual Studio or Visual Studio Code

## Steps Configure the database connection in the appsettings.json file to point to your local database server. 

1- Clone the repository to your local machine</br>

2- Update the connection string:</br>
"ConnectionStrings": {
  "DefaultConnection": "YourConnectionString"
}</br>

3- Open the Package Manager Console or a terminal and run the following commands to create and apply database migrations:</br>
 &bull; dotnet ef migrations add InitialCreate</br>
 &bull; dotnet ef database update

4- Run the API by pressing F5 or using the command: </br>
&bull; dotnet run

## BackEnd Side technologies
&bull; C# .NET 6.0 Web API</br>
&bull; Entity Framework Core</br>
&bull; Linq</br>
&bull; Nunit for unit testing)</br>
&bull; Moq</br>
&bull; FluentAssertions for assertion

## Patterns:
&bull; DDD (Domain-Driven Designr)</br>
&bull; Dependency Injection</br>
