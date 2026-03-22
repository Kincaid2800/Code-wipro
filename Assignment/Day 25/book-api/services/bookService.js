import fs from 'fs/promises';
import path from 'path';
import { EventEmitter } from 'events';
import { v4 as uuidv4 } from 'uuid';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const DATA_PATH = path.join(__dirname, '..', 'data', 'books.json');

class BookService extends EventEmitter {
    constructor() {
        super();
        this.on('Book Added', (book) => console.log(`[EVENT] Book Added: ${book.title} (ID: ${book.id})`));
        this.on('Book Updated', (book) => console.log(`[EVENT] Book Updated: ${book.title} (ID: ${book.id})`));
        this.on('Book Deleted', (id) => console.log(`[EVENT] Book Deleted (ID: ${id})`));
    }

    async #readBooks() {
        try {
            const data = await fs.readFile(DATA_PATH, 'utf-8');
            return JSON.parse(data);
        } catch (error) {
            if (error.code === 'ENOENT') {
                return [];
            }
            throw error;
        }
    }

    async #writeBooks(books) {
        await fs.writeFile(DATA_PATH, JSON.stringify(books, null, 2));
    }

    async getAllBooks() {
        return await this.#readBooks();
    }

    async getBookById(id) {
        const books = await this.#readBooks();
        return books.find(b => b.id === id);
    }

    async createBook(bookData) {
        const books = await this.#readBooks();
        const newBook = {
            id: uuidv4(),
            title: bookData.title,
            author: bookData.author,
            createdAt: new Date().toISOString()
        };
        books.push(newBook);
        await this.#writeBooks(books);
        this.emit('Book Added', newBook);
        return newBook;
    }

    async updateBook(id, updateData) {
        const books = await this.#readBooks();
        const index = books.findIndex(b => b.id === id);
        if (index === -1) return null;

        books[index] = { 
            ...books[index], 
            ...updateData, 
            id, // Ensure ID is not overwritten
            updatedAt: new Date().toISOString()
        };
        
        await this.#writeBooks(books);
        this.emit('Book Updated', books[index]);
        return books[index];
    }

    async deleteBook(id) {
        let books = await this.#readBooks();
        const bookToDelete = books.find(b => b.id === id);
        if (!bookToDelete) return false;

        books = books.filter(b => b.id !== id);
        await this.#writeBooks(books);
        this.emit('Book Deleted', id);
        return true;
    }
}

export default new BookService();
