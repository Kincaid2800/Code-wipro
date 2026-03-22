/**
 * Custom logging middleware.
 * Logs: [TIMESTAMP] [METHOD] URL
 */
const logger = (req, res, next) => {
    const timestamp = new Date().toISOString().replace(/T/, ' ').replace(/\..+/, '');
    const method = req.method;
    const url = req.originalUrl;
    
    console.log(`[${timestamp}] [${method}] ${url}`);
    next();
};

module.exports = logger;
