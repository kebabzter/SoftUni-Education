function solve(arr, n){
    for (let index = 0; index < n; index++) {
        let temp = 0;
        temp = arr.pop();
        arr.unshift(temp);
    }

    console.log(arr.join(' '));
}

solve(['1', 
'2', 
'3', 
'4'], 
2
)