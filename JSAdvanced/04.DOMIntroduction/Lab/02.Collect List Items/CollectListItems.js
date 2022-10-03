function extractText() {
    let items = document.querySelectorAll("ul#items li");
    let area = document.querySelector("#result");

    for (const item of items) {
        area.value += item.textContent + "\n";        
    }
}