"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ContactManager = void 0;
class ContactManager {
    constructor() {
        this.contacts = [];
    }
    /**
     * Adds a new contact to the manager.
     * @param contact The contact to add.
     * @throws Error if contact with the same ID already exists.
     */
    addContact(contact) {
        const existing = this.contacts.find(c => c.id === contact.id);
        if (existing) {
            throw new Error(`Contact with ID ${contact.id} already exists.`);
        }
        this.contacts.push(contact);
        console.log("Contact added successfully");
    }
    /**
     * Returns a list of all contacts.
     */
    viewContacts() {
        return [...this.contacts];
    }
    /**
     * Modifies an existing contact.
     * @param id The ID of the contact to modify.
     * @param updatedContact The fields to update.
     * @throws Error if contact is not found.
     */
    modifyContact(id, updatedContact) {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            throw new Error(`Contact with ID ${id} not found.`);
        }
        this.contacts[index] = Object.assign(Object.assign({}, this.contacts[index]), updatedContact);
        console.log("Contact updated successfully");
    }
    /**
     * Deletes a contact by its ID.
     * @param id The ID of the contact to delete.
     * @throws Error if contact is not found.
     */
    deleteContact(id) {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            throw new Error(`Contact with ID ${id} not found.`);
        }
        this.contacts.splice(index, 1);
        console.log("Contact deleted successfully");
    }
    /**
     * Bonus: Search contact by name.
     * @param name The name to search for.
     */
    searchContactByName(name) {
        return this.contacts.filter(c => c.name.toLowerCase().includes(name.toLowerCase()));
    }
}
exports.ContactManager = ContactManager;
