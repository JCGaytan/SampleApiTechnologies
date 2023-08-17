# Sample API Technologies REST Service

Welcome to the Sample API Technologies REST Service repository. This repository contains the source code and configuration for a sample RESTful API built using ASP.NET Core and Entity Framework Core.

## Table of Contents

- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Database Seeding](#database-seeding)
- [Swagger Documentation](#swagger-documentation)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This repository demonstrates the implementation of a RESTful API for managing programming languages. It showcases basic CRUD operations (Create, Read, Update, Delete) and uses SQLite as the database.

## Project Structure

The repository is structured as follows:

- `SampleApiTechnologies.DataAccess`: Contains the database context and entity configurations.
- `SampleApiTechnologies.Entities`: Contains the entity classes.
- `SampleApiTechnologies.RestAPI`: Contains the API controllers, startup configuration, and Swagger integration.
- `Program.cs`: The entry point of the application.
- `appsettings.json`: Configuration settings for the application.

## Getting Started

1. Clone this repository to your local machine.
2. Open the solution in your preferred development environment (Visual Studio, Visual Studio Code, etc.).
3. Update the `appsettings.json` file with your desired connection string (SQLite by default).
4. Build and run the application.

## API Endpoints

The API provides the following endpoints:

- `GET /api/ProgrammingLanguages`: Get a list of programming languages.
- `GET /api/ProgrammingLanguages/{id}`: Get a programming language by its ID.
- `POST /api/ProgrammingLanguages`: Create a new programming language.
- `PUT /api/ProgrammingLanguages/{id}`: Update an existing programming language.
- `DELETE /api/ProgrammingLanguages/{id}`: Delete a programming language.

## Database Seeding

The application automatically seeds the database with sample programming languages when the application starts (if the table is empty). This is done in the `Configure` method of the `Startup` class.

## Swagger Documentation

Swagger is integrated into the application to provide interactive API documentation. To access the Swagger UI, run the application and navigate to `/swagger` in your web browser.

## Contributing

Contributions to this repository are welcome! If you find any issues or have improvements to suggest, feel free to submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
