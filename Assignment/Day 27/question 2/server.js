const express = require('express');
const courseRoutes = require('./src/routes/courses');

const app = express();
const PORT = 4000;

// Middleware
app.use(express.json());

/**
 * Basic Routing
 */
app.get('/', (req, res) => {
    res.status(200).send("Welcome to SkillSphere LMS API");
});

// Use modular course routes
app.use('/', courseRoutes);

// Start Server
app.listen(PORT, () => {
    console.log(`SkillSphere LMS API is running on http://localhost:${PORT}`);
});
