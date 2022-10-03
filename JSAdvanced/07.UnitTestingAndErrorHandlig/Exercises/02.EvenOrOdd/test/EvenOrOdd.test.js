const isOddOrEven = require('../EvenOrOdd');
const { assert } = require('chai');

describe('Even or Odd function testing', () => {
    it('Should works', () => {
        assert.equal(isOddOrEven('Hello'), 'odd');
        assert.equal(isOddOrEven('Good'), 'even');
    });

    it('Should not works', () => {
        assert.notEqual(isOddOrEven('Hello'), 'even')
        assert.notEqual(isOddOrEven('Good'), 'odd');
    })

    it('Should return undefined', () => {
        assert.isUndefined(isOddOrEven({}))
        assert.isUndefined(isOddOrEven([]))
        assert.isUndefined(isOddOrEven(1))
        assert.isUndefined(isOddOrEven(undefined))
        assert.isUndefined(isOddOrEven(null))
    })
})