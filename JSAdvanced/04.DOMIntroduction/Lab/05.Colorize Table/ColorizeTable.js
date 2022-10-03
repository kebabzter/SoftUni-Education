function colorize() {
    let items = document.getElementsByTagName("tr");

    for (let i = 1; i < items.length - 1; i+=2) {
        items[i].style.background = "teal";
    }
}