# GameNest

GameNest is a backend infrastructure designed for multiplayer games. The project supports core game features such as player management, inventory, items, loadouts, and real-time services.

## Technologies Used

- **.NET 7/8**: Main platform for backend applications.
- **Entity Framework Core**: Database operations and ORM.
- **SQL Server**: Default database.
- **MagicOnion**: gRPC-based real-time services.
- **AutoMapper**: For object mapping.
- **CQRS (Command Query Responsibility Segregation)**: Separation of command and query operations.
- **Dependency Injection**: Service management.
- **JWT Authentication**: Authentication and authorization.

## Project Architecture

- **GameNest.Domain**: Core domain entities and models.
- **GameNest.Application**: Application services, CQRS, interfaces, and business logic.
- **GameNest.Infrastructure**: Infrastructure services (e.g., JWT, external services).
- **GameNest.Persistence**: Entity Framework for database operations and repository layer.
- **GameNest.Api**: RESTful API.
- **GameNest.RealtimeApi**: Real-time services with MagicOnion.
- **GameNest.Client.Console**: Console-based client example.
- **GameNest.Shared**: Shared messages, view models, and common code.

## Setup and First Use

1. **Install Dependencies**
   
   In the project root directory:
   ```sh
   dotnet restore
   ```

2. **Configure Database**
   
   Update the connection string in the `appsettings.json` files.

3. **Apply Database Migrations**
   
   ```sh
   dotnet ef database update -s GameNest.Api
   ```
   or
   ```sh
   dotnet ef database update -s GameNest.RealtimeApi
   ```

4. **Run the Projects**
   
   - For API:
     ```sh
     dotnet run --project GameNest.Api
     ```
   - For Realtime API:
     ```sh
     dotnet run --project GameNest.RealtimeApi
     ```
   - For Console Client:
     ```sh
     dotnet run --project GameNest.Client.Console
     ```

5. **User Registration and Login**
   
   You can test with Register and Login options in the console client.

## Contribution and Development

- You can submit PRs that comply with coding standards and architecture.
- For issues and suggestions, please open an issue.

---

For any questions, you can contact the project maintainer or contributors.
