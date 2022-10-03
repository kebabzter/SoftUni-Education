function roadRadar(speed, road) {
    let residentialLimit = 20;
    let cityLimit = 50;
    let interstateLimit = 90;
    let motorwayLimit = 130;

    let overLimit;   
    let status;

    switch (road) {
        case 'city':
            overLimit = speed - cityLimit;

            if (overLimit > 0 && overLimit <= 20) {
                status = 'speeding';
            }
            else if (overLimit > 0 && overLimit <= 40) {
                status = 'excessive speeding';
            }
            else if (overLimit > 40) {
                status = 'reckless driving';
            }

            if (speed > 50) {
                console.log(`The speed is ${speed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
            }
            else {
                console.log(`Driving ${speed} km/h in a ${cityLimit} zone`);
            }
            break;
        case 'residential':
            overLimit = speed - residentialLimit;

            if (overLimit > 0 && overLimit <= 20) {
                status = 'speeding';
            }
            else if (overLimit > 0 && overLimit <= 40) {
                status = 'excessive speeding';
            }
            else if (overLimit > 40) {
                status = 'reckless driving';
            }

            if (speed > 20) {
                console.log(`The speed is ${speed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
            }
            else {
                console.log(`Driving ${speed} km/h in a ${residentialLimit} zone`);
            }
            break;
        case 'interstate':
            overLimit = speed - interstateLimit;

            if (overLimit > 0 && overLimit <= 20) {
                status = 'speeding';
            }
            else if (overLimit > 0 && overLimit <= 40) {
                status = 'excessive speeding';
            }
            else if (overLimit > 40) {
                status = 'reckless driving';
            }

            if (speed > 90) {
                console.log(`The speed is ${speed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
            }
            else {
                console.log(`Driving ${speed} km/h in a ${interstateLimit} zone`);
            }
            break;
        case 'motorway':
            overLimit = speed - motorwayLimit;

            if (overLimit > 0 && overLimit <= 20) {
                status = 'speeding';
            }
            else if (overLimit > 0 && overLimit <= 40) {
                status = 'excessive speeding';
            }
            else if (overLimit > 40) {
                status = 'reckless driving';
            }

            if (speed > 130) {
                console.log(`The speed is ${speed - motorwayLimit} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
            }
            else {
                console.log(`Driving ${speed} km/h in a ${motorwayLimit} zone`);
            }
            break;
    }        
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');