# MiSalud

Windows Forms application for clinical management. The application uses Entity Framework Core and PostgreSQL.

## Configuration

Database settings are stored in `appsettings.json` located in the project root. Modify the connection string under `ConnectionStrings:DefaultConnection` to match your environment.

Example:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=MiSalud;Username=postgres;Password=1234"
  }
}
```

Alternatively, you can specify the connection string via the `DefaultConnection` environment variable. The application will fall back to the default in `appsettings.json` if no environment variable is set.

## Building

Use the .NET SDK (8.0 or later) to build the project:

```bash
 dotnet build -c Release
```

## Running

Execute the compiled application or run through `dotnet run`. Ensure PostgreSQL is reachable using the configured connection string.

