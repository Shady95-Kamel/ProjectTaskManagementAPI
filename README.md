# Project Task Management API

A clean architecture ASP.NET Core Web API project built using:

- .NET 9
- Clean Architecture
- CQRS
- MediatR
- JWT Authentication
- Refresh Tokens
- Entity Framework Core
- SQL Server

---

# Architecture

The solution follows Clean Architecture principles:

- Domain Layer
- Application Layer
- Persistence Layer
- Infrastructure Layer
- Presentation Layer (API)

CQRS + MediatR pattern is implemented for commands and queries separation.

---

# Features

- User Registration & Login
- JWT Authentication
- Refresh Token
- Project Management
- Task Management
- Global Exception Handling
- Generic API Response Wrapper

---

# Technologies

- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- MediatR
- Swagger

---

# Setup Instructions

## 1. Clone Repository

```bash
git clone https://github.com/USERNAME/REPO.git
```

---

## 2. Update Connection String

Inside:

```text
appsettings.json
```

Update:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjectTaskDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## 3. Apply Migrations

```bash
Update-Database
```

or

```bash
dotnet ef database update
```

---

## 4. Run Project

```bash
dotnet run
```

---

# Authentication

Use:

```text
/api/User/login
```

Then add:

```text
Bearer YOUR_TOKEN
```

inside Swagger authorization.

---

# Swagger

Swagger will open automatically:

```text
https://localhost:xxxx/swagger/index.html
```

---

# Author

Shady Kamel
