function solve(){
    let a = 0;
    let b = 1;

    function calc(){
        let aa = a;
        a = b;
        b += aa;

        return a;
    }

    return calc;
}