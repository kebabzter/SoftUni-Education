function previousDay(year, month, day) {
    var date = new Date(year, month - 1, day - 1).toISOString().replace(/T.*/,'').replace(/\b0/g,'').split('-').join('-');

    console.log(date);
}

previousDay(2016, 9, 30);
previousDay(2016, 10, 1);