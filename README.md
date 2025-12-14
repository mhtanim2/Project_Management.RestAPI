# ProjectManagement.RestAPI

A .NET 8 Web API for managing projects, teams, users, and tasks.

## Features

- **User Management** - Create, read, update, and delete users
- **Team Management** - Manage teams and team members
- **Task Management** - Create and track work tasks
- **Search & Filter** - Filter tasks by status, assigned user, team, and due date

## Technologies

- .NET 8
- Entity Framework Core
- PostgreSQL
- AutoMapper
- FluentValidation
- Swagger/OpenAPI

---

## Setup Instructions

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (for PostgreSQL database)

### 1. Start PostgreSQL Database

Run the following command to start a PostgreSQL container:

```bash
docker run -d --name dev-postgres-projectmanager -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=ProjectManager -p 5432:5432 -v postgres-data:/var/lib/postgresql/data postgres:15
```
### 2. Project Running on local system
- Dont have to run local system
