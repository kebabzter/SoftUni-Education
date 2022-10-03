function deleteByEmail() {
    let email = document.getElementsByName("email");
    let emails = document.querySelectorAll("#customers tbody tr td:nth-child(2)");
    let result = document.getElementById("result");

    for (let currEmail of emails) {
        if (email[0].value == currEmail.textContent) {
            currEmail.parentElement.remove();
            result.textContent = 'Deleted.';
            return;
        }
    }
    result.textContent = 'Not found.'
}