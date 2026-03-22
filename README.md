# Wipro Training Assignments and Capstone Projects

This repository brings together coursework, daily coding assignments, and larger practice projects completed during Wipro training. It includes console applications, class library exercises, ASP.NET projects, database work, and full-stack e-commerce implementations.

## Repository Overview

The repository is split into two broad areas:

- `Assignment`: smaller day-wise tasks focused on specific concepts and problem-solving.
- `Practice Project (Capstone)`: larger end-to-end applications built with Microsoft and web technologies.

## Project Structure

### Assignments

- `Assignment/Day 09`
  - `Q1DAY09`: calculator library and unit testing exercise
  - `Q2Day09`: library management system with tests
  - `Q3DAY09`: Razor Pages web assignment
- `Assignment/Day 10`
  - secure user management component with hashing, encryption, logging, and unit tests
- `Assignment/Day 12`
  - SOLID principles implementation
  - design patterns demo
  - shared test project
- `Assignment/Day 16`
  - MongoDB retail catalog sample data, indexes, and query scripts
- `Assignment/Day 18`
  - Online Movie Catalog (C# Web API) with CRUD for Movies and Directors
- `Assignment/Day 20`
  - Online Book Store (C# Web API) with clean architecture and EF Core
- `Assignment/Day 24`
  - Contact Manager (TypeScript) logic and testing
- `Assignment/Day 25`
  - Book Management REST API (Node.js/Express) with CRUD and event logging
- `Assignment/Day 27`
  - Modular Node.js/Express REST APIs (Books and LMS)
- `Assignment/Day 31`
  - EduLearn Course Management (Angular SPA) with Property/Event/Two-Way Bindings
- `Assignment/Day 35`
  - Event Management Portal (Angular SPA) with custom pipes, directives, and animations
- `Assignment/Day 40`
  - BookStore Pro (Angular) demonstrating Observables, Interceptors, and custom pipes

### Practice Projects

- `Practice Project (Capstone)/Ecommerce-Application`
  - ASP.NET Core MVC e-commerce application with authentication, admin area, and EF Core
- `Practice Project (Capstone)/NEXMART`
  - .NET Web API backend, SQL Server integration, frontend UI, and tests

## Technologies Used

- C#
- .NET and ASP.NET Core
- Razor Pages and MVC
- Entity Framework Core
- SQL Server
- MongoDB
- TypeScript
- Node.js and Express.js
- Angular
- JavaScript, HTML, and CSS
- NUnit and automated testing projects

## Getting Started

Because this repository contains multiple independent projects, setup depends on the folder you want to run.

1. Clone the repository.
2. Open the specific project folder you want to work with.
3. Restore dependencies for that project or solution.
4. Run the project-specific build or test command.

Common commands:

```bash
dotnet restore
dotnet build
dotnet test
```

For Node.js/Angular projects:

```bash
npm install
npm start
```

For database-backed projects, make sure the required SQL Server or MongoDB instance is available and update configuration files as needed. The nested project READMEs include the most relevant setup notes for those applications.

## Recommended Entry Points

If you are browsing this repository on GitHub, these are the best places to start:

- [`Assignment/Day 10/W2Day5AssignmentSolution/README.md`](./Assignment/Day%2010/W2Day5AssignmentSolution/README.md)
- [`Assignment/Day 12/README.md`](./Assignment/Day%2012/README.md)
- [`Assignment/Day 16/README.md`](./Assignment/Day%2016/README.md)
- [`Assignment/Day 25/book-api/README.md`](./Assignment/Day%2025/book-api/README.md)
- [`Assignment/Day 27/question 2/README.md`](./Assignment/Day%2027/question%202/README.md)
- [`Assignment/Day 31/edulearn-app/README.md`](./Assignment/Day%2031/edulearn-app/README.md)
- [`Assignment/Day 35/event-manager-app/README.md`](./Assignment/Day%2035/event-manager-app/README.md)
- [`Assignment/Day 40/bookstore-pro/README.md`](./Assignment/Day%2040/bookstore-pro/README.md)
- [`Practice Project (Capstone)/Ecommerce-Application/README.md`](./Practice%20Project%20(Capstone)/Ecommerce-Application/README.md)
- [`Practice Project (Capstone)/NEXMART/README.md`](./Practice%20Project%20(Capstone)/NEXMART/README.md)

## Notes

- Some folders contain generated build output such as `bin`, `obj`, or IDE metadata.
- Projects in this repository were created as separate exercises, so they do not share a single unified setup flow.
