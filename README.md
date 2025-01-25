# Project Structure:

CognitoDemo/
 ├── CognitoDemo.Domain/           # Entities, Value Objects, Domain Events
 ├── CognitoDemo.Core/             # Interfaces, Base classes
 ├── CognitoDemo.Infrastructure/   # Data access, External services
 ├── CognitoDemo.Application/      # Business logic, Services
 └── CognitoDemo.API/              # API Controllers, DTOs


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