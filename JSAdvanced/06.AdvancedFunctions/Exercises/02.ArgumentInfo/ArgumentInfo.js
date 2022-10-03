function solve(...arr) {
    output = {};

    for (const item of arr) {
        let key = typeof(item);

        if(output[key] != undefined){
            output[key]++;
        } else {
            output[key] = 1;
        }

        console.log(`${key}: ${item}`);
    }
    
    const sortable = Object.entries(output)
    .sort(([,a],[,b]) => b-a)
    .reduce((r, [k, v]) => ({ ...r, [k]: v }), {});

    for (const item in sortable) {
        console.log(`${item} = ${output[item]}`);
    }
}

solve({ name: 'bob'}, 3.333, 9.999);