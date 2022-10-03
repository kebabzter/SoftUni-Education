function solve(commands){
    let newArr = []
    let num = 0;
    for (let index = 0; index < commands.length; index++) {
        num++
        let command = commands[index];
        if (command == 'add') {
            newArr.push(num);
        } else {
            newArr.pop();
        }
    }
    if(newArr.length == 0){
        console.log('Empty');
    } else{
        console.log(newArr.join('\n'));
    }
}

solve(['add', 
'add',
'remove', 
'add', 
'add']
);