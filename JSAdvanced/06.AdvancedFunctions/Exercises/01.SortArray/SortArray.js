function solve(array, type){

    if (type == 'asc'){
        return array.sort((a,b) => a-b);
    } else if (type == 'desc'){
        return array.sort((a,b) => b-a);
    }
}
