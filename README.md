# ASP.NET Application Using Razor Pages

An ASP.NET Core 3.1 Razor Pages web application implementing CRUD (Create, Read, Update, Delete) operations for property management. The application uses **Dapper** as a lightweight ORM and **PostgreSQL** as the database backend.

## Features

- **Property Management**: Perform full CRUD operations (Create, View Details, Edit, Search, Delete) on property records.
- **Dapper ORM**: High-performance micro-ORM for executing database queries and commands.
- **PostgreSQL Database**: Configured to connect to PostgreSQL via `Npgsql`.
- **Repository Pattern**: Clean architecture separating data access logic from UI pages (`IRepository` and `CustomerRepository`).
- **Razor Pages UI**: User-friendly web pages styled with Bootstrap for responsive web interactions.

## Repository Structure

```
├── Entity/
│   ├── Customer.cs               # Property/Customer data model
│   └── ProductSearchModel.cs     # Model for search filtering criteria
├── Pages/
│   ├── Customer/                 # Razor Pages for CRUD workflows
│   │   ├── Create.cshtml         # Create property page
│   │   ├── Details.cshtml        # Property details page
│   │   ├── Edit.cshtml           # Edit property page
│   │   ├── Index.cshtml          # Property listing and search page
│   │   └── Search.cshtml         # Search form page
│   ├── Shared/                   # Layout and shared navigation views
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── Repository/
│   ├── CustomerRepository.cs     # PostgreSQL Dapper database implementation
│   └── IRepository.cs            # Repository interface definition
├── appsettings.json              # Application configuration and DB connection string
├── CRUDApplicationUsingRazorPages.csproj  # .NET project dependencies
├── Program.cs                    # Application entry point
└── Startup.cs                    # Service registration and middleware pipeline
```

## Prerequisites

Before running this application, ensure you have the following installed:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1) (or compatible .NET SDK)
- [PostgreSQL](https://www.postgresql.org/download/) database server

## Database Setup

1. Create a PostgreSQL database named `PropertyDB`.
2. Execute the following SQL query in PostgreSQL to create the required `property` table:

```sql
CREATE TABLE property (
    id BIGSERIAL PRIMARY KEY,
    property_id VARCHAR(255) NOT NULL,
    property_name VARCHAR(255) NOT NULL,
    gm_name VARCHAR(255) NOT NULL,
    street_address VARCHAR(255) NOT NULL,
    city_address VARCHAR(255) NOT NULL,
    state VARCHAR(255) NOT NULL,
    country VARCHAR(255) NOT NULL,
    zipcode VARCHAR(20) NOT NULL
);
```

## Configuration

Update the PostgreSQL connection string in `appsettings.json` with your database credentials:

```json
"DBInfo": {
  "Name": "PropertyDB",
  "ConnectionString": "User ID=postgres;Password=your_password;Host=localhost;Port=5432;Database=PropertyDB;Pooling=true;"
}
```

Replace `your_password`, `localhost`, and `5432` with your actual PostgreSQL setup details.

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/pankajinsan/ASP.NETApplicationUsingRazorPages.git
   cd ASP.NETApplicationUsingRazorPages
   ```

2. Restore dependencies and build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to:
   ```
   https://localhost:5001
   ```
   or
   ```
   http://localhost:5000
   ```

## Technologies Used

- **Framework**: .NET Core 3.1 / ASP.NET Core Razor Pages
- **ORM**: [Dapper](https://github.com/DapperLib/Dapper) 2.0.123
- **Database Driver**: [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.npgsql.org/) 5.0.10
- **Frontend**: Razor Pages, Bootstrap 5, jQuery
