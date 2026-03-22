const express = require('express');
const router = express.Router();
const { getCourseById } = require('../controllers/coursesController');
const { validateCourseId } = require('../middleware/validation');

/**
 * Courses Routes
 * Apply validation middleware specifically to the dynamic route
 */
router.get('/courses/:id', validateCourseId, getCourseById);

module.exports = router;
