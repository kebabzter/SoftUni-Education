function cookingByNumbers(number, action1, action2, action3, action4, action5) {
    let parsed = Number(number);

    if (action1 === 'chop') {
        parsed /= 2;
    }
    else if (action1 === 'dice') {
        parsed = Math.sqrt(parsed);
    }
    else if (action1 === 'spice') {
        parsed += 1;
    }
    else if (action1 === 'bake') {
        parsed *= 3;
    }
    else if (action1 === 'fillet') {
        parsed *= 0.8;
    }

    parsed = Math.round( parsed * 10 ) / 10;

    console.log(parsed);

    if (action2 === 'chop') {
        parsed /= 2;
    }
    else if (action2 === 'dice') {
        parsed = Math.sqrt(parsed);
    }
    else if (action2 === 'spice') {
        parsed += 1;
    }
    else if (action2 === 'bake') {
        parsed *= 3;
    }
    else if (action2 === 'fillet') {
        parsed *= 0.8;
    }

    parsed = Math.round( parsed * 10 ) / 10;

    console.log(parsed);

    if (action3 === 'chop') {
        parsed /= 2;
    }
    else if (action3 === 'dice') {
        parsed = Math.sqrt(parsed);
    }
    else if (action3 === 'spice') {
        parsed += 1;
    }
    else if (action3 === 'bake') {
        parsed *= 3;
    }
    else if (action3 === 'fillet') {
        parsed *= 0.8;
    }

    parsed = Math.round( parsed * 10 ) / 10;

    console.log(parsed);

    if (action4 === 'chop') {
        parsed /= 2;
    }
    else if (action4 === 'dice') {
        parsed = Math.sqrt(parsed);
    }
    else if (action4 === 'spice') {
        parsed += 1;
    }
    else if (action4 === 'bake') {
        parsed *= 3;
    }
    else if (action4 === 'fillet') {
        parsed *= 0.8;
    }

    parsed = Math.round( parsed * 10 ) / 10;

    console.log(parsed);

    if (action5 === 'chop') {
        parsed /= 2;
    }
    else if (action5 === 'dice') {
        parsed = Math.sqrt(parsed);
    }
    else if (action5 === 'spice') {
        parsed += 1;
    }
    else if (action5 === 'bake') {
        parsed *= 3;
    }
    else if (action5 === 'fillet') {
        parsed *= 0.8;
    }

    parsed = Math.round( parsed * 10 ) / 10;

    console.log(parsed);
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');