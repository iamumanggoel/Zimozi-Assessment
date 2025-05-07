# Task Management API Assesment
Created in ASP.NET Core Web APIs 8. It is a simple API WebApp used for CRUD regarding user tasks, with JWT authentication and integration with SQL Server Express

## Features

- Create, view, and list tasks
- JWT-based authentication
- Role-based access (Admin, User)
- Model validation
- Unit tests with NUnit & Moq
- SQL Server Express + EF Core migrations

## Setup Instructions

### Prerequisites
- .NET 8 SDK
- SQL Server Express (or change connection string to suit your setup)


#### 1. Clone the Repository

```bash
git clone https://github.com/iamumanggoel/Zimozi-Assessment.git
cd .\TaskManagerAPI\TaskManagerAPI

```
#### 2. Update DB Connection (if needed)
   
Edit ```.\appsettings.Development.json:```
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=<DatabaseName>;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

#### 3. Run EF Core Migrations
```bash
dotnet ef database update
```

#### 4. Run the Application
```bash
dotnet run
```
Checkout swagger docs on https://localhost:7107/swagger/index.html or http://localhost:5225/swagger/index.html

#### 5. Running Tests
```bash
cd ..
cd TaskManagerAPI.Tests
dotnet test
```

### Tests cover:
  - Task Controller endpoints
  - Task Service logic
  - Positive & negative test cases

JWT Token must be included in Authorization: ```Bearer <token>``` header.

### Authentication
JWT tokens are issued based on login (hardcoded user or via seeded data). Role checks are enforced for endpoint access where applicable.

- Seeded User Credentials (or you can signUp using API endpoint)
  ```json
    [
      {
        "username": "Admin",
        "password": "Zimozi@123"
      },
      {
        "username": "User",
        "password": "Zimozi@123"
      },
    ]
  ```
  
 ### Database Design
- Users

- Tasks (Assigned to Users)

- TaskComments (User + Task Id foreign keys)

### Sample SQL Queries

```sql
-- Get all tasks assigned to user
SELECT * FROM Tasks WHERE UserId = <UserId>; --USE UserId = 1 or 2 for seeded data
```

```sql 
-- Get all comments on a task
SELECT * FROM TaskComments WHERE TaskId = <TaskId>; -- USE TaskId = 1 or 2 for seeded data
```
### Docker Support 
To build and run with Docker:
  1. Make Sure you have Docker Installed in your system.
```bash
docker build -f "<Path>\TaskManagerAPI\TaskManagerAPI\Dockerfile" --force-rm -t taskmanagerapi:dev --target base  --build-arg "BUILD_CONFIGURATION=Debug" --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=TaskManagerAPI" "<Path>\TaskManagerAPI" 
```
#### NOTE
You don't need to provide Visual Studio related Arguments if running with termial directly,

```bash
docker run -p 5000:80 task-manager-api
```



### Video Walkthrough
[Link Text](http://example.com)
