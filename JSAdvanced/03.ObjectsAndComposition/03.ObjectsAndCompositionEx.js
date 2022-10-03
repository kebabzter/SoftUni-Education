// 1.Calorie Object

function calorieObject(array) {
    let obj = {};
    for (let i = 0; i < array.length; i += 2) {
        let name = array[i];
        let calories = Number(array[i + 1]);

        obj[name] = calories;
    }

    console.log(obj);
}

// 2.Construction Crew

function constructionCrew(obj) {
    if (obj.dizziness === true) {
        obj.levelOfHydrated += obj.weight * obj.experience * 0.1;
        obj.dizziness = false;
    };

    return obj;
}

// 3.Car Factory

function carFactory(obj) {
    let power = obj.power;
    let volume = 0;

    if (power <= 90) {
        power = 90;
        volume = 1800;
    } else if (power <= 120) {
        power = 120;
        volume = 2400;
    } else {
        power = 200;
        volume = 3500;
    };

    let wheels = obj.wheelsize % 2 === 0 ? obj.wheelsize - 1 : obj.wheelsize;

    let result = {
        model: obj.model,
        engine: {
            power: power,
            volume: volume,
        },
        carriage: {
            type: obj.carriage,
            color: obj.color
        },
        wheels: new Array(4).fill(wheels, 0, 4)
    };

    return result;
}

// 4.Heroic Inventory

function heroes(array) {
    let result = [];
    for (let i = 0; i < array.length; i++) {
        let [name, level, items] = array[i].split(' / ');

        let obj = {
            name: name,
            level: Number(level),
            items: items ? items.split(", ") : []
        };

        result.push(obj);
    }

    return JSON.stringify(result);
}

//5.Lowest Prices in Cities

function findLowestPricedProducts(input) {
    let products = new Map;
    for (let priceList of input) {
        let [town, product, price] = priceList.split(/\s+\|\s+/g);
        if (!products.has(product))
            products.set(product, new Map);
        products.get(product).set(town, Number(price));
    }

    for (let [product, towns] of products) {
        let minPrice = Number.MAX_VALUE;
        let minPriceTown = '';
        for (let [town, price] of towns) {
            if (price < minPrice) {
                minPrice = price;
                minPriceTown = town;
            }
        }

        console.log(`${product} -> ${minPrice} (${minPriceTown})`);
    }
}

//06.Store Catalogue

function storeCatalogue(arr) {
    let products = new Map();
    for (let line of arr) {
        let data = line.split(/\b\s:\s\b/);
        let letter = line[0][0];
        if (!products.has(letter)) {
            products.set(letter, data);
        }
        else {
            products.set(letter,products.get(letter)+","+data);
        }
    }
    let myProducts = new Map([...products.entries()].sort());
    for (let [letter, items] of myProducts) {
        console.log(letter);
        if(items.constructor !== Array){
            items=items.split(',');
        }
        let products = [];
        for (let i = 0; i < items.length; i+=2) {
            let product =items[i];
            let price =items[i+1];
            let line = product+": "+price;
            products.push(line);
            products.sort();
        }
        for (let product of products) {
            console.log(`  ${product}`);
        }
    }
}

//07.Towns to JSON

function towns(array = []) {
    class Town {
        constructor(name, latitude, longitude) {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
 
    let result = [];
 
    for (let i = 1; i < array.length; i++) {
        let arr = array[i].split("|");
        let name = arr[1].trim();
        let latitude = (+arr[2].trim()).toFixed(2);
        let longitude = (+arr[3].trim()).toFixed(2);
      
        let town = new Town(name, latitude, longitude);
 
        let townForJSON = {};
 
        townForJSON["Town"] = town.name;
        townForJSON["Latitude"] = town.latitude;
        townForJSON["Longitude"] = town.longitude;
 
        let objectToJSON = JSON.stringify(townForJSON, function (key, value) {
            if (key == "Latitude") {
                return Number(value);
            } else if (key == "Longitude") {
                return Number(value);
            } else {
                return value;
            }
        });
 
        result.push(objectToJSON);      
    }
 
    console.log("[" + result.join(",") + "]");
}

//08.Rectangle

function rectangle(width, height, color) {
    return object = {
        width,
        height,
        color: color[0].toUpperCase() + color.substring(1),
        calcArea: () => { 
            return (width * height);
        }
    }

}