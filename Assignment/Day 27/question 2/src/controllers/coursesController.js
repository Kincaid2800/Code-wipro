/**
 * Get course details by ID.
 */
const getCourseById = (req, res) => {
    const { id } = req.params;
    
    // Constant response as per requirements
    res.status(200).json({
        id: id,
        name: "React Mastery",
        duration: "6 weeks"
    });
};

module.exports = { getCourseById };
