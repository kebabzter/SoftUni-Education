function solve(data, criteria){
    let parsedData = JSON.parse(data);
    let splittedCriteria = criteria.split('-');
    let result = parsedData.filter(x => x[splittedCriteria[0]] == splittedCriteria[1]);

    for (let i = 0; i < result.length; i++) {
        console.log(`${i}. ${result[i].first_name} ${result[i].last_name} - ${result[i].email}`);
    }
}