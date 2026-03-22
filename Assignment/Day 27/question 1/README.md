# Express.js REST API

## Project Overview
This is a clean, modular, and professional Express.js application demonstrating core backend concepts including routing, middleware, CRUD operations, and error handling.

## Features
- **Modular Routing**: Separated routes and controllers for better maintainability.
- **Custom Middleware**: Request logger with timestamps: `[TIMESTAMP] [METHOD] URL`.
- **CRUD Operations**: Full management of a books catalog in-memory.
- **Query Parameters**: Product search functionality (`GET /products?name=...`).
- **Error Handling**: Custom 404 handler and a global error catching system.
- **CORS Support**: Cross-Origin Resource Sharing enabled.

## Folder Structure
- `src/routes/`: Modular route definitions (e.g., `books.js`).
- `src/controllers/`: Business logic for routes.
- `src/middleware/`: Custom middleware (e.g., `logger.js`).
- `server.js`: Application entry point.
- `package.json`: Project dependencies and scripts.

## API Endpoints

### General
- `GET /` - Welcome message.
- `GET /status` - Server health status.
- `GET /products?name=...` - Product search (requires `name` query param).

### Books API (Modular)
- `GET /books` - Retrieve all books.
- `GET /books/:id` - Retrieve a book by ID.
- `POST /books` - Create a new book.
- `PUT /books/:id` - Update a book by ID.
- `DELETE /books/:id` - Delete a book by ID.

### Sample Requests & Responses

#### POST /books
**Request Body:**
```json
{
  "title": "Brave New World",
  "author": "Aldous Huxley"
}
```
**Response (201 Created):**
```json
{
  "id": 3,
  "title": "Brave New World",
  "author": "Aldous Huxley"
}
```

## How to Run the Project
1. **Navigate to the project folder:**
   ```bash
   cd "Day 27"
   ```
2. **Install dependencies:**
   ```bash
   npm install
   ```
3. **Start the server:**
   ```bash
   node server.js
   ```
4. **Access the API:** The server runs on `http://localhost:4000`.

## Tools Used
- **Node.js**: Runtime environment.
- **Express.js**: Web framework.
- **CORS**: Middleware for cross-origin requests.
- **Postman**: For API testing and verification.
