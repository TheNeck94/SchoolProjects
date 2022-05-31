// your code here
const assert = require("chai").assert;
const { ConnectionManager } = require("../db/ConnectionManager");
const dbbuilder = require("../db/DatabaseBuilder");
const acc = require("../db/MenuItemAccessor");
const { MenuItem } = require("../entity/MenuItem");
const { Constants } = require("../utils/Constants");
const rs = require("../api/RestaurantService");
let testItems;


describe("Restaraunt API Tests", function(){
    before("Setup", async function() {
        testItems = await defineTestItems();
        await dbbuilder.rebuild();
        console.log("Setup, Database Restored");
    });
    after("Teardown", async function() {
        await ConnectionManager.closeConnection();
    });
    describe("Good Requests (200 series)", function(){
        it("LIST returns status 200, null error, and correct list of items.", async function() {
            // arrange
            let data = await acc.getAllItems();
            let expected = {
                statusCode: 200,
                err: null,
                data: data
            }

            // act
            let actual = await rs.processRequest("List", null);

            // assert
            assert.deepEqual(actual, expected);
        });
        it("ADD adds a new item, returns status 201, null error, and data true if item does not already exist", async function() {
            // arrange
            let item = testItems.itemToAdd
            let expected = {
                statusCode: 201,
                err: null,
                data: true
            }

            // act
            let actual = await rs.processRequest("add", item);
            // verify
            let res = await acc.itemExists(item);
            
            // assert
            assert.deepEqual(actual, expected);
            assert.isTrue(res);
        });
        it("DELETE deletes an item, returns status 200, null error, and data true if item exists", async function() {
            // arrange
            let item = testItems.itemToDelete;
            let expected = {
                statusCode: 200,
                err: null,
                data: true
            }

            // act
            let actual = await rs.processRequest("delete", item);
            // verify
            let res = await acc.itemExists(item);

            // assert
            assert.deepEqual(actual, expected);
            assert.isFalse(res);
        });
        it("UPDATE updates an item, returns status 200, null error, and data true if item exists", async function() {
            // arrange
            let item = testItems.itemToUpdate;
            let expected = {
                statusCode: 200,
                err: null,
                data: true
            }

            // act
            let actual = await rs.processRequest("update", item);
            // verify
            let res = await acc.getItemByID(item.id);
            

            // assert
            assert.deepEqual(actual, expected);
            assert.deepEqual(item, res);
        });
    });
    describe("Bad Requests (400 Series)", function() {
        describe("Invalid Commands - expect: status 405, error message, and null data", function() {
            it("Command is empty: API returns expected response", async function() {
                // arrange
                let expected = {
                    statusCode: 405,
                    err: `unsupported operation: ''`,
                    data: null
                }

                // act
                let actual = await rs.processRequest("", null);

                // assert
                assert.deepEqual(actual, expected);
            });
            it("command is null: API returns expected response", async function() {
                // arrange
                let expected = {
                    statusCode: 405,
                    err: `unsupported operation: ''`,
                    data: null
                }

                // act
                let actual = await rs.processRequest(null, null);

                // assert
                assert.deepEqual(actual, expected);
            });
            it("command is 'foo': API returns expected response", async function() {
                // arrange
                let expected = {
                    statusCode: 405,
                    err: `unsupported operation: 'foo'`,
                    data: null
                }

                // act
                let actual = await rs.processRequest("foo", null);

                // assert
                assert.deepEqual(actual, expected);
            });
            it("command is 'addd': API returns expected response", async function() {
                // arrange
                let expected = {
                    statusCode: 405,
                    err: `unsupported operation: 'addd'`,
                    data: null
                }

                // act
                let actual = await rs.processRequest("addd", null);

                // assert
                assert.deepEqual(actual, expected);
            });
            it("command is 'ad': API returns expected response", async function() {
                // arrange
                let expected = {
                    statusCode: 405,
                    err: `unsupported operation: 'ad'`,
                    data: null
                }

                // act
                let actual = await rs.processRequest("ad", null);

                // assert
                assert.deepEqual(actual, expected);
            });
        });
        describe("Content is not and object = expect: status 400, error message, and null data", function() {
            it("Content is omitted: DELETE does not change database, and returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete");
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("Conted is null: DELETE does not change database, and returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete", null);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("Content is a string: DELETE does not change database, and returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete", "yupp");
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("content is a valid ID (number): DELETE does not change database, and returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete", 107);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });

        });
        describe("Content is an object but not a MenuItem - expect: status 400, error message, and null data", function() {
            it("ADD returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.wrongTypeItem;
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("add", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("DELETE returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.wrongTypeItem;
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("UPDATE returns expected response", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.wrongTypeItem;
                let expected = {
                    statusCode: 400,
                    err: "unrecognized entity",
                    data: null
                }

                // act
                let actual = await rs.processRequest("update", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
        });
        describe("Content is a MenuItem, but the operation cannot be performed", async function() {
            it("ADD does not change database, returns status 409, error message, and null data, if item already exists", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.itemToAdd;
                let expected = {
                    statusCode: 409,
                    err: "entity already exists - could not be added",
                    data: null
                }

                // act
                let actual = await rs.processRequest("add", item);
                let check = await rs.processRequest("add", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.notEqual(check, expected);
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("DELETE does not change the database, returns status 404, error message, and null data, if item does not already exist", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.itemToDelete;
                let expected = {
                    statusCode: 404,
                    err: "entity does not exist - could not delete",
                    data: null
                }

                // act
                let actual = await rs.processRequest("delete", item);
                let check = await rs.processRequest("delete", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.notEqual(check, expected);
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
            it("UPDATE does not change database, returns status 404, error message, and null data, if item does not already exist", async function() {
                // arrange
                let data = await acc.getAllItems();
                let item = testItems.itemToDelete;
                let expected = {
                    statusCode: 404,
                    err: "entity does not exist - could not update",
                    data: null
                }
                
                // act
                let actual = await rs.processRequest("update", item);
                let check = await rs.processRequest("update", item);
                // verify
                let afterData = await acc.getAllItems();

                // assert
                assert.notEqual(check, expected);
                assert.deepEqual(actual, expected);
                assert.deepEqual(data, afterData);
            });
        });

    });
    describe("Server Errors (500 Series)", async function() {
        before(function() {
             Constants.DB_URI = "999"
        });                     //Setup (corrupt connection URI)
        after(function() {
             Constants.DB_URI = "mongodb://localhost:27017"
        });                     //teardown
        it("LIST returns expected response, if there is a server-side error", async function() {
            // arrange
            expected = {
            statusCode: 500,
            err: "server error - please try again later",
            data: null
            };

            // act
            let actual = await rs.processRequest("list", null);

            // assert
            assert.deepEqual(actual, expected);
        });
        it("ADD returns expected response, if there is a server-side error", async function() {
            // arrange
            let item = testItems.itemToAdd;
            expected = {
            statusCode: 500,
            err: "server error - please try again later",
            data: null
            };
            
            // act
            let actual = await rs.processRequest("add", item);

            // assert
            assert.deepEqual(actual, expected);
        });
        it("DELETE returns expected response, if there is a server-side error", async function() {
            // arrange
            let  item = testItems.itemToDelete
            expected = {
            statusCode: 500,
            err: "server error - please try again later",
            data: null
            };

            // act
            let actual = await rs.processRequest("delete", item);

            // assert
            assert.deepEqual(actual, expected);
        });
        it("UPDATE returns expected response, if there is a server-side error", async function() {
            //arrange
            let item = testItems.itemToUpdate
            expected = {
            statusCode: 500,
            err: "server error - please try again later",
            data: null
            };

            //act
            let actual = await rs.processRequest("update", item);
            
            //assert
            assert.deepEqual(actual, expected);
        }); 
    });
});
///*** HELPERS ***///
function defineTestItems() {
    return {
        goodItem: new MenuItem(107, "", "", 0, false),
        badItem: new MenuItem(777, "", "", 0, false),
        itemToAdd: new MenuItem(888, "ENT", "poutine", 11, false),
        itemToDelete: new MenuItem(202, "", "", 30, false),
        itemToUpdate: new MenuItem(303, "ENT", "after update", 11, false),
        wrongTypeItem: {
            id: 107,
            category: "",
            description: "",
            price: 0,
            vegetarian: false,
        },
    };
}
