# Help Desk Ticket Management System

A full-stack Help Desk Ticket Management System developed using **ASP.NET Core 8**, **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**. The application follows the **Repository Pattern**, exposes RESTful APIs, and includes unit testing using **xUnit** and **Moq**.

---

## Project Overview

The system enables users to manage help desk support tickets through a responsive web interface. It supports complete CRUD operations, dashboard statistics, status-based filtering, and REST API integration.

---

## Technologies Used

### Backend
- ASP.NET Core 8 Web API
- Entity Framework Core 8
- SQL Server LocalDB
- Repository Pattern

### Frontend
- ASP.NET Core MVC
- Razor Views
- Bootstrap 5
- HttpClient

### Testing
- xUnit
- Moq

### Development Tools
- Visual Studio 2022
- Swagger (OpenAPI)
- Git & GitHub

---

## Project Structure

```
HelpDeskManagement
│
├── HelpDesk.Api
│   ├── Controllers
│   ├── Data
│   ├── Models
│   ├── Repositories
│   ├── Migrations
│   ├── Program.cs
│   └── appsettings.json
│
├── HelpDesk.Mvc
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Views
│   ├── wwwroot
│   └── Program.cs
│
├── HelpDesk.Tests
│   ├── Controllers
│   └── TicketControllerTests.cs
│
├── README.md
└── .gitignore
```

---

## Features

### Dashboard

- View total number of tickets
- View open tickets
- View in-progress tickets
- View closed tickets

### Ticket Management

- Create Ticket
- View Ticket Details
- Edit Ticket
- Delete Ticket
- View All Tickets

### Filtering

- Filter tickets by:
  - Open
  - In Progress
  - Closed
  - All Tickets

### REST API

- Get all tickets
- Get ticket by ID
- Create ticket
- Update ticket
- Delete ticket
- Get tickets by status

### Unit Testing

- Controller unit tests using xUnit and Moq
- Mock repository implementation
- Automated API testing

---

## Architecture

```
MVC Application
      │
      │ HttpClient
      ▼
ASP.NET Core Web API
      │
Repository Pattern
      │
Entity Framework Core
      │
SQL Server LocalDB
```

---

## Running the Project

### 1. Clone Repository

```bash
git clone https://github.com/Shriya-punnal/HelpDeskManagement.git
```

### 2. Open Solution

Open:

```
HelpDeskManagement.sln
```

using Visual Studio 2022.

### 3. Restore Packages

```
Build → Restore NuGet Packages
```

### 4. Update Database

Open Package Manager Console.

```powershell
Update-Database
```

### 5. Run the Application

Set **Multiple Startup Projects**.

Start:

- HelpDesk.Api
- HelpDesk.Mvc

Run the solution.

---

## Unit Testing

Open:

```
Test → Test Explorer
```

Run all tests.

---

## Author

**Name:** Roli Dwivedi

---

## License

This project was developed for academic purposes as part of the Help Desk Ticket Management System assignment.
