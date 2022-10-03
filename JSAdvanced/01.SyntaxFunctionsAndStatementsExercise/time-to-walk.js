function timeToWalk(steps, stepLength, speed) {
    let metersWalked = stepLength * speed * 1000;
    let stepsWalked = metersWalked * stepLength;

    let timeInSeconds = steps / metersPerSecond;

    let timeInMinutes = steps - timeInSeconds;
}

timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);