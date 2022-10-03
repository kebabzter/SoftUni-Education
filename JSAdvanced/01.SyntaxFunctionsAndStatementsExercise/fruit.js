function calculate(type, grams, pricePerKilo){
    let weightInKilo = grams/1000;
    let moneyNeeded = weightInKilo * pricePerKilo;
    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weightInKilo.toFixed(2)} kilograms ${type}.`)
}

calculate('orange', 2500, 1.80)