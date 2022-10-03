function lockedProfile() {
    let butons = Array.from(document.querySelectorAll(".profile button")).forEach(x => x.addEventListener('click', show));

    function show(ev) {
        if (ev.target.parentElement.querySelector('input[type="radio"]').checked) {
            return;
        }
        
        if (ev.currentTarget.innerText == 'Show more') {
            ev.currentTarget.innerText = 'Hide it';
            ev.currentTarget.parentElement.querySelector('div').style.display = 'block'
        } else {
            ev.currentTarget.innerText = 'Show more';
            ev.currentTarget.parentElement.querySelector('div').style.display = ''
        }
    }
}