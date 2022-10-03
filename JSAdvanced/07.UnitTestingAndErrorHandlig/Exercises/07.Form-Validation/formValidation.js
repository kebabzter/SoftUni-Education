function validate() {
    let usernamePattern = /^[a-zA-Z0-9]{3,20}$/m;  
    let emailPattern = /^.*@.*\..*$/m;
    let passwordPattern = /^[\w]{5,15}$/m;  //
    let companyFieldPattern = /^[1-9][0-9]{3}$/m;  

    const username = document.querySelector('#username');
    const email = document.querySelector('#email');
    const password = document.querySelector('#password');
    const confirmPassword = document.querySelector('#confirm-password');
    const checkBox = document.querySelector('#company')
    const companyInfo = document.querySelector('#companyInfo');
    const companyNumber = document.querySelector('#companyNumber');
    const submitButton = document.querySelector('#submit');

    submitButton.addEventListener('click', (event) => {
        event.preventDefault();
        let isDataValid = true;
        let isCompanyNumberValid = false;
        
        if (!usernamePattern.test(username.value)) {
            username.style = 'border-color: red';
            isDataValid = false;
        } else {
            username.removeAttribute('style');
        }

        if (!emailPattern.test(email.value)) {
            email.style = 'border-color: red';
            isDataValid = false;
        } else {
            email.removeAttribute('style');
        }

        if (!passwordPattern.test(confirmPassword.value) || password.value !== confirmPassword.value) {
            password.style = 'border-color: red';
            isDataValid = false;
        } else {
            password.removeAttribute('style');
        }

        if (!passwordPattern.test(confirmPassword.value) || password.value !== confirmPassword.value) {
            confirmPassword.style = 'border-color: red';
            isDataValid = false;
        } else {
            confirmPassword.removeAttribute('style');
        }

        if (!companyFieldPattern.test(companyNumber.value) && checkBox.checked ==true) {
            companyNumber.style = 'border-color: red';
            isCompanyNumberValid = false;
        } else if (companyFieldPattern.test(companyNumber.value) && checkBox.checked ==true){
            companyNumber.removeAttribute('style');
            isCompanyNumberValid = true;
        }

        if (isDataValid && checkBox.checked ==false){
            document.querySelector('#valid').style = 'display: block';
        } else if (isDataValid && checkBox.checked ==true && isCompanyNumberValid){
            document.querySelector('#valid').style = 'display: block';
        } else {
            document.querySelector('#valid').style = 'display: none';
        }
    });

    checkBox.addEventListener('change', (event) => {
        if (event.target.checked == true){
            companyInfo.style.display = 'block';

        } else {
            companyInfo.style.display = 'none';
        }
    });
}