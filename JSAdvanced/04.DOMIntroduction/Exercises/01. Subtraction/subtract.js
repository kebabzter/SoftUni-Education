function subtract() {
    let firstNumber = Number(document.getElementById("firstNumber").value);
    let secondNumber = Number(document.getElementById("secondNumber").value);

    let subtract = firstNumber - secondNumber;
    document.getElementById("result").textContent = subtract;
}