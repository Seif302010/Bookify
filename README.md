# Bookify

A web application for borrowing books, built with ASP.NET Core MVC. Users can browse the library, search and sort books, and view availability, while admins manage the catalog of books, authors, and categories.

## Features

- **Browse books** in a grid layout
- **Search** across all book properties, and **sort** by author name, category, or book title using DataTables
- **View book details** including availability in the library
- **Admin management** of books, authors, and categories
- **Role-based access** via ASP.NET Core Identity (admin vs. regular users)

## Tech Stack

- .NET / ASP.NET Core MVC
- C#
- Entity Framework Core (Code First with Migrations)
- ASP.NET Core Identity (authentication & role management)
- SQL Server
- Razor Views, HTML, CSS, JavaScript
- DataTables (searching/sorting)
- LibMan (client-side library management)

## Project Structure

| Folder | Purpose |
|---|---|
| `Controllers` | MVC controllers handling requests |
| `Core` | Core domain models / interfaces |
| `Data` | EF Core DbContext and configuration |
| `Migrations` | EF Core database migrations (including `AddRoles`) |
| `Models` | View models and entities |
| `Views` | Razor views and partials |
| `Areas/Identity/Pages` | Identity scaffolding (login, register, etc.) |
| `Helpers` | Utility/helper classes |
| `wwwroot` | Static assets (CSS, JS, images) |

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (matching the project's target framework)
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Setup

1. **Clone the repository**
   ```bash
    git clone https://github.com/Seif302010/Bookify.git
    cd Bookify
   ```
2. **Configure the connection string** in `appsettings.json` (or `appsettings.Development.json`):
   ```bash
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Bookify;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
   ```
3. **Apply migrations** to create the database:

    dotnet ef database update

4. **Restore dependencies**:
   ```bash
    dotnet restore
   ```
5. **Run the app**:
   ```bash
    dotnet run
   ```
   Then open the URL shown in the console (typically https://localhost:7xxx).

## Usage

- Register a new account or log in via the Identity pages.
- Browse the book grid, use the search box, and sort columns via DataTables.
- Click a book to view its details and availability.
- Log in as an admin to access management screens for books, authors, and categories.

> **Note:** To create an admin user, you may need to seed one manually or assign the admin role to a registered user in the database, since the `AddRoles` migration sets up role support.

## Roadmap / Possible Improvements

- Add borrowing/return workflow with due dates and history
- Add book cover image uploads
- Add pagination and advanced filtering
- Add unit/integration tests
- Add API endpoints for external integrations

## Contributing

Contributions are welcome. Feel free to open an issue or submit a pull request.

## License

No license is currently specified in the repository. Consider adding one (e.g., MIT) if you intend others to reuse the code.

---

**Repository:** [github.com/Seif302010/Bookify](https://github.com/Seif302010/Bookify)
