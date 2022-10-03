function solve() {
   let dataTr = Array.from(document.querySelectorAll('tbody > tr'));
   let searchBtn = document.querySelector("#searchBtn");
   let searchField = document.querySelector("#searchField");
   searchBtn.addEventListener('click', function () {
       let regex = new RegExp(searchField.value, 'gim');
       dataTr.map(e => {
           e.classList.remove('select');
           if (e.innerHTML.match(regex) !== null) {
               e.className = 'select';
           }
       });
       searchField.value = '';
   });
}