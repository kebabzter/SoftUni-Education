function solve() {
    document.getElementById('add').addEventListener('click', add);
    let task = document.getElementById('task');
    let description = document.getElementById('description');
    let date = document.getElementById('date');

    function add(ev){
        if (task.value === '' || description.value === '' || date.value === ''){
            return;
        }

        let article = document.createElement('article');

        let headling = document.createElement('h3');
        headling.textContent = task.value;

        let descriptionParagraph = document.createElement('p');
        descriptionParagraph.textContent = `Description: ${description.value}`

        let dateParagraph = document.createElement('p');
        dateParagraph.textContent = `Due Date: ${date.value}`;

        let div = document.createElement('div');
        div.className = 'flex';

        let openStartBtn = document.createElement('button');
        openStartBtn.className = 'green';
        openStartBtn.textContent = 'Start'
        openStartBtn.addEventListener('click', start);
        
        let openDeleteBtn = document.createElement('button');
        openDeleteBtn.className = 'red';
        openDeleteBtn.textContent = 'Delete';
        openDeleteBtn.addEventListener('click', remove);
        
        div.appendChild(openStartBtn);
        div.appendChild(openDeleteBtn);

        article.appendChild(headling);
        article.appendChild(descriptionParagraph);
        article.appendChild(dateParagraph);
        article.appendChild(div);

        document.getElementsByClassName('orange')[0].parentElement.parentElement.querySelectorAll('div')[1].appendChild(article);
    
        function start(ev){
            ev.target.className = 'red';
            ev.target.textContent = 'Delete';
            ev.target.addEventListener('click', remove);
            
            let target = ev.target.parentElement.querySelectorAll('button')[1];
            target.className = 'orange';
            target.textContent = 'Finish';
            target.addEventListener('click', complete);

            let inProgressArticle = ev.target.parentElement.parentElement;
            document.getElementById('in-progress').appendChild(inProgressArticle);
        }

        function complete(ev){
            let completeArticle = ev.target.parentElement.parentElement;
            completeArticle.getElementsByClassName('flex')[0].remove();
            document.getElementsByClassName('green')[0].parentElement.parentElement.querySelectorAll('div')[1].appendChild(completeArticle);
        }

        function remove(ev){
            ev.target.parentElement.parentElement.remove();
        }
    }
}