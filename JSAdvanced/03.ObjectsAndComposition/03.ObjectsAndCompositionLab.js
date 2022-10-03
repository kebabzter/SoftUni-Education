// 1.City Record

function createRecord(name, population, treasury) {
    let city = {
        name: name,
        population: population,
        treasury: treasury
    };

    return city;
}

// 2.Town Population

function townPopulation(array) {
    let towns = {};
    for (const item of array) {
        let tokens = item.split(' <-> ');
        let name = tokens[0];
        let population = Number(tokens[1]);

        if (towns[name] != undefined) {
            population += towns[name];
        }

        towns[name] = population;
    }

    for (const name in towns) {
        console.log(`${name} : ${towns[name]}`);
    }
};

// 3.City Taxes

function createRecord(name, population, treasury) {
    let city = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population = this.population * (1 + (percentage / 100));
        },
        applyRecession(percentage) {
            this.treasury = this.treasury * (1 - (percentage / 100));
        }

    };

    return city;
}

// 4.Object Factory

function factory(library, orders) {
    const result = [];
    for (const order of orders) {
        const composed = Object.assign({}, order.template);
        for (const part of order.parts) {
            composed[part] = library[part]
        }
        result.push(composed);
    }

    return result;
};

//5.Assembly Line

function createAssemblyLine() {
    result = {};
    result.hasClima = (car) => {
        car.temp = 21;
        car.tempSettings = 21;
        car.adjustTemp = () => {
            if (car.temp < car.tempSettings) {
                car.temp++;
            } else if(car.temp > car.tempSettings) {
                car.temp--;
            }
        }
    }
    result.hasAudio = (car) => {
        car.currentTrack = {
            name: null,
            artist: null,
        }
        car.nowPlaying = () => {
            if (car.currentTrack.name !== null){
                console.log(`Now playing ${car.currentTrack.name} by ${car.currentTrack.artist}`);
            }
        }
    }
    result.hasParktronic = (car) => {
        car.checkDistance = (distance) => {
            if (distance < 0.1){
                console.log('Beep! Beep! Beep!');
            } else if (distance >= 0.1 && distance < 0.25) {
                console.log('Beep! Beep!');
            } else if (distance >= 0.25 && distance < 0.5) { 
                console.log('Beep!');
            } else {
                console.log('');
            }
        }
    }
    return result;
}

//6.From JSON to HTML Table

function fromJSONToHTMLTable(input) {

    let symbolsToReplace = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '\"': '&quot;',
        '\'': '&#39;'
    };

    function escapeSymbols(text) {
        return text
            .split("&").join(symbolsToReplace["&"])
            .split("<").join(symbolsToReplace["<"])
            .split(">").join(symbolsToReplace[">"])
            .split("\"").join(symbolsToReplace["\""])
            .split("\'").join(symbolsToReplace["'"])
    }

    let table = []
    table.push('<table>')

    let parsedObject = JSON.parse(input)
    let objectProperties = Object.keys(parsedObject[0])

    function aggregateTableHeading(properties) {
        return properties
            .map(p => `<th>${p}</th>`)
            .reduce((a, b) => {
                a.push(b)
                return a;
            }, ['  <tr>'])
            .join('')
            + '</tr>'
    }

    table.push(aggregateTableHeading(objectProperties))

    function aggregateTableRow(obj) {

        return Object.keys(obj)
            .reduce((a, b) => {
                a.push(`<td>${isNaN(obj[b]) ? escapeSymbols(obj[b]) : obj[b]}</td>`)
                return a;
            }, ['  <tr>'])
            .join('')
            + '</tr>'
    }

    parsedObject
        .map(o => aggregateTableRow(o))
        .forEach(r => table.push(r))
    table.push('</table>')

    return table.join('\n');

}