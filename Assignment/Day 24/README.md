# TypeScript Contact Manager

## Project Overview
This is a clean, modular, and well-structured Contact Manager application built with TypeScript. It allows users to manage contacts with full CRUD operations and features robust error handling.

## Features
- **Add Contact**: Store new contacts with unique IDs.
- **View Contacts**: Retrieve a list of all stored contacts.
- **Modify Contact**: Update specific fields of an existing contact.
- **Delete Contact**: Remove contacts by their ID.
- **Error Handling**: Comprehensive try-catch blocks for validation and missing resources.
- **Search (Bonus)**: Search contacts by name.

## Folder Structure
- `src/interfaces/`: TypeScript interfaces (e.g., `Contact`).
- `src/services/`: Core logic classes (e.g., `ContactManager`).
- `test/`: Automated testing scripts.
- `dist/`: Compiled JavaScript output.
- `tsconfig.json`: TypeScript compiler configuration.
- `package.json`: Project dependencies and scripts.

## How to Run the Project
1. **Navigate to the project folder:**
   ```bash
   cd "Day 24"
   ```
2. **Install dependencies:**
   ```bash
   npm install
   ```
3. **Compile TypeScript:**
   ```bash
   npm run build
   ```
4. **Run the testing script:**
   ```bash
   npm start
   ```

## Example Commands
```bash
# To build and test in one go
npm test
```

## Tools Used
- **TypeScript**: For static typing and modern JavaScript features.
- **Node.js**: For executing the compiled JavaScript.
