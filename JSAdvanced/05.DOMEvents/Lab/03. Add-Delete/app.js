function addItem() {
    let items = document.getElementById("items");
    let item = document.getElementById("newItemText");

    if (item.value.length == 0){
        return;
    }

    let listItem = document.createElement("li");
    listItem.appendChild(document.createTextNode(item.value));
    
    let remove = document.createElement("a");
    let linkText = document.createTextNode("[Delete]");
    remove.appendChild(linkText);
    remove.href = "#";
    remove.addEventListener("click", () => listItem.remove());

    listItem.appendChild(remove);
    items.appendChild(listItem);
    item.value = '';
}