/**
 * Class to represent an item on a restaurant menu.
 */
class MenuItem {
    #id;
    #category;
    #description;
    #price;
    #vegetarian = false; // default

    /**
     * Creates a new MenuItem object.
     *
     * @param {number} id - the item's ID
     * @param {string} category - the item's category
     * @param {string} description - the item's description
     * @param {number} price - the item's price
     * @param {boolean} vegetarian - whether the item is vegetarian
     */
    constructor(id, category, description, price, vegetarian) {
        this.#id = id;
        this.#category = category;
        this.#description = description;
        this.#price = price;
        this.#vegetarian = vegetarian;
    }

    // Getters
    get id() {
        return this.#id;
    }
    get category() {
        return this.#category;
    }
    get description() {
        return this.#description;
    }
    get price() {
        return this.#price;
    }
    get vegetarian() {
        return this.#vegetarian;
    }

    /**
     * Needed because JSON.stringify can't see the (private) fields.
     * JSON.stringify will call this method instead.
     * You can also call this method to get a JS object containing just the data (no methods).
     *
     * @returns an object containing the data without the methods
     */
    toJSON() {
        return {
            id: this.#id,
            category: this.#category,
            description: this.#description,
            price: this.#price,
            vegetarian: this.#vegetarian,
        };
    }
    toCSV() {
        return `${this.#id}, ${this.#category}, ${this.#description}, ${
            this.#price
        }, ${this.#vegetarian}`;
    }

    formatItem() {
        return `\t${this.#description} (ID: ${this.#id}): ${this.#price} ${
            this.#vegetarian ? " (veg)" : ""
        }`;
    }
} // end class

exports.MenuItem = MenuItem;
