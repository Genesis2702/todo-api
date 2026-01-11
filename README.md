# Todo API

## Overview
- Project's use: todo API with CRUD functionality
- Project's purpose: learning

## Tech stack
- Languages: C#
- Framework: ASP.NET Core web API
- Database: SQLite
- Testing: Postman 

## Features
- Create, read, update, delete todo items
- Parital updates with HTTP patch
- Data persistent using SQLite
- DTOs for requesting/responding
- Validation and HTTP status codes
- Database migration using EF Core

## API endpoints
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/todo` | Get all todo items |
| GET | `/todo/{id}` | Get todo item by id |
| POST | `/todo` | Create a new todo item |
| PUT | `/todo/{id}` | Update a todo (full update) |
| PATCH | `/todo/{id}` | Update a todo (partial update) |
| DELETE | `/todo/{id}` | Delete a todo |

# Project structure 
``` text
TodoApi/
|
|-Controllers/
|-Services/
|   |-ImplementationServices/
|   |-InterfaceServices/
|-Data/
|-DTO/
|   |-Request/
|   |-Response/
|-Models/
|-Migrations/
|_Program.cs 
