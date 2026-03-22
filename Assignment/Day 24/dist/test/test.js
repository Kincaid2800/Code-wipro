"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ContactManager_1 = require("../src/services/ContactManager");
const manager = new ContactManager_1.ContactManager();
console.log("--- Contact Manager Testing Script ---\n");
try {
    // 1. Add multiple contacts
    console.log("Adding contacts...");
    manager.addContact({ id: 1, name: "John Doe", email: "john@example.com", phone: "1234567890" });
    manager.addContact({ id: 2, name: "Jane Smith", email: "jane@example.com", phone: "0987654321" });
    manager.addContact({ id: 3, name: "Alice Brown", email: "alice@example.com", phone: "5556667777" });
    // 2. Display all contacts
    console.log("\nViewing all contacts:");
    console.log(manager.viewContacts());
    // 3. Update a contact
    console.log("\nUpdating contact ID 2...");
    manager.modifyContact(2, { name: "Jane Doe-Smith", email: "jane.doe@example.com" });
    console.log("Updated contact details:", manager.viewContacts().find(c => c.id === 2));
    // 4. Delete a contact
    console.log("\nDeleting contact ID 3...");
    manager.deleteContact(3);
    console.log("Remaining contacts:", manager.viewContacts().length);
    // 5. Attempt invalid operations (Errors)
    console.log("\n--- Testing Error Handling ---");
    // Duplicate ID
    console.log("Attempting to add duplicate ID 1:");
    try {
        manager.addContact({ id: 1, name: "Duplicate", email: "dup@example.com", phone: "000" });
    }
    catch (error) {
        console.error("Caught expected error:", error.message);
    }
    // Modify non-existent
    console.log("\nAttempting to modify non-existent ID 99:");
    try {
        manager.modifyContact(99, { name: "Ghost" });
    }
    catch (error) {
        console.error("Caught expected error:", error.message);
    }
    // Delete non-existent
    console.log("\nAttempting to delete non-existent ID 99:");
    try {
        manager.deleteContact(99);
    }
    catch (error) {
        console.error("Caught expected error:", error.message);
    }
    // Bonus: Search
    console.log("\nSearching for 'Jane':");
    console.log(manager.searchContactByName("Jane"));
}
catch (error) {
    console.error("An unexpected error occurred during testing:", error.message);
}
console.log("\n--- Testing Completed ---");
