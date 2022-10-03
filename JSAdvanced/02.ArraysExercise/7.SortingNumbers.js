function solve(arr){
    let result = [];
    arr.sort((a,b) => a-b)
    let num = 0;
    while (arr.length !== 0) {
        if (num % 2 == 0) {
            result.push(arr.shift());
            num++;
        } else {
            result.push(arr.pop());
            num--;
        }  
    }        

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));