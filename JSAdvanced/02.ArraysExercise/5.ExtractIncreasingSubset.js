function solve(arr){
    let newArr = [];
    let currentHighest = 0;
    arr.forEach(element => {
        if (element >= currentHighest) {
            currentHighest = element;
            newArr.push(element);
        }        
    });

    return newArr;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ));
console.log(solve([1, 
    2, 
    3,
    4])
    );

console.log(solve([20, 
    3, 
    2, 
    15,
    6, 
    1]
    ));