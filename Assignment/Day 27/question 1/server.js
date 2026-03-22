const express = require('express');
const cors = require('cors');
const logger = require('./src/middleware/logger');
const bookRouter = require('./src/routes/books');

const app = express();
const PORT = 4000;

// Global Middleware
app.use(cors());
app.use(express.json());
app.use(logger); // Custom Request Logger

// --- Basic Routes ---

// Root welcome route
app.get('/', (req, res) => {
    res.status(200).send("Welcome to Express Server");
});

// Status check route
app.get('/status', (req, res) => {
    res.status(200).json({
        server: "running",
        uptime: "OK"
    });
});

/**
 * Query Parameters Example (Products Search)
 * GET /products?name=<productName>
 */
app.get('/products', (req, res) => {
    const { name } = req.query;
    
    if (name) {
        return res.status(200).json({
            message: `Searching for product: ${name}`,
            query: name
        });
    }
    
    res.status(200).send("Please provide a product name");
});

// --- Modular Routing ---
app.use('/books', bookRouter);

// --- Error Handling ---

// 404 Handler (Route not found)
app.use((req, res, next) => {
    res.status(404).json({ error: "Route not found" });
});

// Global Error Handler
app.use((err, req, res, next) => {
    console.error("Global Error Handler Catch:", err.stack);
    res.status(500).json({ error: "Internal Server Error" });
});

// Start Server
app.listen(PORT, () => {
    console.log(`Express server is running on http://localhost:${PORT}`);
});
