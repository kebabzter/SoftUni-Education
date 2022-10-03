function solve() {
    let inputs = Array.from(document.querySelectorAll('#container input'));
    document.querySelector('#container button').addEventListener('click', onScreenBtn)
    document.querySelector('#archive button').addEventListener('click', clear);

    function onScreenBtn(ev) {
        if (inputs[0].value === '' || inputs[1].value === '' ||
            inputs[2].value === '' || Number.isNaN(Number(inputs[2].value))) {

            inputs[0].value = '';
            inputs[1].value = '';
            inputs[2].value = '';
            return;
        }

        let li = document.createElement('li');
        let span = document.createElement('span');
        span.textContent = inputs[0].value;

        let strong = document.createElement('strong');
        strong.textContent = `Hall: ${inputs[1].value}`;

        let div = document.createElement('div');

        let divStrong = document.createElement('strong');
        divStrong.textContent = Number(inputs[2].value).toFixed(2);

        let input = document.createElement('input');
        input.placeholder = 'Tickets Sold';

        let button = document.createElement('button');
        button.textContent = 'Archive';
        button.addEventListener('click', archiveBtn);

        div.appendChild(divStrong);
        div.appendChild(input);
        div.appendChild(button);

        li.appendChild(span);
        li.appendChild(strong);
        li.appendChild(div);

        document.querySelector('#movies ul').appendChild(li);

        inputs[0].value = '';
        inputs[1].value = '';
        inputs[2].value = '';

        function archiveBtn(ev) {
            let inputValue = ev.target.parentElement.querySelector('input');
            if (Number.isNaN(Number(inputValue.value)) || inputValue.value == '') {
                inputValue.value = '';
                return;
            }

            let liAr = document.createElement('li');

            let spanAr = document.createElement('span');
            spanAr.textContent = ev.target.parentElement.parentElement
                .querySelector('span').textContent;

            let strongAr = document.createElement('strong');
            strongAr.textContent = `Total amount: ${(inputValue.value * ev.target.parentElement.querySelector('strong').textContent).toFixed(2)}`

            let buttonAr = document.createElement('button');
            buttonAr.textContent = 'Delete';
            buttonAr.addEventListener('click', deleteBtn);

            liAr.appendChild(spanAr);
            liAr.appendChild(strongAr);
            liAr.appendChild(buttonAr);

            document.querySelector('#archive ul').appendChild(liAr);
            ev.target.parentElement.parentElement.remove();

            function deleteBtn(ev){
                ev.target.parentElement.remove();
            }
        }
    }

    function clear(ev){
        let lis = Array.from(ev.target.parentElement.querySelectorAll('li'));
        
        for (let i = 0; i < lis.length; i++) {
            lis[i].remove();
        }
    }
}