function solution() {
    let text = '';

    return obj = {
        append(textToInput) {
            text += textToInput;
        },
        removeStart(n) {
            text = text.substring(n);
        },
        removeEnd(n) {
            text = text.substring(0, text.length - n);
        },
        print() {
            console.log(text);
        },
    }
}