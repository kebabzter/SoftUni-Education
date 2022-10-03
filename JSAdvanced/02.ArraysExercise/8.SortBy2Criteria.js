function solve(arr){
    arr.sort(twoCriteriaSort);
    console.log(arr.join('\n'));
    function twoCriteriaSort(current, next){
    
    if (current.length === next.length) {
        return current.localeCompare(next);
    }

    return current.length - next.length;
    }
}



solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
)