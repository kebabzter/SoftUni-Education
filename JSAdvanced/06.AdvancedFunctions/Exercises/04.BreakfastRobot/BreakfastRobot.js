function solution() {
    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    let storage = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

    function restock(element, quantity) {
        storage[element] += Number(quantity);
        return `Success`;
    }

    function prepare(recipe, quantity) {
        let flag = true;
        
        for (const element in recipes[recipe]) {
            if (storage[element] - recipes[recipe][element] * Number(quantity) < 0) {
                flag = false;
                return `Error: not enough ${element} in stock`
            }
        }

        if (flag) {
            for (const element in recipes[recipe]) {
                storage[element] -= recipes[recipe][element] * Number(quantity);
            }

            return `Success`;
        }
    }

    function report() {
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`
    }

    function robot(input) {
        let [command, item, quantity] = input.split(' ');

        if (command == 'restock') {
            return restock(item, quantity);
        } else if (command == 'prepare') {
            return prepare(item, quantity);
        } else if (command == 'report') {
            return report();
        }
    }

    return robot;
}