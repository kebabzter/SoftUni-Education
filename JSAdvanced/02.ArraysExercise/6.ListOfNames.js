function solve(arr){
    arr.sort((a,b) => a.localeCompare(b));
    let num = 1
    arr.forEach(element => {
        console.log(`${num}.${element}`);
        num++;
    });
}

solve(["John", "Bob", "Christina", "Ema"])