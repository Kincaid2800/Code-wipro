# Online Book Store System API

## Project Overview
This is a production-quality ASP.NET Core Web API for managing an online book store. It supports full CRUD operations for books and authors, implements proper RESTful principles, and uses Entity Framework Core with an In-Memory database.

## API Endpoints

### Books API
- `GET /api/books` - Retrieve all books
- `GET /api/books/{id}` - Retrieve a book by ID
- `POST /api/books` - Create a new book
- `PUT /api/books/{id}` - Update a book
- `DELETE /api/books/{id}` - Delete a book

### Authors API
- `GET /api/authors` - Retrieve all authors
- `GET /api/authors/{id}` - Retrieve author by ID
- `POST /api/authors` - Create a new author
- `PUT /api/authors/{id}` - Update author
- `DELETE /api/authors/{id}` - Delete author
- `GET /api/authors/{authorId}/books` - Retrieve all books by a specific author

## Sample Requests & Responses

### POST /api/authors
**Request Body:**
```json
{
  "name": "J.K. Rowling"
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "name": "J.K. Rowling"
}
```

### POST /api/books
**Request Body:**
```json
{
  "title": "Harry Potter and the Sorcerer's Stone",
  "authorId": 1,
  "publicationYear": 1997
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "title": "Harry Potter and the Sorcerer's Stone",
  "authorId": 1,
  "authorName": "J.K. Rowling",
  "publicationYear": 1997
}
```

## How to Run the Project
1. Ensure you have the .NET SDK installed.
2. Open a terminal in the `Day 20` folder.
3. Run: `dotnet run`.
4. The API will be available at the ports specified in the terminal (usually `https://localhost:5001` or similar).

## Tools Used
- **Postman**: For API testing and validation of JSON responses.
- **Fiddler**: For inspecting HTTP headers and request/response flow.
- **ASP.NET Core Web API**: Framework for building the RESTful services.
- **EF Core In-Memory**: For data persistence.

## Folder Structure
- `Controllers/`: API endpoints.
- `Models/`: Database entities.
- `Data/`: DBContext configuration.
- `DTOs/`: Data Transfer Objects.
- `Services/`: Business logic layer.
- `Routes/`: Route documentation.
