let books = [
    { id: 1, title: "1984", author: "Orwell" },
    { id: 2, title: "The Alchemist", author: "Coelho" }
];

/**
 * Get all books
 */
exports.getAllBooks = (req, res) => {
    res.status(200).json(books);
};

/**
 * Get book by ID
 */
exports.getBookById = (req, res) => {
    const id = parseInt(req.params.id);
    const book = books.find(b => b.id === id);
    
    if (!book) {
        return res.status(404).json({ error: "Book not found" });
    }
    
    res.status(200).json(book);
};

/**
 * Create a new book
 */
exports.createBook = (req, res) => {
    const { title, author } = req.body;
    
    if (!title || !author) {
        return res.status(400).json({ error: "Title and author are required" });
    }
    
    const newBook = {
        id: books.length > 0 ? Math.max(...books.map(b => b.id)) + 1 : 1,
        title,
        author
    };
    
    books.push(newBook);
    res.status(201).json(newBook);
};

/**
 * Update an existing book
 */
exports.updateBook = (req, res) => {
    const id = parseInt(req.params.id);
    const { title, author } = req.body;
    
    const bookIndex = books.findIndex(b => b.id === id);
    
    if (bookIndex === -1) {
        return res.status(404).json({ error: "Book not found" });
    }
    
    if (!title || !author) {
        return res.status(400).json({ error: "Title and author are required" });
    }
    
    books[bookIndex] = { ...books[bookIndex], title, author };
    res.status(200).json(books[bookIndex]);
};

/**
 * Delete a book
 */
exports.deleteBook = (req, res) => {
    const id = parseInt(req.params.id);
    const bookIndex = books.findIndex(b => b.id === id);
    
    if (bookIndex === -1) {
        return res.status(404).json({ error: "Book not found" });
    }
    
    const deletedBook = books.splice(bookIndex, 1);
    res.status(200).json({ message: "Book deleted successfully", book: deletedBook[0] });
};
