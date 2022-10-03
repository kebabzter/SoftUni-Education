function solve(array, start, end) {
    if (typeof (array) != typeof ([])) {
        return NaN;
    }

    if (start < 0) {
        start = 0;
    }

    if (end >= array.length) {
        end = array.length - 1;
    }

    let sum = 0;

    for (let i = start; i <= end; i++) {
        sum += Number(array[i]);
    }

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));