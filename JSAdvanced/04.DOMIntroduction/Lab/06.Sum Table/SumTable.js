function sumTable() {
    let items = document.querySelectorAll("table tr td");

    let sum = 0;

    for (let i = 1; i < items.length - 1; i+=2) {
        sum += Number(items[i].textContent);
    }

    document.getElementById("sum").textContent = sum;
}        
