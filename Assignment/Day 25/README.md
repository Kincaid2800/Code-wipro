# Book Management API (Day 25)

A RESTful API built with Node.js and Express to manage a personal book collection.

## 🚀 Features
- Full CRUD operations (Create, Read, Update, Delete)
- Data persistence using a JSON file (`fs.promises`)
- Event-driven logging using Node.js `EventEmitter`
- Request logging middleware
- Input validation for book creation
- UUID for unique book IDs
- Production-ready error handling

## 📁 Project Structure
```text
Day 25/book-api/
├── data/
│   └── books.json          # JSON file for data persistence
├── services/
│   └── bookService.js      # Business logic and File System interactions
├── server.js               # Express application and routes
├── package.json            # Project dependencies and scripts
└── README.md               # Documentation
```

## 🛠️ Setup Instructions

1. **Navigate to the project directory:**
   ```bash
   cd "Day 25/book-api"
   ```

2. **Install dependencies:**
   ```bash
   npm install
   ```

3. **Start the server:**
   ```bash
   npm start
   ```
   The server will run on `http://localhost:3000`.

## 📡 API Endpoints

### 1. Root Welcome
- **URL:** `GET /`
- **Response:** `{ "message": "Welcome to Book Management API" }`

### 2. Get All Books
- **URL:** `GET /books`
- **Success Response:** `200 OK` (Array of books)

### 3. Get Book by ID
- **URL:** `GET /books/:id`
- **Success Response:** `200 OK`
- **Error Response:** `404 Not Found` (If ID doesn't exist)

### 4. Add New Book
- **URL:** `POST /books`
- **Body:**
  ```json
  {
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald"
  }
  ```
- **Success Response:** `201 Created`
- **Error Response:** `400 Bad Request` (If title or author is missing)

### 5. Update Book
- **URL:** `PUT /books/:id`
- **Body:**
  ```json
  {
    "title": "The Great Gatsby - Updated",
    "author": "F. Scott Fitzgerald"
  }
  ```
- **Success Response:** `200 OK`
- **Error Response:** `404 Not Found`

### 6. Delete Book
- **URL:** `DELETE /books/:id`
- **Success Response:** `200 OK`
- **Error Response:** `404 Not Found`

## 🛠️ Best Practices Followed
- **ES6+ Syntax:** Used `import/export`, `async/await`, `const/let`, and arrow functions.
- **Service Layer:** Separated business logic from routing.
- **Asynchronous FS:** Used `fs/promises` for non-blocking file operations.
- **Modular Design:** Clear separation of concerns between `server.js` and `bookService.js`.
- **Proper HTTP Status Codes:** 200, 201, 400, 404, 500.
