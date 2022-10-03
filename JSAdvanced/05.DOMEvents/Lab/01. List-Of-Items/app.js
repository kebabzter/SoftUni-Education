function addItem() {
    let elements = document.getElementById("items");
    let element = document.getElementById("newItemText");
    let liElement = document.createElement("li");
    liElement.appendChild(document.createTextNode(element.value));
    elements.appendChild(liElement);
    element.value = '';
}