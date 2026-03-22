import express from 'express';
import bookService from './services/bookService.js';

const app = express();
const PORT = process.env.PORT || 3000;

// Middleware for parsing JSON
app.use(express.json());

// Request logging middleware (Bonus)
app.use((req, res, next) => {
    console.log(`[${new Date().toISOString()}] ${req.method} ${req.url}`);
    next();
});

// Root endpoint
app.get('/', (req, res) => {
    res.json({ message: "Welcome to Book Management API" });
});

// 1. GET /books - Return all books
app.get('/books', async (req, res) => {
    try {
        const books = await bookService.getAllBooks();
        res.status(200).json(books);
    } catch (error) {
        res.status(500).json({ error: "Failed to fetch books" });
    }
});

// 2. GET /books/:id - Return book by ID
app.get('/books/:id', async (req, res) => {
    try {
        const book = await bookService.getBookById(req.params.id);
        if (!book) {
            return res.status(404).json({ error: "Book not found" });
        }
        res.status(200).json(book);
    } catch (error) {
        res.status(500).json({ error: "Failed to fetch book" });
    }
});

// 3. POST /books - Add new book
app.post('/books', async (req, res) => {
    const { title, author } = req.body;
    
    // Request validation (Bonus)
    if (!title || !author) {
        return res.status(400).json({ error: "Title and author are required" });
    }

    try {
        const newBook = await bookService.createBook({ title, author });
        res.status(201).json(newBook);
    } catch (error) {
        res.status(500).json({ error: "Failed to create book" });
    }
});

// 4. PUT /books/:id - Update existing book
app.put('/books/:id', async (req, res) => {
    try {
        const updatedBook = await bookService.updateBook(req.params.id, req.body);
        if (!updatedBook) {
            return res.status(404).json({ error: "Book not found or invalid ID" });
        }
        res.status(200).json(updatedBook);
    } catch (error) {
        res.status(500).json({ error: "Failed to update book" });
    }
});

// 5. DELETE /books/:id - Delete book
app.delete('/books/:id', async (req, res) => {
    try {
        const success = await bookService.deleteBook(req.params.id);
        if (!success) {
            return res.status(404).json({ error: "Book not found" });
        }
        res.status(200).json({ message: "Book deleted successfully" });
    } catch (error) {
        res.status(500).json({ error: "Failed to delete book" });
    }
});

// Error handling middleware
app.use((err, req, res, next) => {
    console.error(err.stack);
    res.status(500).json({ error: "Something went wrong!" });
});

app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});
