window.addEventListener("load", solve);

function solve() {
  const input = {
    make: document.getElementById('make'),
    model: document.getElementById('model'),
    year: document.getElementById('year'),
    fuel: document.getElementById('fuel'),
    originalCost: document.getElementById('original-cost'),
    sellingPrice: document.getElementById('selling-price'),
  }

  const lists ={
    table: document.getElementById('table-body'),
    sold: document.getElementById('cars-list'),
  }

  const profit = document.getElementById('profit');
  const publishBtn = document.getElementById('publish')
  publishBtn.addEventListener('click', publish);

  function publish(event){
    event.preventDefault();
    const make = input.make.value;
    const model = input.model.value;
    const year = input.year.value;
    const fuel = input.fuel.value;
    const originalCost = input.originalCost.value;
    const sellingPrice = input.sellingPrice.value;
    
    if (make == '' || model == '' || year == '' || fuel == '' || originalCost == '' || sellingPrice == '' || originalCost > sellingPrice || originalCost < 0|| sellingPrice < 0) {
      return;
    }
    
    const tr = document.createElement('tr')
    tr.className ="row";
    tr.innerHTML = `
    <td>${make}</td>
    <td>${model}</td>
    <td>${year}</td>
    <td>${fuel}</td>
    <td>${originalCost}</td>
    <td>${sellingPrice}</td>
    <td>
      <button class="action-btn edit">Edit</button>
      <button class="action-btn sell">Sell</button>
    </td>`;

    lists.table.appendChild(tr);

    const editBtn = tr.querySelector('.edit');
    const sellBtn = tr.querySelector('.sell');
    editBtn.addEventListener('click', edit);
    sellBtn.addEventListener('click', sell);

    input.make.value = '';
    input.model.value = '';
    input.year.value = '';
    input.fuel.value = '';
    input.originalCost.value = '';
    input.sellingPrice.value = '';

    function edit(event){
    
    input.make.value = make;
    input.model.value = model;
    input.year.value = year;
    input.fuel.value = fuel;
    input.originalCost.value = originalCost;
    input.sellingPrice.value = sellingPrice;

    let editButton = event.target;
    let toEdit = editButton.parentElement.parentElement;
    toEdit.remove();
    }

    function sell(event){
      let currProfit = Number(profit.textContent);
      let profitMade = sellingPrice - originalCost;
      currProfit += profitMade;
      profit.textContent = `${currProfit.toFixed(2)}`
      let makeAndModel = make + ' ' + model;
      let li = document.createElement('li');
      li.className = 'each-list';
      li.innerHTML = `
      <span>${makeAndModel}</span>
      <span>${year}</span>
      <span>${profitMade}</span>`;

      lists.sold.appendChild(li);

      let sellBtn = event.target;
      let toRemove = sellBtn.parentElement.parentElement;
      toRemove.remove();
    }
  }
}
