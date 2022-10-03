function solve(card, type){
    const cards = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
    const types = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    };

    if (!cards.includes(card) || types[type] == undefined) {
        throw new Error();
    }

    return `${card}${types[type]}`;
}