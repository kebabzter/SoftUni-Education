function wordsUppercase(input) {
    let regex = /(\w+)/g;
    let regexMatches = input.match(regex);
    let arr = [];

    for (let i = 0; i < regexMatches.length; i++) {
        arr.push(regexMatches[i].toUpperCase());
    }

    console.log(arr.join(', '));
}

wordsUppercase('Hi, how are you?');
wordsUppercase('hello');