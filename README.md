# User Management API

A sample ASP.NET Core Web API that demonstrates user management with Entity Framework Core, SQL Server, and clean architecture practices. The project includes request/response logging middleware, model validation, repository/service layers, and fully asynchronous CRUD endpoints.

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- A SQL Server instance (local or remote)
- [Entity Framework Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Configuration

1. Copy `appsettings.json` to `appsettings.Development.json` (or create a user secret) and update the `DefaultConnection` string with your SQL Server connection details:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=UserManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

2. Apply migrations and update the database:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

### Running the API

```bash
dotnet restore
dotnet build
dotnet run --project src/UserManagement.Api/UserManagement.Api.csproj
```

The API will start on `https://localhost:5001` and `http://localhost:5000` by default.

### API Endpoints

| Method | Endpoint                | Description            |
| ------ | ----------------------- | ---------------------- |
| GET    | `/api/users`            | Retrieve all users     |
| GET    | `/api/users/{id}`       | Retrieve a user by ID  |
| POST   | `/api/users`            | Create a new user      |
| PUT    | `/api/users/{id}`       | Update an existing user|
| DELETE | `/api/users/{id}`       | Delete a user          |

### Project Structure

```
src/UserManagement.Api/
├── Controllers/         # API controllers
├── Data/                # EF Core DbContext and configurations
├── DTOs/                # Data transfer objects with validation attributes
├── Extensions/          # Service registration helpers
├── Middleware/          # Custom middleware (logging, etc.)
├── Models/              # Entity models
├── Repositories/        # Repository interfaces and implementations
├── Services/            # Business logic services
├── appsettings.json     # Base configuration (copy before editing)
└── Program.cs           # Application bootstrap
```

### Logging & Observability

A custom middleware captures request/response metadata and logs it using the built-in logging framework. This is helpful for debugging and tracing API calls.

### Testing the API

Use a tool like `curl`, [HTTPie](https://httpie.io/), or [Postman](https://www.postman.com/) to exercise the endpoints.

Example request:

```bash
curl -X POST https://localhost:5001/api/users \
  -H "Content-Type: application/json" \
  -d '{
        "firstName": "Ada",
        "lastName": "Lovelace",
        "email": "ada@example.com"
      }'
```

### Next Steps

- Add authentication/authorization (e.g., JWT bearer tokens)
- Add automated tests (unit/integration)
- Containerize using Docker

## License

Distributed under the MIT License. See `LICENSE` for more information.

