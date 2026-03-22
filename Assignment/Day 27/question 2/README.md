# SkillSphere LMS API (Question 2)

## Project Overview
This is a foundational Express.js backend for SkillSphere LMS, focusing on modular routing and route-level middleware validation. It demonstrates dynamic routing with parameter validation.

## Features
- **Basic Routing**: Root welcome route.
- **Dynamic Routing**: Retrieve specific course details via `/courses/:id`.
- **Route-Level Middleware**: `validateCourseId` ensures that the `:id` parameter is numeric before allowing the request to proceed to the controller.
- **Modular Routing**: Course routes are organized into a separate module (`src/routes/courses.js`).

## Folder Structure
- `src/middleware/`: Contains validation logic (`validation.js`).
- `src/controllers/`: Contains handler functions for routes (`coursesController.js`).
- `src/routes/`: Contains modular route definitions (`courses.js`).
- `server.js`: Application entry point.
- `package.json`: Project dependencies and scripts.

## API Endpoints

### General
- `GET /` - Welcome message: "Welcome to SkillSphere LMS API".

### Courses API (Modular & Validated)
- `GET /courses/:id` - Retrieve React Mastery course details.
  - **Validation**: `:id` must be numeric.

### Sample Requests & Responses

#### GET /courses/101
**Response (200 OK):**
```json
{
  "id": "101",
  "name": "React Mastery",
  "duration": "6 weeks"
}
```

#### GET /courses/abc
**Response (400 Bad Request):**
```json
{
  "error": "Invalid course ID"
}
```

## How to Run the Project
1. **Navigate to the question folder:**
   ```bash
   cd "Day 27/question 2"
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
- **Node.js**: Runtime.
- **Express.js**: Backend framework.
- **Postman**: For API testing and validation.
