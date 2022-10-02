/**
 * Data Accessor for Mongo.
 *
 * @module MenuItemAccessor
 */
const { ConnectionManager } = require("./ConnectionManager");
const { MenuItem } = require("../entity/MenuItem");
const { Constants } = require("../utils/Constants");

exports.getAllItems = getAllItems;
exports.getItemByID = getItemByID;
exports.itemExists = itemExists;
exports.deleteItem = deleteItem;
exports.addItem = addItem;
exports.updateItem = updateItem;

/**
 * Gets all the items.
 *
 * @example
 * let items = await getAllItems();
 * @throws {Error} if a database error occurs
 * @returns {Promise<array<MenuItem>>} resolves to: an array of MenuItem objects (empty if there are none)
 */
async function getAllItems() {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let objects = await collection.find({}).toArray();

        // 'objects' is an array of objects, but they're not instances of MenuItem.
        let items = [];
        objects.forEach((obj) => {
            let temp = new MenuItem(
                obj.id,
                obj.category,
                obj.description,
                obj.price,
                obj.vegetarian
            );
            items.push(temp);
        });
        ConnectionManager.closeConnection();
        return items;
    } catch (err) {
        throw new Error("Could not complete getAllItems!\n" + err);
        
    }
} // end function

/**
 * Determines if a MenuItem object exists in the database.
 *
 * @param {MenuItem} - the object to find
 * @throws {Error} if a database error occurs
 * @returns {Promise<boolean>} resolves to: true if the item exists; false otherwise
 */
async function itemExists(item) {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let docs = await collection.find({ id: item.id }).toArray();
        let res = docs.length === 1;
        ConnectionManager.closeConnection();
        return res;
    } catch (err) {
        throw new Error("Could not complete itemExists!\n" + err.message);
    }
} // end function

/**
 * Gets the object with the specified ID.
 *
 * @param {number} itemID - the ID of the object to return
 * @throws {Error} if a database error occurs
 * @returns {Promise<MenuItem>} resolves to: the matching MenuItem object; or null if the object doesn't exist
 */
async function getItemByID(itemID) {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let docs = await collection.find({ id: itemID }).toArray();
        let res = null;
        if (docs.length === 1) {
            let obj = docs[0];
            res = new MenuItem(
                obj.id,
                obj.category,
                obj.description,
                obj.price,
                obj.vegetarian
            );
        }
        ConnectionManager.closeConnection();
        return res;
    } catch (err) {
        throw new Error("Could not complete getItemByID!\n" + err.message);
    }
} // end function

/**
 * Adds the specified item (if it doesn't already exist).
 *
 * @param {MenuItem} item - the item to add
 * @throws {Error} if a database error occurs
 * @returns {Promise<boolean>} resolves to: true if the item was added; false if the item already exists.
 */
async function addItem(item) {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let docs = await collection.find({ id: item.id }).toArray();
        let res;
        if (docs.length > 0) {
            res = false;
        } else {
            let result = await collection.insertOne(item.toJSON()); // toJSON actually returns an object, not a JSON string
            res = result.acknowledged;
        }
        ConnectionManager.closeConnection();
        return res;
    } catch (err) {
        throw new Error("Could not complete addItem!\n" + err.message);
    }
} // end function

/**
 * Deletes the specified item (if it exists).
 *
 * @param {MenuItem} item - the item to delete
 * @throws {Error} if a database error occurs
 * @returns {Promise<boolean>} resolves to: true if the item was deleted; false if the item doesn't exist.
 */
async function deleteItem(item) {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let query = { id: item.id };
        let result = await collection.deleteOne(query);
        let res = result.deletedCount === 1;
        ConnectionManager.closeConnection();
        return res;
    } catch (err) {
        throw new Error("Could not complete deleteItem!\n" + err.message);
    }
} // end function

/**
 * Updates the specified item (if it exists).
 *
 * @param {MenuItem} item - the item to update
 * @throws {Error} if a database error occurs
 * @returns {Promise<boolean>} resolves to: true if the item was updated; false if the item doesn't exist.
 */
async function updateItem(item) {
    try {
        let client = await ConnectionManager.getConnection();
        let collection = client
            .db(Constants.DB_NAME)
            .collection(Constants.DB_COLLECTION);
        let query = {
            id: item.id,
        };
        let values = {
            $set: {
                category: item.category,
                description: item.description,
                price: item.price,
                vegetarian: item.vegetarian,
            },
        };
        let docs = await collection.find(query).toArray();
        let res;
        if (docs.length === 0) {
            res = false;
        } else {
            let result = await collection.updateOne(query, values);
            res = result.modifiedCount === 1;
        }
        ConnectionManager.closeConnection();
        return res;
    } catch (err) {
        throw new Error("Could not complete updateItem!\n" + err.message);
    }
} // end function