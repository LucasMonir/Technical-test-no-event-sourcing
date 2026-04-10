# TechnicalTest - Fake Blog Api
> A small CQRS/Hexagonal architecture project

## Requirements:
> .NET SKD 10.0.X
> dotnet-ef tooling
> Docker
> Optional: SQLite3 CLI or any SQL database explorer
> Personal preference: Visual Studio 2022 (For development and local testing)
> Optional: Postman or insomnia, for testing the endpoints

## Migrating the Database:
- To migrate the database and ensure the database is updated, use the following command

>dotnet ef database update --project TechnicalTest.Infrastructure.Persistence --startup-project TechnicalTest.Api

## Running in VisualStudio
- Select the startup method to use the dockerfile present in the project
- In development environment you will be presented with the SwaggerUI with the available endpoints and tryout examples
- The Launch URL is: https://localhost:{port}}/swagger/index.html (Development only), the current port can be seen in launchsettings.json

## GET/POST Request (launching via docker)
> get requests on https://localhost:32779/Post/{guid}
> post requests on https://localhost:32779/Post/ with json body

## Creating image and running this as a docker container 
> To run the published application, use the command docker-compose up --build in the solution's root folder
> The ports used are standard 8080/8081 (HTTP/HTTPS)

### Other info:
> This application currently uses Sqlite as a lightweight database and in-memory sqlite for testing purposes
> This version of the application has no eventsourcing, it's completely using the repository model to read and write with the separation of concerns with CQRS and Hexagonal architecture in mind.