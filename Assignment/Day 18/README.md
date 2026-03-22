# Online Movie Catalog System API

## Project Overview
This is a clean, well-structured ASP.NET Core Web API for managing an online movie catalog. It supports full CRUD operations for movies and directors, implements proper RESTful principles, and uses Entity Framework Core with an In-Memory database.

## API Endpoints

### Movies API
- `GET /api/movies` - Retrieve all movies
- `GET /api/movies/{id}` - Retrieve movie by ID
- `POST /api/movies` - Create a new movie
- `PUT /api/movies/{id}` - Update movie details
- `DELETE /api/movies/{id}` - Delete a movie

### Directors API
- `GET /api/directors` - Retrieve all directors
- `GET /api/directors/{id}` - Retrieve director by ID
- `POST /api/directors` - Create a new director
- `PUT /api/directors/{id}` - Update director
- `DELETE /api/directors/{id}` - Delete director
- `GET /api/directors/{directorId}/movies` - Retrieve all movies by a specific director

## Sample Requests & Responses

### POST /api/directors
**Request Body:**
```json
{
  "name": "Christopher Nolan"
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "name": "Christopher Nolan"
}
```

### POST /api/movies
**Request Body:**
```json
{
  "title": "Inception",
  "directorId": 1,
  "releaseYear": 2010
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "title": "Inception",
  "directorId": 1,
  "directorName": "Christopher Nolan",
  "releaseYear": 2010
}
```

## How to Run the Project
1. Ensure you have the .NET 9.0 SDK installed (or compatible version).
2. Open a terminal in the project root: `Day 18`.
3. Run the command: `dotnet run`.
4. The API will be available at `https://localhost:5001` or `http://localhost:5000` (check terminal output for exact ports).
5. You can use Swagger UI at `https://localhost:5001/swagger/index.html` (if configured) or standard tools like Postman/Fiddler.

## Tools Used
- **Postman**: Used for testing API endpoints with various HTTP methods and verifying JSON responses.
- **Fiddler**: Used for inspecting HTTP traffic, headers, and debugging requests/responses.
- **ASP.NET Core Web API**: Framework for building the RESTful services.
- **EF Core In-Memory**: Used for data persistence during the session.

## Folder Structure
- `Controllers/`: Contains API endpoints.
- `Models/`: Database entities.
- `Data/`: DBContext and data configuration.
- `DTOs/`: Data Transfer Objects for API requests/responses.
- `Services/`: Business logic layer.
- `Routes/`: Route documentation.
