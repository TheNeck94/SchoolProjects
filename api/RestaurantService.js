/**
 * What do we want from an API (data service)?
 *
 * The API is the main point of contact for the user.
 * It receives requests from the user, communicates with the
 * back end processes, and sends responses back to the user.
 *
 * 1. Users should have no knowledge of what the back end
 *    processes are - for example, they don't know that there
 *    a MenuItemAccessor.
 * 2. All data is represented by an entity that is shared
 *    shared by the user (front end) and the back end. In other
 *    words, the user creates instances of the entity to represent
 *    data it wants to send, and the back end responds with instances
 *    of the same entity.
 * 3. The API should catch errors, but it cannot throw them.
 *    This is because there is no way to throw an error over a
 *    network. So, error information must be returned to the user
 *    in the form of an error message.
 * 4. All responses should include a status code to help the user
 *    determine what has happened. We will use the same HTTP status
 *    codes that are used most web applications.
 *
 *    HTTP Status Codes
 *
 *    200 - indicates a successful retrieval, delete, or update.
 *    201 - indicates a successful creation of a new resource.
 *    400 - indicates a mal-formed entity
 *    404 - indicates that the requested entity does not exist
 *    405 - indicates that the requested operation is not supported
 *    409 - indicates a conflict with the requested operation,
 *          such as trying to add an entity that already exists
 *    500 - indicates a server-side error, such as a database
 *          or a network error
 */

const mia = require("../db/MenuItemAccessor");
const { MenuItem } = require("../entity/MenuItem");

/**
 * Handle a request to perform an action on the dataset.
 *
 * @param {string} action - the action to perform: one of LIST, ADD, UPDATE, DELETE
 * @param {MenuItem object} content - the object to be added, updated, or deleted; null for LIST requests.
 * @returns {object} - an object containing three fields: statusCode, err, data. As per convention,
 *                     only one of err or data will be populated.
 */
async function processRequest(action, content) {
    let resp = null;
    if (action == null) {
        action = "";
    }
    switch (action.toUpperCase()) {
        case "LIST":
            resp = doList();
            break;
        case "ADD":
            resp = doAdd(content);
            break;
        case "UPDATE":
            resp = doUpdate(content);
            break;
        case "DELETE":
            resp = doDelete(content);
            break;
        default:
            resp = {
                statusCode: 405,
                err: `unsupported operation: '${action}'`,
                data: null,
            };
    }
    return resp;
}

async function doList() {
    let resp = null;
    try {
        let items = await mia.getAllItems();
        resp = createResponseObject(200, null, items);
    } catch (err) {
        resp = createResponseObject(
            500,
            "server error - please try again later",
            null
        );
    }
    return resp;
}

async function doAdd(content) {
    let resp = null;
    if (!(content instanceof MenuItem)) {
        resp = createResponseObject(400, "unrecognized entity", null);
    } else {
        try {
            let ok = await mia.addItem(content);
            if (ok) {
                resp = createResponseObject(201, null, true);
            } else {
                resp = createResponseObject(
                    409,
                    "entity already exists - could not be added",
                    null
                );
            }
        } catch (err) {
            resp = createResponseObject(
                500,
                "server error - please try again later",
                null
            );
        }
    }
    return resp;
}

async function doDelete(content) {
    let resp = null;
    if (!(content instanceof MenuItem)) {
        resp = createResponseObject(400, "unrecognized entity", null);
    } else {
        try {
            let ok = await mia.deleteItem(content);
            if (ok) {
                resp = createResponseObject(200, null, true);
            } else {
                resp = createResponseObject(
                    404,
                    "entity does not exist - could not delete",
                    null
                );
            }
        } catch (err) {
            resp = createResponseObject(
                500,
                "server error - please try again later",
                null
            );
        }
    }
    return resp;
}

async function doUpdate(content) {
    let resp = null;
    if (!(content instanceof MenuItem)) {
        resp = {
            statusCode: 400,
            err: "unrecognized entity",
            data: null,
        };
    } else {
        try {
            let ok = await mia.updateItem(content);
            if (ok) {
                resp = {
                    statusCode: 200,
                    err: null,
                    data: true,
                };
            } else {
                resp = {
                    statusCode: 404,
                    err: "entity does not exist - could not update",
                    data: null,
                };
            }
        } catch (err) {
            resp = {
                statusCode: 500,
                err: "server error - please try again later",
                data: null,
            };
        }
    }
    return resp;
}

function createResponseObject(statusCode, err, data) {
    return {
        statusCode: statusCode,
        err: err,
        data: data,
    };
}

exports.processRequest = processRequest;
