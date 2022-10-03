function solve() {
  const table = document.querySelector('table.table tbody');

  const [input, output] = Array.from(document.querySelectorAll('textarea'));
  const [generateBtn, buyBtn] = Array.from(document.querySelectorAll('button'));

  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);

  function generate(ev) {
    const data = JSON.parse(input.value);

    for (let item of data) {
      const row = document.createElement('tr');

      const imgCell = document.createElement('td');
      const nameCell = document.createElement('td');
      const priceCell = document.createElement('td');
      const decFacCell = document.createElement('td');
      const checkCell = document.createElement('td');

      const img = document.createElement('img');
      img.src = item.img;
      imgCell.appendChild(img);

      const name = document.createElement('p');
      name.textContent = item.name;
      nameCell.appendChild(name);

      const price = document.createElement('p');
      price.textContent = item.price;
      priceCell.appendChild(price);

      const decFac = document.createElement('p');
      decFac.textContent = item.decFactor;
      decFacCell.appendChild(decFac);

      const check = document.createElement('input');
      check.type = 'checkbox';
      checkCell.appendChild(check);

      row.appendChild(imgCell);
      row.appendChild(nameCell);
      row.appendChild(priceCell);
      row.appendChild(decFacCell);
      row.appendChild(checkCell);

      table.appendChild(row);
    }
  }

  function buy(ev) {
    let boxes = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
    .map(x => x.parentElement.parentElement)
    .map(x => ({
      name: x.children[1].textContent,
      price: Number(x.children[2].textContent),
      decFactor: Number(x.children[3].textContent)
    }));

    const names = [];
    let total = 0;
    let decFactor = 0;

    for (const item of boxes) {
      total += item.price;
      decFactor += item.decFactor;
      names.push(item.name);
    }

    const result = `Bought furniture: ${names.join(', ')}\nTotal price: ${total.toFixed(2)}\nAverage decoration factor: ${decFactor / boxes.length}`;
  
    output.value = result;
  }
}