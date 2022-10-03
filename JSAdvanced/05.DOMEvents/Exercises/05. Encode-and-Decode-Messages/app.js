function encodeAndDecodeMessages() {
    let firstArea = document.querySelectorAll('#main div textarea')[0];
    let secondArea = document.querySelectorAll('#main div textarea')[1];
    document.querySelectorAll('#main div button')[0].addEventListener('click', encode);
    document.querySelectorAll('#main div button')[1].addEventListener('click', decode);

    function encode(ev) {
        secondArea.value = '';
        for (let i = 0; i < firstArea.value.length; i++) {
            secondArea.value += String.fromCharCode(firstArea.value.charCodeAt(i) + 1);
        }
        firstArea.value = '';
    }

    function decode(ev) {
        let encryptedText = '';
        for (let i = 0; i < secondArea.value.length; i++) {
            encryptedText += String.fromCharCode(secondArea.value.charCodeAt(i) - 1);
        }

        secondArea.value = encryptedText;
    }
}