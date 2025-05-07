Task Manager API

This is a simple ASP.NET Core Web API that allows users to manage tasks,
assign them to users, and add comments. The project demonstrates
foundational .NET backend skills such as API creation, database
integration using Entity Framework Core, authentication, and role-based
authorization.

Features:

User registration and login with JWT-based authentication Role-based
access control (Admin and User) Create, retrieve, and list tasks Assign
tasks to users Add comments to tasks In-memory database for development
Swagger UI for testing Model validation using data annotations
Technology Stack:

ASP.NET Core (.NET 8)S Entity Framework Core (InMemory) JWT
Authentication Swagger / Swashbuckle xUnit and Moq for testing Getting
Started:

Prerequisites:

.NET 8 SDK Visual Studio 2022 or later (or any compatible IDE) Steps to
Run the Project:

Clone the repository: git clone
https://github.com/YOUR_USERNAME/task-manager-api.git cd
task-manager-api Run the application: dotnet run Access Swagger UI:
https://localhost:5001/swagger Authentication:

Login via the /login endpoint to receive a JWT token. Use the
"Authorize" button in Swagger UI and input the token in this format:
Bearer `<your_token>`{=html} Seeded Users:

Username: Umang_Admin, Password: Umang@123, Role: Admin Username:
Umang_User, Password: Umang@123, Role: User API Endpoints:

Public:

POST /login -- Authenticate and receive a token POST /signup -- Register
a new user Requires Authentication:

POST /tasks -- Create a new task GET /tasks/{id} -- Get a task by ID GET
/tasks/user/{userId} -- Get tasks for a user GET /users -- List all
users (Admin only) Project Structure:

Run Copy code TaskManagerAPI/ ├── Controllers/ ├── Services/ ├──
Repositories/ ├── Entities/ ├── Data/ ├── DTOs/ ├── Helpers/ └──
Program.cs Database Design:

Tables: Users, Tasks, TaskComments Relationships: One-to-Many: Users →
Tasks One-to-Many: Tasks → TaskComments Sample SQL Queries:

Get all tasks assigned to a user: SELECT \* FROM Tasks WHERE UserId = 1;
Get all comments for a task: SELECT \* FROM TaskComments WHERE TaskId =
1; An ER diagram is included in the docs/ERDiagram.pdf. Unit Testing:

Tests are located in the test project folder. To run tests: dotnet test
Tests include: Positive and negative scenarios Mocked services using Moq
Focused on services and controllers Deployment (Optional):

A basic Dockerfile is provided. The app can be deployed to services like
Render or Railway. Deliverables Checklist:

Private GitHub repository Functional API with endpoints and
authentication Swagger UI for testing Seed data for users ER diagram
README file Unit tests (Optional) Docker deployment Author: This project
was developed as part of the .NET backend recruitment assessment.
