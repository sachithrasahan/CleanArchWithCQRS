# Clean Architecture + CQRS + MediatR (.NET 9 Web API)

This project is a sample implementation of a Clean Architecture Web API built using:

- .NET 9
- CQRS with MediatR
- In-Memory Data Store (Repository Pattern)
- RESTful API with Swagger
- Full Clean Architecture separation

---

## Project Structure

```
📦 src
 ├── 🌐 API (Presentation Layer)
 │    └── Controllers, Dependency Injection, Swagger
 ├── 📦 Application (Core Business Logic)
 │    ├── CQRS (Commands + Queries + Handlers)
 │    └── Interfaces, DTOs
 ├── 🧠 Domain (Entities)
 └── 🗄️ Infrastructure (In-Memory Repository)
 ```

---

## Tech Stack

| Feature | Technology |
|--------|------------|
| Framework | .NET 9 Web API |
| Patterns | Clean Architecture, Repository Pattern |
| CQRS | MediatR |
| Data Storage | In-Memory Database |
| Documentation | Swagger / OpenAPI |

---

## CQRS Pattern

CQRS separates reads and writes into different models to increase maintainability and scalability.

| Operation Type | Description |
|----------------|-------------|
| Commands | Write operations (Create/Update/Delete) |
| Queries | Read operations (Retrieve Data) |

Handlers execute the logic independently through MediatR.

---

## Getting Started

### Prerequisites

- .NET 9 SDK installed
- Visual Studio / VS Code / Rider

### Run the Application

```bash
dotnet restore
dotnet build
dotnet run --project src/API
