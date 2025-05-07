# Task Management API Assesment
Created in ASP.NET Core Web APIs 8. It is a simple API WebApp used for CRUD regarding user tasks, with JWT authentication and integration with SQL Server Express

## Features

- Create, view, and list tasks
- JWT-based authentication
- Role-based access (Admin, User)
- Model validation
- Unit tests with NUnit & Moq
- SQL Server Express + EF Core migrations



# Deliverables
- Video WalkThrough [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/walkthrught.mp3)
- API project code (in GitHub repo) [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment)
- Simple data models and a few seed records [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/tree/main/TaskManagerAPI/Entities)
- Postman collection or Swagger UI for testing [DONE]
- README file explaining how to run the project locally [DONE]
  
- SQL or EF Core migration scripts [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/tree/main/TaskManagerAPI/Migrations)
- ER diagram (can be done in dbdiagram.io or draw.io) [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/ER_Diagram.png)
- A sample SQL query to:
    - 1. Get all tasks assigned to a user [Click ME](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/README.md#sample-sql-queries)
    - 2. Get all comments on a task [Click ME](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/README.md#sample-sql-queries)

- Fixed code file [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/ErrorFix.cs)
- Short written explanation of the changes [Present in Comments in Code file]

- Dockerfile [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/TaskManagerAPI/Dockerfile)
- Link to the live demo (if deployed) [Click Me](https://zimozi-assessment-oh8s.onrender.com/swagger/index.html)
- Screenshot of successful deployment [Image1](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/SuccessFullyDeployed.png); [Image2](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/SuccessFullyDeployed_2.png)

- Test project folder with unit test files [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/tree/main/TaskManagerAPI.Tests)
- README or comment explaining how to run tests [Click Me](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/README.md#5-running-tests)



## Setup Instructions

### Prerequisites
- .NET 8 SDK
- SQL Server Express (or change connection string to suit your setup)


#### 1. Clone the Repository

```bash
git clone https://github.com/iamumanggoel/Zimozi-Assessment.git
cd .\TaskManagerAPI

```
#### 2. Update DB Connection (if needed) 
 ##### NOTE: You can switch between InMemory Database & SQL Server Express with ```UseInMemoryDatabase``` boolean in appsettings.Development.json
   
Edit ```.\appsettings.Development.json:```
```json
"ConnectionStrings": {
    "sqlServer": "Server=localhost\\SQLEXPRESS;Database=<DatabaseName>;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

#### 3. Run EF Core Migrations (not needed for in memory db)
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
cd ./TaskManagerAPI.Tests
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

   #### EF Diagram [Check This Out](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/ER_Diagram.png)

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
  1. Make Sure you have Docker Installed in your system and you are in Repository Root Folder
```bash
docker build -t taskmanagerapi -f ./TaskManagerAPI/Dockerfile .
```

```bash
docker run -d -p 8080:8080 --name taskmanager-container taskmanagerapi
```

Now you can access swagger docs at http://localhost:8080/swagger/index.html



### Video Walkthrough
[CLICK]([http://example.com](https://github.com/iamumanggoel/Zimozi-Assessment/blob/main/walkthrught.mp3))


