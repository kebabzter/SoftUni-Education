const { assert } = require('chai');
const sum = require('../SumOfNumbers.js');

describe('Sum numbers', () => {
    it('sums single number', () => {
        assert.equal(sum([1]), 1);
    });
    it('sums multiple numbers', () => {
        assert.equal(sum([1, 2, 3]), 6);
    })
    it('throw NaN if empty array', () => {
        assert.isNaN(sum(['asd']))
    })
});