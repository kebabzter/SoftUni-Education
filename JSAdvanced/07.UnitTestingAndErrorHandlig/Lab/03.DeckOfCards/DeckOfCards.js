function printDeckOfCards(cards) {
    let result = '';

    function createCard(card, type) {
        const cards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
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

    for (let i = 0; i < cards.length; i++) {
        let card;
        let type;

        if (cards[i].length == 3) {
            card = cards[i][0] + cards[i][1];
            type = cards[i][2]
        } else {
            card = cards[i][0];
            type = cards[i][1];
        }

        try {
            result += createCard(card, type) + ' ';
        } catch (error) {
            console.log(`Invalid card: ${card}${type}`);     
            return;       
        }
    }

    console.log(result);
}