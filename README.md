# Music Distribution System

A .NET Web API for managing artists, tracks, and music distribution across Digital Service Providers (DSPs).

## Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger / OpenAPI

## Project Structure

```
MusicDistributionSystem.sln

├── MusicDistribution.API
├── MusicDistribution.Application
├── MusicDistribution.Core
├── MusicDistribution.Infrastructure
└── MusicDistribution.Persistence
```

## Prerequisites

* .NET SDK
* SQL Server
* Visual Studio 2022 (or Visual Studio Code)

## Restore Packages

```bash
dotnet restore
```

## Apply Database Migrations

```bash
dotnet ef database update
```

## Run the API

```bash
dotnet run
```

Swagger will be available at:

```
https://localhost:<port>/swagger
```

## JWT Authentication

Some endpoints require JWT authentication.

Obtain a token by calling the authentication endpoint, then include it in the request header:

```
Authorization: Bearer <your_token>
```

## Author

Mohamed Eleebs
