# Project Structure:

CognitoDemo/ </br>
 ├── CognitoDemo.Domain/           # Entities, Value Objects, Domain Events </br>
 ├── CognitoDemo.Core/             # Interfaces, Base classes </br>
 ├── CognitoDemo.Infrastructure/   # Data access, External services </br>
 ├── CognitoDemo.Application/      # Business logic, Services </br>
 └── CognitoDemo.API/              # API Controllers, DTOs </br>
 

## Migrate Database

```bash
dotnet ef migrations add AddNewEntity -p CognitoDemo.Infrastructure -s CognitoDemo.API
```

```bash
dotnet ef database update -p CognitoDemo.Infrastructure -s CognitoDemo.API
```

** Some Other Commands **

- List all migrations
    ```bash
    dotnet ef migrations list -p CognitoDemo.Infrastructure -s CognitoDemo.API
    ```

- Remove last migration (if not applied to database)
    ```bash
    dotnet ef database update -p CognitoDemo.Infrastructure -s CognitoDemo.API
    ```
- Drop the database
    ```bash
    dotnet ef database update -p CognitoDemo.Infrastructure -s CognitoDemo.API
    ```

- Generate SQL script
    ```bash
    dotnet ef migrations script -p CognitoDemo.Infrastructure -s CognitoDemo.API
    ``` 